using System;
using System.Collections.Generic;
using System.Linq;

namespace Arrays_3._1._24 {
    internal class Program {
        static void Main(string[] args) {
            int[] numbers = new int[] { 1, 5, 6 };
            List<int> list = new List<int>() { 1, 3, 5 };
            List<int> list2 = new List<int>() { 2, 4, 6 };

            PrintOutIntegerArrayInfo(numbers);
            PrintOutCheckContainsList(new List<int>[2] { list, list2 }, list);
            PrintOutObjectOnIndex(numbers, 2);
            PrintOutConnectedLists(list, list2);
        }

        static void PrintOutIntegerArrayInfo(int[] array) { Console.WriteLine("Arrays size: {0}; Array element product: {1}", array.Length, array.Aggregate(1, (a, b) => a * b)); }

        static void PrintOutCheckContainsList<T>(List<T>[] listArray, List<T> inside) {
            Console.WriteLine("Array with list elements: {0}{1} list with elements: {2}",
                ListArrayToString(listArray),
                listArray.Contains(inside) ? " contains" : " doesn't contain",
                "{ " + String.Join(", ", inside) + " }");
        }

        static String ListArrayToString<T>(List<T>[] listArray, bool newLine = false) {
            String str = "[ ";
            for (int i = 0; i < listArray.Length; i++) {
                str += (i == 0 ? "" : (newLine ? ",\n" : ", ")) + "{ " + String.Join(", ", listArray[i]) + " }";
            }

            return str + " ]";
        }

        static void PrintOutObjectOnIndex<T>(T[] array, int index) { Console.WriteLine("Integer on index {0} {1}", index, index < array.Length ? "is " + array[index] : "is not contained in array."); }

        static void PrintOutConnectedLists<T>(List<T> first, List<T> second) {
            if (first.Count != second.Count) Console.WriteLine("Lists are not the same size!");
            else {
                Console.Write("Connected list contains these elements: { ");
                for (int i = 0; i < first.Count; i++)
                    Console.Write("{0}, {1}", first[i], second[i] + (i == first.Count-1 ? "" : ", "));
                Console.Write(" }\n");
            }
        }

        
    }
}
