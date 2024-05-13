using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Giris yapilan n adet sayilardan 67den kucuk olanlarin,");
        Console.WriteLine("67 ile arasindaki fark toplamlarini yazan, buyuklerinse farklarinin");
        Console.WriteLine("mutlak karelerini ekrana yazdiran program...");
        Console.WriteLine("Input : (56 45 68 77) Output : (33 101)");
        Console.WriteLine("---------------------------------------------------------------------");
        Console.Write("Lutfen sayilari aralarında bosluk olacak sekilde giriniz :");
        
        string input = Console.ReadLine();
        string[] numbers = input.Split(' ');

        int smallDifSum = 0;
        int largDifSum = 0;
        int temp, diff;
        
        foreach(var number in numbers)
        {
            temp = int.Parse(number);
            diff = Math.Abs(67 - temp);

            if (temp < 67)
                smallDifSum += diff;
            else
                largDifSum += diff * diff;
        }
        Console.WriteLine($"{smallDifSum} {largDifSum}");
    }
}
