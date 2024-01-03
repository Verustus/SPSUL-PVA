using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator {
    internal class Program {
        static int Main(string[] args) {
            Console.WriteLine("Type the first number: ");
            if (float.TryParse(Console.ReadLine(), out float num1)) {
                Console.WriteLine("Type the second number: ");
                if (float.TryParse(Console.ReadLine(), out float num2)) {
                    Console.WriteLine("Type the operator (+-*/): ");
                    string op = Console.ReadLine();
                    string result = Calc(num1, num2, op);
                    if (float.TryParse(result, out float output)) {
                        Console.WriteLine("The result of " + num1 + " " + op + " " + num2 + " is: " + output);
                    }
                    else {
                        Console.WriteLine(result);
                        return -1;
                    }
                }
                else {
                    Console.WriteLine("This is not a number!");
                    return -1;
                }
            } else {
                Console.WriteLine("This is not a number!");
                return -1;
            }
            Console.ReadLine();
            return 0;
        }
        public static string Calc(float num1, float num2, string op) {
            switch (op) {
                case "+":
                    return (num1 + num2).ToString();
                case "-":
                    return (num1 - num2).ToString();
                case "*":
                    return (num1 * num2).ToString();
                case "/":
                    return (num1 / num2).ToString();
                default:
                    return "Not a valid operator!";
            }
        }
    }
}
