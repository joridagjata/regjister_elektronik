namespace RegjistriElektronik
{
    partial class CheckinStudent
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
            this.picLogoutCheckinStudent = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoutCheckinStudent)).BeginInit();
            this.SuspendLayout();
            // 
            // picLogoutCheckinStudent
            // 
            this.picLogoutCheckinStudent.BackgroundImage = global::RegjistriElektronik.Properties.Resources._7124045_logout_icon1;
            this.picLogoutCheckinStudent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picLogoutCheckinStudent.Image = global::RegjistriElektronik.Properties.Resources._7124045_logout_icon;
            this.picLogoutCheckinStudent.Location = new System.Drawing.Point(724, 25);
            this.picLogoutCheckinStudent.Name = "picLogoutCheckinStudent";
            this.picLogoutCheckinStudent.Size = new System.Drawing.Size(43, 38);
            this.picLogoutCheckinStudent.TabIndex = 18;
            this.picLogoutCheckinStudent.TabStop = false;
            this.picLogoutCheckinStudent.Click += new System.EventHandler(this.picLogoutCheckinStudent_Click);
            // 
            // CheckinStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.picLogoutCheckinStudent);
            this.Name = "CheckinStudent";
            this.Text = "CheckinStudent";
            ((System.ComponentModel.ISupportInitialize)(this.picLogoutCheckinStudent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picLogoutCheckinStudent;
    }
}