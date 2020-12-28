using System;
using System.Collections.Generic;
using System.Dynamic;
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
            // ExpandoObject에서 dynamic 타입 생성
            dynamic person = new ExpandoObject();

            // 속성 지정
            person.Name = "Cho";
            person.Age = 10;

            // 메서드 지정
            person.Print = (Action)(() =>
            {
                Console.WriteLine($"{person.Name} : {person.Age}");
            });

            // 매개변수 있는 메서드 지정
            person.ChangeInfo = (Action<string, int>)((name, age) =>
            {
                person.Name = name;
                person.Age = age;
                if (person.InfoChanged != null) 
                {
                    person.InfoChanged(person, EventArgs.Empty);
                }
            });

            // 이벤트 초기화
            person.InfoChanged = null;

            // 이벤트핸들러 지정
            person.InfoChanged += new EventHandler(OnInfoChanged);

            // 매개변수로 dynamic 전달
            DynamicTest(person);
        }

        private static void OnInfoChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Info Changed!!");
        }

        private static void DynamicTest(dynamic person)
        {
            person.Print();
            person.ChangeInfo("Kim", 20);
            person.Print();
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
