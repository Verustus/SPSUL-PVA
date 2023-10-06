using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2A {
    internal class Program {
        static void Main(string[] args) {
            while (true) {
                Console.Write("Type a non decimal number (DEC): ");
                string RDEC = Console.ReadLine();
                if (Int64.TryParse(RDEC, out Int64 DEC)) {
                    Console.Write("Type a non decimal number (system): ");
                    string Rsystem = Console.ReadLine();
                    if (Int64.TryParse(Rsystem, out Int64 system)) {
                        string value = DECtoANY(DEC, system);
                        if (value != "") Console.WriteLine("Your number converted to " + Rsystem + " is " + value);
                    }
                    else {
                        Console.WriteLine("That is not a number or not a decimal number!");
                    }
                }
                else {
                    Console.WriteLine("That is not a number or not a decimal number!");
                }
            }
            Console.ReadLine();
        }
        static string DECtoANY(Int64 DEC, Int64 system) {
            if (system > 34) {
                Console.WriteLine("This system is not supported!");
                return "";
            }
            string strInt = "";
            if (system == 1) {
                for (int i = 0; i < DEC; i++) {
                    strInt += "1";
                }
                return strInt;
            }
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToUpper().ToCharArray();
            Int64 last = DEC;
            while(last != 0) {
                Int64 left = last % system;
                if (left > 9) {
                    strInt = alphabet[left-10] + strInt;
                } else {
                    strInt = left + strInt;
                }
                last = last / system;
            }
            return strInt;
        }
    }
}
