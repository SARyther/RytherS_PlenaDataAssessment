using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlenaDataAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                bool validInput = false;
                string input = null;

                while (!validInput)
                {

                    Console.WriteLine("Enter a word: ");
                    input = Console.ReadLine();

                    if (String.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Well, you have to enter something! Try again.\n\n");
                    }
                    else validInput = true;
                }

                Console.WriteLine("Here is your sorted word: ");
                Console.WriteLine(GetSortedString(input) + System.Environment.NewLine);

                Console.WriteLine("Enter another word? (y/n)");

            } while (Console.ReadLine().ToLower() == "y");
        }

        public static string GetSortedString(string input)
        {
            char[] letters = input.ToLower().ToCharArray();
            Dictionary<char, int> letterGroups = new Dictionary<char, int>();

            foreach (char letter in letters)
            {
                if (letterGroups.ContainsKey(letter))
                {
                    letterGroups[letter]++;
                }
                else
                {
                    letterGroups.Add(letter, 1);
                }
            }

            StringBuilder sb = new StringBuilder();

            foreach(KeyValuePair<char, int> letterGroup in letterGroups.OrderBy(group => group.Value))
            {
                sb.Append(letterGroup.Key, letterGroup.Value);
            }

            return sb.ToString();
        }
    }
}
