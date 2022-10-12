namespace lab4
{
    partial class crypter
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.b1 = new System.Windows.Forms.Button();
            this.length = new System.Windows.Forms.TextBox();
            this.ds = new System.Windows.Forms.TextBox();
            this.de = new System.Windows.Forms.TextBox();
            this.re = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.inpath = new System.Windows.Forms.TextBox();
            this.outpath = new System.Windows.Forms.TextBox();
            this.b2 = new System.Windows.Forms.Button();
            this.b3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.inb = new System.Windows.Forms.Button();
            this.indir = new System.Windows.Forms.OpenFileDialog();
            this.outb = new System.Windows.Forms.Button();
            this.outdir = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // b1
            // 
            this.b1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b1.Location = new System.Drawing.Point(577, 12);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(166, 47);
            this.b1.TabIndex = 7;
            this.b1.Text = "Generate password";
            this.b1.UseVisualStyleBackColor = true;
            // 
            // length
            // 
            this.length.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.length.Location = new System.Drawing.Point(489, 23);
            this.length.Name = "length";
            this.length.Size = new System.Drawing.Size(71, 24);
            this.length.TabIndex = 12;
            // 
            // ds
            // 
            this.ds.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ds.Location = new System.Drawing.Point(67, 23);
            this.ds.Name = "ds";
            this.ds.Size = new System.Drawing.Size(119, 24);
            this.ds.TabIndex = 13;
            // 
            // de
            // 
            this.de.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.de.Location = new System.Drawing.Point(236, 23);
            this.de.Name = "de";
            this.de.Size = new System.Drawing.Size(119, 24);
            this.de.TabIndex = 14;
            // 
            // re
            // 
            this.re.AutoSize = true;
            this.re.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.re.Location = new System.Drawing.Point(46, 70);
            this.re.Name = "re";
            this.re.Size = new System.Drawing.Size(58, 18);
            this.re.TabIndex = 15;
            this.re.Text = "Result: ";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(110, 71);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(469, 20);
            this.password.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(21, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 18);
            this.label1.TabIndex = 17;
            this.label1.Text = "Input file path:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(21, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 18);
            this.label2.TabIndex = 18;
            this.label2.Text = "Output path:";
            // 
            // inpath
            // 
            this.inpath.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inpath.Location = new System.Drawing.Point(164, 134);
            this.inpath.Name = "inpath";
            this.inpath.Size = new System.Drawing.Size(415, 24);
            this.inpath.TabIndex = 19;
            // 
            // outpath
            // 
            this.outpath.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.outpath.Location = new System.Drawing.Point(164, 191);
            this.outpath.Name = "outpath";
            this.outpath.Size = new System.Drawing.Size(415, 24);
            this.outpath.TabIndex = 20;
            // 
            // b2
            // 
            this.b2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b2.Location = new System.Drawing.Point(691, 134);
            this.b2.Name = "b2";
            this.b2.Size = new System.Drawing.Size(129, 33);
            this.b2.TabIndex = 21;
            this.b2.Text = "Crypt";
            this.b2.UseVisualStyleBackColor = true;
            // 
            // b3
            // 
            this.b3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b3.Location = new System.Drawing.Point(691, 191);
            this.b3.Name = "b3";
            this.b3.Size = new System.Drawing.Size(129, 33);
            this.b3.TabIndex = 22;
            this.b3.Text = "Decrypt";
            this.b3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(361, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 18);
            this.label3.TabIndex = 23;
            this.label3.Text = "Password length:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(192, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 18);
            this.label4.TabIndex = 24;
            this.label4.Text = "End:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 18);
            this.label5.TabIndex = 25;
            this.label5.Text = "Begin:";
            // 
            // inb
            // 
            this.inb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inb.Location = new System.Drawing.Point(577, 134);
            this.inb.Name = "inb";
            this.inb.Size = new System.Drawing.Size(46, 24);
            this.inb.TabIndex = 26;
            this.inb.Text = "...";
            this.inb.UseVisualStyleBackColor = true;
            // 
            // indir
            // 
            this.indir.DefaultExt = "txt";
            // 
            // outb
            // 
            this.outb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.outb.Location = new System.Drawing.Point(577, 191);
            this.outb.Name = "outb";
            this.outb.Size = new System.Drawing.Size(46, 24);
            this.outb.TabIndex = 27;
            this.outb.Text = "...";
            this.outb.UseVisualStyleBackColor = true;
            // 
            // outdir
            // 
            this.outdir.CheckFileExists = false;
            this.outdir.DefaultExt = "txt";
            // 
            // crypter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 257);
            this.Controls.Add(this.outb);
            this.Controls.Add(this.inb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.b3);
            this.Controls.Add(this.b2);
            this.Controls.Add(this.outpath);
            this.Controls.Add(this.inpath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.password);
            this.Controls.Add(this.re);
            this.Controls.Add(this.de);
            this.Controls.Add(this.ds);
            this.Controls.Add(this.length);
            this.Controls.Add(this.b1);
            this.Name = "crypter";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "crypter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button b1;
        private System.Windows.Forms.TextBox length;
        private System.Windows.Forms.TextBox ds;
        private System.Windows.Forms.TextBox de;
        private System.Windows.Forms.Label re;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inpath;
        private System.Windows.Forms.TextBox outpath;
        private System.Windows.Forms.Button b2;
        private System.Windows.Forms.Button b3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button inb;
        private System.Windows.Forms.OpenFileDialog indir;
        private System.Windows.Forms.Button outb;
        private System.Windows.Forms.OpenFileDialog outdir;
    }
}

