using System.IO;

namespace lab1_1
{
    class Program
    {
        static int[] _10v2(sbyte n)
        {
            int[] a = { 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 7; i >= 0; i--)
            {
                a[i] = n & 1;
                n = (sbyte)(n >> 1);
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
            for (int i = -128; i < 128; i++) write.WriteLine(arrtostr(_10v2((sbyte)i)));
            write.Close();
        }
    }
}