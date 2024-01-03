using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci_sequence {
    internal class Program {
        static void Main(string[] args) {
            Int64 prev = 1;
            Int64 curr = 0, next = 0;
            Int64 read = readConsoleInteger(str: "Type a num to loop for: ");
            for (Int64 i = 0; i <= read; i++) {
                try { checked { next = prev + curr; } }
                catch (OverflowException) { Console.WriteLine("The next fibonacci sequence number doesn't fit in Int64 maximum!"); break; }
                prev = curr;
                curr = next;
                Console.WriteLine(next);
            }
            Console.ReadLine();
        }

        private static Int64 readConsoleInteger(string notANumber = "It has to be an integer!", string str = "") {
            while (true) {
                Console.Write(str);
                if (Int64.TryParse(Console.ReadLine(), out Int64 readNum)) return readNum;
                else Console.WriteLine(notANumber);
            }
        }
    }
}
