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
using System.Xml.Linq;

namespace RegjistriElektronik
{
    public partial class ProfesorButtonAdmin : Form
    {
        private string connectionString = @"Data Source=DESKTOP-1USP24N\SQLEXPRESS;Initial Catalog=Regjisterdb;Integrated Security=True;TrustServerCertificate=True";

        private Form1 _loginForm;
        public ProfesorButtonAdmin(Form1 loginForm)
        {
            InitializeComponent();
            _loginForm = loginForm;
        }

        private void picLogoutadmin_Click(object sender, EventArgs e)
        {
            // Kthehuni në formën AdminSpace dhe mbyllni formën aktuale
            AdminSpace adminForm = new AdminSpace(_loginForm); // Sigurohuni që të kaloni formën e login-it nëse është e nevojshme
            adminForm.Show();
            this.Close();  // Mbyllni formën profesorAdmin
        }

        private void ProfesorButtonAdmin_Load(object sender, EventArgs e)
        {
            LoadProfesorsData();
        }
        private void LoadProfesorsData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT p.id, u.emer_mbiemer, u.email, u.username, u.password, d.emer as Department" +
                    " FROM PROFESOR p " +
                    " INNER JOIN USERS u ON u.ID = p.USER_ID " +
                    " INNER JOIN DEPARTAMENT d ON d.ID = p.DEPARTAMENT_ID ";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridViewProfessors.DataSource = dataTable;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO USERS (Emer_Mbiemer, Username, Email, Password, Role_id) " +
                                " VALUES (@Emer_Mbiemer, @Username, @Email, @Password, (select id from roles where code = 'PRF'))";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Emer_Mbiemer", txtEmriProfesorit.Text);
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                string queryInsertProfesor = " INSERT INTO PROFESOR(USER_ID, DEPARTAMENT_ID)" +
                                                " VALUES ((select id from users where username = @Username), (select id from DEPARTAMENT where CODE = @Department))";

                using (SqlCommand cmd = new SqlCommand(queryInsertProfesor, conn))
                {
                    cmd.Parameters.AddWithValue("@Department", txtDepartament.Text);
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Professor added successfully.");
                    LoadProfesorsData();
                }

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewProfessors.SelectedRows.Count > 0)
            {
                int profesorID = Convert.ToInt32(dataGridViewProfessors.SelectedRows[0].Cells["ID"].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE users " +
                        " SET Emer_Mbiemer = @Emer_Mbiemer, Email = @Email, Username = @Username, Password = @Password " +
                        " WHERE id = (select user_id from profesor where id = @ProfesorID)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProfesorID", profesorID);
                        cmd.Parameters.AddWithValue("@Emer_Mbiemer", txtEmriProfesorit.Text);
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    string queryProfUpdate = "UPDATE PROFESOR SET DEPARTAMENT_ID = (SELECT ID FROM DEPARTAMENT WHERE CODE = @Department)";
                    using (SqlCommand cmd = new SqlCommand(queryProfUpdate, conn))
                    {
                        cmd.Parameters.AddWithValue("@Department", txtDepartament.Text);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Professor updated successfully.");
                        LoadProfesorsData();
                    }
                }      
            }
            else
            {
                MessageBox.Show("Please select a professor to update.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewProfessors.SelectedRows.Count > 0)
            {
                int ProfesorID = Convert.ToInt32(dataGridViewProfessors.SelectedRows[0].Cells["ID"].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string queryUserId = "SELECT USER_ID FROM Profesor WHERE id = @ProfesorID";
                    SqlCommand cmdUserId = new SqlCommand(queryUserId, conn);
                    cmdUserId.Parameters.AddWithValue("@ProfesorID", ProfesorID);

                    SqlDataAdapter daUserId = new SqlDataAdapter(cmdUserId);
                    DataTable dataTableUserId = new DataTable();
                    daUserId.Fill(dataTableUserId);
                    string userId = dataTableUserId.Rows[0]["USER_ID"].ToString();

                    string query = "DELETE FROM Profesor WHERE id = @ProfesorID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProfesorID", ProfesorID);

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

                    MessageBox.Show("Profesor deleted successfully.");
                    LoadProfesorsData();
                }
            }
            else
            {
                MessageBox.Show("Please select a profesor to delete.");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProfesorsData();
        }

        private void dataGridViewProfessors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewProfessors.Rows[e.RowIndex];
                txtEmriProfesorit.Text = row.Cells["Emer_Mbiemer"].Value.ToString();
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString();
                txtDepartament.Text = row.Cells["Department"].Value.ToString();
            }
        }
    }
}