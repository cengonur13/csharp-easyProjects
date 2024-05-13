using System;
using System.Collections.Generic;

public class Program
{
    public static Dictionary<string, int> votes = new Dictionary<string, int>();

    public static void Main(string[] args)
    {
        
        List<string> categories = new List<string> {"Teknoloji Kategorileri", "Film Kategorileri", 
            "Tech Stack Kategorileri", 
            "Spor Kategorileri",
            "Bilim-Kurgu Kategorileri"};

        Console.WriteLine("Uygulamaya Hoş geldiniz!");
        Console.WriteLine("---------------------------------------");

        while (true)
        {
            Console.WriteLine("\nKategoriler:");
            for (int i = 0; i < categories.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {categories[i]}");
            }

            Console.WriteLine("\nLütfen oy vermek istediğiniz kategorinin numarasını girin (Cikis için 0):");
            int categoryIndex = Convert.ToInt32(Console.ReadLine());

            if (categoryIndex == 0)
            {
                // Oylama sonuçlarını göster
                ShowResults();
                break;
            }

            if (categoryIndex < 1 || categoryIndex > categories.Count)
            {
                Console.WriteLine("Geçersiz bir seçim yaptınız, Lütfen tekrar deneyiniz...");
                continue;
            }

            string category = categories[categoryIndex - 1];

            Console.WriteLine("Lütfen kullanici adinizi girin:");
            string username = Console.ReadLine();

            if (!votes.ContainsKey(username))
            {
                votes.Add(username, categoryIndex);
            }
            else
            {
                Console.WriteLine("Onceden oy kullanildi, 1 kullanici 1 kere oy kullanabilir...");
                continue;
            }

            Console.WriteLine($"Tesekkürler {username}! Oyunuz alinmistir...");
        }
    }

    public static void ShowResults()
    {
        Console.WriteLine("\nOylama Sonuçları:");
        Console.WriteLine("**********************");
        
        foreach (var vote in votes)
        {
            Console.WriteLine($"{vote.Key} -> {vote.Value}");
        }

        int totalVotes = votes.Count;
        Dictionary<int, int> categoryVotes = new Dictionary<int, int>();

        foreach (var vote in votes.Values)
        {
            if (!categoryVotes.ContainsKey(vote))
            {
                categoryVotes.Add(vote, 1);
            }
            else
            {
                categoryVotes[vote]++;
            }
        }

        Console.WriteLine("\nKategoriye Göre Oy Dağılımı:");
        Console.WriteLine("*********************************");
        foreach (var kvp in categoryVotes)
        {
            double percentage = (double)kvp.Value / totalVotes * 100;
            Console.WriteLine($"Kategori {kvp.Key}: {kvp.Value} oy, %{percentage:F2}");
            Console.WriteLine("-----------");
        }
    }
}

