namespace RegjistriElektronik
{
    partial class StudentSpace
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.picLogoutstudent = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoutstudent)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkKhaki;
            this.panel1.Location = new System.Drawing.Point(-28, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(857, 39);
            this.panel1.TabIndex = 11;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Olive;
            this.button2.Font = new System.Drawing.Font("Berlin Sans FB Demi", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Honeydew;
            this.button2.Location = new System.Drawing.Point(43, 148);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(300, 92);
            this.button2.TabIndex = 1;
            this.button2.Text = "Check in";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Olive;
            this.button3.Font = new System.Drawing.Font("Berlin Sans FB Demi", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Honeydew;
            this.button3.Location = new System.Drawing.Point(448, 148);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(300, 92);
            this.button3.TabIndex = 2;
            this.button3.Text = "Frekuentim";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Beige;
            this.label1.Font = new System.Drawing.Font("Berlin Sans FB Demi", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(328, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 39);
            this.label1.TabIndex = 10;
            this.label1.Text = "Student";
            // 
            // picLogoutstudent
            // 
            this.picLogoutstudent.BackgroundImage = global::RegjistriElektronik.Properties.Resources._7124045_logout_icon1;
            this.picLogoutstudent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picLogoutstudent.Image = global::RegjistriElektronik.Properties.Resources._7124045_logout_icon;
            this.picLogoutstudent.Location = new System.Drawing.Point(730, 16);
            this.picLogoutstudent.Name = "picLogoutstudent";
            this.picLogoutstudent.Size = new System.Drawing.Size(49, 38);
            this.picLogoutstudent.TabIndex = 12;
            this.picLogoutstudent.TabStop = false;
            this.picLogoutstudent.Click += new System.EventHandler(this.picLogoutstudent_Click);
            // 
            // StudentSpace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(800, 335);
            this.Controls.Add(this.picLogoutstudent);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "StudentSpace";
            this.Text = "StudentSpace";
            ((System.ComponentModel.ISupportInitialize)(this.picLogoutstudent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picLogoutstudent;
    }
}