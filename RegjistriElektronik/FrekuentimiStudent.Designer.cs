namespace RegjistriElektronik
{
    partial class FrekuentimiStudent
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
            this.picLogoutFrekuentim = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoutFrekuentim)).BeginInit();
            this.SuspendLayout();
            // 
            // picLogoutFrekuentim
            // 
            this.picLogoutFrekuentim.BackgroundImage = global::RegjistriElektronik.Properties.Resources._7124045_logout_icon1;
            this.picLogoutFrekuentim.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picLogoutFrekuentim.Image = global::RegjistriElektronik.Properties.Resources._7124045_logout_icon;
            this.picLogoutFrekuentim.Location = new System.Drawing.Point(724, 32);
            this.picLogoutFrekuentim.Name = "picLogoutFrekuentim";
            this.picLogoutFrekuentim.Size = new System.Drawing.Size(43, 38);
            this.picLogoutFrekuentim.TabIndex = 19;
            this.picLogoutFrekuentim.TabStop = false;
            this.picLogoutFrekuentim.Click += new System.EventHandler(this.picLogoutFrekuentim_Click);
            // 
            // FrekuentimiStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.picLogoutFrekuentim);
            this.Name = "FrekuentimiStudent";
            this.Text = "FrekuentimiStudent";
            ((System.ComponentModel.ISupportInitialize)(this.picLogoutFrekuentim)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picLogoutFrekuentim;
    }
}