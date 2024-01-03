using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._8._23___forLoops {
    internal class Program {
        static void Main(string[] args) {
            int loop1To = 11;
            for (int i = 0; i <= loop1To; i++) {
                if (i % 2 != 0) {
                    if (i != loop1To) Console.Write(i + ", ");
                    else Console.WriteLine(i);
                }
            }
            int loop2Size = 2;
            for (int i = -loop2Size; i <= loop2Size; i++) {
                if (i != loop2Size) Console.Write(i + ", ");
                else Console.WriteLine(i);
            }
            int loop3To = 8;
            for (int i = 1; i <= loop3To; i++) {
                int outI = i;
                if (i % 2 == 0) outI = -i;
                if (i != loop3To) Console.Write(outI + ", ");
                else Console.WriteLine(outI);
            }
            int loop4To = 11;
            for (int i = 1; i <= loop4To; i++) {
                if (i != loop4To) Console.Write(i%2 + ", ");
                else Console.WriteLine(i%2);
            }
            Console.ReadLine();
        }
    }
}
