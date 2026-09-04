using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Adv_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region task 1
            //1.Create a Collection with these grades: 85, 92, 78, 95, 88, 70, 100, 65
            List<int> grades = new List<int> {
                85, 92, 78, 95, 88, 70, 100, 65 
            };
            //2.Print the collection, Count, first and last grade
            Console.WriteLine("Grades: " + string.Join(", ", grades));
            //3.Sort the grades ascending, then print
            grades.Sort();
            Console.WriteLine("Sorted Grades: " + string.Join(", ", grades));
            //4.Get the first grade above 90
            int firstAbove90 = grades.First(g => g > 90);
            Console.WriteLine($"\nFirst grade above 90: {firstAbove90}");
            //&&&&&&&&&&&
            int fistAbove90UsingFind = grades.Find(g => g > 90);
            Console.WriteLine($"\nFirst grade above 90 (using Find): {fistAbove90UsingFind}");
            //5.Get all grades below 75(failing grades)
            List<int> failingGrades = grades.Where(g => g < 75).ToList();
            Console.WriteLine($"\nFailing grades (below 75): {string.Join(", ", failingGrades)}");
            //6.Remove all failing grades(below 75)
            grades.RemoveAll(g => g < 75);
            Console.WriteLine($"\nGrades after removing failing grades: {string.Join(", ", grades)}");
            //7.Check if any grade equals 100
            bool hasPerfectScore = grades.Any(g => g == 100);
            Console.WriteLine($"\nAny grade equals 100: {hasPerfectScore}");
            //8.Create a List<string> where each grade becomes "Grade: X"
            List<string> gradeStrings = grades.Select(g => $"Grade: {g}").ToList();
            Console.WriteLine($"\nGrade strings: {string.Join(", ", gradeStrings)}");
            #endregion
        }
    }
}
