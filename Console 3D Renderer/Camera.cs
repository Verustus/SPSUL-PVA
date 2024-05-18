using System.Drawing;
using System.Numerics;

namespace Console_3D_Renderer {
    internal class Camera {
        public float fov;
        public float aspectRatio;
        public Vector3 position;
        public Quaternion rotation;
        public Vector2 screenScale;

        public Camera(float fov, float aspectRatio, Vector3 position, Quaternion rotation, Vector2 screenScale) {
            this.fov = fov;
            this.aspectRatio = aspectRatio;
            this.position = position;
            this.rotation = rotation;
            this.screenScale = screenScale;
        }

        public (Vector2, float) PerspectiveProjection(Vector3 point) {
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

            Vector2 projectedPoint = new Vector2(y/z, x/z);

            float fovRadians = fov * (float) (Math.PI / 180);
            float scaleY = (float) Math.Tan(fovRadians * 0.5f);
            float scaleX = scaleY * aspectRatio;

            projectedPoint.x /= scaleY;
            projectedPoint.y /= scaleX;
            projectedPoint.x = -projectedPoint.x;

            return (projectedPoint, z);
        }
        public void DrawLineToFrame(ref Frame frame, (Vector2, float) from, (Vector2, float) to, Color color) {
            float x0 = (int) ((from.Item1.x+screenScale.x)/screenScale.x/2 * frame.height);
            float y0 = (int) ((from.Item1.y+screenScale.y)/screenScale.y/2 * frame.width);
            float x1 = (int) ((to.Item1.x+screenScale.x)/screenScale.x/2 * frame.height);
            float y1 = (int) ((to.Item1.y+screenScale.y)/screenScale.y/2 * frame.width);
            float z0 = (int) from.Item2;
            float z1 = (int) to.Item2;

            int maxRes = frame.width > frame.height ? frame.width : frame.height;

            float moveX = (x1-x0)/maxRes;
            float moveY = (y1-y0)/maxRes;
            float moveZ = (z1-z0)/maxRes;

            float x = x0;
            float y = y0;
            float zDepth = z0;

            for (int i = 0; i < maxRes; i++) {
                if (x >= 0 && x <= frame.height-1 && y >= 0 && y <= frame.width-1)
                    frame.Set((int) x, (int) y, color, zDepth);
                
                x += moveX;
                y += moveY;
                zDepth += moveZ;
            }
        }

        public void DrawLineToFrame(ref Frame frame, Vector3 from, Vector3 to, Color color) {
            (Vector2, float) fromProjection = PerspectiveProjection(from);
            (Vector2, float) toProjection = PerspectiveProjection(to);

            DrawLineToFrame(ref frame, fromProjection, toProjection, color);
        }

        public void DrawTriangleToFrame(ref Frame frame, Vector3 v0, Vector3 v1, Vector3 v2, Color color) {
            // Project the vertices to 2D
            var (p0, z0) = PerspectiveProjection(v0);
            var (p1, z1) = PerspectiveProjection(v1);
            var (p2, z2) = PerspectiveProjection(v2);

            // Convert to screen space
            int x0 = (int)((p0.x + screenScale.x)/screenScale.x/2 * frame.height);
            int y0 = (int)((p0.y + screenScale.y)/screenScale.y/2 * frame.width);
            int x1 = (int)((p1.x + screenScale.x)/screenScale.x/2 * frame.height);
            int y1 = (int)((p1.y + screenScale.y)/screenScale.y/2 * frame.width);
            int x2 = (int)((p2.x + screenScale.x)/screenScale.x/2 * frame.height);
            int y2 = (int)((p2.y + screenScale.y)/screenScale.y/2 * frame.width);

            // Determine the bounding box of the triangle
            int minX = Math.Max(0, Math.Min(x0, Math.Min(x1, x2)));
            int maxX = Math.Min(frame.height - 1, Math.Max(x0, Math.Max(x1, x2)));
            int minY = Math.Max(0, Math.Min(y0, Math.Min(y1, y2)));
            int maxY = Math.Min(frame.width - 1, Math.Max(y0, Math.Max(y1, y2)));

            // Barycentric coordinates method
            float area = 0.5f * (-y1 * x2 + y0 * (-x1 + x2) + y0 * x1 + x0 * (y1 - y2) + x1 * y2);

            for (int y = minY; y <= maxY; y++) {
                for (int x = minX; x <= maxX; x++) {
                    try {
                        float gamma = ((y1 - y2) * (x - x2) + (x2 - x1) * (y - y2)) /
                                      ((y1 - y2) * (x0 - x2) + (x2 - x1) * (y0 - y2));
                        float beta = ((y2 - y0) * (x - x2) + (x0 - x2) * (y - y2)) /
                                     ((y1 - y2) * (x0 - x2) + (x2 - x1) * (y0 - y2));
                        float alpha = 1 - gamma - beta;

                        //Console.WriteLine($"{alpha}; {beta}; {gamma}");
                        if (alpha >= 0 && beta >= 0 && gamma >= 0) {
                            float z = alpha * z0 + beta * z1 + gamma * z2;
                            if (x >= 0 && x <= frame.height-1 && y >= 0 && y <= frame.width-1)
                                frame.Set(x, y, color, z*3);
                        }
                    } catch {
                        if (x >= 0 && x <= frame.height-1 && y >= 0 && y <= frame.width-1)
                                frame.Set(x, y, color, 0, true);
                    }
                }
            }
        }
    }
}