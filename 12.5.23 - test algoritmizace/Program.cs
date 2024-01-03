using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._5._23___test_algoritmizace {
    internal class Program {
        static void Main(string[] args) {
            int vel = int.Parse(Console.ReadLine());
            int[] pole = new int[vel];
            int pol = vel / 2;
            for (int i = 0; i < pol; i++) {
                pole[i] = i+1;
                pole[vel-i-1] = pole[i];
            }
            if (vel % 2 == 1) pole[pol] = pol+1;
            Console.WriteLine("");
            for (int i = 0; i < vel; i++) Console.Write(pole[i] + ", ");


            int[] pole
        }
    }
}
