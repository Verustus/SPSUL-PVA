namespace Console_3D_Renderer {
    internal class Screen {
        private int screenWidth;
        private int screenHeight;

        public Screen() {
            screenWidth = Console.WindowWidth;
            screenHeight = Console.WindowHeight;
        }

        public void DisplayFrame(ConsoleColor[,] frame) {
            Console.Clear();
            int frameWidth = frame.GetLength(0);
            int frameHeight = frame.GetLength(1);

            int drawWidth = Math.Min(screenWidth, frameWidth);
            int drawHeight = Math.Min(screenHeight, frameHeight);

            for (int y = 0; y < drawHeight; y++) {
                for (int x = 0; x < drawWidth; x++) {
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = frame[x, y];
                    Console.Write(" ");
                }
            }
        }

        public void StartLoop(ConsoleColor[,] initialFrame) {
            while (true) {
                DisplayFrame(initialFrame);
                Thread.Sleep(100);
            }
        }
    }
}
