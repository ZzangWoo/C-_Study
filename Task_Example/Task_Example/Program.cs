using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Example
{
    class A
    {
        private int privateInt;
        protected int protectedInt;
    }

    class B : A
    {
        B ()
        {
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("0");

            Task task = new Task(new Action(Run));
            task.Start();
            //task.Wait();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("----------------");
            }

            
        }

        static void Run()
        {
            while(true)
            {
                Console.WriteLine("Long running method");
            }
        }
    }
}
