using ExCSS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegjistriElektronik
{
    public partial class StudentSpace : Form
    { 
        private Form form;
    
        public StudentSpace(Form form)
        {
            InitializeComponent();
            this.form = form;
        }

        public string getUsername()
        {
            if (form.GetType() == typeof(Form1))
            {
                return ((Form1)form).getUsername();
            }
            return null;
        }

        private void picLogoutstudent_Click(object sender, EventArgs e)
        {
            form.Show();
            this.Hide();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            CheckinStudent form = new CheckinStudent(this);
            form.Show();
            this.Hide();
        }

        private void btnFrekuentimi_Click(object sender, EventArgs e)
        {
            FrekuentimiStudent form = new FrekuentimiStudent(this);
            form.Show();
            this.Hide();
        }
    }
}
