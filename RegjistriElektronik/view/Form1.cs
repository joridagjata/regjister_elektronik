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

namespace RegjistriElektronik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnHyr_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-1USP24N\SQLEXPRESS;Initial Catalog=Regjisterdb;Integrated Security=True;TrustServerCertificate=True");
            try
            {
                conn.Open();
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                // Query to fetch username, password, and role
                string query = "SELECT Username, Password, Role_id FROM Users WHERE Username = @username AND Password = @password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);

                // Check if the user exists
                if (dataTable.Rows.Count > 0)
                {
                    // Get the role from the result
                    string RoleId = dataTable.Rows[0]["Role_id"].ToString();
                    string QueryRole = "SELECT code FROM Roles WHERE id = @roleId";
                    SqlCommand cmdRole = new SqlCommand(QueryRole, conn);
                    cmdRole.Parameters.AddWithValue("@roleId", RoleId);

                    SqlDataAdapter daRole = new SqlDataAdapter(cmdRole);
                    DataTable dataTableRole = new DataTable();
                    daRole.Fill(dataTableRole);
                    string role = dataTableRole.Rows[0]["code"].ToString();

                    // Navigate to the appropriate space based on the role
                    
                    if (role.Equals("ADMIN", StringComparison.OrdinalIgnoreCase))
                    {
                     AdminSpace adminSpace= new AdminSpace(this);
                        adminSpace.Show();
                    }
                    else if (role.Equals("SCRT", StringComparison.OrdinalIgnoreCase))
                    {
                        SekretariSpace sekretariForm = new SekretariSpace(this);
                        sekretariForm.Show();
                    }
                    else if (role.Equals("PRF", StringComparison.OrdinalIgnoreCase))
                    {
                        ProfesorSpace profesorForm = new ProfesorSpace(this);
                        profesorForm.Show();
                    }
                    else if (role.Equals("STD", StringComparison.OrdinalIgnoreCase))
                    {
                        StudentSpace studentform = new StudentSpace(this);
                        studentform.Show();
                    }

                    this.txtPassword.Text = string.Empty;
                    this.txtUsername.Text = string.Empty;
                    // Hide the login form
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
