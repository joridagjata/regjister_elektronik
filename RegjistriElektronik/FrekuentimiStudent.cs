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
  
    public partial class FrekuentimiStudent : Form
    {
        private StudentSpace studentSpace;
        public FrekuentimiStudent(StudentSpace studentSpace)
        {
            InitializeComponent();
            this.studentSpace = studentSpace;

        }

        private void picLogoutFrekuentim_Click(object sender, EventArgs e)
        {
            studentSpace.Show();
            this.Close();
        }
    }
}
