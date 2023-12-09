using System.Text.RegularExpressions;

namespace _02.MirrorWords
{
    internal class Program
    {
        static bool IsPalindrome(string word)
        {
            char[] charArray = word.ToCharArray();
            Array.Reverse(charArray);
            string reversedWord = new string(charArray);

            return word.Equals(reversedWord);


        }
        static void Main()
        {
            string input = Console.ReadLine();

            string pattern = @"(\#|\@)(?<words>[A-Za-z]{3,})\1\1[A-Za-z]{3,}\1";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);

            int matchCounter = matches.Count();

            Console.WriteLine($"{matchCounter} word pairs found!");
            Console.WriteLine("The mirror words are:");

            List<string> wordsMatched = new List<string>();

            foreach (Match match in matches)
            {
                wordsMatched.Add(match.Groups["words"].Value);
            }

            foreach (Match match in matches)
            {
                string word = match.Groups["words"].Value;

                if (IsPalindrome(word))
                {
                    Console.WriteLine(word);
                }
            }



            Console.WriteLine(string.Join(", ", wordsMatched));

        }
    }
}
