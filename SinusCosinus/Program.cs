using System;
using System.Threading;

namespace SinusCosinus {
    internal class Program {
        private static void Main(string[] args) {
            int i = 0;
            while (true) {
                int posX = (int)map(i%1000, 0, 1000, 0, Console.WindowWidth-1);
                if (i % 2000 >= 1000) posX = Console.WindowWidth - posX - 1; 
                int posY = Clamp((int) map((float) Sinus((i+90)%360 * Math.PI / 180), -1, 1, 0, Console.WindowHeight-1), 0, Console.WindowHeight-2);
                Console.SetCursorPosition(posX, posY);
                Console.WriteLine("█");
                if (i % 1000 >= 999) Console.Clear();
                Thread.Sleep(10);
                i++;
            }
        }

        private static double Sinus(double x) {
            double sinus = 0;
            for (int i = 1; i < 15; i++) {
                sinus += Math.Pow(-1, i+1) * Math.Pow(x, 2*i-1) / Factorial(2*i-1);
            }
            return sinus;
        }

        private static double Factorial(int n) {
            double factorial = 1;
            for (int i = 2; i <= n; i++) {
                factorial *= i;
            }
            return factorial;
        }

        private static float map(float s, float a1, float a2, float b1, float b2) {
            return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
        }

        public static T Clamp<T>(T val, T min, T max) where T : IComparable<T> {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }
    }
}
