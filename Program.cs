using System.Numerics;
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


            #region task 2
            //  Create a leaderboard that automatically sorts players by score.
            //1.Add: 500 = "Ahmed", 200 = "Sara", 800 = "Ali", 350 = "Mona"
            SortedDictionary<int, string> leaderboard = new SortedDictionary<int, string>();
            leaderboard.Add(500, "Ahmed");
            leaderboard.Add(200, "Sara");
            leaderboard.Add(800, "Ali");
            leaderboard.Add(350, "Mona");
            //2.Print all entries(they should be sorted by score automatically)
            Console.WriteLine("Leaderboard:");
            foreach (KeyValuePair<int, string>  player in leaderboard.OrderByDescending(x => x.Key))
            {
                Console.WriteLine($"{player.Value}: {player.Key}");
            }
            //3.Access the first key and first value
            int firstKey = leaderboard.First().Key;
            string firstValue = leaderboard.First().Value;
            Console.WriteLine($"First Key: {firstKey} First Value: {firstValue}");

            //4.Check if score 500 exists
            bool exists = leaderboard.ContainsKey(500);
            Console.WriteLine($"Does score 500 exist? {exists}");

            //5.Safely get the player with score 999
            if (leaderboard.TryGetValue(999, out string playerName))
            {
                Console.WriteLine($"Player with score 999: {playerName}");
            }
            else
            {
                Console.WriteLine("No player with score 999 found.");
            }
            //6.Remove the player with score 200 and print the updated list
            leaderboard.Remove(200);
            Console.WriteLine("Updated Leaderboard after removing score 200:");

            foreach (KeyValuePair<int, string> player in leaderboard)
            {
                Console.WriteLine($"{player.Value}: {player.Key}");
            }
            #endregion


        }
    }
}
