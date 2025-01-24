namespace yazlabdeneme
{
    partial class MalzemeDuzenleForm
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
            txtMalzemeAdi = new TextBox();
            txtMiktar = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnKaydet = new Button();
            SuspendLayout();
            // 
            // txtMalzemeAdi
            // 
            txtMalzemeAdi.BackColor = Color.Linen;
            txtMalzemeAdi.Location = new Point(145, 85);
            txtMalzemeAdi.Name = "txtMalzemeAdi";
            txtMalzemeAdi.Size = new Size(125, 27);
            txtMalzemeAdi.TabIndex = 0;
            txtMalzemeAdi.TextChanged += txtMalzemeAdi_TextChanged;
            // 
            // txtMiktar
            // 
            txtMiktar.BackColor = Color.Linen;
            txtMiktar.Location = new Point(145, 142);
            txtMiktar.Name = "txtMiktar";
            txtMiktar.Size = new Size(125, 27);
            txtMiktar.TabIndex = 2;
            txtMiktar.TextChanged += txtMiktar_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Linen;
            label1.Location = new Point(35, 88);
            label1.Name = "label1";
            label1.Size = new Size(104, 20);
            label1.TabIndex = 3;
            label1.Text = "Malzeme Adı: ";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Linen;
            label2.Location = new Point(85, 145);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 4;
            label2.Text = "Miktar:";
            // 
            // btnKaydet
            // 
            btnKaydet.BackColor = Color.DarkKhaki;
            btnKaydet.Location = new Point(176, 201);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(94, 29);
            btnKaydet.TabIndex = 5;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = false;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // MalzemeDuzenleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.arkaplan;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(323, 266);
            Controls.Add(btnKaydet);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtMiktar);
            Controls.Add(txtMalzemeAdi);
            Name = "MalzemeDuzenleForm";
            Text = "MalzemeDuzenleForm";
            Load += MalzemeDuzenleForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMalzemeAdi;
        private TextBox txtMiktar;
        private Label label1;
        private Label label2;
        private Button btnKaydet;
    }
}