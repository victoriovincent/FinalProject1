using System;
public class Soal3
{
    public static void Main(string[] args)
    {
        int i, fact = 1, number;
        Console.Write("Masukkan angka yang ingin difaktorialkan: ");
        number = int.Parse(Console.ReadLine());
        for (i = 1; i <= number; i++)
        {
            fact = fact * i;
        }
        Console.Write("Faktorial dari " + number + " adalah: " + fact);
    }
}