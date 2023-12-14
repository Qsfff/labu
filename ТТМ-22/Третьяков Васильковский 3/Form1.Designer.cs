namespace Третьяков_Васильковский_3
{
    partial class Form1
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
            this.Butt1 = new Третьяков_Васильковский_3.HBrect();
            this.opnfl = new System.Windows.Forms.Button();
            this.clr = new System.Windows.Forms.Button();
            this.Butt2 = new Третьяков_Васильковский_3.HBcirc();
            this.SuspendLayout();
            // 
            // Butt1
            // 
            this.Butt1.Cursor = System.Windows.Forms.Cursors.No;
            this.Butt1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Butt1.FlatAppearance.BorderSize = 0;
            this.Butt1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Butt1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Butt1.ForeColor = System.Drawing.Color.Transparent;
            this.Butt1.Location = new System.Drawing.Point(7, 55);
            this.Butt1.Name = "Butt1";
            this.Butt1.Size = new System.Drawing.Size(643, 713);
            this.Butt1.TabIndex = 0;
            this.Butt1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Butt1.UseVisualStyleBackColor = true;
            this.Butt1.Click += new System.EventHandler(this.Butt1_Click);
            // 
            // opnfl
            // 
            this.opnfl.Location = new System.Drawing.Point(273, 12);
            this.opnfl.Name = "opnfl";
            this.opnfl.Size = new System.Drawing.Size(213, 37);
            this.opnfl.TabIndex = 1;
            this.opnfl.Text = "choose images";
            this.opnfl.UseVisualStyleBackColor = true;
            this.opnfl.Click += new System.EventHandler(this.opnfl_Click);
            // 
            // clr
            // 
            this.clr.Location = new System.Drawing.Point(505, 12);
            this.clr.Name = "clr";
            this.clr.Size = new System.Drawing.Size(213, 37);
            this.clr.TabIndex = 2;
            this.clr.Text = "remove images";
            this.clr.UseMnemonic = false;
            this.clr.UseVisualStyleBackColor = true;
            this.clr.Click += new System.EventHandler(this.clr_Click);
            // 
            // Butt2
            // 
            this.Butt2.FlatAppearance.BorderSize = 0;
            this.Butt2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Butt2.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Butt2.ForeColor = System.Drawing.Color.White;
            this.Butt2.Location = new System.Drawing.Point(656, 55);
            this.Butt2.Name = "Butt2";
            this.Butt2.Size = new System.Drawing.Size(617, 729);
            this.Butt2.TabIndex = 3;
            this.Butt2.Text = "hBcirc1";
            this.Butt2.UseVisualStyleBackColor = true;
            this.Butt2.Click += new System.EventHandler(this.Butt2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 793);
            this.Controls.Add(this.Butt2);
            this.Controls.Add(this.clr);
            this.Controls.Add(this.opnfl);
            this.Controls.Add(this.Butt1);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private HBrect Butt1;
        private System.Windows.Forms.Button opnfl;
        private System.Windows.Forms.Button clr;
        private HBcirc Butt2;
    }
}

