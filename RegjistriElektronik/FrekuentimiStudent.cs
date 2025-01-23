using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        private string connectionString = @"Data Source=DESKTOP-1USP24N\SQLEXPRESS;Initial Catalog=Regjisterdb;Integrated Security=True;TrustServerCertificate=True";


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

        private void btnShikoFrekuentim_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-1USP24N\SQLEXPRESS;Initial Catalog=Regjisterdb;Integrated Security=True;TrustServerCertificate=True");
            string query = " SELECT L.EMER AS LENDA, P.KOHA_E_CHECKIN AS DATA" +
                ", CASE " +
                " WHEN p.PREZENT = 1 THEN 'PREZENT' " +
                " ELSE 'JO PREZENT' " +
                " END AS FREKUENTIMI " +
                " FROM USERS u " +
                " INNER JOIN STUDENT s ON s.USER_ID = u.ID " +
                " INNER JOIN GROUPS g ON s.GROUP_ID = g.ID " +
                " INNER JOIN ORAR_MESIMOR o ON o.GROUP_ID = g.ID " +
                " INNER JOIN LENDET l ON l.ID = o.LENDA_ID " +
                " LEFT JOIN PJESEMARRJA p ON p.ORAR_MESIMOR_ID = o.ID " +
                " WHERE u.USERNAME = @studentUsername and l.EMER = @lenda";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Use SqlCommand with parameters
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@studentUsername", studentSpace.getUsername());
                    command.Parameters.AddWithValue("@lenda", txtLenda.Text);

                    // Use SqlDataAdapter with SqlCommand
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                    // Fill DataTable with data
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Bind DataTable to DataGridView
                    dataGridViewListPrezenca.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

