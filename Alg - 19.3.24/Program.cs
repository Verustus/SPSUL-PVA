using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg___19._3._24 {
    internal class Program {
        static void Main(string[] args) {
            int vel = int.Parse(Console.ReadLine());

            int[,] pole = new int[vel, vel];

            for (int i = 0; i < vel; i++) {
                Console.Write("{");
                for (int j = 0; j < vel; j++) {
                    if (j < vel/2) {
                        if (i/2 > vel/2-j-1) {
                            pole[i, j] = i/2 - (vel/2 - j-1);
                        } else {
                            pole[i, j] = (vel / 2 - j - 1) - i / 2;
                        }
                    } else {
                        if (i/2+1 > j-vel/2-1) {
                            pole[i, j] = i / 2 - (j - vel / 2 - 1);
                        }
                        else {
                            pole[i, j] = (j - vel / 2 - 1) - i/2;
                        }
                    }
                    Console.Write(pole[i, j] + (j != vel - 1 ? "," : ""));
                }
                Console.WriteLine(i != vel-1 ? "}," : "}");
            }
            Console.Write("\n\n\n");
            for (int i = 0; i < vel; i++) {
                Console.Write("{");
                for (int j = 0; j < vel; j++) {
                    if (j < vel / 2) {
                        if (i == vel-j) {
                            pole[i, j] = 0;
                        } else {
                            pole[i, j] = 1;
                        }
                    }
                    else {
                        if (i == vel - j) {
                            pole[i, j] = 2;
                        } else {
                            pole[i, j] = 3;
                        }
                    }
                    Console.Write(pole[i, j] + (j != vel - 1 ? "," : ""));
                }
                Console.WriteLine(i != vel - 1 ? "}," : "}");
            }
        }
    }
}
