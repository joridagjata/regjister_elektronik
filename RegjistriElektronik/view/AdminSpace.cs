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
    public partial class AdminSpace : Form
    {
        private Form1 _loginForm;
        public AdminSpace(Form1 form)
        {
            InitializeComponent();
            _loginForm = form;
        }

        private void button2_Click(object sender, EventArgs e)

        {
            ProfesorButtonAdmin newForm = new ProfesorButtonAdmin(_loginForm);
            newForm.Show();
            this.Hide();
        }

        private void picLogoutadmin_Click(object sender, EventArgs e)
        {
            DashboardAdmin dashboardAdmin = new DashboardAdmin(_loginForm);
            dashboardAdmin.Show();
            this.Hide();


        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _loginForm.Show();
            base.OnFormClosed(e);
        }

        private void btnDepartamentiAdmin_Click(object sender, EventArgs e)
        {
            {
                // Krijoni dhe hapni formën DepartamentAdmin
                DepartamentAdmin departamentAdmin = new DepartamentAdmin(_loginForm);
                departamentAdmin.Show();
                this.Hide();  // Mbyllni AdminSpace përkohësisht
            }
        }

        private void btnLendaAdmin_Click(object sender, EventArgs e)
        {
            LessonPlanAdmin lessonPlanAdmin = new LessonPlanAdmin(_loginForm);
            lessonPlanAdmin.Show();
            this.Hide();
        }

        private void btnSekretariaAdmin_Click(object sender, EventArgs e)
        {
            SekretarButtonAdmincs sekretarButtonAdmincs = new SekretarButtonAdmincs (_loginForm);
            sekretarButtonAdmincs.Show();
            this.Hide();
        }

        private void btnStudentList_Click(object sender, EventArgs e)
        {
            // Open the StudentList form
            StudentList studentListForm = new StudentList(this);
            studentListForm.Show();
            this.Hide();
        }
    }
}
