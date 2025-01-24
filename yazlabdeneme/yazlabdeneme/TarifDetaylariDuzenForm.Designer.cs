namespace yazlabdeneme
{
    partial class TarifDetaylariDuzenForm
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
            pictureBox1 = new PictureBox();
            txtTarifAdi = new TextBox();
            txtSure = new TextBox();
            txtTalimatlar = new RichTextBox();
            dataGridViewMalzemeler = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnGorselDegistir = new Button();
            btnKaydet = new Button();
            btnMalzemeDuzenle = new Button();
            btnMalzemeEkle = new Button();
            btnMalzemeSil = new Button();
            btnGeri = new Button();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMalzemeler).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Linen;
            pictureBox1.Location = new Point(33, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(276, 265);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // txtTarifAdi
            // 
            txtTarifAdi.BackColor = Color.Linen;
            txtTarifAdi.Location = new Point(50, 341);
            txtTarifAdi.Name = "txtTarifAdi";
            txtTarifAdi.Size = new Size(220, 27);
            txtTarifAdi.TabIndex = 1;
            // 
            // txtSure
            // 
            txtSure.BackColor = Color.Linen;
            txtSure.Location = new Point(50, 399);
            txtSure.Name = "txtSure";
            txtSure.Size = new Size(220, 27);
            txtSure.TabIndex = 2;
            txtSure.TextChanged += txtSure_TextChanged;
            // 
            // txtTalimatlar
            // 
            txtTalimatlar.BackColor = Color.Linen;
            txtTalimatlar.Location = new Point(499, 40);
            txtTalimatlar.Name = "txtTalimatlar";
            txtTalimatlar.Size = new Size(323, 120);
            txtTalimatlar.TabIndex = 3;
            txtTalimatlar.Text = "";
            txtTalimatlar.TextChanged += txtTalimatlar_TextChanged;
            // 
            // dataGridViewMalzemeler
            // 
            dataGridViewMalzemeler.BackgroundColor = Color.Linen;
            dataGridViewMalzemeler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMalzemeler.Location = new Point(499, 231);
            dataGridViewMalzemeler.Name = "dataGridViewMalzemeler";
            dataGridViewMalzemeler.RowHeadersWidth = 51;
            dataGridViewMalzemeler.Size = new Size(323, 233);
            dataGridViewMalzemeler.TabIndex = 4;
            dataGridViewMalzemeler.CellContentClick += dataGridViewMalzemeler_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Linen;
            label1.Location = new Point(50, 318);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 5;
            label1.Text = "Tarif Adı";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Linen;
            label2.Location = new Point(50, 376);
            label2.Name = "label2";
            label2.Size = new Size(80, 20);
            label2.TabIndex = 6;
            label2.Text = "Tarif Süresi";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Linen;
            label3.Location = new Point(499, 17);
            label3.Name = "label3";
            label3.Size = new Size(74, 20);
            label3.TabIndex = 7;
            label3.Text = "Talimatlar";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Linen;
            label4.Location = new Point(499, 208);
            label4.Name = "label4";
            label4.Size = new Size(87, 20);
            label4.TabIndex = 8;
            label4.Text = "Malzemeler";
            // 
            // btnGorselDegistir
            // 
            btnGorselDegistir.BackColor = Color.SandyBrown;
            btnGorselDegistir.Location = new Point(215, 283);
            btnGorselDegistir.Name = "btnGorselDegistir";
            btnGorselDegistir.Size = new Size(94, 29);
            btnGorselDegistir.TabIndex = 9;
            btnGorselDegistir.Text = "Değiştir\r\n";
            btnGorselDegistir.UseVisualStyleBackColor = false;
            btnGorselDegistir.Click += btnGorselDegistir_Click;
            // 
            // btnKaydet
            // 
            btnKaydet.BackColor = Color.DarkKhaki;
            btnKaydet.Location = new Point(728, 517);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(94, 29);
            btnKaydet.TabIndex = 10;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = false;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnMalzemeDuzenle
            // 
            btnMalzemeDuzenle.BackColor = Color.SandyBrown;
            btnMalzemeDuzenle.Location = new Point(499, 470);
            btnMalzemeDuzenle.Name = "btnMalzemeDuzenle";
            btnMalzemeDuzenle.Size = new Size(139, 29);
            btnMalzemeDuzenle.TabIndex = 11;
            btnMalzemeDuzenle.Text = "Malzeme Düzenle";
            btnMalzemeDuzenle.UseVisualStyleBackColor = false;
            btnMalzemeDuzenle.Click += btnMalzemeDuzenle_Click;
            // 
            // btnMalzemeEkle
            // 
            btnMalzemeEkle.BackColor = Color.DarkKhaki;
            btnMalzemeEkle.Location = new Point(712, 178);
            btnMalzemeEkle.Name = "btnMalzemeEkle";
            btnMalzemeEkle.Size = new Size(110, 47);
            btnMalzemeEkle.TabIndex = 12;
            btnMalzemeEkle.Text = "Malzeme Ekle";
            btnMalzemeEkle.UseVisualStyleBackColor = false;
            btnMalzemeEkle.Click += btnMalzemeEkle_Click;
            // 
            // btnMalzemeSil
            // 
            btnMalzemeSil.BackColor = Color.SandyBrown;
            btnMalzemeSil.Location = new Point(712, 470);
            btnMalzemeSil.Name = "btnMalzemeSil";
            btnMalzemeSil.Size = new Size(110, 29);
            btnMalzemeSil.TabIndex = 13;
            btnMalzemeSil.Text = "Malzeme Sil";
            btnMalzemeSil.UseVisualStyleBackColor = false;
            btnMalzemeSil.Click += btnMalzemeSil_Click;
            // 
            // btnGeri
            // 
            btnGeri.BackColor = Color.DarkKhaki;
            btnGeri.Location = new Point(50, 499);
            btnGeri.Name = "btnGeri";
            btnGeri.Size = new Size(187, 29);
            btnGeri.TabIndex = 14;
            btnGeri.Text = "Geri";
            btnGeri.UseVisualStyleBackColor = false;
            btnGeri.Click += btnGeri_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImage = Properties.Resources.transparent_salt_shaker_salt_shaker_glass_bottle_kitchen_seaso_plain_salt_bottle_with_black_lettering65e28bb06029e1_6165942617093457123939;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(50, 440);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(187, 129);
            pictureBox2.TabIndex = 15;
            pictureBox2.TabStop = false;
            // 
            // TarifDetaylariDuzenForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.arkaplan;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(899, 578);
            Controls.Add(btnGeri);
            Controls.Add(btnMalzemeSil);
            Controls.Add(btnMalzemeEkle);
            Controls.Add(btnMalzemeDuzenle);
            Controls.Add(btnKaydet);
            Controls.Add(btnGorselDegistir);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridViewMalzemeler);
            Controls.Add(txtTalimatlar);
            Controls.Add(txtSure);
            Controls.Add(txtTarifAdi);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            Name = "TarifDetaylariDuzenForm";
            Text = "Tarifi Düzenle";
            Load += TarifDetaylariDuzenForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMalzemeler).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox txtTarifAdi;
        private TextBox txtSure;
        private RichTextBox txtTalimatlar;
        private DataGridView dataGridViewMalzemeler;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnGorselDegistir;
        private Button btnKaydet;
        private Button btnMalzemeDuzenle;
        private Button btnMalzemeEkle;
        private Button btnMalzemeSil;
        private Button btnGeri;
        private PictureBox pictureBox2;
    }
}