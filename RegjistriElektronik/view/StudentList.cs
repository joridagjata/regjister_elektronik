using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace RegjistriElektronik

{
   
    public partial class StudentList : Form
    { private AdminSpace _adminSpace;
        public StudentList(AdminSpace adminSpace)
        {
            InitializeComponent();
            _adminSpace = adminSpace;
        }

        private void StudentList_Load(object sender, EventArgs e)
        {
            LoadStudentsData();
        }
        private void LoadStudentsData()
        {
            string connectionString = "Data Source=DESKTOP-1USP24N\\SQLEXPRESS;Initial Catalog=Regjisterdb;Integrated Security=True;";

            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-1USP24N\SQLEXPRESS;Initial Catalog=Regjisterdb;Integrated Security=True;TrustServerCertificate=True");
            string query = "SELECT u.EMER_MBIEMER, u.EMAIL, u.PASSWORD, s.CARD_ID, g.EMER AS GRUPI, g.VITI_AKADEMIK, g.DEGA " +
                " FROM STUDENT s " +
                " INNER JOIN USERS u ON u.ID = s.USER_ID " +
                " INNER JOIN GROUPS g ON s.GROUP_ID = g.ID ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Fetch data into a DataTable
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Bind DataTable to DataGridView
                    dataGridViewStudents.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void btnLogoutStudentList_Click(object sender, EventArgs e)
        {
            ; // Sigurohuni që të kaloni formën e login-it nëse është e nevojshme
            _adminSpace.Show();
            this.Close();
        }

        
    }
}
    

