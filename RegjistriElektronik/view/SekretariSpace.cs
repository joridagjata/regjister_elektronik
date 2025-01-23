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
    public partial class SekretariSpace : Form
    {
        private Form _loginForm;
        public SekretariSpace(Form form)
        {
            InitializeComponent();
            _loginForm = form;
        }

        private void picLogoutSekretari_Click(object sender, EventArgs e)
        {
            _loginForm.Show();
            this.Hide();
        }

        private void btnStudentSekretari_Click(object sender, EventArgs e)
        {
            // Krijoni dhe hapni formën DepartamentAdmin
            StudentButton studentButton = new StudentButton(this);
            studentButton.Show();
            this.Hide();
        }

        private void btnGrupetMesimore_Click(object sender, EventArgs e)
        {
            GrupiMesimorSekretari grupiMesimorSekretari = new GrupiMesimorSekretari(this);
            grupiMesimorSekretari.Show();
            this.Hide();
        }

        private void btnOrarMesimor_Click(object sender, EventArgs e)
        {
           OrariMesimorSekretari orariMesimorSekretari = new OrariMesimorSekretari(this);
            orariMesimorSekretari.Show();
            this.Hide();

        }

        private void btnRaporte_Click(object sender, EventArgs e)
        {
            RaportFrekuentim raportFrekuentimi = new RaportFrekuentim(this);
            raportFrekuentimi.Show();
            this.Hide();
        }
    }
}
