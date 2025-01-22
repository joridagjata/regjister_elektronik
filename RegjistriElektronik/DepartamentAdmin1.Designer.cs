namespace RegjistriElektronik
{
    partial class DepartamentAdmin
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
            this.buttonToggleDepartment = new System.Windows.Forms.Button();
            this.picBackToAdmin = new System.Windows.Forms.PictureBox();
            this.dataGridViewDepartments = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.picBackToAdmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDepartments)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Berlin Sans FB Demi", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(446, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "MENAXHIMI I DEPARTAMENTEVE";
            // 
            // buttonToggleDepartment
            // 
            this.buttonToggleDepartment.BackColor = System.Drawing.Color.Peru;
            this.buttonToggleDepartment.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonToggleDepartment.ForeColor = System.Drawing.Color.PapayaWhip;
            this.buttonToggleDepartment.Location = new System.Drawing.Point(526, 366);
            this.buttonToggleDepartment.Name = "buttonToggleDepartment";
            this.buttonToggleDepartment.Size = new System.Drawing.Size(221, 46);
            this.buttonToggleDepartment.TabIndex = 2;
            this.buttonToggleDepartment.Text = "NDRYSHO STATUS";
            this.buttonToggleDepartment.UseVisualStyleBackColor = false;
            this.buttonToggleDepartment.Click += new System.EventHandler(this.buttonToggleDepartment_Click_1);
            // 
            // picBackToAdmin
            // 
            this.picBackToAdmin.BackgroundImage = global::RegjistriElektronik.Properties.Resources._7124045_logout_icon1;
            this.picBackToAdmin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBackToAdmin.Image = global::RegjistriElektronik.Properties.Resources._7124045_logout_icon;
            this.picBackToAdmin.Location = new System.Drawing.Point(724, 24);
            this.picBackToAdmin.Name = "picBackToAdmin";
            this.picBackToAdmin.Size = new System.Drawing.Size(47, 34);
            this.picBackToAdmin.TabIndex = 10;
            this.picBackToAdmin.TabStop = false;
            this.picBackToAdmin.Click += new System.EventHandler(this.picBackToAdmin_Click);
            // 
            // dataGridViewDepartments
            // 
            this.dataGridViewDepartments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDepartments.Location = new System.Drawing.Point(18, 96);
            this.dataGridViewDepartments.Name = "dataGridViewDepartments";
            this.dataGridViewDepartments.RowHeadersWidth = 51;
            this.dataGridViewDepartments.RowTemplate.Height = 24;
            this.dataGridViewDepartments.Size = new System.Drawing.Size(440, 316);
            this.dataGridViewDepartments.TabIndex = 11;
            // 
            // DepartamentAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewDepartments);
            this.Controls.Add(this.picBackToAdmin);
            this.Controls.Add(this.buttonToggleDepartment);
            this.Controls.Add(this.label1);
            this.Name = "DepartamentAdmin";
            this.Text = "Departamenti";
            ((System.ComponentModel.ISupportInitialize)(this.picBackToAdmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDepartments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonToggleDepartment;
        private System.Windows.Forms.PictureBox picBackToAdmin;
        private System.Windows.Forms.DataGridView dataGridViewDepartments;
    }
}