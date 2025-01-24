namespace yazlabdeneme

{    using System.Drawing;
     using System.IO;
    partial class GirisEkrani
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Button btnAnaMenu;
        private Button btnStokKontrol;
        /// <summary>
        ///  Clean up any resources being used.
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

        private void InitializeComponent()
        {
            btnAnaMenu = new Button();
            btnStokKontrol = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnAnaMenu
            // 
            btnAnaMenu.BackColor = Color.Olive;
            btnAnaMenu.ForeColor = SystemColors.ControlLightLight;
            btnAnaMenu.Location = new Point(124, 536);
            btnAnaMenu.Name = "btnAnaMenu";
            btnAnaMenu.Size = new Size(200, 50);
            btnAnaMenu.TabIndex = 0;
            btnAnaMenu.Text = "Ana Menü";
            btnAnaMenu.UseVisualStyleBackColor = false;
            btnAnaMenu.Click += btnAnaMenu_Click;
            // 
            // btnStokKontrol
            // 
            btnStokKontrol.BackColor = Color.Olive;
            btnStokKontrol.ForeColor = SystemColors.ButtonHighlight;
            btnStokKontrol.Location = new Point(599, 536);
            btnStokKontrol.Name = "btnStokKontrol";
            btnStokKontrol.Size = new Size(200, 50);
            btnStokKontrol.TabIndex = 1;
            btnStokKontrol.Text = "Stok Kontrol";
            btnStokKontrol.UseVisualStyleBackColor = false;
            btnStokKontrol.Click += btnStokKontrol_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnStokKontrol);
            panel1.Controls.Add(btnAnaMenu);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(942, 619);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint;
            // 
            // GirisEkrani
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(942, 619);
            Controls.Add(panel1);
            ForeColor = SystemColors.ControlText;
            Name = "GirisEkrani";
            Text = "Giriş Ekranı";
            Load += GirisEkrani_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
    }
}
