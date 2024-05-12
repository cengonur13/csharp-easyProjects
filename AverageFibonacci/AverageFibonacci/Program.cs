using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Lutfen Fibonacci Dizisinin Derinligini Giriniz :");
        try
        {
            int depth = Convert.ToInt32(Console.ReadLine());
            int[] fibonacciArray = GenerateFibonacci(depth);
            Console.WriteLine("Girilen derinlige gore Fibonacci Dizisi :");
            foreach(var item in fibonacciArray)
                Console.Write(item+" ");
            Console.WriteLine();
            Console.WriteLine("Dizinin Ortalamasi :"+AverageFibonacci(fibonacciArray));

        } catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Sayısal olmayan, hata bir veri girisi yapildi...");
        }
    }

    public static double AverageFibonacci(int[] arr)
    {   
        double sum = 0;
        foreach (var item in arr)
            sum += item;
        return sum/arr.Length;
    }

    public static int[] GenerateFibonacci(int depth)
    {
        if(depth <= 0)
        {
            throw new ArgumentException("Sıfır veya negatif derinlikte Fibonacci Dizisi olamaz!");
        }

        int[] fibonacci = new int[depth];

        if(depth >= 1)
            fibonacci[0] = 0;
        if(depth >= 2)
            fibonacci[1] = 1;
        if(depth >= 3)
        {
            for(int i = 2; i < depth; i++)
                fibonacci[i] = fibonacci[i-1] + fibonacci[i-2];
        }

        return fibonacci;
    }
}

