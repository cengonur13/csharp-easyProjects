using System;

public class Calc
{
    public static double AreaCalc(int choice, params double[] edges)
    {
        switch (choice)
        {
            case 1:
                double r = edges[0];
                return Math.PI * r * r;
            case 2:
                double u = (edges[0] + edges[1] + edges[2]) / 2;
                return Math.Sqrt(u * (u-edges[0]) * (u-edges[1]) * (u-edges[2]));
            case 3:
                double edge = edges[0];
                return Math.Pow(edge, 2);
            case 4:
                double x = edges[0];
                double y = edges[1];
                return x * y;
            default: 
                throw new ArgumentException("Geçersiz bir şekil seçimi yapılmıştır");
        }
    }
    
    public static double PerimeterCalc(int choice, params double[] edges)
    {
        switch (choice)
        {
            case 1:
                return 2 * Math.PI * edges[0];
            case 2:
                return (edges[0] + edges[1] + edges[2]);
            case 3:
                return 4 * edges[0];
            case 4:
                return 2 * (edges[0] + edges[1]);
            default: 
                throw new ArgumentException("Geçersiz bir şekil seçimi yapılmıştır");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Lutfen hesaplama yapilacak sekli seciniz ");
        Console.Write("(1)-Daire (2)-Ucgen (3)-Kare (4)-Dikdortgen : ");
        int choice = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Lutfen ilgili seklin kenar uzunluklarini arada , olacak sekilde giriniz :");
        string edgesInput = Console.ReadLine();
        string[] edges = edgesInput.Split(',');
        double[] edgesArr = new double[edges.Length];

        for(int i = 0; i < edges.Length; i++)
        {
            if(!double.TryParse(edges[i], out edgesArr[i]))
            {
                Console.WriteLine("Hatali giris yapilmistir");
                return;
            }
        }

        Console.WriteLine("Lutfen hesaplanacak kismi seciniz (1)-Area (2)-Perimeter ");
        string calcType = Console.ReadLine();
        double result;

        if (calcType == "1")
        {
            result = Calc.AreaCalc(choice, edgesArr);
            Console.WriteLine($"Alan :{result}");
        }
        else if (calcType == "2")
        {
            result = Calc.PerimeterCalc(choice, edgesArr);
            Console.WriteLine($"Cevre :{result}");
        }
        else
            Console.WriteLine("Geçersiz seçim...");


    }
}