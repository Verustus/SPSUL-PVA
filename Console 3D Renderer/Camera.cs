using System.Numerics;

namespace Console_3D_Renderer {
    internal class Camera {
        public float fov;
        public float aspectRatio;
        public Vector3 position;
        public Quaternion rotation;

        public Camera(float fov, float aspectRatio, Vector3 position, Quaternion rotation) {
            this.fov = fov;
            this.aspectRatio = aspectRatio;
            this.position = position;
            this.rotation = rotation;
        }

        public Vector2 PerspectiveProjection(Vector3 point) {
            Vector3 relativePoint = new Vector3(
                point.x - position.x,
                point.y - position.y,
                point.z - position.z
            );

            float x = relativePoint.x * (1 - 2 * (rotation.Y * rotation.Y + rotation.Z * rotation.Z))
                        + relativePoint.y * 2 * (rotation.X * rotation.Y - rotation.W * rotation.Z)
                        + relativePoint.z * 2 * (rotation.X * rotation.Z + rotation.W * rotation.Y);
            float y = relativePoint.x * 2 * (rotation.X * rotation.Y + rotation.W * rotation.Z)
                        + relativePoint.y * (1 - 2 * (rotation.X * rotation.X + rotation.Z * rotation.Z))
                        + relativePoint.z * 2 * (rotation.Y * rotation.Z - rotation.W * rotation.X);
            float z = relativePoint.x * 2 * (rotation.X * rotation.Z - rotation.W * rotation.Y)
                        + relativePoint.y * 2 * (rotation.Y * rotation.Z + rotation.W * rotation.X)
                        + relativePoint.z * (1 - 2 * (rotation.X * rotation.X + rotation.Y * rotation.Y));

            float zDepth = z;
            Vector2 projectedPoint = new Vector2(y / zDepth, x / zDepth);

            float fovRadians = fov * (float) (Math.PI / 180);
            float scaleY = (float) Math.Tan(fovRadians * 0.5f);
            float scaleX = scaleY * aspectRatio;

            projectedPoint.x /= scaleY;
            projectedPoint.y /= scaleX;
            projectedPoint.x = -projectedPoint.x;

            return projectedPoint;
        }

        public void DrawLineToFrame(ref ConsoleColor[,] frame, float sizeX, float sizeY, Vector2 from, Vector2 to, ConsoleColor color = ConsoleColor.White) {
            int x0 = (int) ((from.x+sizeX)/sizeX/2*frame.GetLength(0));
            int y0 = (int) ((from.y+sizeY)/sizeY/2*frame.GetLength(1));
            int x1 = (int) ((to.x+sizeX)/sizeX/2*frame.GetLength(0));
            int y1 = (int) ((to.y+sizeY)/sizeY/2*frame.GetLength(1));

            int dx = Math.Abs(x1 - x0);
            int dy = Math.Abs(y1 - y0);

            int sx = x0 < x1 ? 1 : -1;
            int sy = y0 < y1 ? 1 : -1;

            int err = dx - dy;
            int x = x0, y = y0;

            while (x != x1 || y != y1) {
                if (x >= 0 && y >= 0 && x < frame.GetLength(0) && y < frame.GetLength(1))
                    frame[x, y] = color;

                int e2 = 2 * err;
                if (e2 > -dy) {
                    err -= dy;
                    x += sx;
                }
                if (e2 < dx) {
                    err += dx;
                    y += sy;
                }
            }
        }
    }
}