namespace Console_3D_Renderer {
    internal class Frame {
        private struct FramePoint {
            public ConsoleColor color;
            public float zDepth;

            public FramePoint(ConsoleColor color, float zDepth) {
                this.color = color;
                this.zDepth = zDepth;
            }
        }

        public int height;
        public int width;
        private FramePoint[,] frame;

        public Frame(int height, int width) {
            this.height = height;
            this.width = width;
            this.frame = new FramePoint[height, width];
        }

        public ConsoleColor Get(int x, int y) { return frame[x, y].color; }
        public void Set(int x, int y, ConsoleColor color, float zDepth, bool overwrite = false) {
            if (frame[x, y].zDepth == 0 || frame[x, y].zDepth > zDepth || overwrite)
                frame[x, y] = new FramePoint(color, zDepth);
        }
    }
}
