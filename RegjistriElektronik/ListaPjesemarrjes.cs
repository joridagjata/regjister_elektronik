using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastReport;
using FastReport.Data;
using FastReport.Export.Pdf;

namespace RegjistriElektronik
{
    public partial class ListaPjesemarrjes : Form
    {
        private  AdminSpace _adminSpaceForm;

        string connectionString = "Data Source=DESKTOP-1USP24N\\SQLEXPRESS;Initial Catalog=Regjisterdb;Integrated Security=True;";

        public ListaPjesemarrjes(AdminSpace adminSpaceForm)
        {
            InitializeComponent();
            _adminSpaceForm = adminSpaceForm;
        }


        private void ListaPjesemarrjes_Load(object sender, EventArgs e)
        {
            LoadListaPjesemarrjesData();
        }
        private void LoadListaPjesemarrjesData()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-1USP24N\SQLEXPRESS;Initial Catalog=Regjisterdb;Integrated Security=True;TrustServerCertificate=True");
            
            string query = "SELECT studentUser.EMER_MBIEMER AS STUDENT_EMER, studentUser.USERNAME AS STUDENT_USERNAME, s.CARD_ID AS STUDENT_CARD, s.GROUP_ID AS STUDENT_GROUP " +
                " , l.EMER, g.EMER" +
                " , profUser.EMER_MBIEMER AS PROFESOR_EMER, profUser.USERNAME AS PROFESOR_USERNAME " +
                " , salla.EMER AS EMER_SALLE " +
                " , orar.DITA_E_JAVES, CONCAT(orar.NGA_ORA, ' - ', orar.DERI_NE_ORA) AS ORA" +
                " FROM PJESEMARRJA p " +
                " INNER JOIN STUDENT s ON s.ID = p.STUDENT_ID " +
                " INNER JOIN USERS studentUser ON studentUser.ID = s.USER_ID " +
                " INNER JOIN ORAR_MESIMOR orar ON orar.ID = p.ORAR_MESIMOR_ID " +
                " INNER JOIN LENDET l ON l.ID = orar.LENDA_ID " +
                " INNER JOIN GROUPS g ON g.ID = orar.GROUP_ID " +
                " INNER JOIN PROFESOR prof ON prof.ID = orar.PROFESOR_ID " +
                " INNER JOIN USERS profUser ON profUser.ID = prof.USER_ID " +
                " INNER JOIN SALLA salla ON salla.ID = orar.SALLA_ID "
                ;
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
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnbacktoAdmin_Click(object sender, EventArgs e)
        {
            
            _adminSpaceForm.Show();
            this.Close();
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
