namespace Console_3D_Renderer {
    internal class Vector3 {
        public float x;
        public float y;
        public float z;
        public static Vector3 Zero = new Vector3(0, 0, 0);

        public Vector3(float x, float y, float z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3(Vector3 v) {
            x = v.x;
            y = v.y;
            z = v.z;
        }
        // cele vykraftil sam rotace jednoduche
        public void RotateAroundX(float angle, Vector3 point) {
            float angleInRadians = angle * (float) (Math.PI / 180);
            float cosAngle = (float)Math.Cos(angleInRadians);
            float sinAngle = (float)Math.Sin(angleInRadians);

            y -= point.y;
            z -= point.z;

            float newY = y * cosAngle - z * sinAngle;
            float newZ = y * sinAngle + z * cosAngle;

            y = newY + point.y;
            z = newZ + point.z;
        }

        public void RotateAroundY(float angle, Vector3 point) {
            float angleInRadians = angle * (float) (Math.PI / 180);
            float cosAngle = (float)Math.Cos(angleInRadians);
            float sinAngle = (float)Math.Sin(angleInRadians);

            x -= point.x;
            z -= point.z;

            float newX = x * cosAngle + z * sinAngle;
            float newZ = -x * sinAngle + z * cosAngle;

            x = newX + point.x;
            z= newZ + point.z;
        }

        public void RotateAroundZ(float angle, Vector3 point) {
            float angleInRadians = angle * (float) (Math.PI / 180);
            float cosAngle = (float)Math.Cos(angleInRadians);
            float sinAngle = (float)Math.Sin(angleInRadians);

            x -= point.x;
            y -= point.y;

            float newX = x * cosAngle - y * sinAngle;
            float newY = x * sinAngle + y * cosAngle;

            x = newX + point.x;
            y = newY + point.y;
        }

        public override string ToString() { return $"({x}, {y}, {z})"; }
    }
}