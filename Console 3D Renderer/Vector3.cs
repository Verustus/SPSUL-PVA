using System;

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

        public Vector3 Add(Vector3 add) {
            x += add.x;
            y += add.y;
            z += add.z;

            return this;
        }

        public Vector3 Subtract(Vector3 subtract) {
            x -= subtract.x;
            y -= subtract.y;
            z -= subtract.z;

            return this;
        }
        public Vector3 Rotate(Vector3 rotation) {
            RotateX(rotation.x);
            RotateY(rotation.y);
            RotateZ(rotation.z);

            return this;
        }
        public Vector3 RotateAround(Vector3 rotation, Vector3 point) {
            RotateAroundX(rotation.x, point);
            RotateAroundY(rotation.y, point);
            RotateAroundZ(rotation.z, point);

            return this;
        }
        
        public void RotateX(float angle) {
            float angleInRadians = angle * (float) (Math.PI / 180);
            float cosAngle = (float)Math.Cos(angleInRadians);
            float sinAngle = (float)Math.Sin(angleInRadians);

            y = y * cosAngle - z * sinAngle;
            z = y * sinAngle + z * cosAngle;
        }
        public void RotateY(float angle) {
            float angleInRadians = angle * (float) (Math.PI / 180);
            float cosAngle = (float)Math.Cos(angleInRadians);
            float sinAngle = (float)Math.Sin(angleInRadians);
            
            x = x * cosAngle + z * sinAngle;
            z = -x * sinAngle + z * cosAngle;
        }
        public void RotateZ(float angle) {
            float angleInRadians = angle * (float) (Math.PI / 180);
            float cosAngle = (float)Math.Cos(angleInRadians);
            float sinAngle = (float)Math.Sin(angleInRadians);
            
            x = x * cosAngle - y * sinAngle;
            y = x * sinAngle + y * cosAngle;
        }

        public void RotateAroundX(float angle, Vector3 point) {
            y -= point.y;
            z -= point.z;

            RotateX(angle);

            y += point.y;
            z += point.z;
        }
        public void RotateAroundY(float angle, Vector3 point) {
            x -= point.x;
            z -= point.z;

            RotateY(angle);

            x += point.x;
            z += point.z;
        }
        public void RotateAroundZ(float angle, Vector3 point) {
            x -= point.x;
            y -= point.y;

            RotateZ(angle);

            x += point.x;
            y += point.y;
        }

        public override string ToString() { return $"({x}, {y}, {z})"; }
    }
}