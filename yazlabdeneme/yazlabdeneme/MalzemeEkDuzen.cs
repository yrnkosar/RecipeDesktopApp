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
    public partial class MalzemeEkDuzen : Form
    {
        private int _tarifID; 
        string connectionString = "Server=YAREN-DESKTOP\\SQLEXPRESS;Database=TarifRehberi;Integrated Security=True;";
        public MalzemeEkDuzen(int tarifID)
        {
            InitializeComponent();
            LoadMalzemeler();
            _tarifID = tarifID;
        }
        private void LoadMalzemeler()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MalzemeID, MalzemeAdi FROM Malzemeler";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "MalzemeAdi";
                comboBox1.ValueMember = "MalzemeID";
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                
                DataRowView selectedRow = (DataRowView)comboBox1.SelectedItem;

               
                int malzemeID = (int)selectedRow["MalzemeID"]; 
                string birim = GetMalzemeBirim(malzemeID); 
                label1.Text = $" {birim}"; 
            }
        }
        private string GetMalzemeBirim(int malzemeID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MalzemeBirim FROM Malzemeler WHERE MalzemeID = @MalzemeID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MalzemeID", malzemeID);

                connection.Open();
                object result = command.ExecuteScalar();

                return result != null ? result.ToString() : "Birim bulunamadı"; 
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null && float.TryParse(textBox1.Text, out float miktar))
            {
                int malzemeID = (int)comboBox1.SelectedValue;

             
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO TarifMalzemeleri (TarifID, MalzemeID, Miktar) VALUES (@TarifID, @MalzemeID, @Miktar)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TarifID", _tarifID);
                        command.Parameters.AddWithValue("@MalzemeID", malzemeID);
                        command.Parameters.AddWithValue("@Miktar", miktar);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery(); 

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Malzeme başarıyla eklendi.");
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("Malzeme eklenirken bir hata oluştu.");
                        }
                    }
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir malzeme ve miktar girin.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            YeniMalzemeEkleme yeniMalzemeFormu = new YeniMalzemeEkleme();
            yeniMalzemeFormu.FormClosed += YeniMalzemeEkle_FormClosed;
            yeniMalzemeFormu.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MalzemeEkDuzen_Load(object sender, EventArgs e)
        {

        }
        private void YeniMalzemeEkle_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadMalzemeler();
        }
    }
}
