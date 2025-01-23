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

        string connectionString = "Data Source=DESKTOP-1USP24N\\SQLEXPRESS;Initial Catalog=Regjisterdb;Integrated Security=True;";
        public MenaxhoOrarMesimor(ProfesorSpace profesorSpace)
        {
            InitializeComponent();
            this.profesorSpace = profesorSpace; 
        }

        private void btnHap_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE ORAR_MESIMOR SET STATUS = 1 WHERE" +
                    " LENDA_ID = (select id from LENDET WHERE EMER = @emerLende)" +
                    " and GROUP_ID = (select id from groups where code = @groupCode) " +
                    " and PROFESOR_ID = (select p.id from profesor p inner join users u on u.id = p.user_id where u.username = @profesorUsername) " +
                    " and SALLA_ID = (select id from salla where emer = @emerSalle) " +
                    " and DITA_E_JAVES = @ditaEJaves" +
                    " and NGA_ORA = @ngaOra" +
                    " and DERI_NE_ORA = @deriNeOra" +
                    " ";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@emerLende", txtLenda.Text);
                    cmd.Parameters.AddWithValue("@groupCode", txtGrupiMesimor.Text);
                    cmd.Parameters.AddWithValue("@profesorUsername", txtProfesor.Text);
                    cmd.Parameters.AddWithValue("@emerSalle", txtSalla.Text);
                    cmd.Parameters.AddWithValue("@ditaEJaves", textBoxDitaeJaves.Text);
                    cmd.Parameters.AddWithValue("@ngaOra", txtNgaOra.Text);
                    cmd.Parameters.AddWithValue("@deriNeOra", txtNeOre.Text);

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

        private void btnMbyll_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE ORAR_MESIMOR SET STATUS = 0 WHERE" +
                    " LENDA_ID = (select id from LENDET WHERE EMER = @emerLende)" +
                    " and GROUP_ID = (select id from groups where code = @groupCode) " +
                    " and PROFESOR_ID = (select p.id from profesor p inner join users u on u.id = p.user_id where u.username = @profesorUsername) " +
                    " and SALLA_ID = (select id from salla where emer = @emerSalle) " +
                    " and DITA_E_JAVES = @ditaEJaves" +
                    " and NGA_ORA = @ngaOra" +
                    " and DERI_NE_ORA = @deriNeOra" +
                    " ";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@emerLende", txtLenda.Text);
                    cmd.Parameters.AddWithValue("@groupCode", txtGrupiMesimor.Text);
                    cmd.Parameters.AddWithValue("@profesorUsername", txtProfesor.Text);
                    cmd.Parameters.AddWithValue("@emerSalle", txtSalla.Text);
                    cmd.Parameters.AddWithValue("@ditaEJaves", textBoxDitaeJaves.Text);
                    cmd.Parameters.AddWithValue("@ngaOra", txtNgaOra.Text);
                    cmd.Parameters.AddWithValue("@deriNeOra", txtNeOre.Text);

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

        private void picLogoutMenaxhoOrarinMesimor_Click(object sender, EventArgs e)
        {
            profesorSpace.Show();
            this.Close();
        }
    }
}
