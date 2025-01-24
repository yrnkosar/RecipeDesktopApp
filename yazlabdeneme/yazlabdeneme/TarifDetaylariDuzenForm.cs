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

namespace yazlabdeneme
{
    public partial class TarifDetaylariDuzenForm : Form
    {
        private int tarifID;
        private string connectionString = "Server=YAREN-DESKTOP\\SQLEXPRESS;Database=TarifRehberi;Integrated Security=True;";
        private bool gorselDegistirildi = false; 

        public TarifDetaylariDuzenForm(int id)
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
                string query = "SELECT m.MalzemeID, m.MalzemeAdi, tm.Miktar " +
                               "FROM TarifMalzemeleri tm " +
                               "JOIN Malzemeler m ON tm.MalzemeID = m.MalzemeID " +
                               "WHERE tm.TarifID = @TarifID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TarifID", tarifID);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridViewMalzemeler.DataSource = dataTable;

                dataGridViewMalzemeler.Columns["MalzemeID"].Visible = false; 
            }
        }

        private void TarifDetaylariDuzenForm_Load(object sender, EventArgs e)
        {

        }

        private void txtSure_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTalimatlar_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewMalzemeler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnGorselDegistir_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp"; 
                openFileDialog.Title = "Bir Resim Dosyası Seçin"; 

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string dosyaYolu = openFileDialog.FileName;
                        pictureBox1.Image = Image.FromFile(dosyaYolu);
                        gorselDegistirildi = true; 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Görsel yükleme hatası: {ex.Message}");
                    }
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Tarifler SET TarifAdi = @TarifAdi, Sure = @Sure, Talimatlar = @Talimatlar" +
                               (gorselDegistirildi ? ", Gorsel = @Gorsel" : "") +
                               " WHERE TarifID = @TarifID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TarifAdi", txtTarifAdi.Text);
                command.Parameters.AddWithValue("@Sure", txtSure.Text);
                command.Parameters.AddWithValue("@Talimatlar", txtTalimatlar.Text);
                command.Parameters.AddWithValue("@TarifID", tarifID);

                if (gorselDegistirildi)
                {
                    if (pictureBox1.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            command.Parameters.Add("@Gorsel", SqlDbType.VarBinary).Value = ms.ToArray();
                        }
                    }
                }

                command.ExecuteNonQuery();

                decimal toplamMaliyet = ToplamMaliyetHesapla();
                MessageBox.Show($"Değişiklikler kaydedildi. Toplam Maliyet: {toplamMaliyet:C}");

                string updateMaliyetQuery = "UPDATE Tarifler SET Maliyet = @Maliyet WHERE TarifID = @TarifID";
                SqlCommand updateCommand = new SqlCommand(updateMaliyetQuery, connection);
                updateCommand.Parameters.AddWithValue("@Maliyet", toplamMaliyet);
                updateCommand.Parameters.AddWithValue("@TarifID", tarifID);
                updateCommand.ExecuteNonQuery();
            }

            AnaMenuForm anaMenuForm = new AnaMenuForm();
            anaMenuForm.Show();
            this.Close();
        }

        private void btnMalzemeDuzenle_Click(object sender, EventArgs e)
        {
            if (dataGridViewMalzemeler.CurrentRow != null && dataGridViewMalzemeler.CurrentRow.Cells["MalzemeID"] != null)
            {
                int malzemeID = Convert.ToInt32(dataGridViewMalzemeler.CurrentRow.Cells["MalzemeID"].Value);
                MalzemeDuzenleForm duzenleForm = new MalzemeDuzenleForm(malzemeID, tarifID);
                duzenleForm.ShowDialog();

            }
            else
            {
                MessageBox.Show("Lütfen düzenlemek istediğiniz bir malzeme seçin.");
            }
        }

        private void btnMalzemeEkle_Click(object sender, EventArgs e)
        {

            MalzemeEkDuzen malzemeEkleForm = new MalzemeEkDuzen(tarifID);
            if (malzemeEkleForm.ShowDialog() == DialogResult.OK)
            {
                MalzemeleriYukle();
            }
        }

        private void btnMalzemeSil_Click(object sender, EventArgs e)
        {

            if (dataGridViewMalzemeler.CurrentRow != null && dataGridViewMalzemeler.CurrentRow.Cells["MalzemeID"] != null)
            {
                int malzemeID = Convert.ToInt32(dataGridViewMalzemeler.CurrentRow.Cells["MalzemeID"].Value);

                DialogResult dialogResult = MessageBox.Show("Bu malzemeyi silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "DELETE FROM TarifMalzemeleri WHERE MalzemeID = @MalzemeID AND TarifID = @TarifID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@MalzemeID", malzemeID);
                        command.Parameters.AddWithValue("@TarifID", tarifID); 

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Malzeme başarıyla silindi.");
                            MalzemeleriYukle();
                        }
                        else
                        {
                            MessageBox.Show("Silme işlemi sırasında bir hata oluştu. Lütfen tekrar deneyin.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz bir malzeme seçin.");
            }
        }
        private decimal ToplamMaliyetHesapla()
        {
            decimal toplamMaliyet = 0;

            foreach (DataGridViewRow row in dataGridViewMalzemeler.Rows)
            {
                if (row.IsNewRow) continue; 

                var malzemeAdi = row.Cells["MalzemeAdi"].Value?.ToString();
                var miktarValue = row.Cells["Miktar"].Value;

                if (!string.IsNullOrEmpty(malzemeAdi) && miktarValue != null)
                {
                    if (decimal.TryParse(miktarValue.ToString(), out decimal miktar) && miktar > 0)
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string query = "SELECT BirimFiyat FROM Malzemeler WHERE MalzemeAdi = @MalzemeAdi";
                            SqlCommand cmd = new SqlCommand(query, connection);
                            cmd.Parameters.AddWithValue("@MalzemeAdi", malzemeAdi);

                            object result = cmd.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                            {
                                decimal birimMaliyet = (decimal)result;
                                decimal malzemeMaliyeti = miktar * birimMaliyet;
                                toplamMaliyet += malzemeMaliyeti;
                            }
                        }
                    }
                }
            }

            return toplamMaliyet;
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
           
            AnaMenuForm anaMenuForm = new AnaMenuForm();
            anaMenuForm.Show();

            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
