using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorimizace_test_1._5._24 {
    internal class Program {
        static void Main(string[] args) {
            int size = int.Parse(Console.ReadLine());

            int[,] array = new int[size, size];
            int a = 2;
            int b = 1;

            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    if (i%2 == 0) {
                        if (i * size + j %2 == 0) {
                            array[size-j-1, size-i-1] = a;
                            a += 2;
                        } else {
                            array[size-j-1, size-i-1] = b;
                            b *= 2;
                        }
                    } else {
                        if (i * size + j % 2 == 0) {
                            array[j, size - i - 1] = a;
                            a += 2;
                        }
                        else {
                            array[j, size - i - 1] = b;
                            b *= 2;
                        }
                    }
                }
            }

            for (int i = 0;i < array.GetLength(0); i++) {
                Console.Write("{");
                for (int j = 0; j < array.GetLength(1); j++) {
                    Console.Write((j == 0 ? "" : ", " )+ array[i, j]);
                }
                Console.WriteLine("}\n");
            }
        }
    }
}
