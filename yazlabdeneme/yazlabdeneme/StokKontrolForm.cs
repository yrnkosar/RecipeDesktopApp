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
    public partial class StokKontrolForm : Form
    {
        string connectionString = "Server=YAREN-DESKTOP\\SQLEXPRESS;Database=TarifRehberi;Integrated Security=True;";
        public StokKontrolForm()
        {
            InitializeComponent();

        }

        private void StokKontrolForm_Load(object sender, EventArgs e)
        {
            LoadStokMalzemeleri();
            LoadMalzemeComboBox();
            comboBox1.DropDownHeight = 150;
        }

        private void LoadStokMalzemeleri()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT m.MalzemeID, m.MalzemeAdi, m.ToplamMiktar, m.MalzemeBirim, m.BirimFiyat " +
                               "FROM Malzemeler m;";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;

                dataGridView1.Columns["MalzemeID"].Visible = false;  
                dataGridView1.Columns["MalzemeAdi"].HeaderText = "Malzeme Adı";
                dataGridView1.Columns["ToplamMiktar"].HeaderText = "Toplam Miktar";
                dataGridView1.Columns["MalzemeBirim"].HeaderText = "Birim";
                dataGridView1.Columns["BirimFiyat"].HeaderText = "Maliyet"; 
            }
        }
        private void LoadMalzemeComboBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MalzemeID, MalzemeAdi FROM Malzemeler";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                comboBox1.DisplayMember = "MalzemeAdi";
                comboBox1.ValueMember = "MalzemeID";
                comboBox1.DataSource = dataTable;
             
                comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
                foreach (DataRow row in dataTable.Rows)
                {
                    autoCompleteCollection.Add(row["MalzemeAdi"].ToString());
                }
                comboBox1.AutoCompleteCustomSource = autoCompleteCollection;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnMalzemeEkle_Click(object sender, EventArgs e)
        {
            int malzemeID = Convert.ToInt32(comboBox1.SelectedValue);
            int miktar = Convert.ToInt32(numericUpDown1.Value); 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

       
                string updateQuery = "UPDATE Malzemeler SET ToplamMiktar = ToplamMiktar + @Miktar WHERE MalzemeID = @MalzemeID";
                SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddWithValue("@MalzemeID", malzemeID);
                updateCommand.Parameters.AddWithValue("@Miktar", miktar);
                updateCommand.ExecuteNonQuery();
            }

            LoadStokMalzemeleri();
        }



        private void btnMalzemeSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int malzemeID = Convert.ToInt32(row.Cells["MalzemeID"].Value);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Malzemeler WHERE MalzemeID = @MalzemeID";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MalzemeID", malzemeID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                LoadStokMalzemeleri(); 
                MessageBox.Show("Malzeme başarıyla silindi.");
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir malzeme seçin.");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                comboBox1.Text = row.Cells["MalzemeAdi"].Value.ToString();
                numericUpDown1.Value = Convert.ToDecimal(row.Cells["ToplamMiktar"].Value);
                txtMaliyet.Text = row.Cells["BirimFiyat"].Value.ToString(); 
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            GirisEkrani girisForm = new GirisEkrani(); 
            girisForm.Show();  
            this.Hide();  
        }

        private void txtStokArama_TextChanged(object sender, EventArgs e)
        {

            string searchText = txtStokArama.Text.Trim();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT m.MalzemeID, m.MalzemeAdi, m.ToplamMiktar, m.MalzemeBirim " +
                               "FROM Malzemeler m " +
                               "WHERE m.MalzemeAdi LIKE @SearchText";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SearchText", "%" + searchText + "%"); 

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;

                dataGridView1.Columns["MalzemeID"].Visible = false; 
                dataGridView1.Columns["MalzemeAdi"].HeaderText = "Malzeme Adı";
                dataGridView1.Columns["ToplamMiktar"].HeaderText = "Toplam Miktar";
                dataGridView1.Columns["MalzemeBirim"].HeaderText = "Birim";
            }
        }

        private void btnMalzemeDuzenle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int malzemeID = Convert.ToInt32(row.Cells["MalzemeID"].Value);

                int yeniMiktar = Convert.ToInt32(numericUpDown1.Value);
                decimal yeniMaliyet = Convert.ToDecimal(txtMaliyet.Text); 

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE Malzemeler SET ToplamMiktar = @Miktar, BirimFiyat = @Maliyet WHERE MalzemeID = @MalzemeID";
                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@MalzemeID", malzemeID);
                    command.Parameters.AddWithValue("@Miktar", yeniMiktar);
                    command.Parameters.AddWithValue("@Maliyet", yeniMaliyet);

                    command.ExecuteNonQuery();
                }

                LoadStokMalzemeleri(); 
                MessageBox.Show("Malzeme başarıyla güncellendi.");
            }
            else
            {
                MessageBox.Show("Lütfen düzenlemek için bir malzeme seçin.");
            }
        }

        private void txtMaliyet_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
