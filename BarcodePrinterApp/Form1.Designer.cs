namespace BarcodePrinterApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTedarikci = new Label();
            openFileDialog1 = new OpenFileDialog();
            cmbTedarikci = new ComboBox();
            lblDepo = new Label();
            cmbDepo = new ComboBox();
            lblUrun = new Label();
            cmbUrun = new ComboBox();
            grpKabulBilgileri = new GroupBox();
            lblAdet = new Label();
            lblKondisyon = new Label();
            lblRafNo = new Label();
            lblKabulKodu = new Label();
            numericUpDown1 = new NumericUpDown();
            comboBox1 = new ComboBox();
            txtRafNo = new TextBox();
            txtKabulKodu = new TextBox();
            btnKaydet = new Button();
            cmbYazici = new ComboBox();
            label2 = new Label();
            button2 = new Button();
            btnPrn = new Button();
            grpKabulBilgileri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // lblTedarikci
            // 
            lblTedarikci.AutoSize = true;
            lblTedarikci.Location = new Point(28, 34);
            lblTedarikci.Name = "lblTedarikci";
            lblTedarikci.Size = new Size(68, 20);
            lblTedarikci.TabIndex = 2;
            lblTedarikci.Text = "Tedarikçi";
            lblTedarikci.Click += label1_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // cmbTedarikci
            // 
            cmbTedarikci.BackColor = Color.White;
            cmbTedarikci.FormattingEnabled = true;
            cmbTedarikci.Location = new Point(28, 57);
            cmbTedarikci.Name = "cmbTedarikci";
            cmbTedarikci.Size = new Size(223, 28);
            cmbTedarikci.TabIndex = 3;
            cmbTedarikci.Text = "Seçiniz";
            // 
            // lblDepo
            // 
            lblDepo.AutoSize = true;
            lblDepo.Location = new Point(28, 124);
            lblDepo.Name = "lblDepo";
            lblDepo.Size = new Size(46, 20);
            lblDepo.TabIndex = 4;
            lblDepo.Text = "Depo";
            // 
            // cmbDepo
            // 
            cmbDepo.FormattingEnabled = true;
            cmbDepo.Location = new Point(28, 147);
            cmbDepo.Name = "cmbDepo";
            cmbDepo.Size = new Size(223, 28);
            cmbDepo.TabIndex = 5;
            cmbDepo.Text = "Seçiniz";
            // 
            // lblUrun
            // 
            lblUrun.AutoSize = true;
            lblUrun.Location = new Point(28, 218);
            lblUrun.Name = "lblUrun";
            lblUrun.Size = new Size(40, 20);
            lblUrun.TabIndex = 6;
            lblUrun.Text = "Ürün";
            // 
            // cmbUrun
            // 
            cmbUrun.FormattingEnabled = true;
            cmbUrun.Location = new Point(28, 240);
            cmbUrun.Name = "cmbUrun";
            cmbUrun.Size = new Size(223, 28);
            cmbUrun.TabIndex = 7;
            cmbUrun.Text = "Seçiniz";
            // 
            // grpKabulBilgileri
            // 
            grpKabulBilgileri.BackColor = Color.White;
            grpKabulBilgileri.Controls.Add(btnKaydet);
            grpKabulBilgileri.Controls.Add(txtKabulKodu);
            grpKabulBilgileri.Controls.Add(txtRafNo);
            grpKabulBilgileri.Controls.Add(comboBox1);
            grpKabulBilgileri.Controls.Add(numericUpDown1);
            grpKabulBilgileri.Controls.Add(lblKabulKodu);
            grpKabulBilgileri.Controls.Add(lblRafNo);
            grpKabulBilgileri.Controls.Add(lblKondisyon);
            grpKabulBilgileri.Controls.Add(lblAdet);
            grpKabulBilgileri.Controls.Add(cmbUrun);
            grpKabulBilgileri.Controls.Add(lblTedarikci);
            grpKabulBilgileri.Controls.Add(cmbTedarikci);
            grpKabulBilgileri.Controls.Add(lblDepo);
            grpKabulBilgileri.Controls.Add(cmbDepo);
            grpKabulBilgileri.Controls.Add(lblUrun);
            grpKabulBilgileri.Location = new Point(16, 12);
            grpKabulBilgileri.Name = "grpKabulBilgileri";
            grpKabulBilgileri.Size = new Size(688, 352);
            grpKabulBilgileri.TabIndex = 8;
            grpKabulBilgileri.TabStop = false;
            grpKabulBilgileri.Text = "Kabul Bilgileri";
            // 
            // lblAdet
            // 
            lblAdet.AutoSize = true;
            lblAdet.Location = new Point(428, 34);
            lblAdet.Name = "lblAdet";
            lblAdet.Size = new Size(41, 20);
            lblAdet.TabIndex = 8;
            lblAdet.Text = "Adet";
            // 
            // lblKondisyon
            // 
            lblKondisyon.AutoSize = true;
            lblKondisyon.Location = new Point(428, 93);
            lblKondisyon.Name = "lblKondisyon";
            lblKondisyon.Size = new Size(78, 20);
            lblKondisyon.TabIndex = 9;
            lblKondisyon.Text = "Kondisyon";
            // 
            // lblRafNo
            // 
            lblRafNo.AutoSize = true;
            lblRafNo.Location = new Point(428, 156);
            lblRafNo.Name = "lblRafNo";
            lblRafNo.Size = new Size(55, 20);
            lblRafNo.TabIndex = 10;
            lblRafNo.Text = "Raf No";
            // 
            // lblKabulKodu
            // 
            lblKabulKodu.AutoSize = true;
            lblKabulKodu.Location = new Point(428, 218);
            lblKabulKodu.Name = "lblKabulKodu";
            lblKabulKodu.Size = new Size(127, 20);
            lblKabulKodu.TabIndex = 11;
            lblKabulKodu.Text = "Depo Kabul Kodu";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(428, 57);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(220, 27);
            numericUpDown1.TabIndex = 12;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(428, 116);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(220, 28);
            comboBox1.TabIndex = 13;
            comboBox1.Text = "Seçiniz";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // txtRafNo
            // 
            txtRafNo.Location = new Point(428, 179);
            txtRafNo.Name = "txtRafNo";
            txtRafNo.Size = new Size(220, 27);
            txtRafNo.TabIndex = 14;
            txtRafNo.Text = "Opsiyonel";
            // 
            // txtKabulKodu
            // 
            txtKabulKodu.Location = new Point(428, 241);
            txtKabulKodu.Name = "txtKabulKodu";
            txtKabulKodu.ReadOnly = true;
            txtKabulKodu.Size = new Size(220, 27);
            txtKabulKodu.TabIndex = 15;
            // 
            // btnKaydet
            // 
            btnKaydet.BackColor = Color.LimeGreen;
            btnKaydet.Location = new Point(490, 299);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(171, 34);
            btnKaydet.TabIndex = 17;
            btnKaydet.Text = "Kaydet ve QR Göster";
            btnKaydet.UseVisualStyleBackColor = false;
            // 
            // cmbYazici
            // 
            cmbYazici.FormattingEnabled = true;
            cmbYazici.Location = new Point(420, 393);
            cmbYazici.Name = "cmbYazici";
            cmbYazici.Size = new Size(157, 28);
            cmbYazici.TabIndex = 18;
            cmbYazici.Text = " Yazıcı Seçiniz";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(203, 371);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 20;
            // 
            // button2
            // 
            button2.BackColor = Color.DodgerBlue;
            button2.Location = new Point(583, 389);
            button2.Name = "button2";
            button2.Size = new Size(111, 32);
            button2.TabIndex = 21;
            button2.Text = "Yazdır";
            button2.UseVisualStyleBackColor = false;
            // 
            // btnPrn
            // 
            btnPrn.BackColor = Color.DodgerBlue;
            btnPrn.Location = new Point(12, 393);
            btnPrn.Name = "btnPrn";
            btnPrn.Size = new Size(185, 29);
            btnPrn.TabIndex = 22;
            btnPrn.Text = "PRN Dosyasını Seç";
            btnPrn.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(716, 454);
            Controls.Add(btnPrn);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(cmbYazici);
            Controls.Add(grpKabulBilgileri);
            Name = "Form1";
            Text = "Depo Kabul";
            Load += Form1_Load;
            grpKabulBilgileri.ResumeLayout(false);
            grpKabulBilgileri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblTedarikci;
        private OpenFileDialog openFileDialog1;
        private ComboBox cmbTedarikci;
        private Label lblDepo;
        private ComboBox cmbDepo;
        private Label lblUrun;
        private ComboBox cmbUrun;
        private GroupBox grpKabulBilgileri;
        private TextBox txtKabulKodu;
        private TextBox txtRafNo;
        private ComboBox comboBox1;
        private NumericUpDown numericUpDown1;
        private Label lblKabulKodu;
        private Label lblRafNo;
        private Label lblKondisyon;
        private Label lblAdet;
        private Button btnKaydet;
        private ComboBox cmbYazici;
        private Label label2;
        private Button button2;
        private Button btnPrn;
    }
}
