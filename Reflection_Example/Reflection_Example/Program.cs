using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection_Example
{
    class Profile
    {
        public string Name { get; set; }
        public string Phone { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Example2();
        }
        private static void Example2()
        {
            
        }

        private static void Example1()
        {
            int a = 0;

            Type type = a.GetType();
            FieldInfo[] fields = type.GetFields(); // 필드 목록 조회

            foreach (var field in fields)
            {
                Console.WriteLine("Type:{0}, Name:{1}", field.FieldType.Name, field.Name);
            }
        }
    }
}
