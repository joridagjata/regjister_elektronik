using FastReport;
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

namespace RegjistriElektronik
{
    public partial class ListPrezencacs : Form
    {
        private ProfesorSpace profesorSpace;

        string connectionString = "Data Source=DESKTOP-1USP24N\\SQLEXPRESS;Initial Catalog=Regjisterdb;Integrated Security=True;";

        public ListPrezencacs(ProfesorSpace profesorSpace)
        {
            InitializeComponent();
            this.profesorSpace = profesorSpace;
        }

        private void btnGjenero_Click(object sender, EventArgs e)
        {
            string query = " select l.emer as Lenda, g.emer as Grupi, p.KOHA_E_CHECKIN as Data, u.emer_mbiemer as Studenti, p.PREZENT Frekuentimi " +
               " from PJESEMARRJA p" +
               " inner join ORAR_MESIMOR om on om.id = p.ORAR_MESIMOR_ID " +
               " inner join LENDET l on l.ID = om.LENDA_ID " +
               " inner join GROUPS g on g.ID = om.GROUP_ID " +
               " inner join STUDENT s on s.id = p.STUDENT_ID " +
               " inner join USERS u on u.id = s.user_id " +
               " where (@lenda IS NULL or l.EMER = @lenda) " +
               " and ( @grupi IS NULL or g.code = @grupi ) " +
               " and (@data IS NULL or p.KOHA_E_CHECKIN = @data) ";

            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@lenda", txtLenda.Text);
                    command.Parameters.AddWithValue("@grupi", txtGrupiMesimor.Text);
                    DateTime selectedDate = dataECheckIn.Value;
                    string formattedDate = selectedDate.ToString("yyyy-MM-dd");
                    command.Parameters.AddWithValue("@data", formattedDate);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }

                using (Report report = new Report())
                {
                    report.Load("C:\\Users\\User\\Desktop\\RaportiIFrekuentimit.frx");

                    // Register the DataTable with the report
                    report.RegisterData(dataTable, "MyTable");

                    // Ensure the report binds the data
                    report.GetDataSource("MyTable").Enabled = true;

                    // Show the report preview (or print directly if needed)
                    report.Show();
                    // Alternatively, you can print directly: report.Print();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
