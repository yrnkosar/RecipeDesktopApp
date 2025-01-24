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

namespace yazlabdeneme
{
    public partial class TarifiGoruntule : Form
    {
        private int tarifID;
        private string connectionString = "Server=YAREN-DESKTOP\\SQLEXPRESS;Database=TarifRehberi;Integrated Security=True;";

        public TarifiGoruntule(int id)
        {
            InitializeComponent();
            tarifID = id;
            DetaylariYukle();
            MalzemeleriYukle(); 
        }
        private void DetaylariYukle()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT TarifAdi, KategoriID, Sure, Talimatlar, Gorsel FROM Tarifler WHERE TarifID = @TarifID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TarifID", tarifID);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    txtTarifAdi.Text = reader["TarifAdi"].ToString();
                    txtSure.Text = reader["Sure"].ToString();
                    txtTalimatlar.Text = reader["Talimatlar"].ToString();

                    if (reader["Gorsel"] != DBNull.Value)
                    {
                        byte[] gorselVerisi = (byte[])reader["Gorsel"];
                        using (MemoryStream ms = new MemoryStream(gorselVerisi))
                        {
                            pictureBox1.Image = Image.FromStream(ms);
                        }
                    }
                }
            }
        }

        private void MalzemeleriYukle()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT m.MalzemeAdi, tm.Miktar FROM TarifMalzemeleri tm " +
                               "JOIN Malzemeler m ON tm.MalzemeID = m.MalzemeID " +
                               "WHERE tm.TarifID = @TarifID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TarifID", tarifID);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridViewMalzemeler.DataSource = dataTable; 
            }
        }
        private void txtTalimatlar_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewMalzemeler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TarifiGoruntule_Load(object sender, EventArgs e)
        {

        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
         

            this.Close();
        }

        private void txtTarifAdi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSure_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
