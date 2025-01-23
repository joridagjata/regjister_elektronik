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
    public partial class CheckinStudent : Form
    {
        private StudentSpace studentSpace;
        public CheckinStudent(StudentSpace studentSpace)
        {
            InitializeComponent();
            this.studentSpace = studentSpace;
        }

        private void picLogoutCheckinStudent_Click(object sender, EventArgs e)
        {
            studentSpace.Show();
            this.Close();
        }
    }
    }

