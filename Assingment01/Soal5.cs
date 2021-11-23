using System;
public class Soal5
{
    public static void Main(string[] args)
    {
        int n, sum = 0, r;
        Console.Write("Masukkan angka: ");
        n = int.Parse(Console.ReadLine());
        while (n > 0)
        {
            r = n % 10;
            sum = sum * 10 + r;
            n = n / 10;
        }
        n = sum;
        while (n > 0)
        {
            r = n % 10;
            switch (r)
            {
                case 1:
                    Console.Write("satu ");
                    break;
                case 2:
                    Console.Write("dua ");
                    break;
                case 3:
                    Console.Write("tiga ");
                    break;
                case 4:
                    Console.Write("empat ");
                    break;
                case 5:
                    Console.Write("lima ");
                    break;
                case 6:
                    Console.Write("enam ");
                    break;
                case 7:
                    Console.Write("tujuh ");
                    break;
                case 8:
                    Console.Write("delapan ");
                    break;
                case 9:
                    Console.Write("sembilan ");
                    break;
                case 0:
                    Console.Write("nol ");
                    break;
                default:
                    Console.Write("tttt ");
                    break;
            } 
            n = n / 10;
        }  
    }
}