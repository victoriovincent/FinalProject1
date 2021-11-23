using System;

public class string3
    {
        static void Main()
        {
            string[] str = { "Ini", "adalah", "sebuah", "test." };
            System.Console.WriteLine("Array asli: ");

            for (int i = 0; i < str.Length; i++)
                Console.Write(str[i] + " ");
            System.Console.WriteLine();

            System.Console.WriteLine("\n");

            str[1] = "merupakan";
            str[3] = "test, juga!";

            Console.WriteLine("Array termodifikasi: ");
            for (int i = 0; i < str.Length; i++)
                Console.Write(str[i] + " ");
        }
    }