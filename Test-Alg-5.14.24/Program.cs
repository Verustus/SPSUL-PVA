namespace Test_Alg_5._14._24 {
    internal class Program {
        public static void Main(string[] args) {
            start:
            Console.Write("Specifikuj velikost: ");
            int vel;
            if (int.TryParse(Console.ReadLine(), out vel)) {
                for (int i = 0; i < vel; i++) {
                    for (int j = 0; j < vel; j++) {
                        if (vel-j-1 > i) Console.Write("  ");
                        else Console.Write("\u2588\u2588");
                    }
                    Console.WriteLine();
                }
                for (int i = 0; i < 2*vel; i++) {
                    for (int j = 0; j < 2*vel; j++) {
                        if (i > vel) {
                            if (vel*vel >= (i-vel)*(i-vel)+(j-vel+1)*(j-vel+1)) Console.Write("\u2588\u2588");
                            else Console.Write("  ");
                        } else {
                            if (j > vel-vel/3 && j < vel) Console.Write("\u2588\u2588");
                            else Console.Write("  ");
                        }
                    }
                    Console.WriteLine();
                }
            } else {
                Console.WriteLine("Velikost musí byt 32 bitové celé číslo!!! Zkus to znovu.");
                goto start;
            }

        }
    }
}