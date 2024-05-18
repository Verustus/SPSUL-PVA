namespace Console_3D_Renderer {
    internal class ConsoleDisplay {
        ConsoleColor[,] lastRenderPixels;
        ConsoleColor[,] pixels;
        int lastConsoleHeight;
        int lastConsoleWidth;

        public ConsoleDisplay() {
            pixels = new ConsoleColor[Console.WindowHeight, Console.WindowWidth/2];
            lastRenderPixels = pixels;
            lastConsoleHeight = Console.WindowHeight;
            lastConsoleWidth = Console.WindowWidth;
        }

        public void SetPixel(int x, int y, ConsoleColor color) {
            int writeX = x%pixels.GetLength(0);
            int writeY = y%pixels.GetLength(1);

            pixels[writeX, writeY] = color;
        }
        public void Draw(Frame frame) {
            for (int i = 0; i < frame.height; i++) {
                for (int j = 0; j < frame.width; j++)
                    SetPixel(i, j, frame.Get(i, j));
            }
            Draw();
        }

        public void Draw() {
            ConsoleColor[,] pixels = this.pixels;

            if (lastConsoleHeight != Console.WindowHeight || lastConsoleWidth != Console.WindowWidth) {
                Console.Clear();
                Console.WriteLine("\x1b[3J");
                lastConsoleHeight = Console.WindowHeight;
                lastConsoleWidth = Console.WindowWidth;
            }

            int renderY = pixels.GetLength(0) > Console.WindowHeight ? Console.WindowHeight : pixels.GetLength(0);
            int renderX = pixels.GetLength(1) > Console.WindowWidth/2 ? Console.WindowWidth/2 : pixels.GetLength(1);

            bool rerender = false;
            for (int i = 0; i < renderY; i++) {
                for (int j = 0; j < renderX; j++) {
                    try {
                        if (lastRenderPixels[i, j] != pixels[i, j]) {
                            try {
                                Console.BackgroundColor = pixels[i, j];
                                Console.SetCursorPosition(j * 2, i);
                            } catch {
                                rerender = true;
                                Console.ResetColor();
                                break;
                            }

                            byte[] buffer = Enumerable.Repeat((byte)' ', 2).ToArray();
                            using (Stream stdout = Console.OpenStandardOutput(Console.WindowHeight*Console.WindowWidth)) {
                                stdout.Write(buffer, 0, buffer.Length);
                            }
                            
                            Console.ResetColor();
                            Console.SetCursorPosition(0, 0);
                        }
                    } catch {}
                }
                if (rerender) break;
            }
            if (rerender) Draw();
            
            lastRenderPixels = pixels;
            this.pixels = new ConsoleColor[Console.WindowHeight, Console.WindowWidth / 2];
        }
    }
}
