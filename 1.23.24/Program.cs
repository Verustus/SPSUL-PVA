using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._23._24 {
    internal class Program {
        private static void Main(string[] args) {

        }

        private static void FillArray(int[,] pole) {
            if (pole.GetLength(0) >= 1) pole[0, 0] = 1;
            for (int i = 0; i < pole.GetLength(0); i++) {
                for (int j = 0; j < pole.GetLength(1); j++) {
                    if (i <= 1) {
                        if (j != 0) pole[i, j] = pole[i, j - 1];
                    } else {
                        if (j == 0) pole[i, j] 
                    }
                }
            }
        }

        private static void PrintOutArray(int[,] array) {
            Console.Write("[");
            for (int i = 0; i < array.GetLength(0); i++) {
                Console.Write("[");
                for (int j = 0; j < array.GetLength(1); j++) {
                    Console.Write((j == 0 ? "" : ", ") + array[i, j]);
                }
                Console.Write("]\n");
            }
            Console.Write("]");
        }
    }
}
