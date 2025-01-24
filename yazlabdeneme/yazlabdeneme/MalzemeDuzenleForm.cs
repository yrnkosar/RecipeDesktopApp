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
    public partial class MalzemeDuzenleForm : Form
    {
        private int malzemeID;
        private int tarifID; 
        private string connectionString = "Server=YAREN-DESKTOP\\SQLEXPRESS;Database=TarifRehberi;Integrated Security=True;";

        public MalzemeDuzenleForm(int malzemeId, int tarifId)
        {
            InitializeComponent();
            malzemeID = malzemeId;
            tarifID = tarifId; 
            MalzemeDetaylariniYukle();
        }
        private void MalzemeDetaylariniYukle()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT m.MalzemeAdi, tm.Miktar FROM Malzemeler m " +
                               "JOIN TarifMalzemeleri tm ON m.MalzemeID = tm.MalzemeID " +
                               "WHERE m.MalzemeID = @MalzemeID AND tm.TarifID = @TarifID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MalzemeID", malzemeID);
                command.Parameters.AddWithValue("@TarifID", tarifID);  

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    txtMalzemeAdi.Text = reader["MalzemeAdi"].ToString();
                    txtMiktar.Text = reader["Miktar"].ToString();
                }
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MalzemeDuzenleForm_Load(object sender, EventArgs e)
        {

        }

        private void txtMalzemeAdi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMiktar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

               
                string queryMalzeme = "UPDATE Malzemeler SET MalzemeAdi = @MalzemeAdi WHERE MalzemeID = @MalzemeID";
                SqlCommand commandMalzeme = new SqlCommand(queryMalzeme, connection);
                commandMalzeme.Parameters.AddWithValue("@MalzemeAdi", txtMalzemeAdi.Text);
                commandMalzeme.Parameters.AddWithValue("@MalzemeID", malzemeID);
                commandMalzeme.ExecuteNonQuery();

               
                string queryMiktar = "UPDATE TarifMalzemeleri SET Miktar = @Miktar WHERE MalzemeID = @MalzemeID AND TarifID = @TarifID";
                SqlCommand commandMiktar = new SqlCommand(queryMiktar, connection);
                commandMiktar.Parameters.AddWithValue("@Miktar", Convert.ToDecimal(txtMiktar.Text));
                commandMiktar.Parameters.AddWithValue("@MalzemeID", malzemeID);
                commandMiktar.Parameters.AddWithValue("@TarifID", tarifID);  
                commandMiktar.ExecuteNonQuery();

                MessageBox.Show("Malzeme bilgileri güncellendi.");
                this.Close();
            }
        }
    }
}
