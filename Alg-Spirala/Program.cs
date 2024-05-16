namespace Alg_Spirala {
    internal class Program {
        public static void Main(string[] args) {
            Console.Write("Zadej velikost: ");
            int vel;
            if (int.TryParse(Console.ReadLine(), out vel)) {
                NormalSpiral(vel);
                TurtleSpiral(vel);
            } else Main(args);
        }

        private static void Print2DArray(int[,] array) {

            for (int i = 0; i < array.GetLength(0); i++) {
                for (int j = 0; j < array.GetLength(1); j++)
                    Console.Write(array[i, j] == 1 ? "\u2588\u2588" : "__");
                Console.WriteLine();
            }
        }

        private static void NormalSpiral(int vel) {
            int[,] pole = new int[vel, vel];

            for (int i = 0; i < vel; i++) {
                for (int j = 0; j < vel; j++) {
                    bool sideI = i >= vel/2;
                    int distI = sideI ? vel-i-1 : i;
                    bool sideJ = j >= vel/2;
                    int distJ = sideJ ? vel-j-1 : j;
                    if (i%2 == 1) {
                        if (distJ <= distI) {
                            if (sideJ) {
                                if (distJ%2 == 0) pole[i, j] = 1;
                            } else {
                                int dist = sideJ ? vel-j-1 : j+2;
                                if (dist%2 == 1 && dist <= distI) pole[i, j] = 1;
                            }
                        }
                    } else {
                        if (i == vel/2+1 && (sideJ ? distJ%2 == 0 : distJ%2 == 1)) pole[i, j] = 1;
                        if (sideI) {
                            if (j-2 >= vel-i-1 && j < i) pole[i, j] = 1;
                        } else {
                            if (j >= i && j < vel-i-1) pole[i, j] = 1;
                        }
                    }
                }
            }
            
            Print2DArray(pole);
        }

        private static void TurtleSpiral(int vel) {
            byte dir = 0;
            int lineLength = vel-1;
            int currentLenght = 0;
            int[,] pole = new int[vel, vel];
            int cursorX = 0;
            int cursorY = 0;
                
            while (lineLength != 0) {
                pole[cursorY, cursorX] = 1;

                switch (dir) {
                    case 0:
                        cursorX++;
                        break;
                    case 1:
                        cursorY++;
                        break;
                    case 2:
                        cursorX--;
                        break;
                    case 3:
                        cursorY--;
                        break;
                }
                currentLenght++;
                if (currentLenght == lineLength) {
                    switch (dir) {
                        case 0:
                            cursorY++;
                            break;
                        case 1:
                            cursorX--;
                            break;
                        case 2:
                            cursorY--;
                            break;
                        case 3:
                            cursorX++;
                            break;
                    }
                    if (++dir == 4) dir = 0;
                    lineLength--;
                    currentLenght = 0;
                }
            }
            
            Print2DArray(pole);
        }
    }
}