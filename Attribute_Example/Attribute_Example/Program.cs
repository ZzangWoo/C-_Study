using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Attribute_Example
{
    class ExampleClass1
    {
        [Obsolete("Deprecated")]
        public static void OldMethod()
        {
            Console.WriteLine("Old Method");
        }

        public static void NewMethod()
        {
            Console.WriteLine("New Method");
        }
    }

    public static class ExampleClass2
    {
        public static void WriteLine(string message,
            [CallerFilePath] string file = "",
            [CallerLineNumber] int line = 0,
            [CallerMemberName] string member = "")
        {
            Console.WriteLine($"{file}(Line:{line}) {member}: {message}\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Test1();
        }

        private static void Test1()
        {
            ExampleClass2.WriteLine("Hello World!");
        }
    }
}
