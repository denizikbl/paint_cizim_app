namespace paint_cizim_app
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.beyazRenk_button = new System.Windows.Forms.Button();
            this.kahveRenk_button = new System.Windows.Forms.Button();
            this.morRenk_button = new System.Windows.Forms.Button();
            this.turuncuRenkbutton = new System.Windows.Forms.Button();
            this.siyahRenk_button = new System.Windows.Forms.Button();
            this.sarıRenk_button = new System.Windows.Forms.Button();
            this.yesilRenk_button = new System.Windows.Forms.Button();
            this.maviRenk_button = new System.Windows.Forms.Button();
            this.kırmızıRenk_button = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.temizSayfa_button = new System.Windows.Forms.Button();
            this.sil_button = new System.Windows.Forms.Button();
            this.secim_button = new System.Windows.Forms.Button();
            this.g_dosyaİslem = new System.Windows.Forms.GroupBox();
            this.Kaydet_button = new System.Windows.Forms.Button();
            this.dosyaAc_button = new System.Windows.Forms.Button();
            this.g_cizim_sekli = new System.Windows.Forms.GroupBox();
            this.ucgen_button = new System.Windows.Forms.Button();
            this.altıgen_button = new System.Windows.Forms.Button();
            this.diktortgen_button = new System.Windows.Forms.Button();
            this.daire_button = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cizimAlanı_panel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.g_dosyaİslem.SuspendLayout();
            this.g_cizim_sekli.SuspendLayout();
            this.panel1.SuspendLayout();
            this.cizimAlanı_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(5, 632);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "fare konumu";
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.beyazRenk_button);
            this.groupBox4.Controls.Add(this.kahveRenk_button);
            this.groupBox4.Controls.Add(this.morRenk_button);
            this.groupBox4.Controls.Add(this.turuncuRenkbutton);
            this.groupBox4.Controls.Add(this.siyahRenk_button);
            this.groupBox4.Controls.Add(this.sarıRenk_button);
            this.groupBox4.Controls.Add(this.yesilRenk_button);
            this.groupBox4.Controls.Add(this.maviRenk_button);
            this.groupBox4.Controls.Add(this.kırmızıRenk_button);
            this.groupBox4.Location = new System.Drawing.Point(3, 223);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(211, 151);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "RENK SEÇİMİ";
            // 
            // beyazRenk_button
            // 
            this.beyazRenk_button.BackColor = System.Drawing.Color.White;
            this.beyazRenk_button.Location = new System.Drawing.Point(141, 106);
            this.beyazRenk_button.Name = "beyazRenk_button";
            this.beyazRenk_button.Size = new System.Drawing.Size(55, 38);
            this.beyazRenk_button.TabIndex = 13;
            this.beyazRenk_button.UseVisualStyleBackColor = false;
            this.beyazRenk_button.Click += new System.EventHandler(this.beyazRenk_button_Click);
            // 
            // kahveRenk_button
            // 
            this.kahveRenk_button.BackColor = System.Drawing.Color.Maroon;
            this.kahveRenk_button.Location = new System.Drawing.Point(79, 106);
            this.kahveRenk_button.Name = "kahveRenk_button";
            this.kahveRenk_button.Size = new System.Drawing.Size(53, 38);
            this.kahveRenk_button.TabIndex = 12;
            this.kahveRenk_button.UseVisualStyleBackColor = false;
            this.kahveRenk_button.Click += new System.EventHandler(this.kahveRenk_button_Click);
            // 
            // morRenk_button
            // 
            this.morRenk_button.BackColor = System.Drawing.Color.Purple;
            this.morRenk_button.Location = new System.Drawing.Point(17, 106);
            this.morRenk_button.Name = "morRenk_button";
            this.morRenk_button.Size = new System.Drawing.Size(56, 38);
            this.morRenk_button.TabIndex = 11;
            this.morRenk_button.UseVisualStyleBackColor = false;
            this.morRenk_button.Click += new System.EventHandler(this.morRenk_button_Click);
            // 
            // turuncuRenkbutton
            // 
            this.turuncuRenkbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.turuncuRenkbutton.Location = new System.Drawing.Point(17, 64);
            this.turuncuRenkbutton.Name = "turuncuRenkbutton";
            this.turuncuRenkbutton.Size = new System.Drawing.Size(56, 38);
            this.turuncuRenkbutton.TabIndex = 10;
            this.turuncuRenkbutton.UseVisualStyleBackColor = false;
            this.turuncuRenkbutton.Click += new System.EventHandler(this.turuncuRenkbutton_Click);
            // 
            // siyahRenk_button
            // 
            this.siyahRenk_button.BackColor = System.Drawing.Color.Black;
            this.siyahRenk_button.Location = new System.Drawing.Point(79, 64);
            this.siyahRenk_button.Name = "siyahRenk_button";
            this.siyahRenk_button.Size = new System.Drawing.Size(53, 38);
            this.siyahRenk_button.TabIndex = 9;
            this.siyahRenk_button.UseVisualStyleBackColor = false;
            this.siyahRenk_button.Click += new System.EventHandler(this.siyahRenk_button_Click);
            // 
            // sarıRenk_button
            // 
            this.sarıRenk_button.BackColor = System.Drawing.Color.Yellow;
            this.sarıRenk_button.Location = new System.Drawing.Point(141, 64);
            this.sarıRenk_button.Name = "sarıRenk_button";
            this.sarıRenk_button.Size = new System.Drawing.Size(55, 38);
            this.sarıRenk_button.TabIndex = 6;
            this.sarıRenk_button.UseVisualStyleBackColor = false;
            this.sarıRenk_button.Click += new System.EventHandler(this.sarıRenk_button_Click);
            // 
            // yesilRenk_button
            // 
            this.yesilRenk_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.yesilRenk_button.Location = new System.Drawing.Point(141, 21);
            this.yesilRenk_button.Name = "yesilRenk_button";
            this.yesilRenk_button.Size = new System.Drawing.Size(55, 37);
            this.yesilRenk_button.TabIndex = 7;
            this.yesilRenk_button.UseVisualStyleBackColor = false;
            this.yesilRenk_button.Click += new System.EventHandler(this.yesilRenk_button_Click);
            // 
            // maviRenk_button
            // 
            this.maviRenk_button.BackColor = System.Drawing.Color.Blue;
            this.maviRenk_button.Location = new System.Drawing.Point(79, 21);
            this.maviRenk_button.Name = "maviRenk_button";
            this.maviRenk_button.Size = new System.Drawing.Size(53, 37);
            this.maviRenk_button.TabIndex = 8;
            this.maviRenk_button.UseVisualStyleBackColor = false;
            this.maviRenk_button.Click += new System.EventHandler(this.maviRenk_button_Click);
            // 
            // kırmızıRenk_button
            // 
            this.kırmızıRenk_button.BackColor = System.Drawing.Color.Red;
            this.kırmızıRenk_button.Location = new System.Drawing.Point(17, 21);
            this.kırmızıRenk_button.Name = "kırmızıRenk_button";
            this.kırmızıRenk_button.Size = new System.Drawing.Size(56, 37);
            this.kırmızıRenk_button.TabIndex = 0;
            this.kırmızıRenk_button.UseVisualStyleBackColor = false;
            this.kırmızıRenk_button.Click += new System.EventHandler(this.kırmızıRenk_button_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.temizSayfa_button);
            this.groupBox5.Controls.Add(this.sil_button);
            this.groupBox5.Controls.Add(this.secim_button);
            this.groupBox5.Location = new System.Drawing.Point(3, 380);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(212, 114);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "ŞEKİL İŞLEMLERİ";
            // 
            // temizSayfa_button
            // 
            this.temizSayfa_button.Image = global::paint_cizim_app.Properties.Resources.kalem;
            this.temizSayfa_button.Location = new System.Drawing.Point(139, 21);
            this.temizSayfa_button.Name = "temizSayfa_button";
            this.temizSayfa_button.Size = new System.Drawing.Size(66, 86);
            this.temizSayfa_button.TabIndex = 2;
            this.temizSayfa_button.UseVisualStyleBackColor = true;
            this.temizSayfa_button.Click += new System.EventHandler(this.temizSayfa_button_Click);
            // 
            // sil_button
            // 
            this.sil_button.Image = global::paint_cizim_app.Properties.Resources.geridönüşüm;
            this.sil_button.Location = new System.Drawing.Point(80, 21);
            this.sil_button.Name = "sil_button";
            this.sil_button.Size = new System.Drawing.Size(56, 86);
            this.sil_button.TabIndex = 1;
            this.sil_button.UseVisualStyleBackColor = true;
            this.sil_button.Click += new System.EventHandler(this.sil_button_Click);
            // 
            // secim_button
            // 
            this.secim_button.Image = global::paint_cizim_app.Properties.Resources.secim_cursor;
            this.secim_button.Location = new System.Drawing.Point(1, 21);
            this.secim_button.Name = "secim_button";
            this.secim_button.Size = new System.Drawing.Size(77, 86);
            this.secim_button.TabIndex = 0;
            this.secim_button.UseVisualStyleBackColor = true;
            this.secim_button.Click += new System.EventHandler(this.secim_button_Click);
            // 
            // g_dosyaİslem
            // 
            this.g_dosyaİslem.Controls.Add(this.Kaydet_button);
            this.g_dosyaİslem.Controls.Add(this.dosyaAc_button);
            this.g_dosyaİslem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.g_dosyaİslem.Location = new System.Drawing.Point(3, 500);
            this.g_dosyaİslem.Name = "g_dosyaİslem";
            this.g_dosyaİslem.Size = new System.Drawing.Size(211, 92);
            this.g_dosyaİslem.TabIndex = 2;
            this.g_dosyaİslem.TabStop = false;
            this.g_dosyaİslem.Text = "DOSYA İŞLEMLERİ";
            // 
            // Kaydet_button
            // 
            this.Kaydet_button.Image = global::paint_cizim_app.Properties.Resources.kaydetme;
            this.Kaydet_button.Location = new System.Drawing.Point(101, 17);
            this.Kaydet_button.Name = "Kaydet_button";
            this.Kaydet_button.Size = new System.Drawing.Size(78, 69);
            this.Kaydet_button.TabIndex = 0;
            this.Kaydet_button.UseVisualStyleBackColor = true;
            this.Kaydet_button.Click += new System.EventHandler(this.Kaydet_button_Click);
            // 
            // dosyaAc_button
            // 
            this.dosyaAc_button.Image = global::paint_cizim_app.Properties.Resources.dosya;
            this.dosyaAc_button.Location = new System.Drawing.Point(17, 17);
            this.dosyaAc_button.Name = "dosyaAc_button";
            this.dosyaAc_button.Size = new System.Drawing.Size(78, 69);
            this.dosyaAc_button.TabIndex = 1;
            this.dosyaAc_button.UseVisualStyleBackColor = true;
            this.dosyaAc_button.Click += new System.EventHandler(this.dosyaAc_button_Click);
            // 
            // g_cizim_sekli
            // 
            this.g_cizim_sekli.Controls.Add(this.ucgen_button);
            this.g_cizim_sekli.Controls.Add(this.altıgen_button);
            this.g_cizim_sekli.Controls.Add(this.diktortgen_button);
            this.g_cizim_sekli.Controls.Add(this.daire_button);
            this.g_cizim_sekli.Location = new System.Drawing.Point(3, 9);
            this.g_cizim_sekli.Name = "g_cizim_sekli";
            this.g_cizim_sekli.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.g_cizim_sekli.Size = new System.Drawing.Size(212, 208);
            this.g_cizim_sekli.TabIndex = 0;
            this.g_cizim_sekli.TabStop = false;
            this.g_cizim_sekli.Text = "ÇİZİM ŞEKLİ";
            // 
            // ucgen_button
            // 
            this.ucgen_button.Image = global::paint_cizim_app.Properties.Resources.ucgen;
            this.ucgen_button.Location = new System.Drawing.Point(6, 125);
            this.ucgen_button.Name = "ucgen_button";
            this.ucgen_button.Size = new System.Drawing.Size(89, 77);
            this.ucgen_button.TabIndex = 2;
            this.ucgen_button.UseVisualStyleBackColor = true;
            this.ucgen_button.Click += new System.EventHandler(this.ucgen_button_Click);
            // 
            // altıgen_button
            // 
            this.altıgen_button.Image = global::paint_cizim_app.Properties.Resources.hexagon_64;
            this.altıgen_button.Location = new System.Drawing.Point(109, 125);
            this.altıgen_button.Name = "altıgen_button";
            this.altıgen_button.Size = new System.Drawing.Size(96, 77);
            this.altıgen_button.TabIndex = 1;
            this.altıgen_button.UseVisualStyleBackColor = true;
            this.altıgen_button.Click += new System.EventHandler(this.altıgen_button_Click);
            // 
            // diktortgen_button
            // 
            this.diktortgen_button.Image = global::paint_cizim_app.Properties.Resources.dikdörtgen;
            this.diktortgen_button.Location = new System.Drawing.Point(6, 21);
            this.diktortgen_button.Name = "diktortgen_button";
            this.diktortgen_button.Size = new System.Drawing.Size(89, 98);
            this.diktortgen_button.TabIndex = 0;
            this.diktortgen_button.UseVisualStyleBackColor = true;
            this.diktortgen_button.Click += new System.EventHandler(this.diktortgen_button_Click);
            // 
            // daire_button
            // 
            this.daire_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.daire_button.Image = global::paint_cizim_app.Properties.Resources.daire;
            this.daire_button.Location = new System.Drawing.Point(109, 21);
            this.daire_button.Name = "daire_button";
            this.daire_button.Size = new System.Drawing.Size(96, 98);
            this.daire_button.TabIndex = 0;
            this.daire_button.UseVisualStyleBackColor = true;
            this.daire_button.Click += new System.EventHandler(this.daire_button_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.g_cizim_sekli);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.g_dosyaİslem);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(801, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(222, 655);
            this.panel1.TabIndex = 2;
            // 
            // cizimAlanı_panel
            // 
            this.cizimAlanı_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cizimAlanı_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cizimAlanı_panel.Controls.Add(this.label2);
            this.cizimAlanı_panel.Location = new System.Drawing.Point(12, 10);
            this.cizimAlanı_panel.Name = "cizimAlanı_panel";
            this.cizimAlanı_panel.Size = new System.Drawing.Size(783, 639);
            this.cizimAlanı_panel.TabIndex = 3;
            this.cizimAlanı_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.cizimAlanı_panel_Paint);
            this.cizimAlanı_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cizimAlanı_panel_MouseDown);
            this.cizimAlanı_panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cizimAlanı_panel_MouseMove);
            this.cizimAlanı_panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cizimAlanı_panel_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2    x değeri";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 655);
            this.Controls.Add(this.cizimAlanı_panel);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.g_dosyaİslem.ResumeLayout(false);
            this.g_cizim_sekli.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.cizimAlanı_panel.ResumeLayout(false);
            this.cizimAlanı_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox g_dosyaİslem;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox g_cizim_sekli;
        private System.Windows.Forms.Button ucgen_button;
        private System.Windows.Forms.Button altıgen_button;
        private System.Windows.Forms.Button diktortgen_button;
        private System.Windows.Forms.Button daire_button;
        private System.Windows.Forms.Button temizSayfa_button;
        private System.Windows.Forms.Button sil_button;
        private System.Windows.Forms.Button secim_button;
        private System.Windows.Forms.Button beyazRenk_button;
        private System.Windows.Forms.Button kahveRenk_button;
        private System.Windows.Forms.Button morRenk_button;
        private System.Windows.Forms.Button turuncuRenkbutton;
        private System.Windows.Forms.Button siyahRenk_button;
        private System.Windows.Forms.Button sarıRenk_button;
        private System.Windows.Forms.Button yesilRenk_button;
        private System.Windows.Forms.Button maviRenk_button;
        private System.Windows.Forms.Button kırmızıRenk_button;
        private System.Windows.Forms.Button Kaydet_button;
        private System.Windows.Forms.Button dosyaAc_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel cizimAlanı_panel;
        private System.Windows.Forms.Label label2;
    }
}

