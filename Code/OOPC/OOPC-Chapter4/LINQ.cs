using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;
namespace OOPCChapter4
{
    public class LINQ
    {
        public static void LINQQueryExpressionsExample()
        {
            // Specify the data source.
            int[] scores = new int[] { 97, 92, 81, 60 };

            // Define the query expression.
            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80
                orderby score
                select score;

            // Execute the query.
            foreach (int i in scoreQuery)
            {
                Console.Write(i + " ");
            }
        }

        public static void LinqLambdaExpressionsExample()
        {
            // Specify the data source.
            int[] scores = new int[] { 97, 92, 81, 60 };

            var scoreQuery = scores.Where(x => x > 80).OrderBy(x => x);

            // Execute the query.
            foreach (int i in scoreQuery)
            {
                Console.Write(i + " ");
            }
        }

        // Create a data source by using a collection initializer.
        static List<Student> students = new List<Student>
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
            new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91} }
        };

        public static void StandardLinqOperations()
        {
            //filtering
            var studentsMoreThan80Percent = students.Where(x => (((double)x.Scores.Sum() / (double)x.Scores.Count()) * 100) > 80.00);
            studentsMoreThan80Percent.ToList().ForEach((student) => { Console.WriteLine($"{student.First} {student.Last} - Total: {student.Scores.Sum()}");});
            //Grouping - group by first letter of the last name
            var groupedStudents = students.GroupBy(x => x.Last[0]);
            Action<List<Student>> printAll = (obj) => obj.ForEach(item => Console.WriteLine($"\t{item.First} {item.Last}"));
            foreach (var item in groupedStudents)
            {
                Console.WriteLine($"Key: {item.Key}");
                printAll(item.ToList());
            }

            //projections
            var projectedStudent = students.Select(x => new { Name = String.Format($"{x.First} {x.Last}"), TotalMarks = x.Scores.Sum() });
            projectedStudent.ToList().ForEach(x => Console.WriteLine($"Name: {x.Name} - Total Marks: {x.TotalMarks}"));

            //aggregations
            var averageMarks = students.Average(x => x.Scores.Sum());
            var maxMarks = students.Max(x => x.Scores.Sum());
            var minMarks = students.Min(x => x.Scores.Sum());

            //quantifiers
            var anyStudentWithMarksGreaterThan300 = students.Any(x => x.Scores.Sum() > 300);
            var allStudentsWithMarksGreaterThan300 = students.All(x => x.Scores.Sum() > 300);

            //partitioning
            var allExceptFirst3 = students.Skip(3);
            var skipAllUntilLastNameStartingWithM = students.SkipWhile(x => x.Last.ToLower().StartsWith("m"));
            var first5 = students.Take(5);
            var takeAllUntilFirstNameIsHugo = students.TakeWhile(x => x.First.ToLower() != "hugo");
        }
    }

    public class Student
    {
        public string First { get; set; }
        public string Last { get; set; }
        public int ID { get; set; }
        public List<int> Scores;
    }
}