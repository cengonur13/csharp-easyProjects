using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Lutfen ilgili cumleyi giriniz :");
        string input = Console.ReadLine();

        string[] words = input.Split(' ');

        foreach (var word in words)
        {
            bool hasConsecutiveConsonants = CheckMethod(word);
            Console.Write(hasConsecutiveConsonants + " ");
        }
    }

    static bool CheckMethod(string word)
    {
        for (int i = 0; i < word.Length - 1; i++)
        {
            if (IsConsonant(word[i]) && IsConsonant(word[i + 1]))
            {
                return true;
            }
        }
        return false;
    }

    static bool IsConsonant(char c)
    {
        return "bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ".Contains(c);
    }
}
