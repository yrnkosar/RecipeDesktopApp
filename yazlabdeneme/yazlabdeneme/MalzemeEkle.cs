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
    public partial class MalzemeEkle : Form
    {
        private YeniTarifEkleme _tarifEkleForm;
        private int _tarifID; 
        string connectionString = "Server=YAREN-DESKTOP\\SQLEXPRESS;Database=TarifRehberi;Integrated Security=True;";
      
        public MalzemeEkle(YeniTarifEkleme tarifEkleForm)
        {
            InitializeComponent();
            _tarifEkleForm = tarifEkleForm;
            LoadMalzemeler();
        }
        private void LoadMalzemeler()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MalzemeID, MalzemeAdi FROM Malzemeler ORDER BY MalzemeAdi ASC";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "MalzemeAdi";
                comboBox1.ValueMember = "MalzemeID";
               
                comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }
        private void MalzemeEkle_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null && float.TryParse(textBox1.Text, out float miktar))
            {
                int malzemeID = (int)comboBox1.SelectedValue;
                string malzemeAdi = comboBox1.Text;

               
                if (!MalzemeVarMi(malzemeID))
                {
                    
                    _tarifEkleForm.MalzemeEkle(malzemeID, malzemeAdi, miktar);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Bu malzeme zaten eklenmiş.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir malzeme ve miktar girin.");
            }
        }
        private bool MalzemeVarMi(int malzemeID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM TarifMalzemeleri WHERE MalzemeID = @MalzemeID AND TarifID = @TarifID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MalzemeID", malzemeID);
                command.Parameters.AddWithValue("@TarifID", _tarifEkleForm.TarifID);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0; 
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            YeniMalzemeEkleme yeniMalzemeFormu = new YeniMalzemeEkleme();
            yeniMalzemeFormu.FormClosed += YeniMalzemeEkle_FormClosed; 
            yeniMalzemeFormu.Show();
        }

        private void YeniMalzemeEkle_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            LoadMalzemeler();
        }
    }
}
