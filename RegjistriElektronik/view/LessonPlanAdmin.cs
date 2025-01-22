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
    public partial class LessonPlanAdmin : Form
    {
        private Form1 _loginForm;

        string connectionString = "Data Source=DESKTOP-1USP24N\\SQLEXPRESS;Initial Catalog=Regjisterdb;Integrated Security=True;";

        public LessonPlanAdmin(Form1 loginForm)
        {
            InitializeComponent();
            _loginForm = loginForm;
            InitializeLessonPlans();
        }
        private void InitializeLessonPlans()
        {
            String query = " SELECT p.ID, d.EMER as EMER_DEPARTAMENTI, d.CODE as KOD_DEPARTTAMENTI, l.EMER AS EMER_LENDE, p.VITI_AKADEMIK " +
                " FROM PLANI_MESIMOR p " +
                " INNER JOIN DEPARTAMENT d ON p.DEPARTAMENT_ID = d.ID " +
                " INNER JOIN LENDET l ON p.LENDA_ID = l.ID ";
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
                    dataGridViewPlaniMesimor.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       

        private void btnBackToAdmin_Click(object sender, EventArgs e)
        {
            AdminSpace adminForm = new AdminSpace(_loginForm); // Sigurohuni që të kaloni formën e login-it nëse është e nevojshme
            adminForm.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
         using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string insertDepartamentQuery = " INSERT INTO DEPARTAMENT (EMER, CODE, STATUS) VALUES (@emerDepartament, @codeDep, 1) ";

                using (SqlCommand cmd = new SqlCommand(insertDepartamentQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@emerDepartament", txtDepartamenti.Text);
                    cmd.Parameters.AddWithValue("@codeDep", txtDepcode.Text);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    } catch (Exception exception){
                    
                    } finally
                    {
                        conn.Close();
                    }
                }

                string insertLendaQuery = " INSERT INTO LENDET (EMER, DEPARTAMENT_ID) " +
                    "VALUES (@emerLende, (select id from DEPARTAMENT where CODE = @codeDep)) ";

                using (SqlCommand cmd = new SqlCommand(insertLendaQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@emerLende", txtLenda.Text);
                    cmd.Parameters.AddWithValue("@codeDep", txtDepcode.Text);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception exception) { }
                    finally
                    {
                        conn.Close();
                    }
                }

                string query = "INSERT INTO PLANI_MESIMOR (LENDA_ID, DEPARTAMENT_ID , VITI_AKADEMIK) " +
                                " VALUES ((select id from LENDET WHERE EMER = @emerLende) " +
                                ", (select id from DEPARTAMENT where CODE = @codeDep) " +
                                ", @vitiAkademik" +
                                ")";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@emerLende", txtLenda.Text);
                    cmd.Parameters.AddWithValue("@codeDep", txtDepcode.Text);
                    cmd.Parameters.AddWithValue("@vitiAkademik", txtVitiAkademik.Text);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Plani mesimor u shtua me sukses.");
                        InitializeLessonPlans();
                    }
                    catch (SqlException excpetion)
                    {
                        MessageBox.Show("Plani mesimor nuk u shtua sepse ka perplasje.");
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Plani mesimor nuk u shtua sepse ka ndodhur nje gabim ne server.");
                    }
                    finally
                    {
                        conn.Close();
                    }
                }

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           if (dataGridViewPlaniMesimor.SelectedRows.Count > 0)
            {
                int planMesimorId = Convert.ToInt32(dataGridViewPlaniMesimor.SelectedRows[0].Cells["ID"].Value);
                string oldCodeDep = Convert.ToString(dataGridViewPlaniMesimor.SelectedRows[0].Cells["KOD_DEPARTTAMENTI"].Value);
                string oldEmerLende = Convert.ToString(dataGridViewPlaniMesimor.SelectedRows[0].Cells["EMER_LENDE"].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string queryDep = "UPDATE DEPARTAMENT SET " +
                        " EMER = @emerDepartament, CODE = @codeDep " +
                        " WHERE DEPARTAMENT.CODE = @oldCodeDep ";
                    using (SqlCommand cmd = new SqlCommand(queryDep, conn))
                    {
                        cmd.Parameters.AddWithValue("@emerDepartament", txtDepartamenti.Text);
                        cmd.Parameters.AddWithValue("@codeDep", txtDepcode.Text);
                        cmd.Parameters.AddWithValue("@oldCodeDep", oldCodeDep);

                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception exception)
                        {
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }


                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE LENDET SET " +
                        " EMER = @emerLende " +
                        " WHERE LENDET.EMER = @oldEmerLende ";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@emerLende", txtLenda.Text);
                        cmd.Parameters.AddWithValue("@oldEmerLende", oldEmerLende);

                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception exception)
                        {
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Plani_Mesimor SET " +
                        " VITI_AKADEMIK = @vitiAkademik " +
                        " WHERE Plani_Mesimor.ID = @planMesimorId ";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@vitiAkademik", txtVitiAkademik.Text);
                        cmd.Parameters.AddWithValue("@planMesimorId", planMesimorId);

                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Plani mesimor u azhornua me sukses.");
                            InitializeLessonPlans();
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show("Plani mesimor nuk u azhornua sepse ka ndodhur nje gabim ne server.");

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
                MessageBox.Show("Please select a plan mesimor to update.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           if (dataGridViewPlaniMesimor.SelectedRows.Count > 0)
            {
                int planMesimorId = Convert.ToInt32(dataGridViewPlaniMesimor.SelectedRows[0].Cells["ID"].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM PLANI_MESIMOR WHERE id = @planMesimorId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@planMesimorId", planMesimorId);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    MessageBox.Show("Plani mesimor u fshi me sukses.");
                    InitializeLessonPlans();
                }
            }
            else
            {
                MessageBox.Show("Please select a plan mesimor to delete.");
            }
        }

    }

}

