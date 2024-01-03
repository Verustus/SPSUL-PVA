using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_multiplication_table {
    internal class Program {
        static void Main(string[] args) {
            List<int> list = new List<int>();
            for (int i = 1; i <= 10; i++) {
                for (int j = 1; j <= 10; j++) {
                    int multiply = i * j;
                    if (!list.Contains(multiply)) {
                        list.Add(multiply);
                        Console.WriteLine(i + " * " + j + " = " + multiply);
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
