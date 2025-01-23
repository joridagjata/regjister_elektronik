using FastReport.DevComponents.DotNetBar.Controls;
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
    public partial class SaktesoList : Form
    {

        ProfesorSpace profesorSpace;


        string connectionString = "Data Source=DESKTOP-1USP24N\\SQLEXPRESS;Initial Catalog=Regjisterdb;Integrated Security=True;";

        public SaktesoList(ProfesorSpace profesorSpace)
        {
            InitializeComponent();
            this.profesorSpace = profesorSpace;

        }

        public void SaktesoList_Load(object sender, EventArgs e)
        {
            loadDate();
        }

        private void loadDate()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-1USP24N\SQLEXPRESS;Initial Catalog=Regjisterdb;Integrated Security=True;TrustServerCertificate=True");

            string query = "SELECT p.ID as ID, studentUser.EMER_MBIEMER AS STUDENT_EMER, s.CARD_ID AS STUDENT_CARD" +
                " , l.EMER AS LENDA, g.EMER AS GRUPI" +
                " , profUser.EMER_MBIEMER AS PROFESOR_EMER" +
                " , salla.EMER AS EMER_SALLE " +
                " , orar.DITA_E_JAVES, CONCAT(orar.NGA_ORA, ' - ', orar.DERI_NE_ORA) AS ORA, p.PREZENT as PREZENT " +
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
                    dataGridViewListPrezenca.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSakteso_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO PJESEMARRJA (STUDENT_ID, ORAR_MESIMOR_ID, PREZENT, KOHA_E_CHECKIN) " +
                                " VALUES (" +
                                " (select id from student where card_id = @cardId )" +
                                " , (select id from ORAR_MESIMOR where  " +
                                " LENDA_ID = (select id from LENDET WHERE EMER = @emerLende)" +
                                " and GROUP_ID = (select id from groups where code = @groupCode) " +
                                " and PROFESOR_ID = (select p.id from profesor p inner join users u on u.id = p.user_id where u.username = @profesorUsername) " +
                                " and SALLA_ID = (select id from salla where emer = @emerSalle) " +
                                " and DITA_E_JAVES = @ditaEJaves" +
                                " and NGA_ORA = @ngaOra" +
                                " and DERI_NE_ORA = @deriNeOra ) " +
                                " , 1" +
                                ", CAST(GETDATE() AS DATE)" +
                                ")";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cardId", txtStudentCardID.Text);
                    cmd.Parameters.AddWithValue("@emerLende", txtLenda.Text);
                    cmd.Parameters.AddWithValue("@groupCode", txtGrupiMesimor.Text);
                    cmd.Parameters.AddWithValue("@profesorUsername", txtProfesor.Text);
                    cmd.Parameters.AddWithValue("@emerSalle", txtSalla.Text);
                    cmd.Parameters.AddWithValue("@ditaEJaves", textBoxDitaeJaves.Text);
                    cmd.Parameters.AddWithValue("@ngaOra", txtNgaOra.Text);
                    cmd.Parameters.AddWithValue("@deriNeOra", txtNeOre.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("List Prezenca u shtua me sukses.");
                    loadDate();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewListPrezenca.SelectedRows.Count > 0)
            {
                int frekuentimiID = Convert.ToInt32(dataGridViewListPrezenca.SelectedRows[0].Cells["ID"].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = " update PJESEMARRJA set PREZENT = 0 " +
                                " where ID = @frekuentimiID";
                               
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@frekuentimiID", frekuentimiID);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Pjesemarrja updated successfully.");
                        loadDate();
                        conn.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a Student to update.");
            }
        }

        private void picLogoutSaktesoList_Click(object sender, EventArgs e)
        {
            profesorSpace.Show();
            this.Close();
        }
    }
}
