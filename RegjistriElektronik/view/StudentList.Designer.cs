namespace RegjistriElektronik
{
    partial class StudentList
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewStudents = new System.Windows.Forms.DataGridView();
            this.btnLogoutStudentList = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogoutStudentList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Berlin Sans FB Demi", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(172, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(451, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lista e Studenteve te Regjistruar";
            // 
            // dataGridViewStudents
            // 
            this.dataGridViewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStudents.Location = new System.Drawing.Point(12, 142);
            this.dataGridViewStudents.Name = "dataGridViewStudents";
            this.dataGridViewStudents.RowHeadersWidth = 51;
            this.dataGridViewStudents.RowTemplate.Height = 24;
            this.dataGridViewStudents.Size = new System.Drawing.Size(902, 253);
            this.dataGridViewStudents.TabIndex = 1;
            // 
            // btnLogoutStudentList
            // 
            this.btnLogoutStudentList.BackgroundImage = global::RegjistriElektronik.Properties.Resources._7124045_logout_icon1;
            this.btnLogoutStudentList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogoutStudentList.Image = global::RegjistriElektronik.Properties.Resources._7124045_logout_icon;
            this.btnLogoutStudentList.Location = new System.Drawing.Point(847, 42);
            this.btnLogoutStudentList.Name = "btnLogoutStudentList";
            this.btnLogoutStudentList.Size = new System.Drawing.Size(49, 38);
            this.btnLogoutStudentList.TabIndex = 8;
            this.btnLogoutStudentList.TabStop = false;
            this.btnLogoutStudentList.Click += new System.EventHandler(this.btnLogoutStudentList_Click);
            // 
            // StudentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 450);
            this.Controls.Add(this.btnLogoutStudentList);
            this.Controls.Add(this.dataGridViewStudents);
            this.Controls.Add(this.label1);
            this.Name = "StudentList";
            this.Text = "StudentList";
            this.Load += new System.EventHandler(this.StudentList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogoutStudentList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewStudents;
        private System.Windows.Forms.PictureBox btnLogoutStudentList;
    }
}