using System.Drawing;
using System.Runtime.InteropServices;
using PastelExtended;

namespace Console_3D_Renderer {
    internal class ConsoleDisplay {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetStdHandle(int nStdHandle);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteConsole(IntPtr hConsoleOutput, string lpBuffer, uint nNumberOfCharsToWrite, out uint lpNumberOfCharsWritten, IntPtr lpReserved);
        private const int STD_OUTPUT_HANDLE = -11;

        Color[,] lastRenderPixels;
        Color[,] pixels;
        int lastConsoleHeight;
        int lastConsoleWidth;
        IntPtr consoleHandle;

        public ConsoleDisplay() {
            pixels = new Color[Console.WindowHeight, Console.WindowWidth/2];
            lastRenderPixels = pixels;
            lastConsoleHeight = Console.WindowHeight;
            lastConsoleWidth = Console.WindowWidth;
            consoleHandle = GetStdHandle(STD_OUTPUT_HANDLE);
        }

        public void SetPixel(int x, int y, Color color) {
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
            Color[,] pixels = this.pixels;

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
                                Console.SetCursorPosition(j * 2, i);
                                string pixel = "  ".Bg(pixels[i, j]);
                                WriteConsole(consoleHandle, pixel, (uint) pixel.Length, out uint _, IntPtr.Zero);
                            } catch {
                                rerender = true;
                                Console.ResetColor();
                                break;
                            }
                            /*byte[] buffer = Enumerable.Repeat((byte)' ', 2).ToArray();
                            using (Stream stdout = Console.OpenStandardOutput(Console.WindowHeight*Console.WindowWidth)) {
                                stdout.Write(buffer, 0, buffer.Length);
                            }*/
                            
                            Console.ResetColor();
                            Console.SetCursorPosition(0, 0);
                        }
                    } catch {}
                }
                if (rerender) break;
            }
            if (rerender) Draw();
            
            lastRenderPixels = pixels;
            this.pixels = new Color[Console.WindowHeight, Console.WindowWidth / 2];
        }
    }
}
