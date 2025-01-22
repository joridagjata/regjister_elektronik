namespace RegjistriElektronik
{
    partial class LessonPlanAdmin
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
            this.dataGridViewPlaniMesimor = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtVitiAkademik = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtLenda = new System.Windows.Forms.TextBox();
            this.txtDepartamenti = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDepcode = new System.Windows.Forms.TextBox();
            this.btnBackToAdmin = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlaniMesimor)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBackToAdmin)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPlaniMesimor
            // 
            this.dataGridViewPlaniMesimor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPlaniMesimor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPlaniMesimor.Location = new System.Drawing.Point(12, 435);
            this.dataGridViewPlaniMesimor.Name = "dataGridViewPlaniMesimor";
            this.dataGridViewPlaniMesimor.ReadOnly = true;
            this.dataGridViewPlaniMesimor.RowHeadersWidth = 51;
            this.dataGridViewPlaniMesimor.RowTemplate.Height = 24;
            this.dataGridViewPlaniMesimor.Size = new System.Drawing.Size(964, 158);
            this.dataGridViewPlaniMesimor.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDepcode);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtVitiAkademik);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.txtLenda);
            this.groupBox1.Controls.Add(this.txtDepartamenti);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.groupBox1.Location = new System.Drawing.Point(14, 137);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(962, 292);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Plani Mesimor";
            // 
            // txtVitiAkademik
            // 
            this.txtVitiAkademik.Location = new System.Drawing.Point(161, 122);
            this.txtVitiAkademik.Name = "txtVitiAkademik";
            this.txtVitiAkademik.Size = new System.Drawing.Size(310, 22);
            this.txtVitiAkademik.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(21, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Viti Akademik";
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Berlin Sans FB Demi", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnDelete.Location = new System.Drawing.Point(584, 240);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(98, 37);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Berlin Sans FB Demi", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnUpdate.Location = new System.Drawing.Point(408, 240);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(92, 37);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Berlin Sans FB Demi", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnAdd.Location = new System.Drawing.Point(223, 240);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 37);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtLenda
            // 
            this.txtLenda.Location = new System.Drawing.Point(128, 83);
            this.txtLenda.Name = "txtLenda";
            this.txtLenda.Size = new System.Drawing.Size(343, 22);
            this.txtLenda.TabIndex = 7;
            // 
            // txtDepartamenti
            // 
            this.txtDepartamenti.Location = new System.Drawing.Point(181, 37);
            this.txtDepartamenti.Name = "txtDepartamenti";
            this.txtDepartamenti.Size = new System.Drawing.Size(290, 22);
            this.txtDepartamenti.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Lenda";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Departamenti";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Font = new System.Drawing.Font("Berlin Sans FB Demi", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(267, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(429, 38);
            this.label1.TabIndex = 19;
            this.label1.Text = "Menaxhimi i Planit Mesimor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Departament Code";
            // 
            // txtDepcode
            // 
            this.txtDepcode.Location = new System.Drawing.Point(212, 161);
            this.txtDepcode.Name = "txtDepcode";
            this.txtDepcode.Size = new System.Drawing.Size(263, 22);
            this.txtDepcode.TabIndex = 19;
            // 
            // btnBackToAdmin
            // 
            this.btnBackToAdmin.BackgroundImage = global::RegjistriElektronik.Properties.Resources._7124045_logout_icon1;
            this.btnBackToAdmin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBackToAdmin.Image = global::RegjistriElektronik.Properties.Resources._7124045_logout_icon;
            this.btnBackToAdmin.Location = new System.Drawing.Point(889, 32);
            this.btnBackToAdmin.Name = "btnBackToAdmin";
            this.btnBackToAdmin.Size = new System.Drawing.Size(49, 38);
            this.btnBackToAdmin.TabIndex = 5;
            this.btnBackToAdmin.TabStop = false;
            this.btnBackToAdmin.Click += new System.EventHandler(this.btnBackToAdmin_Click);
            // 
            // LessonPlanAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 596);
            this.Controls.Add(this.dataGridViewPlaniMesimor);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBackToAdmin);
            this.Name = "LessonPlanAdmin";
            this.Text = "LessonPlanAdmin";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlaniMesimor)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBackToAdmin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox btnBackToAdmin;
        private System.Windows.Forms.DataGridView dataGridViewPlaniMesimor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtVitiAkademik;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtLenda;
        private System.Windows.Forms.TextBox txtDepartamenti;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDepcode;
        private System.Windows.Forms.Label label5;
    }
}