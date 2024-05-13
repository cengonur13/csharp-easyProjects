using System;

public class ReverseString
{
    public static void ReversingInput(string arr)
    {
        string[] newArr = arr.Split(' ');

        for (int i = 0; i < newArr.Length; i++)
        {
            char[] temp = newArr[i].ToCharArray();
            Array.Reverse(temp);
            newArr[i] = new string(temp);

        }

        foreach (var item in newArr)
            Console.Write(item + " ");
    }


    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("input : (Hello World) output : (olleH dlroW)");
            Console.WriteLine("--------------------------");
            Console.Write("Lutfen ters cevrilecek metni giriniz : ");
            
            string input = Console.ReadLine();

            ReverseString.ReversingInput(input);
        }
    }
}
