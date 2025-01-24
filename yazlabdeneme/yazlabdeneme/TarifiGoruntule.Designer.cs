namespace yazlabdeneme
{
    partial class TarifiGoruntule
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
            txtTarifAdi = new TextBox();
            txtSure = new TextBox();
            pictureBox1 = new PictureBox();
            dataGridViewMalzemeler = new DataGridView();
            btnTamam = new Button();
            txtTalimatlar = new RichTextBox();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMalzemeler).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // txtTarifAdi
            // 
            txtTarifAdi.BackColor = Color.Linen;
            txtTarifAdi.Location = new Point(460, 69);
            txtTarifAdi.Name = "txtTarifAdi";
            txtTarifAdi.ReadOnly = true;
            txtTarifAdi.Size = new Size(176, 27);
            txtTarifAdi.TabIndex = 0;
            txtTarifAdi.TextChanged += txtTarifAdi_TextChanged;
            // 
            // txtSure
            // 
            txtSure.BackColor = Color.Linen;
            txtSure.Location = new Point(460, 133);
            txtSure.Name = "txtSure";
            txtSure.ReadOnly = true;
            txtSure.Size = new Size(176, 27);
            txtSure.TabIndex = 1;
            txtSure.TextChanged += txtSure_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Location = new Point(40, 42);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(235, 210);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // dataGridViewMalzemeler
            // 
            dataGridViewMalzemeler.BackgroundColor = Color.Linen;
            dataGridViewMalzemeler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMalzemeler.Location = new Point(40, 312);
            dataGridViewMalzemeler.Name = "dataGridViewMalzemeler";
            dataGridViewMalzemeler.RowHeadersWidth = 51;
            dataGridViewMalzemeler.Size = new Size(292, 195);
            dataGridViewMalzemeler.TabIndex = 4;
            dataGridViewMalzemeler.CellContentClick += dataGridViewMalzemeler_CellContentClick;
            // 
            // btnTamam
            // 
            btnTamam.BackColor = Color.DarkKhaki;
            btnTamam.Location = new Point(617, 346);
            btnTamam.Name = "btnTamam";
            btnTamam.Size = new Size(94, 29);
            btnTamam.TabIndex = 5;
            btnTamam.Text = "Tamam";
            btnTamam.UseVisualStyleBackColor = false;
            btnTamam.Click += btnTamam_Click;
            // 
            // txtTalimatlar
            // 
            txtTalimatlar.BackColor = Color.Linen;
            txtTalimatlar.Location = new Point(460, 196);
            txtTalimatlar.Name = "txtTalimatlar";
            txtTalimatlar.ReadOnly = true;
            txtTalimatlar.Size = new Size(206, 113);
            txtTalimatlar.TabIndex = 6;
            txtTalimatlar.Text = "";
            txtTalimatlar.TextChanged += txtTalimatlar_TextChanged;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImage = Properties.Resources.transparent_alcohol_bottle_glass_pink_liquid_square_shape_liqu_alcohol_bottle_with_pink_liquid_and_glass656c1112610b551;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(601, 381);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(135, 171);
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Linen;
            label2.Location = new Point(460, 110);
            label2.Name = "label2";
            label2.Size = new Size(80, 20);
            label2.TabIndex = 8;
            label2.Text = "Tarif Süresi";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Linen;
            label3.Location = new Point(460, 173);
            label3.Name = "label3";
            label3.Size = new Size(74, 20);
            label3.TabIndex = 9;
            label3.Text = "Talimatlar";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Linen;
            label4.Location = new Point(40, 280);
            label4.Name = "label4";
            label4.Size = new Size(87, 20);
            label4.TabIndex = 10;
            label4.Text = "Malzemeler";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Linen;
            label1.Location = new Point(460, 42);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 11;
            label1.Text = "Tarif Adı";
            // 
            // TarifiGoruntule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.arkaplan;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(748, 588);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtTalimatlar);
            Controls.Add(btnTamam);
            Controls.Add(dataGridViewMalzemeler);
            Controls.Add(pictureBox1);
            Controls.Add(txtSure);
            Controls.Add(txtTarifAdi);
            Controls.Add(pictureBox2);
            Name = "TarifiGoruntule";
            Text = "TarifiGoruntule";
            Load += TarifiGoruntule_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMalzemeler).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTarifAdi;
        private TextBox txtSure;
        private PictureBox pictureBox1;
        private DataGridView dataGridViewMalzemeler;
        private Button btnTamam;
        private RichTextBox txtTalimatlar;
        private PictureBox pictureBox2;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label1;
    }
}