using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_1._16._24 {
    internal class Program {
        static void Main(string[] args) {
            int vel = int.Parse(Console.ReadLine());

            int[,] pole = new int[vel, vel];
            
            for (int i = 0; i < vel; i++) {
                for (int j = 0; j < vel; j++) {
                    //if ((i+1)/2+j==vel/2 || j-vel/2 == (i+1)/2 || i==vel-1 || j==vel/2) {
                    //if ((i+1)/2+j==vel/2 || j-vel/2 == (i+1)/2 || i==vel/3) {
                    //if (i == j-j/3+vel/3 || i+j-j/3 == vel || (i+1)/2+j == vel/2 || j-vel/2 == (i+1)/2 || i == vel/3) { //star
                    //if (i == j+vel/2 || vel-i-1 == j-vel/2 || i == vel-j-1-vel/2 || i == j-vel/2) {
                    if ((i>=vel/4 && i<=vel-vel/4 && j >= vel/4 && j<= vel-vel/4) &&
                        (i==vel/4 && j-vel/2>=0 || j==vel-vel/4 && i-vel/2>=0 ||
                        i==vel/2 || j==vel/2 || i == j || i==vel-j ||
                        i==vel-vel/4 && vel-j-1-vel/2>=0 || j==vel/4 && vel-i-1-vel/2>=0)) { //propeler
                        pole[i, j] = 1;
                    } else {
                        pole[i, j] = 0;
                    }
                }
            }

            printOutArray(pole);
        }

        public static void printOutArray(int[,] array) {
            //Console.Write("[");
            for (int i = 0; i < array.GetLength(0); i++) {
                //Console.Write("[");
                Console.Write("|");
                for (int j = 0; j < array.GetLength(1); j++) {
                    //Console.Write((j == 0 ? "" : ", ") + array[i, j]);
                    if (array[i, j] == 0) Console.Write("░░");
                    else Console.Write("██");
                }
                Console.Write("|\n");
                //Console.Write("]\n");
            }
            //Console.Write("]");
        }
    }
}
