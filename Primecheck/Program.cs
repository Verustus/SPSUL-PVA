using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Primecheck {
    internal class Program {
        static void Main(string[] args) {
            while (true) {
                Console.WriteLine("");
                Console.Write("Type a non decimal number: ");
                string read = Console.ReadLine();
                if (Int64.TryParse(read, out Int64 num)) {
                    if (isPrime(num)) Console.WriteLine("Your number is prime!");
                    else Console.WriteLine("Your number isn't prime!");
                } else {
                    Console.WriteLine("That is not a number or not a decimal number!");
                }
            }
            Console.ReadLine();
        }

        static bool isPrime(Int64 num) {
            if (num == 2) return true;
            if (num == 1 | num % 2 == 0) return false;
            for (int i = 2; i < num; i++) {
                if (num % i == 0) {
                    return false;
                }
            }
            return true;
        }
    }
}
