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
using System.IO;
using System.Drawing;
using System.Globalization;

namespace yazlabdeneme
{
    public partial class YeniTarifEkleme : Form
    {
        string connectionString = "Server=YAREN-DESKTOP\\SQLEXPRESS;Database=TarifRehberi;Integrated Security=True;";
        public int TarifID { get; set; } 
        public YeniTarifEkleme()
        {
            InitializeComponent();
            KategoriDoldur();
            dataGridView1.CellContentClick += dataGridView1_CellContentClick; 
        }
        
        public void MalzemeEkle(int malzemeID, string malzemeAdi, float miktar)
        {
            dataGridView1.Rows.Add(malzemeID, malzemeAdi, miktar);
        }
        private void KategoriDoldur()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT KategoriID, KategoriAdi FROM Kategoriler", connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(new { Text = reader["KategoriAdi"].ToString(), Value = reader["KategoriID"] });
                    }
                    comboBox1.DisplayMember = "Text";
                    comboBox1.ValueMember = "Value";
                 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kategoriler yüklenirken hata: " + ex.Message);
                }
               
            }
        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                int tarifID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["MalzemeID"].Value);

                TarifDetaylariDuzenForm detayForm = new TarifDetaylariDuzenForm(tarifID);
                detayForm.Show();
            }
        }

        private void txtTarifAdi_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            MalzemeEkle malzemeEkleFormu = new MalzemeEkle(this);
            malzemeEkleFormu.Show();

        }


        private int KategoriEkleVeIDGetir(string kategoriAdi)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                   
                    string kategoriEkleQuery = "INSERT INTO Kategoriler (KategoriAdi) OUTPUT INSERTED.KategoriID VALUES (@KategoriAdi)";
                    SqlCommand command = new SqlCommand(kategoriEkleQuery, connection);
                    command.Parameters.AddWithValue("@KategoriAdi", kategoriAdi);

                    int kategoriID = (int)command.ExecuteScalar();  
                    return kategoriID;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kategori ekleme hatası: " + ex.Message);
                    return -1;  
                }
            }
        }
        private void TarifKaydet(int kategoriID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    
                    byte[] gorselVerisi = null;
                    if (pictureBox1.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                            gorselVerisi = ms.ToArray();
                        }
                    }

                    
                    decimal toplamMaliyet = ToplamMaliyetHesapla();

                   
                    string tarifEkleQuery = "INSERT INTO Tarifler (TarifAdi, KategoriID, Sure, Talimatlar, Gorsel, Maliyet) OUTPUT INSERTED.TarifID VALUES (@TarifAdi, @KategoriID, @Sure, @Talimatlar, @Gorsel, @Maliyet)";
                    SqlCommand command = new SqlCommand(tarifEkleQuery, connection);
                    command.Parameters.AddWithValue("@TarifAdi", txtTarifAdi.Text);
                    command.Parameters.AddWithValue("@KategoriID", kategoriID);
                    command.Parameters.AddWithValue("@Sure", textBox3.Text);
                    command.Parameters.AddWithValue("@Talimatlar", richTextBox1.Text);
                    command.Parameters.AddWithValue("@Gorsel", (object)gorselVerisi ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Maliyet", toplamMaliyet);

                    int tarifID = (int)command.ExecuteScalar();  

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["MalzemeID"].Value != null)
                        {
                            int malzemeID = Convert.ToInt32(row.Cells["MalzemeID"].Value);
                            float miktar = Convert.ToSingle(row.Cells["Miktar"].Value); 

                            
                            if (miktar <= 0)
                            {
                                MessageBox.Show($"'{row.Cells["MalzemeAdi"].Value}' için geçerli bir miktar girin.");
                                return; 
                            }

                            string tarifMalzemeEkleQuery = "INSERT INTO TarifMalzemeleri (TarifID, MalzemeID, Miktar) VALUES (@TarifID, @MalzemeID, @Miktar)";
                            SqlCommand malzemeCommand = new SqlCommand(tarifMalzemeEkleQuery, connection);
                            malzemeCommand.Parameters.AddWithValue("@TarifID", tarifID);
                            malzemeCommand.Parameters.AddWithValue("@MalzemeID", malzemeID);
                            malzemeCommand.Parameters.AddWithValue("@Miktar", miktar); 

                            malzemeCommand.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Tarif ve malzemeler başarıyla kaydedildi.");

                    AnaMenuForm anaMenuForm = new AnaMenuForm();
                    anaMenuForm.Show();
                    this.Close(); 

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            MalzemeSil();  
        }
        
        private void MalzemeSil()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.Remove(row); 
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz malzemeyi seçin.");
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
     private decimal ToplamMaliyetHesapla()
       {
           decimal toplamMaliyet = 0;

           foreach (DataGridViewRow row in dataGridView1.Rows)
           {
               if (row.IsNewRow) continue;

               var malzemeAdi = row.Cells["MalzemeAdi"].Value?.ToString(); 
               var miktarValue = row.Cells["Miktar"].Value;

               if (!string.IsNullOrEmpty(malzemeAdi) && miktarValue != null) 
               {
                 
                   if (!decimal.TryParse(miktarValue.ToString(), out decimal miktar) || miktar <= 0)
                   {
                       MessageBox.Show($"'{malzemeAdi}' için geçerli bir miktar girin.");
                       continue; 
                   }

                  
                   using (SqlConnection connection = new SqlConnection(connectionString))
                   {
                       connection.Open();
                       string query = "SELECT BirimFiyat FROM Malzemeler WHERE MalzemeAdi = @MalzemeAdi";
                       using (SqlCommand cmd = new SqlCommand(query, connection))
                       {
                           cmd.Parameters.AddWithValue("@MalzemeAdi", malzemeAdi);

                           object result = cmd.ExecuteScalar();
                           if (result != null && result != DBNull.Value)
                           {
                               decimal birimMaliyet = (decimal)result; 

                               decimal malzemeMaliyeti = miktar * birimMaliyet;

                               toplamMaliyet += malzemeMaliyeti;
                           }
                           else
                           {
                               MessageBox.Show($"'{malzemeAdi}' için birim maliyet bulunamadı.");
                           }
                       }
                   }
               }
           }

           return toplamMaliyet;
       }
        private void button4_Click_1(object sender, EventArgs e)
        {

            if (TarifVarMi(txtTarifAdi.Text))
            {
                MessageBox.Show("Bu tarif zaten mevcut.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTarifAdi.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Lütfen tarif adı ve süre alanlarını doldurun.");
                return;
            }

            if (comboBox1.SelectedIndex == -1 && !string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                int yeniKategoriID = KategoriEkleVeIDGetir(comboBox1.Text);

                if (yeniKategoriID > 0)
                {
                    TarifKaydet(yeniKategoriID); 
                }
            }
            else if (comboBox1.SelectedIndex != -1)
            {

                int seciliKategoriID = ((dynamic)comboBox1.SelectedItem).Value;
                TarifKaydet(seciliKategoriID); 
            }
            else
            {
                MessageBox.Show("Lütfen bir kategori seçin veya yeni bir kategori ekleyin.");
            }
        }

        private bool TarifVarMi(string tarifAdi)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Tarifler WHERE TarifAdi = @TarifAdi";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TarifAdi", tarifAdi);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0; 
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
       
        private void YeniTarifEkleme_Load(object sender, EventArgs e)
        {

            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "MalzemeID"; 
            dataGridView1.Columns[1].Name = "MalzemeAdi";
            dataGridView1.Columns[2].Name = "Miktar";

           
            dataGridView1.Columns[0].Visible = false;
        }

        private void btnGorselSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp"; 

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
           
            AnaMenuForm anaMenuForm = new AnaMenuForm();
            anaMenuForm.Show();

         
            this.Close();
        }
    }
}
