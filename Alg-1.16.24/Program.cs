using System;
using System.Collections.Generic;
using System.IO;
using Z.Expressions;


namespace Alg_1._16._24 {
    internal class Program {

        private static FileStream ostrm;
        private static StreamWriter writer;
        private static TextWriter oldOut;

        private static void Main(string[] args) {
            //String fileName = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
            //Console.WriteLine(fileName);
            //startLoggingToFile(fileName);
            byte[] inputBuffer = new byte[1024];
            Stream inputStream = Console.OpenStandardInput(inputBuffer.Length);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));
            String read = "";
            int vel = -1;
            String condition = null;
            while(read.ToLower() != "exit") {
                if (condition == null) Console.WriteLine("First read param is the condition and then the size.");
                read = Console.ReadLine();
                if (read.ToLower() != "exit") {
                    if (condition != null) {
                        try {
                            vel = int.Parse(read);
                            if (vel == 0) vel = -1;
                        }
                        catch {}
                        if (vel <= 0) Console.WriteLine("Size has to be integer greater than zero!");
                        else {
                            int[,] pole = new int[vel, vel];

                            for (int i = 0; i < vel; i++) {
                                for (int j = 0; j < vel; j++) {
                                    try {
                                        bool conditionResult = Eval.Execute<bool>(condition, new { i, j, vel, pole });
                                        if (conditionResult) pole[i, j] = 1;
                                        else pole[i, j] = 0;
                                    } catch {
                                        Console.WriteLine("The condition: ({0}) is incorrect!", condition);
                                        condition = null;
                                        vel = -1;
                                    }
                                }
                            }
                            if (condition != null) {
                                printOutArray(pole);
                                condition = null;
                                vel = -1;
                            }
                        }
                    }
                    else condition = read;
                }
            }
            
            //stopLoggingToFile();
        }

        private static void printOutArray(int[,] array) {
            //Console.Write("[");
            for (int i = 0; i < array.GetLength(0); i++) {
                //Console.Write("[");
                Console.Write("|");
                for (int j = 0; j < array.GetLength(1); j++) {
                    //Console.Write((j == 0 ? "" : ", ") + array[i, j]);
                    if (array[i, j] == 0) Console.Write("░░");
                    else Console.Write("██");
                }
                Console.Write("|\n");
                //Console.Write("]\n");
            }
            //Console.Write("]");
        }

        private static void startLoggingToFile(String fileName) {
            oldOut = Console.Out;
            try
            {
                ostrm = new FileStream("C:\\Users\\kukul\\Desktop\\projects\\SPSUL-PVA\\Alg-1.16.24" + fileName + ".log", FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(ostrm);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open {0}.log for writing", fileName);
                Console.WriteLine(e.Message);
                return;
            }
            Console.SetOut(writer);
        }

        private static void stopLoggingToFile() {
            Console.SetOut(oldOut);
            writer.Close();
            ostrm.Close();
        }
    }
}
/*
int vel = int.Parse();

int[,] pole = new int[vel, vel];

for (int i = 0; i < vel; i++)
{
    for (int j = 0; j < vel; j++)
    {
        //if ((i+1)/2+j==vel/2 || j-vel/2 == (i+1)/2 || i==vel-1 || j==vel/2) {
        //if ((i+1)/2+j==vel/2 || j-vel/2 == (i+1)/2 || i==vel/3) {
        //if (i == j-j/3+vel/3 || i+j-j/3 == vel || (i+1)/2+j == vel/2 || j-vel/2 == (i+1)/2 || i == vel/3) { //star
        //if (i == j+vel/2 || vel-i-1 == j-vel/2 || i == vel-j-1-vel/2 || i == j-vel/2) {
        if ((i >= vel / 4 && i <= vel - vel / 4 && j >= vel / 4 && j <= vel - vel / 4) &&
            (i == vel / 4 && j - vel / 2 >= 0 || j == vel - vel / 4 && i - vel / 2 >= 0 ||
            i == vel / 2 || j == vel / 2 || i == j || i == vel - j ||
            i == vel - vel / 4 && vel - j - 1 - vel / 2 >= 0 || j == vel / 4 && vel - i - 1 - vel / 2 >= 0))
        { //propeler
            pole[i, j] = 1;
        }
        else
        {
            pole[i, j] = 0;
        }
    }
}

//(i>=vel/3&&i<vel-vel/3&&j>=vel/3&&j<vel-vel/3)&&(i+vel/6==j||i-vel/6==j||i+vel/6==vel-j-1||i-vel/6==vel-j-1)||!(i>=vel/3&&i<vel-vel/3&&j>=vel/3&&j<vel-vel/3)&&(i==vel/2||j==vel/2)