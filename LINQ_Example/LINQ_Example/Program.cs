using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Example
{
    public class Student
    {
        public string First { get; set; }
        public string Last { get; set; }
        public int ID { get; set; }
        public List<int> Scores;
    }

    public class StudentGrade
    {
        public int ID { get; set; }
        public int Grade { get; set; }
    }

    public class Program
    {
        private static List<Student> students = new List<Student>
        {
            new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
            new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
            new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
            new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
            new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
            new Student {First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
            new Student {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
            new Student {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
            new Student {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
            new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
            new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
            new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}}
        };

        private static List<StudentGrade> studentGrades = new List<StudentGrade>
        {
            new StudentGrade {ID=111, Grade=1},
            new StudentGrade {ID=112, Grade=2},
            new StudentGrade {ID=114, Grade=3},
            new StudentGrade {ID=119, Grade=2},
            new StudentGrade {ID=122, Grade=3},
            new StudentGrade {ID=140, Grade=5}
        };

        static void Main(string[] args)
        {
            Example6();
        }

        static void Example6()
        {
            var results = from student in students
                          join grade in studentGrades on student.ID equals grade.ID into a
                          from grade in a.DefaultIfEmpty(new StudentGrade() { ID = 0 })
                          select new
                          {
                              student.ID,
                              student.First,
                              grade.Grade
                          };

            foreach (var result in results)
            {
                Console.WriteLine($"ID : {result.ID} | Name : {result.First} | Grade : {result.Grade}");
            }
        }

        static void Example5()
        {
            var results = from student in students
                          join grade in studentGrades on student.ID equals grade.ID
                          select new
                          {
                              student.ID,
                              student.First,
                              grade.Grade
                          };

            foreach (var result in results)
            {
                Console.WriteLine($"ID : {result.ID} | Name : {result.First} | Grade : {result.Grade}");
            }
        }

        static void Example4()
        {
            var results = from student in students
                          group student by student.Scores.Average() >= 85 into g
                          select new { GroupKey = g.Key, Profiles = g };

            foreach (var group in results)
            {
                Console.WriteLine($"평균 85점 이상 : {group.GroupKey}");

                foreach (var profile in group.Profiles)
                {
                    Console.WriteLine($"\t{profile.First}의 평균점수 : {profile.Scores.Average()}");
                }
            }

        }
        static void Example1()
        {
            int[] numbers = { 9, 2, 6, 4, 5, 3, 7, 8, 1, 10 };

            var result = from n in numbers
                         where n % 2 == 0
                         orderby n
                         select n;

            foreach (int n in result)
            {
                Console.WriteLine($"짝수 : {n}");
            }
        }

        static void Example2()
        {
            var result = from student in students
                         where student.ID % 2 == 0
                         select new { student.First, NewID = student.First + student.ID.ToString() };

            foreach (var n in result)
            {
                Console.WriteLine($"{n.First} : {n.NewID}");
            }
        }

        static void Example3()
        {
            var results = from student in students
                          from score in student.Scores
                          where score < 60
                          select new { student.First, Score = score };

            foreach (var result in results)
            {
                Console.WriteLine($"{result.First} : {result.Score}");
            }
        }
    }
}

