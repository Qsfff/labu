using System;
using System.IO;

namespace lab1_4
{
    class Program
    {
        static int _2v10(int[] a)
        {
            int n = 0;
            for (int i = 7; i > 0; i--)
            {
                n = (int)(n + (a[i] * Math.Pow(2, (7 - i))));
            }
            if (a[0] == 1) n = -128 + n;
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
            StreamWriter write = new StreamWriter("output.txt");
            StreamReader read = new StreamReader("input.txt");
            for (int i = -128; i < 128; i++) write.WriteLine(_2v10(strtoarr(read.ReadLine())));
            read.Close();
            write.Close();
        }
    }
}