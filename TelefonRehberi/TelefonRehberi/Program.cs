using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        PhoneBook phoneBook = new PhoneBook();
        phoneBook.AddContact("Onur", "Tas", "123321456654");
        phoneBook.AddContact("Taylan", "Tas", "456654123321");
        phoneBook.AddContact("Ali", "Tas", "123321789987");
        phoneBook.AddContact("Kobra", "Nejdet", "012332145665");
        phoneBook.AddContact("Kolpaci", "Hursit", "123321025520");

        while (true)
        {
            Console.WriteLine("Lutfen yapmak istediginiz islemi seciniz :");
            Console.WriteLine("*********************************************");
            Console.WriteLine("(1) - Yeni Numara Kaydetmek");
            Console.WriteLine("(2) - Varolan Numara Silmek");
            Console.WriteLine("(3) - Varolan Numarayı Güncellemek");
            Console.WriteLine("(4) - Rehberi Görüntüle");
            Console.WriteLine("(5) - Rehberde Arama Yap");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    phoneBook.AddNewNumber();
                    break;
                case 2:
                    phoneBook.DeleteNumber();
                    break;
                case 3:
                    phoneBook.UpdateNumber();
                    break;
                case 4:
                    phoneBook.ListContacts();
                    break;
                case 5:
                    phoneBook.SearchContacts();
                    break;
                default:
                    Console.WriteLine("Geçersiz bir giriş... Tekrar Deneyiniz!");
                    break;
            }
        }
    }
}

class Contact
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public string PhoneNumber { get; set; } 
}

class PhoneBook
{
    private List<Contact> contacts = new List<Contact>();

    public void AddContact(string firstName, string lastName, string phoneNumber)
    {
        contacts.Add(new Contact { FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber });
    }
    public void AddNewNumber()
    {
        Console.WriteLine("Lutfen Ad bilgisini giriniz :");
        string name = Console.ReadLine();

        Console.WriteLine("Lutfen Soyad bilgisini giriniz :");
        string surname = Console.ReadLine();

        Console.WriteLine("Lutfen Numara bilgisini giriniz :");
        string phoneNumber = Console.ReadLine();

        AddContact(name, surname, phoneNumber);
        Console.WriteLine("Ekleme başarılı bir şekilde tamamlanmıştır.");
    }
    public void DeleteNumber()
    {
        Console.WriteLine("Lutfen silmek istediginiz kisinin Ad veya Soyadini giriniz :");
        string input = Console.ReadLine().ToLower();

        Contact contactDelete = contacts.FirstOrDefault(x => x.FirstName.ToLower() == input || x.LastName.ToLower() == input); 

        if(contactDelete == null)
        {
            Console.WriteLine("Silmek istediginiz numara bulunmamaktadır. Lutfen yeni bir islem yapiniz...");
            return;
        }

        Console.WriteLine($"{contactDelete.FirstName} {contactDelete.LastName} isimli kişi silinmek üzere");
        Console.WriteLine("İşlem için tercih yapınız : E/H");
        
        string choice = Console.ReadLine().ToLower();

        if(choice == "e")
        {
            contacts.Remove(contactDelete);
            Console.WriteLine("İşlem başarıyla tamamlanmıştır...");
        }
        else
        {
            Console.WriteLine("İşlem iptal edilmiştir...");
        }
    }
    public void UpdateNumber()
    {
        Console.Write("Lutfen numarasını güncellemek istediginiz kayitin ad veya soyadını giriniz :");
        string input = Console.ReadLine();

        Contact updateContact = contacts.FirstOrDefault(x => x.FirstName.ToLower() == input || x.LastName.ToLower() == input);

        if(updateContact == null)
        {
            Console.WriteLine("Aranan kisi rehberde bulunmamaktadir. Lutfen bir secim yapiniz :");
            return;
        }
        Console.WriteLine($"{updateContact.FirstName} {updateContact.LastName} isimli kisinin telefonunu giriniz :");
        string phoneNumberUp = Console.ReadLine();

        updateContact.PhoneNumber = phoneNumberUp;
        Console.WriteLine("Giriş yapılan numara, rehbere eklenmiştir.");
    }
    public void ListContacts()
    {
        foreach(var item in contacts)
        {
            Console.WriteLine($"{item.FirstName} {item.LastName} : {item.PhoneNumber}");
        }
    }
    public void SearchContacts()
    {
        Console.WriteLine("Lutfen arama kriterinizi giriniz :");
        Console.WriteLine("************************************");
        Console.WriteLine("(1) - ad veya soyad ile arama");
        Console.WriteLine("(2) - numara bilgisi ile arama");

        int choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 1:
                Console.WriteLine("Arama yapılacak ad veya soyadı giriniz :");
                string name = Console.ReadLine().ToLower();

                var resultName = contacts.Where(x => x.FirstName.ToLower().Contains(name) || x.LastName.ToLower().Contains(name)).ToList();

                if(resultName.Count == 0)
                {
                    Console.WriteLine("Aranan kisi bulunamadi...");
                    break;
                }
                Console.WriteLine("------ Arama Sonuclari ------");
                foreach(var item in resultName)
                {
                    Console.WriteLine($"Ad: {item.FirstName} Soyad: {item.LastName} Numara: {item.PhoneNumber}");
                }
                break;

            case 2:
                Console.WriteLine("Aranan telefon numarasını giriniz :");
                string searchNumber = Console.ReadLine();

                var resultNumber = contacts.Where(x => x.PhoneNumber.Contains(searchNumber)).ToList();

                if(resultNumber.Count == 0)
                {
                    Console.WriteLine("Aranan kriterlere uygun kisi, rehberde bulunmamaktadir.");
                    break;
                }
                Console.WriteLine("------ Arama Sonuclari ------");
                foreach (var item in resultNumber)
                    Console.WriteLine($"Ad: {item.FirstName} Soyad: {item.LastName} Numara: {item.PhoneNumber}");

                break;
            default: Console.WriteLine("Geçersiz Giriş... Lutfen tekrar deneyiniz!!");
                break;
        }
    }
}
