using System;

public class DrawingTriangle
{
    public static void DrawTri(int size)
    {
        for(int i = 0; i < size; i++)
        {
            for (int j = 0; j <= i; j++)
                Console.Write("* ");
            Console.WriteLine();
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Cizilecek ucgenin boyutunu giriniz :");
        try
        {
            int size = Convert.ToInt32(Console.ReadLine());
            DrawingTriangle.DrawTri(size);
        } catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Hatali veri girisi nedeniyle cizim yapilamamistir...");
        }
    }
}