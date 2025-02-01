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
    public partial class OrariMesimorSekretari : Form
    {
        private SekretariSpace _sekretariSpace;
        private int selectedDepartament = -1;
        private int selectedGrup = -1;
        private int selectedLende = -1;
        private int selectedProfesor = -1;

        string connectionString = "Data Source=DESKTOP-1USP24N\\SQLEXPRESS;Initial Catalog=Regjisterdb;Integrated Security=True;";

        public OrariMesimorSekretari(SekretariSpace sekretariSpace)
        {
            InitializeComponent();
             _sekretariSpace = sekretariSpace; 
        

        }
        private void OrarMesimorList_Load(object sender, EventArgs e)
        {
            loadData();
            loadComboBoxDepartament();
            loadGroups();
        }

        private void loadData()
        {
            string query = " SELECT ORAR.ID, G.EMER, G.viti_akademik, G.dega, L.EMER, S.EMER, U.EMER_MBIEMER" +
                ", CASE " +
                "   WHEN ORAR.DITA_E_JAVES = 1 THEN 'E HENE' " +
                "   WHEN ORAR.DITA_E_JAVES = 2 THEN 'E MARTE' " +
                "   WHEN ORAR.DITA_E_JAVES = 3 THEN 'E MERKURE' " +
                "   WHEN ORAR.DITA_E_JAVES = 4 THEN 'E ENJTE' " +
                "   WHEN ORAR.DITA_E_JAVES = 5 THEN 'E PREMTE' " +
                "   ELSE 'ERROR' " +
                " END AS DITA_E_JAVES " +
                ", CONCAT(ORAR.NGA_ORA ,  ' - ', ORAR.DERI_NE_ORA) AS ORA" +
                " FROM ORAR_MESIMOR ORAR" +
                " INNER JOIN LENDET L ON L.ID = ORAR.LENDA_ID " +
                " INNER JOIN GROUPS G ON ORAR.GROUP_ID = G.ID " +
                " INNER JOIN PROFESOR P ON P.ID = ORAR.PROFESOR_ID " +
                " INNER JOIN USERS U ON U.ID = P.USER_ID " +
                " INNER JOIN SALLA S ON S.ID = ORAR.SALLA_ID ";
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
                    dataGridViewOrarMesimor.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (selectedLende == -1)
            {
                MessageBox.Show("Ju lutem selektoni nje lende!");
            } else if(selectedProfesor == -1) {
                MessageBox.Show("Ju lutem selektoni nje profesor!");
            } else if (selectedGrup == -1)
            {
                MessageBox.Show("Ju lutem selektoni nje grup mesimor!");
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO ORAR_MESIMOR (LENDA_ID, GROUP_ID, PROFESOR_ID, SALLA_ID, DITA_E_JAVES, NGA_ORA, DERI_NE_ORA) " +
                                    " VALUES (" +
                                    " @lendaId, @groupId, @profesorId" +
                                    //"(select id from LENDET WHERE EMER = @emerLende) " +
                                    //", (select id from groups where code = @groupCode) " +
                                    //", (select p.id from profesor p inner join users u on u.id = p.user_id where u.username = @profesorUsername) " +
                                    ", (select id from salla where emer = @emerSalle) " +
                                    ", @ditaEJaves, @ngaOra, @deriNeOra " +
                                    ")";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        //cmd.Parameters.AddWithValue("@emerLende", txtLenda.Text);
                        //cmd.Parameters.AddWithValue("@groupCode", txtGrupiMesimor.Text);
                        //cmd.Parameters.AddWithValue("@profesorUsername", txtProfesor.Text);
                        cmd.Parameters.AddWithValue("@lendaId", selectedLende);
                        cmd.Parameters.AddWithValue("@groupId", selectedGrup);
                        cmd.Parameters.AddWithValue("@profesorId", selectedProfesor);
                        cmd.Parameters.AddWithValue("@emerSalle", txtSalla.Text);
                        cmd.Parameters.AddWithValue("@ditaEJaves", textBoxDitaeJaves.Text);
                        cmd.Parameters.AddWithValue("@ngaOra", txtNgaOra.Text);
                        cmd.Parameters.AddWithValue("@deriNeOra", txtNeOre.Text);

                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Orari mesimor u shtua me sukses.");
                            loadData();
                        }
                        catch (SqlException excpetion)
                        {
                            MessageBox.Show("Orari mesimor nuk u shtua sepse ka perplasje oraresh.");
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show("Orari mesimor nuk u shtua sepse ka ndodhur nje gabim ne server.");
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }

                }
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrarMesimor.SelectedRows.Count > 0)
            {
                int orarMesimorId = Convert.ToInt32(dataGridViewOrarMesimor.SelectedRows[0].Cells["ID"].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE ORAR_MESIMOR SET LENDA_ID = @lendaId, GROUP_ID = @groupId, PROFESOR_ID = @profesorId " +
                        ", SALLA_ID = (select id from salla where emer = @emerSalle) " +
                        ", DITA_E_JAVES = @ditaEJaves" +
                        ", NGA_ORA = @ngaOra" +
                        ", DERI_NE_ORA = @deriNeOra" +
                        " WHERE ORAR_MESIMOR.ID = @orarMesimorId ";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@lendaId", selectedLende);
                        cmd.Parameters.AddWithValue("@groupId", selectedGrup);
                        cmd.Parameters.AddWithValue("@profesorId", selectedProfesor);
                        cmd.Parameters.AddWithValue("@emerSalle", txtSalla.Text);
                        cmd.Parameters.AddWithValue("@ditaEJaves", textBoxDitaeJaves.Text);
                        cmd.Parameters.AddWithValue("@ngaOra", txtNgaOra.Text);
                        cmd.Parameters.AddWithValue("@deriNeOra", txtNeOre.Text);
                        cmd.Parameters.AddWithValue("@orarMesimorId", orarMesimorId);

                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Orari mesimor u azhornua me sukses.");
                            loadData();
                        }
                        catch (SqlException excpetion)
                        {
                            MessageBox.Show("Orari mesimor nuk u azhornua sepse ka perplasje oraresh.");
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show("Orari mesimor nuk u azhornua sepse ka ndodhur nje gabim ne server.");
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a orar mesimor to update.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrarMesimor.SelectedRows.Count > 0)
            {
                int orarMesimorID = Convert.ToInt32(dataGridViewOrarMesimor.SelectedRows[0].Cells["ID"].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM ORAR_MESIMOR WHERE id = @orarMesimorID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@orarMesimorID", orarMesimorID);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    MessageBox.Show("Orari mesimor u fshi me sukses.");
                    loadData();
                }
            }
            else
            {
                MessageBox.Show("Please select a orar mesimor to delete.");
            }
        }

        private void btnLogoutOrarMesimor_Click(object sender, EventArgs e)
        {
            _sekretariSpace.Show();
            this.Close();
        }
        private void loadLendet()
        {
            string connectionString = @"Data Source=DESKTOP-1USP24N\SQLEXPRESS;Initial Catalog=Regjisterdb;Integrated Security=True;TrustServerCertificate=True";
            string query = "select l.ID as ID, l.EMER as EMER from lendet l where DEPARTAMENT_ID = @departamentId";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@departamentId", selectedDepartament);

                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Columns.Add("ID", typeof(int));
                            dataTable.Columns.Add("EMER", typeof(string));
                            dataTable.Rows.Add(DBNull.Value, "");
                            dataAdapter.Fill(dataTable);

                            comboBoxLendet.DataSource = dataTable;
                            comboBoxLendet.DisplayMember = "EMER";
                            comboBoxLendet.ValueMember = "ID";
                            comboBoxLendet.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadProfesoret()
        {
            string connectionString = @"Data Source=DESKTOP-1USP24N\SQLEXPRESS;Initial Catalog=Regjisterdb;Integrated Security=True;TrustServerCertificate=True";
            string query = "SELECT p.ID as ID, u.EMER_MBIEMER as EMER " +
                " FROM PROFESOR p " +
                " INNER JOIN USERS u ON u.ID = p.USER_ID " +
                " WHERE p.DEPARTAMENT_ID = @departamentId";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@departamentId", selectedDepartament);

                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Columns.Add("ID", typeof(int));
                            dataTable.Columns.Add("EMER", typeof(string));
                            dataTable.Rows.Add(DBNull.Value, "");
                            dataAdapter.Fill(dataTable);

                            comboBoxProfesoret.DataSource = dataTable;
                            comboBoxProfesoret.DisplayMember = "EMER";
                            comboBoxProfesoret.ValueMember = "ID";
                            comboBoxProfesoret.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadGroups()
        {
            string connectionString = @"Data Source=DESKTOP-1USP24N\SQLEXPRESS;Initial Catalog=Regjisterdb;Integrated Security=True;TrustServerCertificate=True";
            string query = "SELECT g.ID as ID, CONCAT(g.EMER, ' ', g.VITI_AKADEMIK, ' Dega:', g.DEGA) as EMER FROM GROUPS g";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Columns.Add("ID", typeof(int));
                            dataTable.Columns.Add("EMER", typeof(string));
                            dataTable.Rows.Add(DBNull.Value, "");
                            dataAdapter.Fill(dataTable);

                            comboBoxGrupet.DataSource = dataTable;
                            comboBoxGrupet.DisplayMember = "EMER";
                            comboBoxGrupet.ValueMember = "ID";
                            comboBoxGrupet.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadComboBoxDepartament()
        {
            string connectionString = @"Data Source=DESKTOP-1USP24N\SQLEXPRESS;Initial Catalog=Regjisterdb;Integrated Security=True;TrustServerCertificate=True";
            string query = " SELECT d.ID AS DEP_ID, d.EMER AS DEPARTAMENT_NAME " +
                           " FROM DEPARTAMENT d ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Columns.Add("DEP_ID", typeof(int));
                            dataTable.Columns.Add("DEPARTAMENT_NAME", typeof(string));
                            dataTable.Rows.Add(DBNull.Value, "");
                            dataAdapter.Fill(dataTable);

                            comboBoxDepartament.DataSource = dataTable;
                            comboBoxDepartament.DisplayMember = "DEPARTAMENT_NAME";
                            comboBoxDepartament.ValueMember = "DEP_ID";
                            comboBoxDepartament.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxProfesoret_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProfesoret.SelectedValue != null && int.TryParse(comboBoxProfesoret.SelectedValue.ToString(), out int id))
            {
                selectedProfesor = id;
            }
            else
            {
                selectedProfesor = -1;
            }
        }

        private void comboBoxLendet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLendet.SelectedValue != null && int.TryParse(comboBoxLendet.SelectedValue.ToString(), out int id))
            {
                selectedLende = id;
            }
            else
            {
                selectedLende = -1;
            }
        }

        private void comboBoxDepartament_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDepartament.SelectedValue != null && int.TryParse(comboBoxDepartament.SelectedValue.ToString(), out int id))
            {
                selectedDepartament = id;
                loadProfesoret();
                loadLendet();
            }
            else
            {
                selectedDepartament = -1;
            }
        }

        private void comboBoxGrupet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxGrupet.SelectedValue != null && int.TryParse(comboBoxGrupet.SelectedValue.ToString(), out int id))
            {
                selectedGrup = id;
            }
            else
            {
                selectedGrup = -1;
            }
        }
    }
}
