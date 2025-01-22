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
    public partial class SekretarButtonAdmincs : Form
    {
        private string connectionString = @"Data Source=DESKTOP-1USP24N\SQLEXPRESS;Initial Catalog=Regjisterdb;Integrated Security=True;TrustServerCertificate=True";

        private Form1 _loginForm;
        public SekretarButtonAdmincs(Form1 loginForm)
        {
            InitializeComponent();
            _loginForm = loginForm;
        }

        private void picLogoutadmin_Click(object sender, EventArgs e)
        {
            // Kthehuni në formën AdminSpace dhe mbyllni formën aktuale
            AdminSpace adminForm = new AdminSpace(_loginForm); // Sigurohuni që të kaloni formën e login-it nëse është e nevojshme
            adminForm.Show();
            this.Close();
        }

        private void SekretarButtonAdmincs_Load(object sender, EventArgs e)
        {
            LoadSekretarData();
        }
        private void LoadSekretarData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT id, Emer_Mbiemer, Username, Email, Password FROM Users where role_id = (select id from roles where code = 'SCRT')";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridViewSekretar.DataSource = dataTable;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO USERS (Emer_Mbiemer, Username, Email, Role_id, Password) VALUES (@Emer_Mbiemer, @Username, @Email, (SELECT ID FROM ROLES WHERE CODE = 'SCRT'), @Password)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Emer_Mbiemer", txtEmriSekretar.Text);
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Secretary added successfully.");
                    LoadSekretarData(); // Refresh the list
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewSekretar.SelectedRows.Count > 0)
            {
                int SekretarID = Convert.ToInt32(dataGridViewSekretar.SelectedRows[0].Cells["ID"].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Users SET Emer_Mbiemer = @Emer_Mbiemer, Email = @Email, Username = @Username, Password = @Password WHERE id = @SekretarID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Emer_Mbiemer", txtEmriSekretar.Text);
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                        cmd.Parameters.AddWithValue("@SekretarID", SekretarID);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Professor updated successfully.");
                        LoadSekretarData(); // Refresh the list
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
            if (dataGridViewSekretar.SelectedRows.Count > 0)
            {
                int SekretarID = Convert.ToInt32(dataGridViewSekretar.SelectedRows[0].Cells["ID"].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Users WHERE ID = @SekretarID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SekretarID", SekretarID);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Secretary deleted successfully.");
                        LoadSekretarData(); // Refresh the list
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a Secretary to delete.");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadSekretarData();
        }

        private void dataGridViewSekretar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewSekretar.Rows[e.RowIndex];
                txtEmriSekretar.Text = row.Cells["Emer_Mbiemer"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString();
               
            }
        }
    }
}
