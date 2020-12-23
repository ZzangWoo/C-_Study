using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Example
{
    class TestClassAA
    {
        public void TestMethodAA()
        {
            Console.WriteLine($"{this.GetType()} : AA메서드 호출");
        }
        public void TestMethodBB()
        {
            Console.WriteLine($"{this.GetType()} : BB메서드 호출");
        }
    }

    class TestClassBB : TestClassAA { }

    class TestClassCC
    {
        public void TestMethodAA()
        {
            Console.WriteLine($"{this.GetType()} : AA메서드 호출");
        }
        public void TestMethodBB()
        {
            Console.WriteLine($"{this.GetType()} : BB메서드 호출");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Example2();
        }

        private static void Example2()
        {
            //dynamic person = new ExpandoObject();
        }

        private static void Example1()
        {
            dynamic[] arr = new dynamic[] { new TestClassAA(), new TestClassBB(), new TestClassCC() };

            foreach (dynamic test in arr)
            {
                Console.WriteLine(test.GetType());
                test.TestMethodAA();
                test.TestMethodBB();

                Console.WriteLine();
            }
        }
    }
}
