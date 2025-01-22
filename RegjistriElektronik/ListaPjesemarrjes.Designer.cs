namespace RegjistriElektronik
{
    partial class ListaPjesemarrjes
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
            this.btnbacktoAdmin = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttongjeneroraportLP = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btnbacktoAdmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Berlin Sans FB Demi", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(257, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 35);
            this.label1.TabIndex = 9;
            this.label1.Text = "Lista e Pjesemarrjes";
            // 
            // btnbacktoAdmin
            // 
            this.btnbacktoAdmin.BackgroundImage = global::RegjistriElektronik.Properties.Resources._7124045_logout_icon1;
            this.btnbacktoAdmin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnbacktoAdmin.Image = global::RegjistriElektronik.Properties.Resources._7124045_logout_icon;
            this.btnbacktoAdmin.Location = new System.Drawing.Point(725, 47);
            this.btnbacktoAdmin.Name = "btnbacktoAdmin";
            this.btnbacktoAdmin.Size = new System.Drawing.Size(49, 38);
            this.btnbacktoAdmin.TabIndex = 11;
            this.btnbacktoAdmin.TabStop = false;
            this.btnbacktoAdmin.Click += new System.EventHandler(this.btnbacktoAdmin_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 91);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(740, 347);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // buttongjeneroraportLP
            // 
            this.buttongjeneroraportLP.Location = new System.Drawing.Point(25, 25);
            this.buttongjeneroraportLP.Name = "buttongjeneroraportLP";
            this.buttongjeneroraportLP.Size = new System.Drawing.Size(75, 49);
            this.buttongjeneroraportLP.TabIndex = 13;
            this.buttongjeneroraportLP.Text = "Gjenero Raport ";
            this.buttongjeneroraportLP.UseVisualStyleBackColor = true;
            // 
            // ListaPjesemarrjes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttongjeneroraportLP);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnbacktoAdmin);
            this.Controls.Add(this.label1);
            this.Name = "ListaPjesemarrjes";
            this.Text = "ListaPjesemarrjes";
            this.Load += new System.EventHandler(this.ListaPjesemarrjes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnbacktoAdmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btnbacktoAdmin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttongjeneroraportLP;
    }
}