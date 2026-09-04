using Microsoft.VisualBasic;
using System.Drawing;
using System.Numerics;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
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

            #region Task 3
            //Build a phone book application.
            //1.Create a Collection  with 4 contacts(name → phone number)
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();

            phoneBook.Add("Ahmed", "01012345678");
            phoneBook.Add("Sara", "01123456789");
            phoneBook.Add("Ali", "01234567890");
            phoneBook.Add("Mona", "01512345678");

            //2.Add a new contact using [] syntax (add or update)
            phoneBook["Hassan"] = "01098765432"; // Add new contact

            //3.Try adding a duplicate using .Add() — catch the exception and print the error
            try
            {
                phoneBook.Add("Ahmed", "01111111111");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            //4.Try adding a duplicate using .TryAdd() — print whether it succeeded
            bool result = phoneBook.TryAdd("Ahmed", "01111111111");

            Console.WriteLine($"Was the contact added? {result}");
            //5.Search for a contact that doesn’t exist
            if (phoneBook.ContainsKey("Youssef"))
            {
                Console.WriteLine($"Phone: {phoneBook["Youssef"]}");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
            //6.Get a contact with a fallback of "Not Found"
            string phone = phoneBook.GetValueOrDefault("Youssef", "Not Found");
            Console.WriteLine(phone);
            //7.Print all Keys on one line, then all Values on another line
            Console.WriteLine("Keys:");
            Console.WriteLine(string.Join(", ", phoneBook.Keys));
            Console.WriteLine("Values:");
            Console.WriteLine(string.Join(", ", phoneBook.Values));
            #endregion

            #region task4
            //1.Create a HashSet<string> with a case -insensitive comparer: new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            HashSet<string> emails =
                new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            //2.Add these emails: "ahmed@test.com", "AHMED@test.com", "sara@test.com", "Sara@Test.Com"            emails.Add("ahmed@test.com");
            emails.Add("AHMED@test.com");
            emails.Add("sara@test.com");
            emails.Add("Sara@Test.Com");

            //3.Print Count — how many are actually stored? Explain why.Console.WriteLine($"Count: {emails.Count}");

            //4.Create two sets: Set A = { 1, 2, 3, 4, 5 } and Set B = { 4,5,6,7,8}
            HashSet<int> setA = new HashSet<int> { 1, 2, 3, 4, 5 };
            HashSet<int> setB = new HashSet<int> { 4, 5, 6, 7, 8 };
            //5.Print the result of: UnionWith, IntersectWith, ExceptWith
            // UnionWith
            HashSet<int> union = new HashSet<int>(setA);
            union.UnionWith(setB);

            Console.WriteLine("Union:");
            Console.WriteLine(string.Join(", ", union));

            HashSet<int> intersection = new HashSet<int>(setA);
            intersection.IntersectWith(setB);

            Console.WriteLine("Intersection:");
            Console.WriteLine(string.Join(", ", intersection));

            // ExceptWith
            HashSet<int> except = new HashSet<int>(setA);
            except.ExceptWith(setB);

            Console.WriteLine("Except:");
            Console.WriteLine(string.Join(", ", except));

            // 6. Use IsSubsetOf to check if { 1,2} is a subset of Set A
            HashSet<int> subset = new HashSet<int> { 1, 2 };

            bool resulte = subset.IsSubsetOf(setA);

            Console.WriteLine($"Is {{1,2}} a subset of Set A? {resulte}");
            #endregion
        }
    }
}
