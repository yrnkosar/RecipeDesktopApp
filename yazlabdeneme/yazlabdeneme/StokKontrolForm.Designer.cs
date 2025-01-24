namespace yazlabdeneme
{
    partial class StokKontrolForm
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
            comboBox1 = new ComboBox();
            numericUpDown1 = new NumericUpDown();
            dataGridView1 = new DataGridView();
            btnMalzemeEkle = new Button();
            btnMalzemeSil = new Button();
            btnGeri = new Button();
            pictureBox1 = new PictureBox();
            txtStokArama = new TextBox();
            btnMalzemeDuzenle = new Button();
            txtMaliyet = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.LightSalmon;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(634, 67);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // numericUpDown1
            // 
            numericUpDown1.BackColor = Color.LightSalmon;
            numericUpDown1.Location = new Point(634, 127);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 27);
            numericUpDown1.TabIndex = 1;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.AntiqueWhite;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(84, 67);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(418, 377);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnMalzemeEkle
            // 
            btnMalzemeEkle.BackColor = Color.DarkOliveGreen;
            btnMalzemeEkle.ForeColor = SystemColors.ButtonHighlight;
            btnMalzemeEkle.Location = new Point(691, 179);
            btnMalzemeEkle.Name = "btnMalzemeEkle";
            btnMalzemeEkle.Size = new Size(94, 30);
            btnMalzemeEkle.TabIndex = 3;
            btnMalzemeEkle.Text = "Ekle";
            btnMalzemeEkle.UseVisualStyleBackColor = false;
            btnMalzemeEkle.Click += btnMalzemeEkle_Click;
            // 
            // btnMalzemeSil
            // 
            btnMalzemeSil.BackColor = Color.DarkOliveGreen;
            btnMalzemeSil.ForeColor = SystemColors.Control;
            btnMalzemeSil.Location = new Point(428, 469);
            btnMalzemeSil.Name = "btnMalzemeSil";
            btnMalzemeSil.Size = new Size(74, 30);
            btnMalzemeSil.TabIndex = 5;
            btnMalzemeSil.Text = "Sil";
            btnMalzemeSil.UseVisualStyleBackColor = false;
            btnMalzemeSil.Click += btnMalzemeSil_Click;
            // 
            // btnGeri
            // 
            btnGeri.BackColor = Color.CornflowerBlue;
            btnGeri.ForeColor = SystemColors.ButtonHighlight;
            btnGeri.Location = new Point(672, 315);
            btnGeri.Name = "btnGeri";
            btnGeri.Size = new Size(183, 29);
            btnGeri.TabIndex = 6;
            btnGeri.Text = "Geri ";
            btnGeri.UseVisualStyleBackColor = false;
            btnGeri.Click += btnGeri_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = Properties.Resources.a99u6owju;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(672, 350);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(183, 193);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // txtStokArama
            // 
            txtStokArama.BackColor = Color.LightSalmon;
            txtStokArama.Cursor = Cursors.IBeam;
            txtStokArama.Location = new Point(123, 25);
            txtStokArama.Name = "txtStokArama";
            txtStokArama.Size = new Size(334, 27);
            txtStokArama.TabIndex = 8;
            txtStokArama.Text = "Aramak için malzeme giriniz.";
            txtStokArama.TextAlign = HorizontalAlignment.Right;
            txtStokArama.TextChanged += txtStokArama_TextChanged;
            // 
            // btnMalzemeDuzenle
            // 
            btnMalzemeDuzenle.BackColor = Color.DarkOliveGreen;
            btnMalzemeDuzenle.ForeColor = SystemColors.Control;
            btnMalzemeDuzenle.Location = new Point(316, 469);
            btnMalzemeDuzenle.Name = "btnMalzemeDuzenle";
            btnMalzemeDuzenle.Size = new Size(74, 30);
            btnMalzemeDuzenle.TabIndex = 9;
            btnMalzemeDuzenle.Text = "Düzenle";
            btnMalzemeDuzenle.UseVisualStyleBackColor = false;
            btnMalzemeDuzenle.Click += btnMalzemeDuzenle_Click;
            // 
            // txtMaliyet
            // 
            txtMaliyet.BackColor = Color.LightSalmon;
            txtMaliyet.Location = new Point(176, 471);
            txtMaliyet.Name = "txtMaliyet";
            txtMaliyet.Size = new Size(112, 27);
            txtMaliyet.TabIndex = 10;
            txtMaliyet.TextChanged += txtMaliyet_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(81, 474);
            label1.Name = "label1";
            label1.Size = new Size(89, 20);
            label1.TabIndex = 11;
            label1.Text = "Yeni Maliyet";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Moccasin;
            label2.Location = new Point(634, 44);
            label2.Name = "label2";
            label2.Size = new Size(97, 20);
            label2.TabIndex = 12;
            label2.Text = "Malzeme Adı";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Moccasin;
            label3.Location = new Point(634, 104);
            label3.Name = "label3";
            label3.Size = new Size(51, 20);
            label3.TabIndex = 13;
            label3.Text = "Miktar";
            // 
            // StokKontrolForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Moccasin;
            BackgroundImage = Properties.Resources.arkaplan;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(889, 564);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtMaliyet);
            Controls.Add(btnMalzemeDuzenle);
            Controls.Add(txtStokArama);
            Controls.Add(pictureBox1);
            Controls.Add(btnGeri);
            Controls.Add(btnMalzemeSil);
            Controls.Add(btnMalzemeEkle);
            Controls.Add(dataGridView1);
            Controls.Add(numericUpDown1);
            Controls.Add(comboBox1);
            Name = "StokKontrolForm";
            Text = "StokKontrolForm";
            Load += StokKontrolForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private NumericUpDown numericUpDown1;
        private DataGridView dataGridView1;
        private Button btnMalzemeEkle;
        private Button btnMalzemeSil;
        private Button btnGeri;
        private PictureBox pictureBox1;
        private TextBox txtStokArama;
        private Button btnMalzemeDuzenle;
        private TextBox txtMaliyet;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}