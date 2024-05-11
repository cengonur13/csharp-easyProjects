using System;
using System.Collections.Generic;

public enum KartBuyuklugu
{
    XS = 1,
    S,
    M,
    L,
    XL
}

public class Kart
{
    public string Baslik { get; set; }
    public string Icerik { get; set; }
    public int AtananKisiId { get; set; }
    public KartBuyuklugu Buyukluk { get; set; }

    public static implicit operator Kart(List<Kart> v)
    {
        throw new NotImplementedException();
    }
}

public class Board
{
    public List<Kart>[] Lines { get; set; }

    public Board()
    {
        Lines = new List<Kart>[3];
        for(int i = 0; i < 3; i++)
            Lines[i] = new List<Kart>();
    }

    public void KartEkle(Kart kart, int Index)
    {
        Lines[Index].Add(kart);
    }

    public void KartSil(string baslik)
    {
        bool isDeleted = false;

        foreach(var line in Lines)
        {
            var kart = line.Find(x => x.Baslik == baslik);
            if(kart != null)
            {
                line.Remove(kart);
                isDeleted = true;
            }
        }
        if (!isDeleted)
            Console.WriteLine("Aranan kart bulunamamistir...");
    }
    public void KartTasi(string baslik, int sourceIndex, int targetIndex)
    {
        var kart = Lines[sourceIndex].Find(x => x.Baslik == baslik);

        if(kart != null)
        {
            Lines[sourceIndex].Remove(kart);
            Lines[targetIndex].Add(kart);
        }
        else
            Console.WriteLine("Aranan kart bulunamamistir...");
        
    }
    public void Listele()
    {
        string[] lineNames = { "TODO", "IN PROGRESS", "DONE" };

        for(int i = 0; i < 3; i++)
        {
            Console.WriteLine($"{lineNames[i]} Line");
            Console.WriteLine("-----------------------");
            foreach(var kart in Lines[i])
            {
                Console.WriteLine($"Baslik      :{kart.Baslik}");
                Console.WriteLine($"İcerik      :{kart.Icerik}");
                Console.WriteLine($"Atanan Kisi :{kart.AtananKisiId}");
                Console.WriteLine($"Buyukluk    :{kart.Buyukluk}");
                Console.WriteLine("****");
            }
            Console.WriteLine();
        }   
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Dictionary<int, string> teamMember = new Dictionary<int, string>()
        {
            {1, "Onur"},
            {2, "Taylan"},
            {3, "Kobra Nejdet"}
        };

        Kart kart1 = new Kart() { 
            Baslik = "Kart 1", 
            Icerik = "Kart 1'in Icerigi", 
            AtananKisiId = 1, 
            Buyukluk = KartBuyuklugu.M};
        Kart kart2 = new Kart()
        {
            Baslik = "Kart 2",
            Icerik = "Kart 2'nin Icerigi",
            AtananKisiId = 2,
            Buyukluk = KartBuyuklugu.XL
        };
        Kart kart3 = new Kart()
        {
            Baslik = "Kart 3",
            Icerik = "Kart 3'un Icerigi",
            AtananKisiId = 3,
            Buyukluk = KartBuyuklugu.S
        };

        Board board = new Board();
        board.KartEkle(kart1, 0);
        board.KartEkle(kart2, 1);
        board.KartEkle(kart3, 2);

        while (true)
        {
            Console.WriteLine("Lutfen yapmak istediginiz islemi seciniz:");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Board'u Listelemek");
            Console.WriteLine("(2) Board'a Kart Eklemek");
            Console.WriteLine("(3) Board'dan Kart Silmek");
            Console.WriteLine("(4) Kart Taşımak");
            Console.WriteLine("*******************************************");

            int secim = Convert.ToInt32(Console.ReadLine());

            switch (secim)
            {
                case 1:
                    board.Listele();
                    break;
                case 2:
                    Console.WriteLine("Baslik Giriniz :");
                    string baslik = Console.ReadLine();
                    
                    Console.WriteLine("Icerik Giriniz :");
                    string icerik = Console.ReadLine();
                    
                    Console.WriteLine("Buyukluk Seciniz : XS(1) S(2) M(3) L(4) XL(5)");
                    int buyuklukSecim;

                    if (int.TryParse(Console.ReadLine(), out buyuklukSecim) && Enum.IsDefined(typeof(KartBuyuklugu), buyuklukSecim))
                    {
                        KartBuyuklugu buyukluk = (KartBuyuklugu)buyuklukSecim;

                        Console.WriteLine("Kisi Secimi Yapiniz :");
                        
                        int kisiId;
                        if (int.TryParse(Console.ReadLine(), out kisiId) && teamMember.ContainsKey(kisiId))
                        {
                            Kart newKart = new Kart() { 
                                Baslik = baslik, 
                                Icerik = icerik, 
                                AtananKisiId = kisiId, 
                                Buyukluk = buyukluk };
                            board.KartEkle(newKart, 0);
                        }
                        else
                            Console.WriteLine("Hatali bir secim yapildi...");
                    }
                        break;
                  case 3:
                        Console.WriteLine("Lutfen Silmek Istenen Kart Basligini Yaziniz :");
                        string silinenBaslik = Console.ReadLine();
                        board.KartSil(silinenBaslik);
                        break;
                  case 4:
                        Console.WriteLine("Lutfen Tasinacak Kartin Basligini Giriniz :");
                        string tasinacakBaslik = Console.ReadLine();
                       
                        Console.WriteLine("Lutfen Hedef Line Secimi Yapiniz :");
                        Console.WriteLine("(1) TODO - (2) IN PROGRESS - (3) DONE");
                        
                        int sourceIndex;
                    if (int.TryParse(Console.ReadLine(), out sourceIndex)
                    && sourceIndex >= 1 && sourceIndex <= 3)
                    {
                        Console.WriteLine("Bulunmus Kart Bilgisi :");
                        Kart tasinacakKart = null;

                        foreach (var kart in board.Lines)
                        {
                            tasinacakKart = kart.Find(x => x.Baslik == tasinacakBaslik);
                            if (tasinacakKart != null)
                                break;
                        }
                        if (tasinacakKart != null)
                        {
                            Console.WriteLine("------------------------------------");
                            Console.WriteLine($"Baslik       : {tasinacakKart.Baslik}");
                            Console.WriteLine($"Icerik       : {tasinacakKart.Icerik}");
                            Console.WriteLine($"Atanan Kisi  : {tasinacakKart.AtananKisiId}");
                            Console.WriteLine($"Buyukluk     : {tasinacakKart.Buyukluk}");
                            Console.WriteLine($"Line Bilgisi : {(sourceIndex == 1 ? "TODO" : sourceIndex == 2 ? "IN PROGRESS" : "DONE")}");
                        }

                        Console.WriteLine("Lutfen Yukaridaki Kartin Tasinacagi Line Bilgisini Giriniz :");
                        int targetIndex;
                        if (int.TryParse(Console.ReadLine(), out targetIndex) && targetIndex >= 1 && targetIndex <= 3)
                        {
                            board.KartTasi(tasinacakBaslik, sourceIndex - 1, targetIndex - 1);
                            Console.WriteLine("Tasima İslemi tamamlanmistir...");

                        }
                        else
                            Console.WriteLine("Hatali bir secim yaptiniz...");
                    }
                   
                    else
                        Console.WriteLine("Hatali bir secim yapildi...");
                        break;
                default:
                    Console.WriteLine("Gecersiz giris...");
                    break;
            }
            Console.WriteLine("Devam için bir giris yapiniz :");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
