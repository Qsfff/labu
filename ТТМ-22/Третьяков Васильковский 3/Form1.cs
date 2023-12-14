using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Третьяков_Васильковский_3
{
    public partial class Form1 : Form
    {
        List<string> list = new List<string>();
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }
        private void THE_IMAGE()
        {
            int rand = rnd.Next(0, list.Count);
            FileStream fs = new FileStream(list[rand], FileMode.Open);
            Image img = Image.FromStream(fs);
            Bitmap bitmap = new Bitmap(img);
            Butt1.BackgroundImage = bitmap;
            Butt1.BackgroundImageLayout = ImageLayout.Zoom;
            Butt1.a = list[rand].Remove(0, list[rand].LastIndexOf('\\') + 1);
            Butt1.Text = Butt1.a;
            Butt2.BackgroundImage = bitmap;
            Butt2.BackgroundImageLayout = ImageLayout.Zoom;
            Butt2.a = list[rand].Remove(0, list[rand].LastIndexOf('\\') + 1);
            Butt2.Text = Butt2.a;
            fs.Close();
        }
        private void opnfl_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = "c";
            dlg.DefaultExt = ".png";
            dlg.Filter = "images (.png)|*.png";
            dlg.Multiselect = true;
            if (dlg.ShowDialog() == DialogResult.OK)
                foreach (String file in dlg.FileNames)
                    if (!list.Contains(file))
                    {
                        list.Add(file);
                    }
            THE_IMAGE();
        }
        private void Butt1_Click(object sender, EventArgs e)
        {
            if (list.Count != 0)
            {
                THE_IMAGE();
            }
        }
        private void clr_Click(object sender, EventArgs e)
        {

            list.Clear();
            Butt1.BackgroundImage = null;
            Butt1.Text = "";
            Butt2.BackgroundImage = null;
            Butt2.Text = "";
        }
        private void Butt2_Click(object sender, EventArgs e)
        {
            if (list.Count != 0)
            {
                THE_IMAGE();
            }
        }
    }
    public class HBrect : Button
    {
        public string a;
        public HBrect() : base()
        {
            ForeColor = Color.White;
            Font = new Font("Arial", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FlatAppearance.BorderSize = 0;
            FlatStyle = FlatStyle.Flat;
            base.TextAlign = ContentAlignment.BottomCenter;
            base.ForeColor = Color.White;
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.Text = a;
            a = "";
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            a = base.Text;
            base.Text = "";
        }
    }
    public class HBcirc : HBrect
    {
        public HBcirc() : base()
        {
            ForeColor = Color.White;
            Font = new Font("Arial", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FlatAppearance.BorderSize = 0;
            FlatStyle = FlatStyle.Flat;
            base.TextAlign = ContentAlignment.MiddleCenter;
            base.ForeColor = Color.White;
            SetStyle(ControlStyles.Selectable, false);
            SetStyle(ControlStyles.Selectable, false);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddEllipse(new Rectangle(0, 0, Width - 1, Height - 1));
            Region = new Region(graphicsPath);
        }
    }
}
