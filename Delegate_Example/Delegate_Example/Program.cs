using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_Example
{
    delegate int TestDelegate(int a, int b);

    class Calculator
    {
        public int Plus(int a, int b)
        {
            return a + b;
        }

        public static int Minus(int a, int b)
        {
            return a - b;
        }
    }

    class ClassEx2
    {
        public static int AscendCompare(int a, int b)
        {
            if (a > b) return 1;
            else if (a == b) return 0;
            else return -1;
        }

        public static int DescendCompare(int a, int b)
        {
            if (a < b) return 1;
            else if (a == b) return 0;
            else return -1;
        }

        public static void BubbleSort(int[] dataSet, Compare compare)
        {
            int i = 0;
            int j = 0;
            int temp = 0;

            for (i = 0; i < dataSet.Length - 1; i++)
            {
                for (j = 0; j < dataSet.Length - (i + 1); j++)
                {
                    if (compare(dataSet[j], dataSet[j + 1]) > 0) {
                        temp = dataSet[j + 1];
                        dataSet[j + 1] = dataSet[j];
                        dataSet[j] = temp;
                    }
                }
            }
        }
    }

    delegate int Compare(int a, int b);

    class Program
    {
        static void Main(string[] args)
        {
            Example2();
        }

        static void Example2()
        {
            int[] array = { 3, 7, 4, 2, 10 };

            Console.WriteLine("-- 오름차순 정렬 --");
            ClassEx2.BubbleSort(array, new Compare(ClassEx2.AscendCompare));

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }

            int[] array2 = { 7, 2, 8, 10, 11 };
            Console.WriteLine("\n-- 내림차순 정렬 --");
            ClassEx2.BubbleSort(array2, new Compare(ClassEx2.DescendCompare));

            for (int i = 0; i < array2.Length; i++)
            {
                Console.Write($"{array2[i]} ");
            }

            Console.WriteLine();
        }

        static void Example1()
        {
            Calculator calculator = new Calculator();
            TestDelegate testDelegate;

            testDelegate = new TestDelegate(calculator.Plus);
            Console.WriteLine(testDelegate(3, 4));

            testDelegate = new TestDelegate(Calculator.Minus);
            Console.WriteLine(testDelegate(7, 5));
        }
    }
}
