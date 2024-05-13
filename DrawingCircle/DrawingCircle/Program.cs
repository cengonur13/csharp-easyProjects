using System;

public class DrawingCircle
{
    public static void DrawCircle(int r)
    {
        for (int i = -r; i <= r; i++)
        {
            for(int j = -r; j <= r; j++)
            {
                if (Math.Sqrt(j * j + i * i) <= r)
                    Console.Write("* ");
                else
                    Console.Write("  ");
            }
            Console.WriteLine();
        }
    } 
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Lutfen cizim yapilacak dairenin yaricapini giriniz :");
        try
        {
            int r = Convert.ToInt32(Console.ReadLine());
            DrawingCircle.DrawCircle(r);

        }catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Hatali bir giris yaptiniz...");
        }
    }
}