namespace yazlabdeneme
{
    partial class AnaMenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label2 = new Label();
            label1 = new Label();
            radioButtonMaliyetAzalan = new RadioButton();
            radioButtonMaliyetArtan = new RadioButton();
            radioButtonSureAzalan = new RadioButton();
            radioButtonSureArtan = new RadioButton();
            button4 = new Button();
            textBox1 = new TextBox();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            btnGeri = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            panel1 = new Panel();
            label10 = new Label();
            btnFiltrele = new Button();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            numericUpDownMalzemeMax = new NumericUpDown();
            numericUpDownMalzemeMin = new NumericUpDown();
            numericUpDownMaliyetMax = new NumericUpDown();
            numericUpDownMaliyetMin = new NumericUpDown();
            comboBoxKategoriler = new ComboBox();
            panel2 = new Panel();
            btnEslesmeOraniHesapla = new Button();
            checkedListBox1 = new CheckedListBox();
            btnSifirla = new Button();
            pictureBox1 = new PictureBox();
            radioButtonEslesmeArtan = new RadioButton();
            radioButtonEslesmeAzalan = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMalzemeMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMalzemeMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMaliyetMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMaliyetMin).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Linen;
            label2.Location = new Point(761, 66);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 26;
            label2.Text = "Filtreleme";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Linen;
            label1.Location = new Point(761, 390);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 25;
            label1.Text = "Sıralama";
            label1.Click += label1_Click;
            // 
            // radioButtonMaliyetAzalan
            // 
            radioButtonMaliyetAzalan.AutoSize = true;
            radioButtonMaliyetAzalan.BackColor = Color.Linen;
            radioButtonMaliyetAzalan.Location = new Point(761, 503);
            radioButtonMaliyetAzalan.Name = "radioButtonMaliyetAzalan";
            radioButtonMaliyetAzalan.Size = new Size(151, 24);
            radioButtonMaliyetAzalan.TabIndex = 24;
            radioButtonMaliyetAzalan.TabStop = true;
            radioButtonMaliyetAzalan.Text = "Maliyet (Çok->Az)";
            radioButtonMaliyetAzalan.UseVisualStyleBackColor = false;
            radioButtonMaliyetAzalan.CheckedChanged += radioButtonMaliyetAzalan_CheckedChanged;
            // 
            // radioButtonMaliyetArtan
            // 
            radioButtonMaliyetArtan.AutoSize = true;
            radioButtonMaliyetArtan.BackColor = Color.Linen;
            radioButtonMaliyetArtan.Location = new Point(761, 473);
            radioButtonMaliyetArtan.Name = "radioButtonMaliyetArtan";
            radioButtonMaliyetArtan.Size = new Size(155, 24);
            radioButtonMaliyetArtan.TabIndex = 23;
            radioButtonMaliyetArtan.TabStop = true;
            radioButtonMaliyetArtan.Text = "Maliyet (Az->Çok )";
            radioButtonMaliyetArtan.UseVisualStyleBackColor = false;
            radioButtonMaliyetArtan.CheckedChanged += radioButtonMaliyetArtan_CheckedChanged;
            // 
            // radioButtonSureAzalan
            // 
            radioButtonSureAzalan.AutoSize = true;
            radioButtonSureAzalan.BackColor = Color.Linen;
            radioButtonSureAzalan.Location = new Point(761, 443);
            radioButtonSureAzalan.Name = "radioButtonSureAzalan";
            radioButtonSureAzalan.Size = new Size(213, 24);
            radioButtonSureAzalan.TabIndex = 22;
            radioButtonSureAzalan.TabStop = true;
            radioButtonSureAzalan.Text = "Hazırlama Süresi (Çok->Az)";
            radioButtonSureAzalan.UseVisualStyleBackColor = false;
            radioButtonSureAzalan.CheckedChanged += radioButtonSureAzalan_CheckedChanged;
            // 
            // radioButtonSureArtan
            // 
            radioButtonSureArtan.AutoSize = true;
            radioButtonSureArtan.BackColor = Color.Linen;
            radioButtonSureArtan.Location = new Point(761, 413);
            radioButtonSureArtan.Name = "radioButtonSureArtan";
            radioButtonSureArtan.Size = new Size(213, 24);
            radioButtonSureArtan.TabIndex = 21;
            radioButtonSureArtan.TabStop = true;
            radioButtonSureArtan.Text = "Hazırlama Süresi (Az->Çok)";
            radioButtonSureArtan.UseVisualStyleBackColor = false;
            radioButtonSureArtan.CheckedChanged += radioButtonSureArtan_CheckedChanged;
            // 
            // button4
            // 
            button4.BackColor = Color.DarkKhaki;
            button4.Location = new Point(332, 45);
            button4.Name = "button4";
            button4.Size = new Size(71, 29);
            button4.TabIndex = 19;
            button4.Text = "Ara";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Linen;
            textBox1.Location = new Point(28, 47);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(298, 27);
            textBox1.TabIndex = 18;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button3
            // 
            button3.BackColor = Color.SandyBrown;
            button3.Location = new Point(516, 390);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 17;
            button3.Text = "Sil";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.SandyBrown;
            button2.Location = new Point(267, 390);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 16;
            button2.Text = "Güncelle";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.SandyBrown;
            button1.Location = new Point(45, 390);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 15;
            button1.Text = "Tarif Ekle";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = Color.Bisque;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(30, 92);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(601, 290);
            dataGridView1.TabIndex = 14;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnGeri
            // 
            btnGeri.BackColor = Color.SandyBrown;
            btnGeri.Location = new Point(12, 479);
            btnGeri.Name = "btnGeri";
            btnGeri.Size = new Size(208, 29);
            btnGeri.TabIndex = 27;
            btnGeri.Text = "Geri";
            btnGeri.UseVisualStyleBackColor = false;
            btnGeri.Click += btnGeri_Click;
            // 
            // label3
            // 
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 96);
            label4.Name = "label4";
            label4.Size = new Size(34, 20);
            label4.TabIndex = 6;
            label4.Text = "Min";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(173, 96);
            label5.Name = "label5";
            label5.Size = new Size(37, 20);
            label5.TabIndex = 7;
            label5.Text = "Max";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(36, 180);
            label6.Name = "label6";
            label6.Size = new Size(34, 20);
            label6.TabIndex = 8;
            label6.Text = "Min";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(173, 180);
            label7.Name = "label7";
            label7.Size = new Size(37, 20);
            label7.TabIndex = 9;
            label7.Text = "Max";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(25, 67);
            label8.Name = "label8";
            label8.Size = new Size(62, 20);
            label8.TabIndex = 10;
            label8.Text = "Maliyet ";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(25, 149);
            label9.Name = "label9";
            label9.Size = new Size(120, 20);
            label9.TabIndex = 11;
            label9.Text = "Malzeme Miktari";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(label10);
            panel1.Controls.Add(btnFiltrele);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(label16);
            panel1.Controls.Add(numericUpDownMalzemeMax);
            panel1.Controls.Add(numericUpDownMalzemeMin);
            panel1.Controls.Add(numericUpDownMaliyetMax);
            panel1.Controls.Add(numericUpDownMaliyetMin);
            panel1.Controls.Add(comboBoxKategoriler);
            panel1.Location = new Point(761, 92);
            panel1.Name = "panel1";
            panel1.Size = new Size(290, 265);
            panel1.TabIndex = 30;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Linen;
            label10.Location = new Point(25, 149);
            label10.Name = "label10";
            label10.Size = new Size(120, 20);
            label10.TabIndex = 11;
            label10.Text = "Malzeme Miktari";
            // 
            // btnFiltrele
            // 
            btnFiltrele.BackColor = Color.DarkOliveGreen;
            btnFiltrele.ForeColor = SystemColors.ControlLightLight;
            btnFiltrele.Location = new Point(196, 221);
            btnFiltrele.Name = "btnFiltrele";
            btnFiltrele.Size = new Size(80, 28);
            btnFiltrele.TabIndex = 31;
            btnFiltrele.Text = "Filtrele";
            btnFiltrele.UseVisualStyleBackColor = false;
            btnFiltrele.Click += btnFiltrele_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Linen;
            label11.Location = new Point(25, 67);
            label11.Name = "label11";
            label11.Size = new Size(62, 20);
            label11.TabIndex = 10;
            label11.Text = "Maliyet ";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Linen;
            label12.Location = new Point(173, 180);
            label12.Name = "label12";
            label12.Size = new Size(37, 20);
            label12.TabIndex = 9;
            label12.Text = "Max";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Linen;
            label13.Location = new Point(36, 180);
            label13.Name = "label13";
            label13.Size = new Size(34, 20);
            label13.TabIndex = 8;
            label13.Text = "Min";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Linen;
            label14.Location = new Point(173, 96);
            label14.Name = "label14";
            label14.Size = new Size(37, 20);
            label14.TabIndex = 7;
            label14.Text = "Max";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Linen;
            label15.Location = new Point(33, 96);
            label15.Name = "label15";
            label15.Size = new Size(34, 20);
            label15.TabIndex = 6;
            label15.Text = "Min";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Linen;
            label16.Location = new Point(25, 27);
            label16.Name = "label16";
            label16.Size = new Size(83, 20);
            label16.TabIndex = 5;
            label16.Text = "Kategoriler";
            // 
            // numericUpDownMalzemeMax
            // 
            numericUpDownMalzemeMax.BackColor = Color.Linen;
            numericUpDownMalzemeMax.Location = new Point(216, 178);
            numericUpDownMalzemeMax.Name = "numericUpDownMalzemeMax";
            numericUpDownMalzemeMax.Size = new Size(60, 27);
            numericUpDownMalzemeMax.TabIndex = 4;
            numericUpDownMalzemeMax.ValueChanged += numericUpDownMalzemeMax_ValueChanged;
            // 
            // numericUpDownMalzemeMin
            // 
            numericUpDownMalzemeMin.BackColor = Color.Linen;
            numericUpDownMalzemeMin.Location = new Point(76, 178);
            numericUpDownMalzemeMin.Name = "numericUpDownMalzemeMin";
            numericUpDownMalzemeMin.Size = new Size(60, 27);
            numericUpDownMalzemeMin.TabIndex = 3;
            numericUpDownMalzemeMin.ValueChanged += numericUpDownMalzemeMin_ValueChanged;
            // 
            // numericUpDownMaliyetMax
            // 
            numericUpDownMaliyetMax.BackColor = Color.Linen;
            numericUpDownMaliyetMax.Location = new Point(216, 94);
            numericUpDownMaliyetMax.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownMaliyetMax.Name = "numericUpDownMaliyetMax";
            numericUpDownMaliyetMax.Size = new Size(60, 27);
            numericUpDownMaliyetMax.TabIndex = 2;
            numericUpDownMaliyetMax.ValueChanged += numericUpDownMaliyetMax_ValueChanged;
            // 
            // numericUpDownMaliyetMin
            // 
            numericUpDownMaliyetMin.BackColor = Color.Linen;
            numericUpDownMaliyetMin.Location = new Point(76, 94);
            numericUpDownMaliyetMin.Name = "numericUpDownMaliyetMin";
            numericUpDownMaliyetMin.Size = new Size(60, 27);
            numericUpDownMaliyetMin.TabIndex = 1;
            numericUpDownMaliyetMin.ValueChanged += numericUpDownMaliyetMin_ValueChanged;
            // 
            // comboBoxKategoriler
            // 
            comboBoxKategoriler.BackColor = Color.Linen;
            comboBoxKategoriler.FormattingEnabled = true;
            comboBoxKategoriler.Location = new Point(114, 24);
            comboBoxKategoriler.Name = "comboBoxKategoriler";
            comboBoxKategoriler.Size = new Size(162, 28);
            comboBoxKategoriler.TabIndex = 0;
            comboBoxKategoriler.SelectedIndexChanged += comboBoxKategoriler_SelectedIndexChanged;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(btnEslesmeOraniHesapla);
            panel2.Controls.Add(checkedListBox1);
            panel2.Location = new Point(1077, 92);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 497);
            panel2.TabIndex = 32;
            panel2.Paint += panel2_Paint;
            // 
            // btnEslesmeOraniHesapla
            // 
            btnEslesmeOraniHesapla.BackColor = Color.Peru;
            btnEslesmeOraniHesapla.Location = new Point(3, 449);
            btnEslesmeOraniHesapla.Name = "btnEslesmeOraniHesapla";
            btnEslesmeOraniHesapla.Size = new Size(244, 45);
            btnEslesmeOraniHesapla.TabIndex = 1;
            btnEslesmeOraniHesapla.Text = "Malzemeleri seç";
            btnEslesmeOraniHesapla.UseVisualStyleBackColor = false;
            btnEslesmeOraniHesapla.Click += btnEslesmeOraniHesapla_Click;
            // 
            // checkedListBox1
            // 
            checkedListBox1.BackColor = Color.DarkKhaki;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(3, 3);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(244, 444);
            checkedListBox1.TabIndex = 0;
            checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged_1;
            // 
            // btnSifirla
            // 
            btnSifirla.BackColor = Color.SandyBrown;
            btnSifirla.Location = new Point(1077, 33);
            btnSifirla.Name = "btnSifirla";
            btnSifirla.Size = new Size(247, 52);
            btnSifirla.TabIndex = 33;
            btnSifirla.Text = "Filtreleri Sıfırla";
            btnSifirla.UseVisualStyleBackColor = false;
            btnSifirla.Click += btnSifirla_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = Properties.Resources.ca85ff9d93475ec3aa8811013ea13e9d;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(12, 514);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(208, 175);
            pictureBox1.TabIndex = 34;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // radioButtonEslesmeArtan
            // 
            radioButtonEslesmeArtan.AutoSize = true;
            radioButtonEslesmeArtan.BackColor = Color.Linen;
            radioButtonEslesmeArtan.Location = new Point(761, 533);
            radioButtonEslesmeArtan.Name = "radioButtonEslesmeArtan";
            radioButtonEslesmeArtan.Size = new Size(195, 24);
            radioButtonEslesmeArtan.TabIndex = 35;
            radioButtonEslesmeArtan.TabStop = true;
            radioButtonEslesmeArtan.Text = "Eşleşme Oranı (Az->Çok)";
            radioButtonEslesmeArtan.UseVisualStyleBackColor = false;
            radioButtonEslesmeArtan.CheckedChanged += radioButtonEslesmeArtan_CheckedChanged;
            // 
            // radioButtonEslesmeAzalan
            // 
            radioButtonEslesmeAzalan.AutoSize = true;
            radioButtonEslesmeAzalan.BackColor = Color.Linen;
            radioButtonEslesmeAzalan.Location = new Point(761, 565);
            radioButtonEslesmeAzalan.Name = "radioButtonEslesmeAzalan";
            radioButtonEslesmeAzalan.Size = new Size(195, 24);
            radioButtonEslesmeAzalan.TabIndex = 36;
            radioButtonEslesmeAzalan.TabStop = true;
            radioButtonEslesmeAzalan.Text = "Eşleşme Oranı (Çok->Az)";
            radioButtonEslesmeAzalan.UseVisualStyleBackColor = false;
            radioButtonEslesmeAzalan.CheckedChanged += radioButtonEslesmeAzalan_CheckedChanged;
            // 
            // AnaMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = Properties.Resources.arkaplan;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1384, 701);
            Controls.Add(radioButtonEslesmeAzalan);
            Controls.Add(radioButtonEslesmeArtan);
            Controls.Add(btnSifirla);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(btnGeri);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(radioButtonMaliyetAzalan);
            Controls.Add(radioButtonMaliyetArtan);
            Controls.Add(radioButtonSureAzalan);
            Controls.Add(radioButtonSureArtan);
            Controls.Add(button4);
            Controls.Add(textBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(pictureBox1);
            Name = "AnaMenuForm";
            Text = "AnaMenuForm";
            Load += AnaMenuForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMalzemeMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMalzemeMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMaliyetMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMaliyetMin).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label1;
        private RadioButton radioButtonMaliyetAzalan;
        private RadioButton radioButtonMaliyetArtan;
        private RadioButton radioButtonSureAzalan;
        private RadioButton radioButtonSureArtan;
        private Button button4;
        private TextBox textBox1;
        private Button button3;
        private Button button2;
        private Button button1;
        private DataGridView dataGridView1;
        private Button btnGeri;
      
   
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Panel panel1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private NumericUpDown numericUpDownMalzemeMax;
        private NumericUpDown numericUpDownMalzemeMin;
        private NumericUpDown numericUpDownMaliyetMax;
        private NumericUpDown numericUpDownMaliyetMin;
        private ComboBox comboBoxKategoriler;
        private Button btnFiltrele;
        private Panel panel2;
        private Button btnEslesmeOraniHesapla;
        private CheckedListBox checkedListBox1;
        private Button btnSifirla;
        private PictureBox pictureBox1;
        private RadioButton radioButtonEslesmeArtan;
        private RadioButton radioButtonEslesmeAzalan;
    }
}