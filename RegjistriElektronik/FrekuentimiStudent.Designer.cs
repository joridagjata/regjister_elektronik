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
            this.btnShikoFrekuentim = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLenda = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewListPrezenca = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoutFrekuentim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListPrezenca)).BeginInit();
            this.SuspendLayout();
            // 
            // picLogoutFrekuentim
            // 
            this.picLogoutFrekuentim.BackgroundImage = global::RegjistriElektronik.Properties.Resources._7124045_logout_icon1;
            this.picLogoutFrekuentim.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picLogoutFrekuentim.Image = global::RegjistriElektronik.Properties.Resources._7124045_logout_icon;
            this.picLogoutFrekuentim.Location = new System.Drawing.Point(774, 28);
            this.picLogoutFrekuentim.Name = "picLogoutFrekuentim";
            this.picLogoutFrekuentim.Size = new System.Drawing.Size(43, 38);
            this.picLogoutFrekuentim.TabIndex = 19;
            this.picLogoutFrekuentim.TabStop = false;
            this.picLogoutFrekuentim.Click += new System.EventHandler(this.picLogoutFrekuentim_Click);
            // 
            // btnShikoFrekuentim
            // 
            this.btnShikoFrekuentim.BackColor = System.Drawing.Color.Olive;
            this.btnShikoFrekuentim.Font = new System.Drawing.Font("Berlin Sans FB Demi", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShikoFrekuentim.ForeColor = System.Drawing.Color.Honeydew;
            this.btnShikoFrekuentim.Location = new System.Drawing.Point(603, 131);
            this.btnShikoFrekuentim.Name = "btnShikoFrekuentim";
            this.btnShikoFrekuentim.Size = new System.Drawing.Size(214, 92);
            this.btnShikoFrekuentim.TabIndex = 75;
            this.btnShikoFrekuentim.Text = "Shiko Frekuentim";
            this.btnShikoFrekuentim.UseVisualStyleBackColor = false;
            this.btnShikoFrekuentim.Click += new System.EventHandler(this.btnShikoFrekuentim_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 20);
            this.label9.TabIndex = 74;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(449, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 73;
            // 
            // txtLenda
            // 
            this.txtLenda.Location = new System.Drawing.Point(99, 161);
            this.txtLenda.Name = "txtLenda";
            this.txtLenda.Size = new System.Drawing.Size(350, 22);
            this.txtLenda.TabIndex = 65;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 58;
            this.label3.Text = "Lenda";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Beige;
            this.label1.Font = new System.Drawing.Font("Berlin Sans FB Demi", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(254, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 38);
            this.label1.TabIndex = 57;
            this.label1.Text = "Frekuentimi i Studentit";
            // 
            // dataGridViewListPrezenca
            // 
            this.dataGridViewListPrezenca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListPrezenca.Location = new System.Drawing.Point(6, 255);
            this.dataGridViewListPrezenca.Name = "dataGridViewListPrezenca";
            this.dataGridViewListPrezenca.RowHeadersWidth = 51;
            this.dataGridViewListPrezenca.RowTemplate.Height = 24;
            this.dataGridViewListPrezenca.Size = new System.Drawing.Size(837, 232);
            this.dataGridViewListPrezenca.TabIndex = 71;
            // 
            // FrekuentimiStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 500);
            this.Controls.Add(this.btnShikoFrekuentim);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewListPrezenca);
            this.Controls.Add(this.txtLenda);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picLogoutFrekuentim);
            this.Name = "FrekuentimiStudent";
            this.Text = "FrekuentimiStudent";
            ((System.ComponentModel.ISupportInitialize)(this.picLogoutFrekuentim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListPrezenca)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picLogoutFrekuentim;
        private System.Windows.Forms.Button btnShikoFrekuentim;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLenda;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewListPrezenca;
    }
}