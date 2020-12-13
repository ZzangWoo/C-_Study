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

    class Program
    {
        static void Main(string[] args)
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
