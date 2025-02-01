namespace RegjistriElektronik
{
    partial class MenaxhoOrarMesimor
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
            this.btnMbyll = new System.Windows.Forms.Button();
            this.btnHap = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.picLogoutMenaxhoOrarinMesimor = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxOraret = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoutMenaxhoOrarinMesimor)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMbyll
            // 
            this.btnMbyll.BackColor = System.Drawing.Color.Olive;
            this.btnMbyll.Font = new System.Drawing.Font("Berlin Sans FB Demi", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMbyll.ForeColor = System.Drawing.Color.Honeydew;
            this.btnMbyll.Location = new System.Drawing.Point(488, 357);
            this.btnMbyll.Name = "btnMbyll";
            this.btnMbyll.Size = new System.Drawing.Size(220, 65);
            this.btnMbyll.TabIndex = 14;
            this.btnMbyll.Text = "Mbyll";
            this.btnMbyll.UseVisualStyleBackColor = false;
            this.btnMbyll.Click += new System.EventHandler(this.btnMbyll_Click);
            // 
            // btnHap
            // 
            this.btnHap.BackColor = System.Drawing.Color.Olive;
            this.btnHap.Font = new System.Drawing.Font("Berlin Sans FB Demi", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHap.ForeColor = System.Drawing.Color.Honeydew;
            this.btnHap.Location = new System.Drawing.Point(80, 357);
            this.btnHap.Name = "btnHap";
            this.btnHap.Size = new System.Drawing.Size(229, 65);
            this.btnHap.TabIndex = 13;
            this.btnHap.Text = "Hap";
            this.btnHap.UseVisualStyleBackColor = false;
            this.btnHap.Click += new System.EventHandler(this.btnHap_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkKhaki;
            this.panel1.Location = new System.Drawing.Point(-2, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(803, 39);
            this.panel1.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Beige;
            this.label1.Font = new System.Drawing.Font("Berlin Sans FB Demi", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(220, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 38);
            this.label1.TabIndex = 15;
            this.label1.Text = "Menaxho Orar Mesimor";
            // 
            // picLogoutMenaxhoOrarinMesimor
            // 
            this.picLogoutMenaxhoOrarinMesimor.BackgroundImage = global::RegjistriElektronik.Properties.Resources._7124045_logout_icon1;
            this.picLogoutMenaxhoOrarinMesimor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picLogoutMenaxhoOrarinMesimor.Image = global::RegjistriElektronik.Properties.Resources._7124045_logout_icon;
            this.picLogoutMenaxhoOrarinMesimor.Location = new System.Drawing.Point(745, 19);
            this.picLogoutMenaxhoOrarinMesimor.Name = "picLogoutMenaxhoOrarinMesimor";
            this.picLogoutMenaxhoOrarinMesimor.Size = new System.Drawing.Size(43, 38);
            this.picLogoutMenaxhoOrarinMesimor.TabIndex = 17;
            this.picLogoutMenaxhoOrarinMesimor.TabStop = false;
            this.picLogoutMenaxhoOrarinMesimor.Click += new System.EventHandler(this.picLogoutMenaxhoOrarinMesimor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(304, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 20);
            this.label2.TabIndex = 59;
            this.label2.Text = "Zgjidh Orar Mesimor";
            // 
            // comboBoxOraret
            // 
            this.comboBoxOraret.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxOraret.FormattingEnabled = true;
            this.comboBoxOraret.Location = new System.Drawing.Point(158, 224);
            this.comboBoxOraret.Name = "comboBoxOraret";
            this.comboBoxOraret.Size = new System.Drawing.Size(467, 37);
            this.comboBoxOraret.TabIndex = 58;
            this.comboBoxOraret.SelectedIndexChanged += new System.EventHandler(this.comboBoxOraret_SelectedIndexChanged);
            // 
            // MenaxhoOrarMesimor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxOraret);
            this.Controls.Add(this.picLogoutMenaxhoOrarinMesimor);
            this.Controls.Add(this.btnMbyll);
            this.Controls.Add(this.btnHap);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "MenaxhoOrarMesimor";
            this.Text = "MenaxhoOrarMesimor";
            ((System.ComponentModel.ISupportInitialize)(this.picLogoutMenaxhoOrarinMesimor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picLogoutMenaxhoOrarinMesimor;
        private System.Windows.Forms.Button btnMbyll;
        private System.Windows.Forms.Button btnHap;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxOraret;
    }
}