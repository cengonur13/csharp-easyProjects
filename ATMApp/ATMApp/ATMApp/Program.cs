using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static Dictionary<string, decimal> accounts = new Dictionary<string, decimal>();
    static List<string> transactionsLog = new List<string>();
    static List<string> fraudLog = new List<string>();

    static void Main(string[] args)
    {
        
        List<string> operations = new List<string> 
        {   "Para Çekme Islemi",
            "Para Yatırma Islemi", 
            "Ödeme Yapma Islemi", 
            "Bakiye Sorgulama Islemi", 
            "Gün Sonu Islemi" };

        
        accounts.Add("user1", 5000);
        accounts.Add("user2", 3000);
        accounts.Add("Onur", 9999999999);
        accounts.Add("Taylan", 111111111);

        Console.WriteLine("Uygulamaya Hoş geldiniz!");
        Console.WriteLine("------------------------------");

        while (true)
        {
            Console.WriteLine("\nIslem seçenekleriniz:");
            for (int i = 0; i < operations.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {operations[i]}");
            }

            Console.WriteLine("\nLütfen yapmak istediğiniz işlemin numarasını girin:");
            Console.WriteLine("------------------------------------------------------");
            
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == operations.Count)
            {
                PerformEndOfDay();
                break;
            }

            if (choice < 1 || choice > operations.Count - 1)
            {
                Console.WriteLine("Gecersiz bir secim yapildi... Lütfen tekrar deneyiniz!.");
                continue;
            }

            string operation = operations[choice - 1];

            Console.WriteLine("Lütfen kullanıcı adınızı girin:");
            string username = Console.ReadLine();

            if (!accounts.ContainsKey(username))
            {
                Console.WriteLine("Bu kullanici, veritabaninda bulunmamaktadir...");
                continue;
            }

            switch (operation)
            {
                case "Para Çekme Islemi":
                    Withdraw(username);
                    break;
                case "Para Yatırma Islemi":
                    Deposit(username);
                    break;
                case "Ödeme Yapma Islemi":
                    MakePayment(username);
                    break;
                case "Bakiye Sorgulama Islemi":
                    CheckBalance(username);
                    break;
            }
        }
    }

    static void Withdraw(string username)
    {
        Console.WriteLine("Lutfen cekmek istediginiz miktari giriniz :");
        decimal amount = Convert.ToDecimal(Console.ReadLine());

        if (amount <= 0)
        {
            Console.WriteLine("Gecersiz miktar! Lütfen pozitif bir değer giriniz...");
            return;
        }

        if (amount > accounts[username])
        {
            Console.WriteLine("Yetersiz bakiye...");
            return;
        }

        accounts[username] -= amount;
        transactionsLog.Add($"{DateTime.Now}: {username} hesabından {amount} TL çekildi.");
        Console.WriteLine($"{amount} TL çekildi. Yeni bakiye: {accounts[username]} TL");
    }

    public static void Deposit(string username)
    {
        Console.WriteLine("Yatırmak istediginiz miktarı giriniz :");
        decimal amount = Convert.ToDecimal(Console.ReadLine());

        if (amount <= 0)
        {
            Console.WriteLine("Geçersiz miktar! Lütfen pozitif bir deger giriniz...");
            return;
        }

        accounts[username] += amount;
        transactionsLog.Add($"{DateTime.Now}: {username} hesabına {amount} TL yatırıldı.");
        Console.WriteLine($"{amount} TL yatırıldı. Yeni bakiye: {accounts[username]} TL");
    }

    public static void MakePayment(string username)
    {
        Console.WriteLine("Ödemek istediginiz miktari giriniz :");
        decimal amount = Convert.ToDecimal(Console.ReadLine());

        if (amount <= 0)
        {
            Console.WriteLine("Geçersiz miktar! Lütfen pozitif bir deger giriniz...");
            return;
        }

        if (amount > accounts[username])
        {
            Console.WriteLine("Yetersiz bakiye... Lutfen sinirlar icinde bir miktar giriniz!");
            return;
        }

        accounts[username] -= amount;
        transactionsLog.Add($"{DateTime.Now}: {username} hesabından {amount} TL ödeme yapıldı.");
        Console.WriteLine($"{amount} TL ödeme yapıldı. Yeni bakiye: {accounts[username]} TL");
    }

    static void CheckBalance(string username)
    {
        Console.WriteLine($"Bakiyeniz: {accounts[username]} TL");
    }

    static void PerformEndOfDay()
    {
        
        Console.WriteLine("\nGün sonu işlemleri:");
        Console.WriteLine("Transaction Log:");
        foreach (var transaction in transactionsLog)
        {
            Console.WriteLine(transaction);
        }

        Console.WriteLine("Fraud Log:");
        foreach (var fraud in fraudLog)
        {
            Console.WriteLine(fraud);
        }

       
        string fileName = $"EOD_{DateTime.Now:ddMMyyyy}.txt";
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var transaction in transactionsLog)
            {
                writer.WriteLine(transaction);
            }

            foreach (var fraud in fraudLog)
            {
                writer.WriteLine(fraud);
            }
        }

        Console.WriteLine($"Gün sonu işlemleri {fileName} dosyasına yazıldı.");
    }
}
