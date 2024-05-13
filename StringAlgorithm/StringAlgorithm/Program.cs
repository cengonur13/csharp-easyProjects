using System;

public class AlgorithmString
{
    public static void EditString(string input, int index)
    {
        if(index < 0 || index >= input.Length)
        {
            Console.WriteLine("Hatalı index girilmistir...");
            return;
        }
        string newString = input.Remove(index,1);
        Console.WriteLine(newString);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Lutfen ilgili metni ve index degerini arada , ile giriniz :");
        Console.Write("(data,index) -> ");
        string input = Console.ReadLine();

        string[] newArr = input.Split(',');
        /*
         input : (OnurTas,3) -> output : (OnuTas)
               : (HelloWorld,5)        : (Helloorld)
         */
        if(newArr.Length == 2 && int.TryParse(newArr[1], out int index))
            AlgorithmString.EditString(newArr[0], index);
        else
        {
            Console.WriteLine("Hatalı formatta veri girisi yapilmistir...");
        }
    }
}
