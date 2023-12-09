namespace _01.SecretChat
{
    internal class Program
    {
        static void Main()
        {
            string input = Console.ReadLine(); // heVVodar!gniV

            string tokens;

            while ((tokens = Console.ReadLine()) != "Reveal")
            {

                string [] commands = tokens.Split(":|:");

                if (commands[0] == "InsertSpace")
                {
                    int insertIndex = int.Parse(commands[1]);
                    input = input.Insert(insertIndex, " ");
                }
                else if (commands[0] == "ChangeAll")
                {
                    string substring = commands[1];
                    string replaceLetter = commands[2];
                    input = input.Replace(substring, replaceLetter);
                }
                else
                {
                    string substring = commands[1];
                    bool isSubstringPresented = input.Contains(substring);

                    if (!isSubstringPresented)
                    {
                        Console.WriteLine("error");
                        continue;
                    }

                    int substringIndex = input.IndexOf(substring);
                    input = input.Remove(substringIndex, substring.Length);
                    string reversedSubstring = new string(substring.Reverse().ToArray());

                    input += reversedSubstring;

                }               
                    Console.WriteLine(input);
            }

            Console.WriteLine($"You have a new text message: {input}");
        }
    }
}
