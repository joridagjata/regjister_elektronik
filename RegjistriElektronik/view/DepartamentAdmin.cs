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
using static RegjistriElektronik.DepartamentAdmin;

namespace RegjistriElektronik
{
    public partial class DepartamentAdmin : Form
    {
        private string connectionString = @"Data Source=DESKTOP-1USP24N\SQLEXPRESS;Initial Catalog=Regjisterdb;Integrated Security=True;TrustServerCertificate=True";

        private Form1 _loginForm;
        public class Department
        {
            public int ID { get; set; }
            public string Name { get; set; }

            public bool IsOpen { get; set; }

            public Department(string name)
            {
                Name = name;
                IsOpen = false; // Fillimisht, departamenti është mbyllur
            }

            public override string ToString()
            {
                return $"{Name} - {(IsOpen ? "Open" : "Closed")}";
            }
        }

        private List<Department> departments;
        public DepartamentAdmin(Form1 form)
        {
            InitializeComponent();
            _loginForm = form;
            loadDepartments();
        }
        private void loadDepartments()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT ID, Emer, case when status = 1 then 'HAPUR' else 'MBYLLUR' end AS STATUS FROM DEPARTAMENT";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridViewDepartments.DataSource = dataTable;
            }
            
        }

   

    private void buttonToggleDepartment_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewDepartments.SelectedRows.Count >= 0)
            {
                int departamentId= Convert.ToInt32(dataGridViewDepartments.SelectedRows[0].Cells["ID"].Value);
                string status = Convert.ToString(dataGridViewDepartments.SelectedRows[0].Cells["STATUS"].Value);
                int newStatus = 0;
                if (string.IsNullOrEmpty(status) 
                    || string.Equals(status, "MBYLLUR", StringComparison.OrdinalIgnoreCase))
                {
                    newStatus = 1;
                }
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE DEPARTAMENT SET STATUS = @newStatus WHERE id = @departamentId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@departamentId", departamentId);
                        cmd.Parameters.AddWithValue("@newStatus", newStatus);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Departamenti u azhornua me sukses.");
                        loadDepartments(); // Refresh the list
                    }
                }

            }
            else
            {
                MessageBox.Show("Ju lutem, zgjidhni një departament.");
            }
        }

        private void picBackToAdmin_Click(object sender, EventArgs e)
        {
            // Kthehuni në formën AdminSpace dhe mbyllni formën aktuale
            AdminSpace adminForm = new AdminSpace(_loginForm); // Sigurohuni që të kaloni formën e login-it nëse është e nevojshme
            adminForm.Show();
            this.Close();  // Mbyllni formën DepartamentAdmin
        }

        private void listBoxDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}

