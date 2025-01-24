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
    public partial class YeniMalzemeEkleme : Form
    {
        string connectionString = "Server=YAREN-DESKTOP\\SQLEXPRESS;Database=TarifRehberi;Integrated Security=True;";

        public YeniMalzemeEkleme()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string malzemeAdi = textBox1.Text;
            string birim = comboBox1.Text;
            string birimMaliyet = textBox2.Text;

            if (!string.IsNullOrEmpty(malzemeAdi) && !string.IsNullOrEmpty(birim) && !string.IsNullOrEmpty(birimMaliyet))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                 
                    string query = "INSERT INTO Malzemeler (MalzemeAdi, MalzemeBirim, BirimFiyat, ToplamMiktar) VALUES (@MalzemeAdi, @Birim, @BirimMaliyet, @ToplamMiktar)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MalzemeAdi", malzemeAdi);
                        cmd.Parameters.AddWithValue("@Birim", birim);
                        cmd.Parameters.AddWithValue("@BirimMaliyet", decimal.Parse(birimMaliyet));
                        cmd.Parameters.AddWithValue("@ToplamMiktar", 0); 

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Yeni malzeme başarıyla eklendi.");
                    this.Close(); 
                }
            }
            else
            {
                MessageBox.Show("Lütfen tüm bilgileri doldurun.");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void YeniMalzemeEkleme_Load(object sender, EventArgs e)
        {
           
            comboBox1.Items.Add("kg");
            comboBox1.Items.Add("Litre");
            comboBox1.Items.Add("adet");
            comboBox1.Items.Add("gram");
        }
    }
}
