using System;


public class Assign1
{
    public static void Main(string[] args)
    {
        Console.WriteLine("====WELCOME TO ASSIGNMENT 1====");
        Console.WriteLine();

        Console.WriteLine("Nama         : Victorio Vincent Sugianto");
        Console.WriteLine("Kode Peserta : FSDO002ONL006");
        Console.WriteLine("Alamat       : Mojokerto");
        Console.WriteLine();

        Console.WriteLine("Pilih Soal: ");
        Console.WriteLine("1. Segitiga Alfabet");
        Console.WriteLine("2. Segitiga Angka");
        Console.WriteLine("3. Faktorial");
        Console.WriteLine("4. Membalik Angka");
        Console.WriteLine("5. Konversi Angka ke String");

        string ulang = "N";


        do
        {
            Console.Write("Silahkan Masukan Nomor Soal: ");
            int tipe_soal = int.Parse(Console.ReadLine());

            switch (tipe_soal)
            {
                case 1:
                    {
                        Console.WriteLine();
                        Console.WriteLine("Anda memilih : 1. Segitiga Alfabet");

                        char ch = 'A';
                        int i, j, k, m;
                        for (i = 1; i <= 5; i++)
                        {
                            for (j = 5; j >= i; j--)
                                Console.Write(" ");
                            for (k = 1; k <= i; k++)
                                Console.Write(ch++);
                            ch--;
                            for (m = 1; m < i; m++)
                                Console.Write(--ch);
                            Console.Write("\n");
                            ch = 'A';
                        }
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine();
                        Console.WriteLine("Anda memilih : 2. Segitiga Angka");

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
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine();
                        Console.WriteLine("Anda memilih : 3. Faktorial");

                        int i, fact = 1, number;
                        Console.Write("Masukkan angka yang ingin difaktorialkan: ");
                        number = int.Parse(Console.ReadLine());
                        for (i = 1; i <= number; i++)
                        {
                            fact = fact * i;
                        }
                        Console.Write("Faktorial dari " + number + " adalah: " + fact);
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine();
                        Console.WriteLine("Anda memilih : 4. Membalik Angka");

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
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine();
                        Console.WriteLine("Anda memilih : 5. Konversi Angka ke String");

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
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Angka tidak valid");
                        break;
                    }
            }

            Console.WriteLine();
            Console.Write("Ingin mencoba lagi? (Y/N) : ");
            ulang = Console.ReadLine();

        }
        while (ulang == "Y");

        if (ulang == "N")
        {
            Console.WriteLine("Terimakasih telah mencoba! :)");
        }

    }
}