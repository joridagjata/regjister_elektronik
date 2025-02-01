namespace RegjistriElektronik
{
    partial class SaktesoList
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
            this.btnSakteso = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.picLogoutSaktesoList = new System.Windows.Forms.PictureBox();
            this.dataGridViewListPrezenca = new System.Windows.Forms.DataGridView();
            this.txtStudentUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.comboBoxOraret = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoutSaktesoList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListPrezenca)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSakteso
            // 
            this.btnSakteso.BackColor = System.Drawing.Color.Olive;
            this.btnSakteso.Font = new System.Drawing.Font("Berlin Sans FB Demi", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSakteso.ForeColor = System.Drawing.Color.Honeydew;
            this.btnSakteso.Location = new System.Drawing.Point(346, 205);
            this.btnSakteso.Name = "btnSakteso";
            this.btnSakteso.Size = new System.Drawing.Size(139, 41);
            this.btnSakteso.TabIndex = 33;
            this.btnSakteso.Text = "Sakteso";
            this.btnSakteso.UseVisualStyleBackColor = false;
            this.btnSakteso.Click += new System.EventHandler(this.btnSakteso_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Beige;
            this.label1.Font = new System.Drawing.Font("Berlin Sans FB Demi", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(377, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(347, 38);
            this.label1.TabIndex = 35;
            this.label1.Text = "Sakteso List Prezencen";
            // 
            // picLogoutSaktesoList
            // 
            this.picLogoutSaktesoList.BackgroundImage = global::RegjistriElektronik.Properties.Resources._7124045_logout_icon1;
            this.picLogoutSaktesoList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picLogoutSaktesoList.Image = global::RegjistriElektronik.Properties.Resources._7124045_logout_icon;
            this.picLogoutSaktesoList.Location = new System.Drawing.Point(1016, 12);
            this.picLogoutSaktesoList.Name = "picLogoutSaktesoList";
            this.picLogoutSaktesoList.Size = new System.Drawing.Size(43, 38);
            this.picLogoutSaktesoList.TabIndex = 37;
            this.picLogoutSaktesoList.TabStop = false;
            this.picLogoutSaktesoList.Click += new System.EventHandler(this.picLogoutSaktesoList_Click);
            // 
            // dataGridViewListPrezenca
            // 
            this.dataGridViewListPrezenca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListPrezenca.Location = new System.Drawing.Point(32, 281);
            this.dataGridViewListPrezenca.Name = "dataGridViewListPrezenca";
            this.dataGridViewListPrezenca.RowHeadersWidth = 51;
            this.dataGridViewListPrezenca.RowTemplate.Height = 24;
            this.dataGridViewListPrezenca.Size = new System.Drawing.Size(1047, 209);
            this.dataGridViewListPrezenca.TabIndex = 51;
            // 
            // txtStudentUsername
            // 
            this.txtStudentUsername.Location = new System.Drawing.Point(676, 136);
            this.txtStudentUsername.Name = "txtStudentUsername";
            this.txtStudentUsername.Size = new System.Drawing.Size(330, 22);
            this.txtStudentUsername.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(475, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 53;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(753, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(164, 20);
            this.label9.TabIndex = 54;
            this.label9.Text = "Student Username";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Olive;
            this.btnUpdate.Font = new System.Drawing.Font("Berlin Sans FB Demi", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.Honeydew;
            this.btnUpdate.Location = new System.Drawing.Point(585, 205);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(139, 41);
            this.btnUpdate.TabIndex = 55;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // comboBoxOraret
            // 
            this.comboBoxOraret.FormattingEnabled = true;
            this.comboBoxOraret.Location = new System.Drawing.Point(115, 134);
            this.comboBoxOraret.Name = "comboBoxOraret";
            this.comboBoxOraret.Size = new System.Drawing.Size(327, 24);
            this.comboBoxOraret.TabIndex = 56;
            this.comboBoxOraret.SelectedIndexChanged += new System.EventHandler(this.comboBoxOraret_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(171, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 20);
            this.label3.TabIndex = 57;
            this.label3.Text = "Zgjidh Orar Mesimor";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // SaktesoList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 502);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxOraret);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtStudentUsername);
            this.Controls.Add(this.dataGridViewListPrezenca);
            this.Controls.Add(this.picLogoutSaktesoList);
            this.Controls.Add(this.btnSakteso);
            this.Controls.Add(this.label1);
            this.Name = "SaktesoList";
            this.Text = "SaktesoList";
            this.Load += new System.EventHandler(this.SaktesoList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogoutSaktesoList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListPrezenca)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picLogoutSaktesoList;
        private System.Windows.Forms.Button btnSakteso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewListPrezenca;
        private System.Windows.Forms.TextBox txtStudentUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox comboBoxOraret;
        private System.Windows.Forms.Label label3;
    }
}