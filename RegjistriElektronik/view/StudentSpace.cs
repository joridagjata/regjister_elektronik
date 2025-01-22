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
        private Form1 _loginForm;
    
        public StudentSpace(Form1 form)
        {
            InitializeComponent();
        _loginForm = form;
    }

        private void picLogoutstudent_Click(object sender, EventArgs e)
        {
        _loginForm.Show();
        this.Hide();

    }
    }
}
