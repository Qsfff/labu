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
        private int[] binAdd(int[] a, int[] b)
        {
            int ai = _2v10(a);
            int bi = _2v10(b);
            int ci = ai + bi;
            if ((ci > -129) && (ci < 128)) return _10v2(ci);
            else result.Text = "Add out of range";
            int[] c = { 0 };
            return c;
        }
        private int[] binSub(int[] a, int[] b)
        {
            int ai = _2v10(a);
            int bi = _2v10(b);
            int ci = ai - bi;
            if ((ci > -129) && (ci < 128)) return _10v2(ci);
            else result.Text = "Sub out of range";
            int[] c = { 0 };
            return c;
        }
        private int[] binMul(int[] a, int[] b)
        {
            int ai = _2v10(a);
            int bi = _2v10(b);
            int ci = ai * bi;
            if ((ci > -129) && (ci < 128)) return _10v2(ci);
            else result.Text = "Mul out of range";
            int[] c = { 0 };
            return c;
        }
        private int[] binDiv(int[] a, int[] b)
        {
            int ai = _2v10(a);
            int bi = _2v10(b);
            int ci;
            int[] c = { 0 };
            if (bi != 0) ci = ai / bi;
            else
            {
                result.Text = "Divided to 0";
                return c;
            }
            if ((ci > -129) && (ci < 128)) return _10v2(ci);
            else result.Text = "Div out of range";
            return c;
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
            if (binAdd(geta(), getb()).Length != 1) result.Text = arrtostr(binAdd(geta(), getb()));
        }
        private void Sub_Click(object Sub, EventArgs e)
        {
            if (binSub(geta(), getb()).Length != 1) result.Text = arrtostr(binSub(geta(), getb()));
        }
        private void Mul_Click(object Mul, EventArgs e)
        {
            if (binMul(geta(), getb()).Length != 1) result.Text = arrtostr(binMul(geta(), getb()));
        }
        private void Div_Click(object Div, EventArgs e)
        {
            if (binDiv(geta(), getb()).Length != 1) result.Text = arrtostr(binDiv(geta(), getb()));
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}