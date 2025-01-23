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
    public partial class DashboardAdmin : Form
    {
        private Form1 _loginForm;
        public DashboardAdmin(Form1 loginForm)
        {
            InitializeComponent();
            _loginForm = loginForm;
        }

        private void picLogoutDshboardAdmin_Click(object sender, EventArgs e)
        {

            _loginForm.Show();
            this.Hide();
        }

        private void btnAdminSpace_Click(object sender, EventArgs e)
        {
            AdminSpace form = new AdminSpace(_loginForm);
            form.Show();
            this.Hide();
        }

        private void btnSekretariSpace_Click(object sender, EventArgs e)
        {
            SekretariSpace form = new SekretariSpace(this);
            form.Show();
            this.Hide();
        }

        private void btnProfesorSpace_Click(object sender, EventArgs e)
        {
            ProfesorSpace form = new ProfesorSpace(this);
            form.Show();
            this.Hide();
        }

        private void btnStudentSpace_Click(object sender, EventArgs e)
        {
            StudentSpace form = new StudentSpace(this);
            form.Show();
            this.Hide();
        }
    }
}
