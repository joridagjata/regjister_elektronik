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
using FastReport;
using FastReport.Data;
using FastReport.Export.Pdf;
using System.Collections;

namespace RegjistriElektronik
{
    public partial class StudentButton : Form
    {
        private SekretariSpace _sekretariSpace;

        private string connectionString = @"Data Source=DESKTOP-1USP24N\SQLEXPRESS;Initial Catalog=Regjisterdb;Integrated Security=True;TrustServerCertificate=True";

        public StudentButton(SekretariSpace sekretariSpace)
        {
            InitializeComponent();
            _sekretariSpace = sekretariSpace;

        }

        private void StudentButtonSekretari_Load(object sender, EventArgs e)
        {
            LoadStudentData();
        }

        private void LoadStudentData()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-1USP24N\SQLEXPRESS;Initial Catalog=Regjisterdb;Integrated Security=True;TrustServerCertificate=True");
            string query = "SELECT s.ID, u.EMER_MBIEMER, u.EMAIL, u.PASSWORD, s.CARD_ID, g.EMER AS GRUPI, g.VITI_AKADEMIK, g.DEGA " +
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
                    dataGridViewStudent.DataSource = dataTable;
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
                string query = "INSERT INTO USERS (Emer_Mbiemer, Username, Email, Password, Role_id) " +
                                " VALUES (@Emer_Mbiemer, @Username, @Email, @Password, (select id from roles where code = 'STD'))";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Emer_Mbiemer", txtEmriStudentit.Text);
                    cmd.Parameters.AddWithValue("@Username", txtUsernameStudent.Text);
                    cmd.Parameters.AddWithValue("@Email", txtStudentEmail.Text);
                    cmd.Parameters.AddWithValue("@Password", txtBoxPasswordStudent.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                //Gjeneron nje kod unik, i cili do te perfaqesoje CARD_ID
                Guid generatedId = Guid.NewGuid();
                string CARD_ID = generatedId.ToString();

                string queryInsertProfesor = " INSERT INTO STUDENT(USER_ID, CARD_ID, GROUP_ID)" +
                                                " VALUES ((select id from users where username = @Username) " +
                                                " , @cardId " +
                                                " , (select id from GROUPS where CODE = @GroupCode))";

                using (SqlCommand cmd = new SqlCommand(queryInsertProfesor, conn))
                {
                    cmd.Parameters.AddWithValue("@GroupCode", txtStudentGroupCode.Text);
                    cmd.Parameters.AddWithValue("@cardId", CARD_ID);
                    cmd.Parameters.AddWithValue("@Username", txtUsernameStudent.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student added successfully.");
                    LoadStudentData();
                }

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudent.SelectedRows.Count > 0)
            {
                int studentID = Convert.ToInt32(dataGridViewStudent.SelectedRows[0].Cells["ID"].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE users " +
                        " SET Emer_Mbiemer = @Emer_Mbiemer, Email = @Email, Username = @Username, Password = @Password " +
                        " WHERE id = (select user_id from student where id = @studentID)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentID", studentID);
                        cmd.Parameters.AddWithValue("@Emer_Mbiemer", txtEmriStudentit.Text);
                        cmd.Parameters.AddWithValue("@Username", txtUsernameStudent.Text);
                        cmd.Parameters.AddWithValue("@Email", txtStudentEmail.Text);
                        cmd.Parameters.AddWithValue("@Password", txtBoxPasswordStudent.Text);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    string queryProfUpdate = "UPDATE STUDENT " +
                        " SET GROUP_ID = (SELECT ID FROM GROUPS WHERE CODE = @groupCode) " +
                        " WHERE STUDENT.ID = @studentID";
                    using (SqlCommand cmd = new SqlCommand(queryProfUpdate, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentID", studentID);
                        cmd.Parameters.AddWithValue("@groupCode", txtStudentGroupCode.Text);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Student updated successfully.");
                        LoadStudentData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a Student to update.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudent.SelectedRows.Count > 0)
            {
                int studentId = Convert.ToInt32(dataGridViewStudent.SelectedRows[0].Cells["ID"].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string queryUserId = "SELECT USER_ID FROM Student WHERE id = @studentId";
                    SqlCommand cmdUserId = new SqlCommand(queryUserId, conn);
                    cmdUserId.Parameters.AddWithValue("@studentId", studentId);

                    SqlDataAdapter daUserId = new SqlDataAdapter(cmdUserId);
                    DataTable dataTableUserId = new DataTable();
                    daUserId.Fill(dataTableUserId);
                    string userId = dataTableUserId.Rows[0]["USER_ID"].ToString();

                    string query = "DELETE FROM Student WHERE id = @studentId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentId", studentId);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    string queryUser = "DELETE FROM Users WHERE id = @userId";
                    using (SqlCommand cmd = new SqlCommand(queryUser, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    MessageBox.Show("Student deleted successfully.");
                    LoadStudentData();
                }
            }
            else
            {
                MessageBox.Show("Please select a student to delete.");
            }
        }

        private void btnLogoutStudent_Click(object sender, EventArgs e)
        {
            _sekretariSpace.Show();
            this.Close();
        }

        

        
    }
        }
