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
    public partial class MenaxhoOrarMesimor : Form
    {
        private ProfesorSpace profesorSpace;

        private int selectedOrarId = -1;


        string connectionString = "Data Source=DESKTOP-1USP24N\\SQLEXPRESS;Initial Catalog=Regjisterdb;Integrated Security=True;";
        public MenaxhoOrarMesimor(ProfesorSpace profesorSpace)
        {
            InitializeComponent();
            this.profesorSpace = profesorSpace;
            loadComboBox();
        }

        private void btnHap_Click(object sender, EventArgs e)
        {
            if (selectedOrarId == -1)
            {
                MessageBox.Show("Ju lutem selektoni nje orar mesimor!");
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE ORAR_MESIMOR SET STATUS = 1 WHERE id = @selectedOrarId ";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@selectedOrarId", selectedOrarId);

                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Orari mesimor u hap me sukses.");
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show("Orari mesimor nuk u hap sepse ka ndodhur nje gabim ne server.");
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }
            }
            
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
                           "INNER JOIN PROFESOR p ON o.PROFESOR_ID = p.DEPARTAMENT_ID " +
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

        private void btnMbyll_Click(object sender, EventArgs e)
        {
            if (selectedOrarId == -1)
            {
                MessageBox.Show("Ju lutem selektoni nje orar mesimor!");
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE ORAR_MESIMOR SET STATUS = 0 WHERE id = @selectedOrarId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@selectedOrarId", selectedOrarId);

                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Orari mesimor u mbyll me sukses.");
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show("Orari mesimor nuk u mbyll sepse ka ndodhur nje gabim ne server.");
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }
            }
        }

        private void picLogoutMenaxhoOrarinMesimor_Click(object sender, EventArgs e)
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
    }
}
