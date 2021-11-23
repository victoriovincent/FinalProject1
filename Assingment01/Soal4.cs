using System;
public class Soal4
{
    public static void Main(string[] args)
    {
        int n, reverse = 0, rem;
        Console.Write("Masukkan angka: ");
        n = int.Parse(Console.ReadLine());
        while (n != 0)
        {
            rem = n % 10;
            reverse = reverse * 10 + rem;
            n /= 10;
        }
        Console.Write("Angka setelah dibalik: " + reverse);
    }
}