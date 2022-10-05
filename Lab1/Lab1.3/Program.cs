using System.IO;

namespace Lab1_3
{
    class Program
    {
        static int[] _10v2(int n)
        {
            int[] a = { 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 7; i >= 0; i--)
            {
                a[i] = n & 1;
                n = n >> 1;
            }
            return a;
        }
        static string arrtostr(int[] a)
        {
            string s = "";
            foreach (int i in a)
            {
                s = s + i;
            }
            return s;
        }
        static void Main(string[] args)
        {
            StreamWriter write = new StreamWriter("output.txt");
            for (int i = -128; i < 128; i++) write.WriteLine(arrtostr(_10v2(i)));
            write.Close();
        }
    }
}