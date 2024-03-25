using System;

namespace Alg_BarevnePoleUceni {
    internal class ConsoleDisplay {
        ConsoleColor[,] pixels;
        int lastConsoleHeight;
        int lastConsoleWidth;

        public ConsoleDisplay() {
            pixels = new ConsoleColor[Console.WindowHeight, Console.WindowWidth/2];
            lastConsoleHeight = Console.WindowHeight;
            lastConsoleWidth = Console.WindowWidth;
        }

        public void SetPixel(int x, int y, ConsoleColor color) {
            int writeX = x%pixels.GetLength(0);
            int writeY = y%pixels.GetLength(1);

            pixels[writeX, writeY] = color;
        }

        public void Render() {
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
                    Console.ForegroundColor = pixels[i, j];
                    if (i >= Console.WindowHeight || j >= Console.WindowWidth) {
                        rerender = true;
                        break;
                    } else {
                        Console.SetCursorPosition(j*2, i);
                        Console.Write("██");
                        Console.ResetColor();
                    }
                }
                if (rerender) break;
            }
            if (rerender) this.Render();

            this.pixels = new ConsoleColor[Console.WindowHeight, Console.WindowWidth / 2];

            //Program.PrintOut2DArray(pixels);
        }
    }
}
