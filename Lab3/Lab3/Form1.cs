using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class binConverter : Form
    {
        static int[] dual10v2(int n)
        {
            int[] a = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 15; i >= 0; i--)
            {
                a[i] = n & 1;
                n = n >> 1;
            }
            return a;
        }
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
            for (int i = 7; i >= 0; i--)
            {
                n = (int)(n + (a[i] * Math.Pow(2, (7 - i))));
            }
            //if (a[0] == 1) n = -128 + n;
            return n;
        }
        static float mant2v10(int[] a)
        {
            float n = 0;
            for (int i = 23; i >= 0; i--)
            {
                n = (float)(n + (a[i] * Math.Pow(2, -i - 1)));
            }
            return n;
        }
        static float ce2v10(int[] a)
        {
            float n = 0;
            for (int i = 23; i >= 0; i--)
            {
                n = (float)(n + (a[i] * Math.Pow(2, (23-i))));
            }
            return n;
        }
        static int[] manttoarr(string s)
        {
            int[] a = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < 23; i++)
            {
                a[i] = int.Parse(char.ToString(s[i]));
            }
            return a;
        }
        static int[] _10v2(byte n)
        {
            int[] a = { 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 7; i >= 0; i--)
            {
                a[i] = n & 1;
                n = (byte)(n >> 1);
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
        static byte byte2v10(int[] a)
        {
            byte n = 0;
            for (int i = 7; i >= 0; i--)
            {
                n = (byte)(n + (a[i] * Math.Pow(2, (7 - i))));
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
        public binConverter()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            b1.Click += new EventHandler(b1_Click);
            Controls.Add(b1);
            b2.Click += new EventHandler(b2_Click);
            Controls.Add(b2);
            b3.Click += new EventHandler(b3_Click);
            Controls.Add(b3);
            b4.Click += new EventHandler(b4_Click);
            Controls.Add(b4);
        }
        private void b1_Click(object b1, EventArgs e)
        {
            string tmp = "";
            byte[] a = BitConverter.GetBytes(Single.Parse(in1.Text));
            for (int i = 3; i >= 0; i--)
            {
                tmp += arrtostr(_10v2(a[i]));
            }
            res1.Text = "Result: " + tmp.Substring(0, 1) + " " + tmp.Substring(1, 8) + " " + tmp.Substring(9);
        }
        private void b2_Click(object b2, EventArgs e)
        {
            res2.Text = "Result: ";
            int[][] a = new int[4][];
            for (int i = 0; i < 4; i++)
            {
                a[i] = new int[8];
                for (int j = 0; j < 8; j++)
                {
                    a[i][j] = int.Parse(in2.Text.Substring((i * 8) + j, 1));
                }
            }
            byte[] b = new byte[4];
            for (int i = 3; i >= 0; i--)
            {
                b[i] = byte2v10(a[3-i]);
            }
            res2.Text += BitConverter.ToSingle(b, 0);
        }
        private void b3_Click(object b3, EventArgs e)
        {
            res3.Text = "Result: ";
            double d = double.Parse(in3.Text);
            if (d != 0)
            {
                string z = d < 0 ? "1" : "0";
                d = Math.Abs(d);
                string c = arrtostr(dual10v2((int)d));
                while (c.Length != 0 && c[0] == '0')
                {
                    c = c.Remove(0, 1);
                }
                d = Math.Abs(d - (int)d);
                string dr = "";
                for (int i = 0; i < 24; i++)
                {
                    d *= 2;
                    if (d > 1)
                    {
                        dr += "1";
                        d -= 1;
                    }
                    else dr += "0";
                }
                string zapas = "";
                for (int i = 0; i < 24; i++)
                {
                    d *= 2;
                    if (d > 1)
                    {
                        zapas += "1";
                        d -= 1;
                    }
                    else zapas += "0";
                }
                string mant = "";
                int exp = 0;
                if (c != "")
                {
                    c = c.Remove(0, 1);
                    mant = c != "" ? c + dr : dr;
                    exp = c.Length;
                    if (mant.Length > 23) mant = mant.Remove(23);
                }
                else
                {
                    while (dr[0] == '0')
                    {
                        dr = dr.Remove(0, 1);
                        exp -= 1;
                    }
                    dr = dr.Remove(0, 1);
                    exp -= 1;
                    mant = dr + zapas;
                    if (mant.Length > 23) mant = mant.Remove(23);
                }
                string ex = arrtostr(_10v2(exp-129));
                res3.Text += (z + ex + mant).Substring(0, 1) /*+ " "*/ + (z + ex + mant).Substring(1, 8) /*+ " "*/ + (z + ex + mant).Substring(9);
            }
            else res3.Text = "Result: 0 10000000 00000000000000000000000";
        }
        private void b4_Click(object b4, EventArgs e)
        {
            string z = in4.Text.Substring(0, 1);
            string ex = in4.Text.Substring(1, 8);
            string m = in4.Text.Substring(9);
            int exp = _2v10(strtoarr(ex)) - 127;
            string c = "1";
            float ce;
            float d;
            if (exp >= 0)
            {
                for (int i = 0; i < exp; i++)
                {
                    c += m.Substring(0, 1);
                    m = m.Remove(0, 1);
                    m += "0";
                }
                while (m.Length < 24) m += "0";
                while (c.Length < 24) c = "0" + c;
                d = mant2v10(manttoarr(m));
                ce = ce2v10(manttoarr(c));
            }
            else
            {
                m = "1" + m;
                exp += 1;
                c = "";
                d = mant2v10(manttoarr(m)) * (float)Math.Pow(2, exp);
                ce = 0;
            }
            ce += d;
            ce *= (float)Math.Pow(-1, int.Parse(z));
            res4.Text = "Result: " + ce;
        }
    }
}