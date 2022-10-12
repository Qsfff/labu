using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab4
{
    public partial class crypter : Form
    {
        private char crypt(char s, char code)
        {
            int a = (int)s;
            int b = (int)code;
            s = (char)(a+b);
            return s;
        }
        private char decrypt(char s, char code)
        {
            int a = (int)s;
            int b = (int)code;
            s = (char)(a - b);
            return s;
        }
        public crypter()
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
            inb.Click += new EventHandler(inb_Click);
            Controls.Add(inb);
            outb.Click += new EventHandler(outb_Click);
            Controls.Add(outb);
        }
        private void b1_Click(object b1, EventArgs e)
        {
            password.Text = "";
            Random rnd = new Random();
            for (int i = 0; i < int.Parse(length.Text); i++)
            {
                int a = int.Parse(ds.Text, System.Globalization.NumberStyles.HexNumber);
                int b = int.Parse(de.Text, System.Globalization.NumberStyles.HexNumber);
                password.Text += char.ConvertFromUtf32(rnd.Next(a, b)).ToString();
            }
        }
        private void inb_Click(object inb, EventArgs e)
        {
            if (indir.ShowDialog() == DialogResult.OK)
            {
                inpath.Text = indir.FileName;
            }
        }
        private void outb_Click(object outb, EventArgs e)
        {
            if (outdir.ShowDialog() == DialogResult.OK)
            {
                outpath.Text = outdir.FileName;
            }
        }
        private void b2_Click(object b2, EventArgs e)
        {
            FileStream file = File.OpenRead(inpath.Text);
            byte[] array = new byte[file.Length]; 
            file.Read(array, 0, array.Length); 
            string s = System.Text.Encoding.UTF8.GetString(array);
            string o = "";
            string pass = password.Text;
            int f = o.Length;
            int len = s.Length / pass.Length + ((s.Length % pass.Length) > 0 ? 1 : 0);
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; (((i+1) != len) && (j < pass.Length)) || ((j < s.Length % pass.Length) && (s.Length % pass.Length != 0)) || (((j < pass.Length)) && (s.Length % pass.Length == 0)); j++)
                {
                    o += crypt(s[i*pass.Length+j], pass[j]);
                }
                string code = "";
                for (int j = 0; j < pass.Length; j++)
                {
                    code += crypt('\u0001', pass[j]);
                }
                pass = code;
            }
            FileStream crypted = new FileStream(outpath.Text, FileMode.OpenOrCreate);
            byte[] array2 = System.Text.Encoding.UTF8.GetBytes(o); 
            crypted.Write(array2, 0, array2.Length); 
            file.Close();
            crypted.Close();
        }
        private void b3_Click(object b3, EventArgs e)
        {
            FileStream file = File.OpenRead(inpath.Text);
            byte[] array = new byte[file.Length];
            file.Read(array, 0, array.Length);
            string s = System.Text.Encoding.UTF8.GetString(array);
            string o = "";
            string pass = password.Text;
            int len = s.Length / pass.Length + ((s.Length % pass.Length) > 0 ? 1 : 0);
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; (((i + 1) != len) && (j < pass.Length)) || ((j < s.Length % pass.Length) && (s.Length % pass.Length != 0)) || (((j < pass.Length)) && (s.Length % pass.Length == 0)); j++)
                {
                    o += decrypt(s[i * pass.Length + j], pass[j]);
                }
                string code = "";
                for (int j = 0; j < pass.Length; j++)
                {
                    code += crypt('\u0001', pass[j]);
                }
                pass = code;
            }
            StreamWriter decrypted = new StreamWriter(outpath.Text);
            decrypted.Write(o); 
            file.Close();
            decrypted.Close();
        }
    }
}