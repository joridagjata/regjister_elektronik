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

namespace RegjistriElektronik
{
    public partial class GrupiMesimorSekretari : Form
    {
        private SekretariSpace _sekretariSpace;
        string connectionString = "Data Source=DESKTOP-1USP24N\\SQLEXPRESS;Initial Catalog=Regjisterdb;Integrated Security=True;";

        public GrupiMesimorSekretari(SekretariSpace sekretariSpace)
        {
            InitializeComponent();
             _sekretariSpace = sekretariSpace; ;
        }
        private void GrupeMesimoreList_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            string query = " SELECT * FROM GROUPS ";
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
                    dataGridViewGrupMesimor.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddGrupMesimor_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO GROUPS (emer, viti_akademik, dega, code) " +
                                " VALUES (@emer, @viti_akademik, @dega, @code)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@emer", txtEmriGrupit.Text);
                    cmd.Parameters.AddWithValue("@viti_akademik", txtVitiAkademik.Text);
                    cmd.Parameters.AddWithValue("@dega", txtDega.Text);
                    cmd.Parameters.AddWithValue("@code", txtGroupCode.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Grupi mesimor u shtua me sukses.");
                loadData();
            }
        }

        private void picLogoutSekretari_Click(object sender, EventArgs e)
        {
            _sekretariSpace .Show();
            this.Close();
        }
    }
}
