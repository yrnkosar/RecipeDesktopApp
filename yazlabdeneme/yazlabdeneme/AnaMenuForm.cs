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
    public partial class AnaMenuForm : Form
    {
        public AnaMenuForm()
        {
            InitializeComponent();
        }
        private DataTable dataTable; 

        private void AnaMenuForm_Load(object sender, EventArgs e)
        {
            string connectionString = "Server=YAREN-DESKTOP\\SQLEXPRESS;Database=TarifRehberi;Integrated Security=True;";
            
            radioButtonEslesmeArtan.Visible = false;
            radioButtonEslesmeAzalan.Visible = false;
           
            LoadTarifler(connectionString);
            KategoriYukle();
            LoadCheckedListBoxWithMalzemeler(); 
            CalculateAndAddCosts(); 
           
            radioButtonSureArtan.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            radioButtonSureAzalan.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            radioButtonMaliyetArtan.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            radioButtonMaliyetAzalan.CheckedChanged += new EventHandler(radioButton_CheckedChanged);

            dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
        }

        private void LoadCheckedListBoxWithMalzemeler()
        {
            string connectionString = "Server=YAREN-DESKTOP\\SQLEXPRESS;Database=TarifRehberi;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MalzemeID, MalzemeAdi FROM Malzemeler";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

             
                DataView dataView = dataTable.DefaultView;
                dataView.Sort = "MalzemeAdi ASC"; 
                DataTable sortedTable = dataView.ToTable(); 
              
                checkedListBox1.Items.Clear(); 
                foreach (DataRow row in sortedTable.Rows)
                {
                    string malzemeAdi = row["MalzemeAdi"].ToString();
                    int malzemeID = Convert.ToInt32(row["MalzemeID"]);

                    checkedListBox1.Items.Add(new KeyValuePair<int, string>(malzemeID, malzemeAdi));
                }

                checkedListBox1.DisplayMember = "Value";
                checkedListBox1.ValueMember = "Key";
            }
        }
        private void LoadTarifler(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                  
                    string query = "SELECT T.TarifID, T.TarifAdi, K.KategoriAdi, T.Sure, T.Maliyet " +
                                   "FROM Tarifler T " +
                                   "JOIN Kategoriler K ON T.KategoriID = K.KategoriID " +
                                   "ORDER BY T.TarifAdi ASC";

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                  
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.Columns["TarifID"].Visible = false;
                    CheckAndHighlightIngredients();
                    CalculateAndAddCosts(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tarifler yüklenirken hata: " + ex.Message);
                }
            }

        }
        private void KategoriYukle()
        {
            string connectionString = "Server=YAREN-DESKTOP\\SQLEXPRESS;Database=TarifRehberi;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT KategoriID, KategoriAdi FROM Kategoriler";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable kategoriTable = new DataTable();
                    dataAdapter.Fill(kategoriTable);

                   
                    comboBoxKategoriler.DisplayMember = "KategoriAdi";
                    comboBoxKategoriler.ValueMember = "KategoriID";
                    comboBoxKategoriler.DataSource = kategoriTable;
                    comboBoxKategoriler.SelectedIndex = -1; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kategoriler yüklenirken hata: " + ex.Message);
                }
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {

            ApplySortAfterEslesmeOrani();
            ApplyFiltersAndSorting();
            CalculateAndAddCosts();

            if (radioButtonSureArtan.Checked)
            {
                SortDataGridView("Sure", true);  
            }
            else if (radioButtonSureAzalan.Checked)
            {
                SortDataGridView("Sure", false);  
            }
            else if (radioButtonMaliyetArtan.Checked)
            {
                SortDataGridView("Maliyet", true);  
            }
            else if (radioButtonMaliyetAzalan.Checked)
            {
                SortDataGridView("Maliyet", false);  
            }
            else if (radioButtonEslesmeArtan.Checked)
            {
                SortDataGridView("EslesmeOrani", true); 
            }
            else if (radioButtonEslesmeAzalan.Checked)
            {
                SortDataGridView("EslesmeOrani", false);  
            }
        }
      
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { 
            if (e.RowIndex >= 0) 
            {
                int tarifID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["TarifID"].Value);

               
                TarifiGoruntule detayForm = new TarifiGoruntule(tarifID);
                detayForm.ShowDialog(); 
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string aramaMetni = textBox1.Text;

            if (string.IsNullOrWhiteSpace(aramaMetni)) 
            {
               
                dataGridView1.DataSource = null; 
                return;
            }

            string connectionString = "Server=YAREN-DESKTOP\\SQLEXPRESS;Database=TarifRehberi;Integrated Security=True;";
            string query = @"SELECT DISTINCT T.TarifID, T.TarifAdi, K.KategoriAdi, T.Sure, T.Maliyet 
                     FROM Tarifler T 
                     JOIN Kategoriler K ON T.KategoriID = K.KategoriID 
                     JOIN TarifMalzemeleri TM ON T.TarifID = TM.TarifID 
                     JOIN Malzemeler M ON TM.MalzemeID = M.MalzemeID 
                     WHERE T.TarifAdi LIKE @arama 
                     OR K.KategoriAdi LIKE @arama 
                     OR M.MalzemeAdi LIKE @arama 
                     ORDER BY T.TarifAdi ASC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@arama", "%" + aramaMetni + "%");

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                    CheckAndHighlightIngredients();

                    if (dataTable.Rows.Count == 0) 
                    {
                       
                         MessageBox.Show("Arama sonucu bulunamadı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Arama sırasında hata: " + ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {


            string aramaMetni = textBox1.Text;

            if (string.IsNullOrWhiteSpace(aramaMetni)) 
            {
                MessageBox.Show("Lütfen bir arama terimi girin.");
                return;
            }

            string connectionString = "Server=YAREN-DESKTOP\\SQLEXPRESS;Database=TarifRehberi;Integrated Security=True;";
            string query = @"SELECT DISTINCT T.TarifID, T.TarifAdi, K.KategoriAdi, T.Sure, T.Maliyet 
                     FROM Tarifler T 
                     JOIN Kategoriler K ON T.KategoriID = K.KategoriID 
                     JOIN TarifMalzemeleri TM ON T.TarifID = TM.TarifID 
                     JOIN Malzemeler M ON TM.MalzemeID = M.MalzemeID 
                     WHERE T.TarifAdi LIKE @arama 
                     OR K.KategoriAdi LIKE @arama 
                     OR M.MalzemeAdi LIKE @arama 
                     ORDER BY T.TarifAdi ASC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@arama", "%" + aramaMetni + "%"); 

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    dataTable = new DataTable(); 
                    dataAdapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                    CheckAndHighlightIngredients();

                    if (dataTable.Rows.Count == 0) 
                    {
                        MessageBox.Show("Arama sonucu bulunamadı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Arama sırasında hata: " + ex.Message);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
        
            YeniTarifEkleme yeniTarif = new YeniTarifEkleme();
            yeniTarif.Show();
            this.Hide(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.CurrentRow != null)
            {
                int tarifID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TarifID"].Value);
                TarifDetaylariDuzenForm tarifGuncelleme = new TarifDetaylariDuzenForm(tarifID);
                tarifGuncelleme.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek için bir tarif seçin.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            if (dataGridView1.CurrentRow != null)
            {
                int tarifID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TarifID"].Value);

               
                DialogResult result = MessageBox.Show("Bu tarifi silmek istediğinizden emin misiniz?", "Tarif Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    string connectionString = "Server=YAREN-DESKTOP\\SQLEXPRESS;Database=TarifRehberi;Integrated Security=True;";
                    string query = "DELETE FROM Tarifler WHERE TarifID = @tarifID";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@tarifID", tarifID);
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Tarif başarıyla silindi.");
                               
                                AnaMenuForm_Load(sender, e);
                                CheckAndHighlightIngredients();
                            }
                            else
                            {
                                MessageBox.Show("Tarif silinirken bir sorun oluştu.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Veritabanı hatası: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir tarif seçin.");
            }
        }

      

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonSureArtan_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSureArtan.Checked)
            {
                SortDataGridView("Sure", true);
            }
        }

        private void radioButtonSureAzalan_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSureAzalan.Checked)
            {
                SortDataGridView("Sure", false);
            }
        }

        private void radioButtonMaliyetArtan_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonMaliyetArtan.Checked)
            {
                SortDataGridView("Maliyet", true);
            }
        }

        private void radioButtonMaliyetAzalan_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonMaliyetAzalan.Checked)
            {
                SortDataGridView("Maliyet", false);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            GirisEkrani girisForm = new GirisEkrani(); 
            girisForm.Show();  
            this.Hide();  
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void comboBoxKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void numericUpDownMaliyetMin_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void numericUpDownMaliyetMax_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void numericUpDownMalzemeMin_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void numericUpDownMalzemeMax_ValueChanged(object sender, EventArgs e)
        {
            
        }
        private void CheckAndHighlightIngredients()
        {
            string connectionString = "Server=YAREN-DESKTOP\\SQLEXPRESS;Database=TarifRehberi;Integrated Security=True;MultipleActiveResultSets=True;";

         
            Dictionary<int, bool> recipeAvailability = new Dictionary<int, bool>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

               
                string recipeQuery = "SELECT rm.TarifID, m.MalzemeAdi, rm.Miktar " +
                                     "FROM TarifMalzemeleri rm " +
                                     "JOIN Malzemeler m ON rm.MalzemeID = m.MalzemeID;";

                using (SqlCommand recipeCommand = new SqlCommand(recipeQuery, connection))
                {
                    using (SqlDataReader reader = recipeCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int recipeID = reader.GetInt32(0);
                            string malzemeAdi = reader.GetString(1);
                            double gerekliMiktar = reader.GetDouble(2); 

                            string stockQuery = "SELECT ToplamMiktar FROM Malzemeler WHERE MalzemeAdi = @MalzemeAdi";
                            using (SqlCommand stockCommand = new SqlCommand(stockQuery, connection))
                            {
                                stockCommand.Parameters.AddWithValue("@MalzemeAdi", malzemeAdi);

                              
                                object result = stockCommand.ExecuteScalar();

                                
                                double stockAmount = (result != DBNull.Value) ? Convert.ToDouble(result) : 0;

                                if (!recipeAvailability.ContainsKey(recipeID))
                                {
                                    recipeAvailability[recipeID] = true; 
                                }

                                if (stockAmount < gerekliMiktar)
                                {
                                    recipeAvailability[recipeID] = false; 
                                }
                            }
                        }
                    }
                }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    int recipeID = Convert.ToInt32(row.Cells["TarifID"].Value);
                    if (recipeAvailability.TryGetValue(recipeID, out bool isAvailable))
                    {
                        row.DefaultCellStyle.BackColor = isAvailable ? Color.DarkSeaGreen : Color.Salmon;
                    }
                }
            }
        }
        private void CalculateAndAddCosts()
        {
            string connectionString = "Server=YAREN-DESKTOP\\SQLEXPRESS;Database=TarifRehberi;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
            SELECT T.TarifID, 
                   SUM(CASE 
                        WHEN M.ToplamMiktar < TM.Miktar THEN (TM.Miktar - ISNULL(M.ToplamMiktar, 0)) * M.BirimFiyat
                        ELSE 0
                   END) AS EksikMaliyet
            FROM Tarifler T
            LEFT JOIN TarifMalzemeleri TM ON T.TarifID = TM.TarifID
            LEFT JOIN Malzemeler M ON TM.MalzemeID = M.MalzemeID
            GROUP BY T.TarifID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (!dataGridView1.Columns.Contains("HesaplananMaliyet"))
                    {
                        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Hesaplanan Maliyet", Name = "HesaplananMaliyet" });
                    }

                    while (reader.Read())
                    {
                        int tarifID = reader.GetInt32(0); 
                       double eksikMaliyet = reader.IsDBNull(1) ? 0 : reader.GetDouble(1); 
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (Convert.ToInt32(row.Cells["TarifID"].Value) == tarifID)
                            {
                                row.Cells["HesaplananMaliyet"].Value = eksikMaliyet;
                                break;
                            }
                        }
                    }
                }
            }
        }

        
        private void SortDataGridView(string sortColumn, bool ascending)
        {
            var dataSource = dataGridView1.DataSource;

            DataTable dataTable;

            if (dataSource is DataView dataView)
            {
                dataTable = dataView.ToTable();  
            }
            else if (dataSource is DataTable)
            {
                dataTable = (DataTable)dataSource; 
            }
            else
            {
                MessageBox.Show("Veri kaynağı geçerli bir tablo değil.");
                return;
            }

           
            if (dataTable != null)
            {
                DataView dataViewSorted = dataTable.DefaultView;
                dataViewSorted.Sort = sortColumn + (ascending ? " ASC" : " DESC");
                dataGridView1.DataSource = dataViewSorted;
            }
            CheckAndHighlightIngredients();
            CalculateAndAddCosts();
        }

        private void ApplyFiltersAndSorting()
        {
            
            string connectionString = "Server=YAREN-DESKTOP\\SQLEXPRESS;Database=TarifRehberi;Integrated Security=True;";

            string query = @"SELECT T.TarifID, T.TarifAdi, K.KategoriAdi, T.Sure, T.Maliyet 
             FROM Tarifler T
             JOIN Kategoriler K ON T.KategoriID = K.KategoriID
             JOIN TarifMalzemeleri TM ON T.TarifID = TM.TarifID
             WHERE 1=1";  

            
            if (comboBoxKategoriler.SelectedIndex != -1)
            {
                query += " AND T.KategoriID = @kategoriID";
            }

           
            if (numericUpDownMaliyetMin.Value > 0 || numericUpDownMaliyetMax.Value > 0)
            {
                query += " AND T.Maliyet BETWEEN @maliyetMin AND @maliyetMax";
            }

            if (numericUpDownMalzemeMin.Value > 0 || numericUpDownMalzemeMax.Value > 0)
            {
                query += " GROUP BY T.TarifID, T.TarifAdi, K.KategoriAdi, T.Sure, T.Maliyet HAVING COUNT(TM.MalzemeID) BETWEEN @malzemeMin AND @malzemeMax";
            }
            else
            {
                query += " GROUP BY T.TarifID, T.TarifAdi, K.KategoriAdi, T.Sure, T.Maliyet"; 
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open(); 

                    SqlCommand command = new SqlCommand(query, connection);

                    if (comboBoxKategoriler.SelectedIndex != -1)
                    {
                        command.Parameters.AddWithValue("@kategoriID", comboBoxKategoriler.SelectedValue);
                    }

                    command.Parameters.AddWithValue("@maliyetMin", numericUpDownMaliyetMin.Value);
                    command.Parameters.AddWithValue("@maliyetMax", numericUpDownMaliyetMax.Value);
                    command.Parameters.AddWithValue("@malzemeMin", numericUpDownMalzemeMin.Value);
                    command.Parameters.AddWithValue("@malzemeMax", numericUpDownMalzemeMax.Value);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable; 

                    CheckAndHighlightIngredients();
                    CalculateAndAddCosts();

                 
                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("Filtrelere uyan tarif bulunamadı.");
                    }
                }
                catch (Exception ex)
                {
             
                    MessageBox.Show("Filtreleme sırasında hata: " + ex.Message);
                }
            }
        }
        private void btnFiltrele_Click(object sender, EventArgs e)
        {

            ApplyFiltersAndSorting();

        }

        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        
                private void btnEslesmeOraniHesapla_Click(object sender, EventArgs e)
                {

                    List<int> selectedMalzemeIDs = new List<int>();

                    foreach (KeyValuePair<int, string> item in checkedListBox1.CheckedItems)
                    {
                        selectedMalzemeIDs.Add(item.Key); 
                    }

                    if (selectedMalzemeIDs.Count == 0)
                    {
                        MessageBox.Show("Lütfen en az bir malzeme seçin.");
                        return;
                    }

                    string malzemeIDs = string.Join(",", selectedMalzemeIDs);


                    string connectionString = "Server=YAREN-DESKTOP\\SQLEXPRESS;Database=TarifRehberi;Integrated Security=True;";
                    string query = $@"SELECT T.TarifID, T.TarifAdi, K.KategoriAdi, T.Sure, T.Maliyet,
                     (SELECT COUNT(*) FROM TarifMalzemeleri TM WHERE TM.TarifID = T.TarifID AND TM.MalzemeID IN ({malzemeIDs})) AS EslesenMalzemeSayisi,
                     (SELECT COUNT(*) FROM TarifMalzemeleri TM WHERE TM.TarifID = T.TarifID) AS ToplamMalzemeSayisi
                     FROM Tarifler T
                     JOIN Kategoriler K ON T.KategoriID = K.KategoriID
                     WHERE T.TarifID IN (SELECT DISTINCT TM.TarifID FROM TarifMalzemeleri TM WHERE TM.MalzemeID IN ({malzemeIDs}))";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand(query, connection);

                            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                            DataTable dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);

                            
                            dataTable.Columns.Add("EslesmeOrani", typeof(double));

                            foreach (DataRow row in dataTable.Rows)
                            {
                                int eslesenMalzemeSayisi = Convert.ToInt32(row["EslesenMalzemeSayisi"]);
                                int toplamMalzemeSayisi = Convert.ToInt32(row["ToplamMalzemeSayisi"]);

                                if (toplamMalzemeSayisi > 0)
                                {
                                    double eslesmeOrani = (double)eslesenMalzemeSayisi / toplamMalzemeSayisi * 100;
                                    row["EslesmeOrani"] = Math.Round(eslesmeOrani, 2); 
                                }
                                else
                                {
                                    row["EslesmeOrani"] = 0; 
                                }
                            }

                       
                            dataGridView1.DataSource = dataTable;
                            CheckAndHighlightIngredients();
                    CalculateAndAddCosts(); 
                    ApplySortAfterEslesmeOrani();
                       
                            radioButtonEslesmeArtan.Visible = true;
                            radioButtonEslesmeAzalan.Visible = true;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Eşleşme oranı hesaplama sırasında hata: " + ex.Message);
                        }
                    }
                }

        /*private void btnEslesmeOraniHesapla_Click(object sender, EventArgs e)
        {
            List<int> selectedMalzemeIDs = new List<int>();

            foreach (KeyValuePair<int, string> item in checkedListBox1.CheckedItems)
            {
                selectedMalzemeIDs.Add(item.Key);
            }

            if (selectedMalzemeIDs.Count == 0)
            {
                MessageBox.Show("Lütfen en az bir malzeme seçin.");
                return;
            }

            string malzemeIDs = string.Join(",", selectedMalzemeIDs);

            string connectionString = "Server=YAREN-DESKTOP\\SQLEXPRESS;Database=TarifRehberi;Integrated Security=True;";
            string query = $@"SELECT T.TarifID, T.TarifAdi, K.KategoriAdi, T.Sure, T.Maliyet,
      (SELECT COUNT(TM.MalzemeID) FROM TarifMalzemeleri TM WHERE TM.TarifID = T.TarifID AND TM.MalzemeID IN ({malzemeIDs})) AS EslesenMalzemeSayisi
      FROM Tarifler T
      JOIN Kategoriler K ON T.KategoriID = K.KategoriID
      WHERE T.TarifID IN (SELECT DISTINCT TM.TarifID FROM TarifMalzemeleri TM WHERE TM.MalzemeID IN ({malzemeIDs}))";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                   
                    dataTable.Columns.Add("EslesmeOrani", typeof(double));

                    foreach (DataRow row in dataTable.Rows)
                    {
                        int eslesenMalzemeSayisi = Convert.ToInt32(row["EslesenMalzemeSayisi"]);
                        int secilenMalzemeSayisi = selectedMalzemeIDs.Count;

                        
                        if (secilenMalzemeSayisi > 0)
                        {
                            
                            double eslesmeOrani = (double)eslesenMalzemeSayisi / secilenMalzemeSayisi * 100;
                            row["EslesmeOrani"] = Math.Round(eslesmeOrani, 2); 
                        }
                        else
                        {
                            row["EslesmeOrani"] = 0; 
                        }
                    }

                   
                    dataGridView1.DataSource = dataTable;
                    CheckAndHighlightIngredients();

                    ApplySortAfterEslesmeOrani();

                
                    radioButtonEslesmeArtan.Visible = true;
                    radioButtonEslesmeAzalan.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eşleşme oranı hesaplama sırasında hata: " + ex.Message);
                }
            }
        }*/

        private void ApplySortAfterEslesmeOrani()
        {
            if (radioButtonSureArtan.Checked)
            {
                SortDataGridView("Sure", true); 
            }
            else if (radioButtonSureAzalan.Checked)
            {
                SortDataGridView("Sure", false); 
            }
            else if (radioButtonMaliyetArtan.Checked)
            {
                SortDataGridView("Maliyet", true);  
            }
            else if (radioButtonMaliyetAzalan.Checked)
            {
                SortDataGridView("Maliyet", false);  
            }
            else if (radioButtonEslesmeArtan.Checked)
            {
                SortDataGridView("EslesmeOrani", true);  
            }
            else if (radioButtonEslesmeAzalan.Checked)
            {
                SortDataGridView("EslesmeOrani", false); 
            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSifirla_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=YAREN-DESKTOP\\SQLEXPRESS;Database=TarifRehberi;Integrated Security=True;";

           
            comboBoxKategoriler.SelectedIndex = -1;
            numericUpDownMaliyetMin.Value = 0;
            numericUpDownMaliyetMax.Value = 0;
            numericUpDownMalzemeMin.Value = 0;
            numericUpDownMalzemeMax.Value = 0;

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false); 
            }

            radioButtonSureArtan.Checked = false;
            radioButtonSureAzalan.Checked = false;
            radioButtonMaliyetArtan.Checked = false;
            radioButtonMaliyetAzalan.Checked = false;
            radioButtonEslesmeArtan.Checked = false;
            radioButtonEslesmeAzalan.Checked = false;
            radioButtonEslesmeArtan.Visible = false;
            radioButtonEslesmeAzalan.Visible = false;
           
            LoadTarifler(connectionString);
        }

        private void radioButtonEslesmeArtan_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEslesmeArtan.Checked)
            {
                SortDataGridView("EslesmeOrani", true);  
            }
        }

        private void radioButtonEslesmeAzalan_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEslesmeAzalan.Checked)
            {
                SortDataGridView("EslesmeOrani", false);  
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}