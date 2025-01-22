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
    public partial class ProfesorSpace : Form
    {
        private Form1 _loginForm;
        public ProfesorSpace(Form1 loginForm)
        {
            InitializeComponent();
            _loginForm = loginForm;
        }

        private void picLogoutPetagog_Click(object sender, EventArgs e)
        {
            _loginForm.Show();
            this.Hide();
        }

        private void btnMenaxhoOrarMesimor_Click(object sender, EventArgs e)
        {
            MenaxhoOrarMesimor menaxhoOrarMesimor = new MenaxhoOrarMesimor(this);
            menaxhoOrarMesimor.Show();
            this.Hide();
        }

        private void btnListPrezenca_Click(object sender, EventArgs e)
        {
            ListPrezencacs form = new ListPrezencacs(this);
            form.Show();
            this.Hide();
        }

        private void btnSakteso_Click(object sender, EventArgs e)
        {
            SaktesoList form = new SaktesoList(this);
            form.Show();
            this.Hide();
        }
    }
}
