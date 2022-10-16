using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_1
{
    public partial class binCalc : Form
    {
        private bool eqal(string sc, string sb)
        {
            bool c = true;
            for (int i = 1; i < sc.Length; i++)
            {
                if (sc[i] < sb[i]) { c = false; }
            }
            return c;
        }
        private int[] reverse(int[] b)
        {
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] == 0) b[i] = 1;
                else b[i] = 0;
            }
            int k = 1;
            for (int i = b.Length - 1; i >= 0; i--)
            {
                b[i] = b[i] + k;
                k = 0;
                if (b[i] > 1) { k = 1; b[i] -= 2; }
            }
            return b;
        }
        private int[] binAdd(int[] a, int[] b)
        {
            int k = 0;
            int[] c = new int[a.Length];
            for (int i = a.Length - 1; i >= 0; i--)
            {
                c[i] = a[i] + b[i] + k;
                k = 0;
                if (c[i] > 1) { k = 1; c[i] -= 2; }
            }
            return c;
            
        }
        private int[] binMul(int[] a, int[] b)
        {
            int[][] c = new int[8][];
            for (int i = 0; i < 8; i++)
            {
                c[i] = new int[16];
                for (int j = 0; j < 15; j++)
                {
                    c[i][j] = 0;
                }
            }
            int z = (a[0] == b[0]) ? 0 : 1;
            if (a[0] == 1) a = reverse(a);
            if (b[0] == 1) b = reverse(b);
            for (int i = 1; i < 8; i++)
            {
                for (int j = 1; j < 8; j++)
                {
                    c[i][1 + j + i] = a[i] * b[j];
                }
            }
            for (int i = 0; i < 8; i++)
            {
                c[0] = binAdd(c[0], c[i]);
            }
            if (z == 1) c[0] = reverse(c[0]);
            return c[0];
        }
        private int[] binDiv(int[] a, int[] b)
        {
            if (b[0] == 0 && b[1] == 0 && b[2] == 0 && b[3] == 0 && b[4] == 0 && b[5] == 0 && b[6] == 0 && b[7] == 0)
            {
                result.Text = "Divided by 0";
                int[] c = { 0 };
                return c;
            }
            else if ((b[0] == 1 && b[1] == 1 && b[2] == 1 && b[3] == 1 && b[4] == 1 && b[5] == 1 && b[6] == 1 && b[7] == 1) && (a[0] == 1 && a[1] == 0 && a[2] == 0 && a[3] == 0 && a[4] == 0 && a[5] == 0 && a[6] == 0 && a[7] == 0))
            {
                result.Text = "Impossible in this size";
                int[] c = { 0 };
                return c;
            }
            else
            {
                int z = (a[0] == b[0]) ? 0 : 1;
                if (a[0] == 1) a = reverse(a);
                if (b[0] == 1) b = reverse(b);
                string sa = arrtostr(a);
                string sd = "";
                while (sa.Length != 0 && sa[0] == '0')
                {
                    sa = sa.Remove(0, 1);
                    sd += "0";
                }
                string sb = arrtostr(b);
                while (sb[0] == '0') sb = sb.Remove(0, 1);
                string sc = "";
                if (sa.Length != 0)
                {
                    for (int i = 0; i < sa.Length; i++)
                    {
                        sc += sa.Substring(i, 1);
                        while (sc.Length != 0 && sc[0] == '0')
                        {
                            sc = sc.Remove(0, 1);
                        }
                        if (sc.Length < sb.Length) sd += "0";
                        else if (sc == sb) { sd += "1"; sc = ""; }
                        else if ((sc.Length == sb.Length) && eqal(sc, sb))
                        {
                            sd += "1";
                            sc = arrtostr(binAdd(strtoarr(sc), reverse(strtoarr(sb))));
                        }
                        else if ((sc.Length == sb.Length) && !eqal(sc, sb)) sd += "0";
                        else if (sc.Length > sb.Length) 
                        {
                            sd += "1";
                            sc = arrtostr(binAdd(strtoarr(sc), reverse(strtoarr("0" + sb))));
                        }
                    }
                }
                int[] d = new int[8];
                d = strtoarr(sd);
                if (z == 1) d = reverse(d);
                return d;
            }
        }
        static int[] strtoarr(string s)
        {
            int[] a = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                a[i] = int.Parse(char.ToString(s[i]));
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
        public binCalc()
        {
            InitializeComponent();
        }
        private int[] geta()
        {
            int[] a = {int.Parse(a1.Text), int.Parse(a2.Text), int.Parse(a3.Text), int.Parse(a4.Text), int.Parse(a5.Text), int.Parse(a6.Text), int.Parse(a7.Text), int.Parse(a8.Text)};
            return a;
        }
        private int[] getb()
        {
            int[] b = { int.Parse(b1.Text), int.Parse(b2.Text), int.Parse(b3.Text), int.Parse(b4.Text), int.Parse(b5.Text), int.Parse(b6.Text), int.Parse(b7.Text), int.Parse(b8.Text) };
            return b;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Add.Click += new EventHandler(Add_Click);
            Controls.Add(Add);
            Sub.Click += new EventHandler(Sub_Click);
            Controls.Add(Sub);
            Mul.Click += new EventHandler(Mul_Click);
            Controls.Add(Mul);
            Div.Click += new EventHandler(Div_Click);
            Controls.Add(Div);
        }
        private void Add_Click(object Add, EventArgs e)
        {
            result.Text = arrtostr(binAdd(geta(), getb()));
        }
        private void Sub_Click(object Sub, EventArgs e)
        {
            
            result.Text = arrtostr(binAdd(geta(), reverse(getb())));
        }
        private void Mul_Click(object Mul, EventArgs e)
        {
            result.Text = arrtostr(binMul(geta(), getb()));
        }
        private void Div_Click(object Div, EventArgs e)
        {
            if (binDiv(geta(), getb()).Length != 1) result.Text = arrtostr(binDiv(geta(), getb()));
        }
    }
}