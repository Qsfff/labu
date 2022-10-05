using System;
using System.IO;

namespace lab1_2
{
    class Program
    {
        static sbyte _2v10(int[] a)
        {
            sbyte n = 0;
            for (int i = 7; i >= 0; i--)
            {
                n = (sbyte)(n + (a[i] * Math.Pow(2, (7 - i))));
            }
            return n;
        }
        static int[] strtoarr(string s)
        {
            int[] a = { 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < 8; i++)
            {
                a[i] = int.Parse(char.ToString(s[i]));
            }
            return a;
        }
        static void Main(string[] args)
        {
            StreamReader read = new StreamReader("input.txt");
            StreamWriter write = new StreamWriter("output.txt");
            for (int i = -128; i < 128; i++) write.WriteLine(_2v10(strtoarr(read.ReadLine())));
            read.Close();
            write.Close();
        }
    }
}