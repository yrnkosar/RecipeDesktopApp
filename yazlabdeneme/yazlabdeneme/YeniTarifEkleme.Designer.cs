namespace yazlabdeneme
{
    partial class YeniTarifEkleme
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
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button3 = new Button();
            txtTarifAdi = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox3 = new TextBox();
            richTextBox1 = new RichTextBox();
            label4 = new Label();
            label5 = new Label();
            comboBox1 = new ComboBox();
            button4 = new Button();
            pictureBox1 = new PictureBox();
            btnGorselSec = new Button();
            btnGeri = new Button();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.Linen;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(30, 28);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(398, 297);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkKhaki;
            button1.Location = new Point(30, 331);
            button1.Name = "button1";
            button1.Size = new Size(109, 29);
            button1.TabIndex = 2;
            button1.Text = "Ekle";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.DarkKhaki;
            button3.Location = new Point(308, 331);
            button3.Name = "button3";
            button3.Size = new Size(120, 29);
            button3.TabIndex = 4;
            button3.Text = "Sil";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // txtTarifAdi
            // 
            txtTarifAdi.BackColor = Color.Linen;
            txtTarifAdi.Location = new Point(674, 37);
            txtTarifAdi.Name = "txtTarifAdi";
            txtTarifAdi.Size = new Size(150, 27);
            txtTarifAdi.TabIndex = 5;
            txtTarifAdi.TextChanged += txtTarifAdi_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Linen;
            label1.Location = new Point(591, 40);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 6;
            label1.Text = "Tarif Adı:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Linen;
            label2.Location = new Point(591, 86);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 7;
            label2.Text = "Kategori:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Linen;
            label3.Location = new Point(591, 133);
            label3.Name = "label3";
            label3.Size = new Size(41, 20);
            label3.TabIndex = 8;
            label3.Text = "Süre:";
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.Linen;
            textBox3.Location = new Point(674, 130);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(124, 27);
            textBox3.TabIndex = 10;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.Linen;
            richTextBox1.Location = new Point(674, 174);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(224, 92);
            richTextBox1.TabIndex = 12;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Linen;
            label4.Location = new Point(591, 177);
            label4.Name = "label4";
            label4.Size = new Size(77, 20);
            label4.TabIndex = 14;
            label4.Text = "Talimatlar:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Linen;
            label5.Location = new Point(604, 289);
            label5.Name = "label5";
            label5.Size = new Size(54, 20);
            label5.TabIndex = 15;
            label5.Text = "Görsel:";
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.Linen;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(673, 83);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 16;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button4
            // 
            button4.BackColor = Color.SandyBrown;
            button4.Location = new Point(30, 373);
            button4.Name = "button4";
            button4.Size = new Size(398, 29);
            button4.TabIndex = 17;
            button4.Text = "Tarifi Kaydet";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click_1;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Location = new Point(673, 289);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(245, 211);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 18;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // btnGorselSec
            // 
            btnGorselSec.BackColor = Color.SandyBrown;
            btnGorselSec.Location = new Point(824, 506);
            btnGorselSec.Name = "btnGorselSec";
            btnGorselSec.Size = new Size(94, 34);
            btnGorselSec.TabIndex = 19;
            btnGorselSec.Text = "Gorsel Seç";
            btnGorselSec.UseVisualStyleBackColor = false;
            btnGorselSec.Click += btnGorselSec_Click;
            // 
            // btnGeri
            // 
            btnGeri.BackColor = Color.DarkKhaki;
            btnGeri.Location = new Point(30, 415);
            btnGeri.Name = "btnGeri";
            btnGeri.Size = new Size(206, 29);
            btnGeri.TabIndex = 20;
            btnGeri.Text = "Geri";
            btnGeri.UseVisualStyleBackColor = false;
            btnGeri.Click += btnGeri_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImage = Properties.Resources.ayz85yun8;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(30, 459);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(206, 166);
            pictureBox2.TabIndex = 21;
            pictureBox2.TabStop = false;
            // 
            // YeniTarifEkleme
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.arkaplan;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1012, 661);
            Controls.Add(btnGeri);
            Controls.Add(btnGorselSec);
            Controls.Add(pictureBox1);
            Controls.Add(button4);
            Controls.Add(comboBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(richTextBox1);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtTarifAdi);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(pictureBox2);
            Name = "YeniTarifEkleme";
            Text = "YeniTarifEkleme";
            Load += YeniTarifEkleme_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private Button button3;
        private TextBox txtTarifAdi;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox3;
        private RichTextBox richTextBox1;
        private Label label4;
        private Label label5;
        private ComboBox comboBox1;
        private Button button4;
        private PictureBox pictureBox1;
        private Button btnGorselSec;
        private Button btnGeri;
        private PictureBox pictureBox2;
    }
}