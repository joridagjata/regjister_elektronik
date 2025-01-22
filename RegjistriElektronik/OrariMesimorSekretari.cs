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

        string connectionString = "Data Source=DESKTOP-1USP24N\\SQLEXPRESS;Initial Catalog=Regjisterdb;Integrated Security=True;";

        public OrariMesimorSekretari(SekretariSpace sekretariSpace)
        {
            InitializeComponent();
             _sekretariSpace = sekretariSpace; 
        

        }
        private void OrarMesimorList_Load(object sender, EventArgs e)
        {
            loadData();
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
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ORAR_MESIMOR (LENDA_ID, GROUP_ID, PROFESOR_ID, SALLA_ID, DITA_E_JAVES, NGA_ORA, DERI_NE_ORA) " +
                                " VALUES ((select id from LENDET WHERE EMER = @emerLende) " +
                                ", (select id from groups where code = @groupCode) " +
                                ", (select p.id from profesor p inner join users u on u.id = p.user_id where u.username = @profesorUsername) " +
                                ", (select id from salla where emer = @emerSalle) " +
                                ", @ditaEJaves, @ngaOra, @deriNeOra " +
                                ")";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@emerLende", txtLenda.Text);
                    cmd.Parameters.AddWithValue("@groupCode", txtGrupiMesimor.Text);
                    cmd.Parameters.AddWithValue("@profesorUsername", txtProfesor.Text);
                    cmd.Parameters.AddWithValue("@emerSalle", txtSalla.Text);
                    cmd.Parameters.AddWithValue("@ditaEJaves", textBoxDitaeJaves.Text);
                    cmd.Parameters.AddWithValue("@ngaOra", txtNgaOra.Text);
                    cmd.Parameters.AddWithValue("@deriNeOra", txtNeOre.Text);

                    try {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Orari mesimor u shtua me sukses.");
                        loadData();
                    } catch(SqlException excpetion) {
                        MessageBox.Show("Orari mesimor nuk u shtua sepse ka perplasje oraresh.");
                    } catch(Exception exception)
                    {
                        MessageBox.Show("Orari mesimor nuk u shtua sepse ka ndodhur nje gabim ne server.");
                    }
                    finally {
                        conn.Close();
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
                    string query = "UPDATE ORAR_MESIMOR SET " +
                        " LENDA_ID = (select id from LENDET WHERE EMER = @emerLende)" +
                        ", GROUP_ID = (select id from groups where code = @groupCode) " +
                        ", PROFESOR_ID = (select p.id from profesor p inner join users u on u.id = p.user_id where u.username = @profesorUsername) " +
                        ", SALLA_ID = (select id from salla where emer = @emerSalle) " +
                        ", DITA_E_JAVES = @ditaEJaves" +
                        ", NGA_ORA = @ngaOra" +
                        ", DERI_NE_ORA = @deriNeOra" +
                        " WHERE ORAR_MESIMOR.ID = @orarMesimorId ";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@emerLende", txtLenda.Text);
                        cmd.Parameters.AddWithValue("@groupCode", txtGrupiMesimor.Text);
                        cmd.Parameters.AddWithValue("@profesorUsername", txtProfesor.Text);
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
    }
}
