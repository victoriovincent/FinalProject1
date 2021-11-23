using System;
public class Soal2
{
    public static void Main(string[] args)
    {
        int range = 0;
        int i, j;

        Console.Write("Masukkan angka: ");
        range = int.Parse(Console.ReadLine());

        for (i = 1; i <= range; i++)
        {
            for (j = 1; j <= range - i; j++)
            {
                Console.Write(" ");
            }
            for (j = 1; j <= i; j++)
            {
                Console.Write("{0}", j);
            }
            for (j = i - 1; j >= 1; j--)
            {
                Console.Write("{0}", j);
            }

            Console.WriteLine();
        }
    }
}