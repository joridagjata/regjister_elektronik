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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RegjistriElektronik
{
    public partial class SaktesoList : Form
    {

        ProfesorSpace profesorSpace;
        private int selectedOrarId = -1;


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

            if (profesorSpace != null && !string.IsNullOrEmpty(profesorSpace.getUsername())) { loadComboBox(); };
        }

        private void loadComboBox()
        {
            string connectionString = @"Data Source=DESKTOP-1USP24N\SQLEXPRESS;Initial Catalog=Regjisterdb;Integrated Security=True;TrustServerCertificate=True";
            string query = "SELECT o.ID AS ORAR_ID, CONCAT (l.EMER, ' Grupi: ', g.EMER, ' Orari: ', " +
                           "CASE " +
                           "   WHEN o.DITA_E_JAVES = 1 THEN 'E HENE' " +
                           "   WHEN o.DITA_E_JAVES = 2 THEN 'E MARTE' " +
                           "   WHEN o.DITA_E_JAVES = 3 THEN 'E MERKURE' " +
                           "   WHEN o.DITA_E_JAVES = 4 THEN 'E ENJTE' " +
                           "   WHEN o.DITA_E_JAVES = 5 THEN 'E PREMTE' " +
                           "   ELSE 'ERROR' END, ' ', o.NGA_ORA, ' - ', o.DERI_NE_ORA) AS ORAR_NAME " +
                           "FROM ORAR_MESIMOR o " +
                           "INNER JOIN PROFESOR p ON o.PROFESOR_ID = p.ID " +
                           "INNER JOIN LENDET l ON l.ID = o.LENDA_ID " +
                           "INNER JOIN GROUPS g ON g.ID = o.GROUP_ID " +
                           "INNER JOIN SALLA s ON s.ID = o.SALLA_ID " +
                           "INNER JOIN USERS u ON u.ID = p.USER_ID " +
                           "WHERE u.USERNAME = @usernameProfesor";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@usernameProfesor", profesorSpace.getUsername());

                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Columns.Add("ORAR_ID", typeof(int));
                            dataTable.Columns.Add("ORAR_NAME", typeof(string));
                            dataTable.Rows.Add(DBNull.Value, "");
                            dataAdapter.Fill(dataTable);

                            comboBoxOraret.DataSource = dataTable;
                            comboBoxOraret.DisplayMember = "ORAR_NAME";
                            comboBoxOraret.ValueMember = "ORAR_ID";
                            comboBoxOraret.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSakteso_Click(object sender, EventArgs e)
        {
            if(selectedOrarId == -1)
            {
                MessageBox.Show("Ju lutem selektoni nje orar mesimor!");
            } else if (string.IsNullOrWhiteSpace(txtStudentUsername.Text))
            {
                MessageBox.Show("Ju lutem vendosni nje username studenti!");
            }
            else{
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO PJESEMARRJA (STUDENT_ID, ORAR_MESIMOR_ID, PREZENT, KOHA_E_CHECKIN) " +
                                    " VALUES (" +
                                    " (select student.id from student inner join users on student.user_id = users.id where users.Username = @studentUsername )" +
                                    ", @selectedOrarId " +
                                    " , 1" +
                                    ", CAST(GETDATE() AS DATE)" +
                                    ")";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentUsername", txtStudentUsername.Text);
                        cmd.Parameters.AddWithValue("@selectedOrarId", selectedOrarId);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("List Prezenca u shtua me sukses.");
                        loadDate();
                    }
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
                    string query = " update PJESEMARRJA " +
                        " set PREZENT = (CASE WHEN PREZENT = 1 THEN 0 ELSE 1 END)" +
                        " where ID = @frekuentimiID ";
                               
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

        private void comboBoxOraret_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOraret.SelectedValue != null && int.TryParse(comboBoxOraret.SelectedValue.ToString(), out int id))
            {
                selectedOrarId = id;
            }
            else
            {
                selectedOrarId = -1;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
