using System;
using System.Collections.Generic;
using System.Linq;

public class TotalCalc
{

    public static void TotalCalculation(List<int> duos)
    {

        int[] resultArr = new int[duos.Count];
        int firstNum, secondNum;

        for (int i = 0; i < duos.Count; i += 2)
        {
            firstNum = duos[i];
            secondNum = duos[i + 1];

            if(firstNum != secondNum)
            {
                resultArr[i] = firstNum + secondNum;
            }
            else
            {
                resultArr[i] = (firstNum + secondNum) * (firstNum + secondNum);
            }
        }

        foreach (var i in resultArr)
        {
            if(i != 0)
                Console.Write(i+" ");
        }

    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("İkililer farklı ise toplamları, aynı ise toplamlarının karesi çıktı olarak verilecektir.");
        Console.WriteLine("Input : (1,1,2,3,4,5) Output : (4,5,9)");
        Console.WriteLine("Lutfen ikili verileri int tipinde, aralarında bosluk olacak sekilde giriniz ");
        string input = Console.ReadLine();

        List<int>  binaryInput = input.Split(' ').Select(int.Parse).ToList();

        if(binaryInput.Count % 2 != 0)
        {
            Console.WriteLine("Eksik giris yapildi, çift sayida veri beklenmektedir...");
            return;
        }
        TotalCalc.TotalCalculation(binaryInput);
    }
}