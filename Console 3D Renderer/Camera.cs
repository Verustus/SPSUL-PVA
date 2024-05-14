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

            //matrix pain - chatgpt
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
            Vector2 projectedPoint = new Vector2(x / zDepth, y / zDepth);

            float fovRadians = fov * (float) (Math.PI / 180);
            float aspect = aspectRatio;
            float scaleY = (float)Math.Tan(fovRadians * 0.5f);
            float scaleX = scaleY * aspect;

            projectedPoint.x /= scaleX;
            projectedPoint.y /= scaleY;

            return projectedPoint;
        }
    }
}
