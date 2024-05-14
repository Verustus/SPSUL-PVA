namespace Console_3D_Renderer {
    internal class Vector2 {
        public float x;
        public float y;

        public Vector2(float x, float y) {
            this.x = x;
            this.y = y;
        }

        public override string ToString() { return $"({x}, {y})"; }
    }
}
