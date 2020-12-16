using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Reflection_Example
{
    class Profile
    {
        public string Name { get; set; }
        public string Phone { get; set; }

        public void Print()
        {
            Console.WriteLine("{0}, {1}", Name, Phone);
        }
    }

    class PersonalInfo : IEnumerable
    {
        private Dictionary<string, Person> data = new Dictionary<string, Person>();

        [IndexerNameAttribute("PersonIndexer")]
        public Person this[string code]
        {
            get
            {
                if (data.ContainsKey(code))
                {
                    return data[code];
                }
                else
                {
                    throw new Exception("없는 code입니다.");
                }
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("인덱서 오류");
                }
                else
                {
                    if (data.ContainsKey(code))
                    {
                        data[code] = value;
                    }
                    else
                    {
                        data.Add(code, value);
                    }
                }
            }
        }

        /// <summary>
        /// IEnumerable 구현
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            foreach (var result in data)
            {
                // yield : 데이터를 하나씩 리턴할 때 사용
                yield return result.Value;
            }
        }
    }

    class Person
    {
        public string name { get; set; }
        public string sex { get; set; }
        public string regNod { get; set; }
        public string tel { get; set; }
        public string address { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Example3();
        }

        private static void Example3()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(@"D:\Study\C#_Restudy\CSharp_Study\Reflection_Example\Reflection_Example\AddressBook.xml");

            XmlNodeList xmlList = xml.SelectNodes("PersonalInfo/person");

            PersonalInfo personalInfo = new PersonalInfo();
            foreach (XmlNode items in xmlList)
            {
                PropertyInfo propertyInfo = typeof(PersonalInfo).GetProperty("PersonIndexer");
                string code = items.Attributes["code"].Value;

                Person person = new Person();
                foreach(XmlNode item in items.ChildNodes)
                {
                    person.GetType().GetProperty(item.Name).SetValue(person, item.InnerText.Trim(), null);
                }
                propertyInfo.SetValue(personalInfo, person, new object[] { code });
            }

            // 출력 
            foreach (var personData in personalInfo)
            {
                var personList = personData.GetType().GetProperties();
                foreach (var item in personList)
                {
                    Console.WriteLine($"{item.Name} : {item.GetValue(personData, null)}");
                }
                Console.WriteLine();
            }
        }

        private static void Example2()
        {
            Type type = typeof(Profile);
            Profile profile = Activator.CreateInstance(type) as Profile;

            profile.Name = "박찬호";
            profile.Phone = "123-4567";

            MethodInfo method = type.GetMethod("Print");

            method.Invoke(profile, null);
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
