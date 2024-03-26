using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_BarevnePoleUceni {
    internal class Program {

        private static ConsoleDisplay display = new ConsoleDisplay();

        public static void Main(string[] args) {
            Console.Write("Test size: ");
            int size = int.Parse(Console.ReadLine()!);
            int[,] array = new int[size, size];

            A(ref array);

            while (true) {
                Thread.Sleep(1000);
                DisplayColored2DArray(array);
            }
        }

        private static void DisplayColored2DArray(int[,] coloredArray) {
            ConsoleColor[] colors = {
                ConsoleColor.Black,
                ConsoleColor.DarkBlue,
                ConsoleColor.DarkGreen,
                ConsoleColor.DarkRed,
                ConsoleColor.DarkMagenta,
                ConsoleColor.DarkYellow,
                ConsoleColor.DarkGray,
                ConsoleColor.Gray,
                ConsoleColor.Blue,
                ConsoleColor.Green,
                ConsoleColor.Cyan,
                ConsoleColor.Red,
                ConsoleColor.Magenta,
                ConsoleColor.Yellow,
                ConsoleColor.White
            };

            for (int i = 0; i < coloredArray.GetLength(0); i++) {
                for (int j = 0; j < coloredArray.GetLength(1); j++) {
                    ConsoleColor color = colors[Math.Abs(coloredArray[i, j]%colors.Length)];
                    display.SetPixel(i, j, color);
                }
            }
            display.Render();
        }

        public static void PrintOut2DArray<T>(T[,] array) {
            for (int i = 0; i < array.GetLength(0); i++) {
                Console.Write("{");
                for (int j = 0; j < array.GetLength(1); j++) {
                    Console.Write(array[i, j]);
                    if (j < array.GetLength(1) - 1) Console.Write(", ");
                }
                Console.Write("}");
                if (i < array.GetLength(0) - 1) Console.WriteLine(", ");
            }
        }

        private static void A(ref int[,] array) {
            int size = array.GetLength(0);

            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    if (i < size/2) {
                        if (j < size/2) {
                            if (i > j/2) array[i, j] = i - j/2;
                            else  array[i, j] = j/2 - i;
                        } else {
                            if (i > (size-j-1)/2) array[i, j] = i - (size-j-1)/2;
                            else array[i, j] = (size-j-1)/2 - i;
                        }
                    } else {
                        if (j < size/2) {
                            if (size-i-1 > j/2) array[i, j] = (size-i-1) - j/2;
                            else  array[i, j] = j/2 - (size-i-1);
                        } else {
                            if (size-i > (size-j-1)/2) array[i, j] = (size-i-1) - (size-j-1)/2;
                            else array[i, j] = (size-j-1)/2 - (size-i-1);
                        }
                    }
                }
            }
        }

        private static void B(ref int[,] array) {
            int size = array.GetLength(0);

            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    if (size-i-1 >= j-(j+1)/4+size/4)
                        array[i, j] = (size-i-1) - (j-(j+1)/4+size/4);
                    else {
                        if (j == size/2) array[i, j] = j - size/2;
                        else array[i, j] = size/2 - j;
                    }
                }
            }
        }
    }
}
