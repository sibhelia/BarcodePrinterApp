using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using QRCoder;

namespace BarcodePrinterApp
{
    public partial class Form1 : Form
    {
        private string _prnFilePath = string.Empty;
        private static readonly Random _rng = new Random();

        public Form1()
        {
            InitializeComponent();
            btnKaydet.Click += btnKaydet_Click;
            button2.Click += button2_Click;
            btnPrn.Click += btnPrn_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            YazicilariListele();
            cmbTedarikci.Items.AddRange(new object[] { "Tedarikcı A", "Tedarikcı B", "Tedarikcı C" });
            cmbDepo.Items.AddRange(new object[] { "Ana Depo", "Yedek Depo", "Soguk Depo" });
            cmbUrun.Items.AddRange(new object[] { "Urun 001", "Urun 002", "Urun 003" });
            comboBox1.Items.AddRange(new object[] { "Sifir", "Ikinci El", "Hasarli" });
            txtKabulKodu.Text = UretKabulKodu();
            txtRafNo.ForeColor = Color.Gray;
            txtRafNo.Enter += TxtRafNo_Enter;
            txtRafNo.Leave += TxtRafNo_Leave;
        }

        private void TxtRafNo_Enter(object sender, EventArgs e)
        {
            if (txtRafNo.Text == "Opsiyonel")
            {
                txtRafNo.Text = "";
                txtRafNo.ForeColor = Color.Black;
            }
        }

        private void TxtRafNo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRafNo.Text))
            {
                txtRafNo.Text = "Opsiyonel";
                txtRafNo.ForeColor = Color.Gray;
            }
        }

        private void YazicilariListele()
        {
            cmbYazici.Items.Clear();
            foreach (string yazici in PrinterSettings.InstalledPrinters)
                cmbYazici.Items.Add(yazici);
            if (cmbYazici.Items.Count > 0)
                cmbYazici.SelectedIndex = 0;
        }

        private string UretKabulKodu()
        {
            // 24 karakter: "ABDE" + 20 rastgele hex karakter (0-9, A-F)
            const string prefix  = "ABDE";
            const string alfabe  = "0123456789ABCDEF";
            const int    rastLen = 20;
            char[] rastgele = new char[rastLen];
            for (int i = 0; i < rastLen; i++)
                rastgele[i] = alfabe[_rng.Next(alfabe.Length)];
            return prefix + new string(rastgele);
        }

        private void btnPrn_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "PRN Dosyalari (*.prn)|*.prn|Tum Dosyalar (*.*)|*.*";
            openFileDialog1.Title = "PRN Dosyasi Sec";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _prnFilePath = openFileDialog1.FileName;
                MessageBox.Show("Dosya secildi:\n" + _prnFilePath, "PRN Dosyasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_prnFilePath))
            {
                MessageBox.Show("Lutfen once bir PRN dosyasi secin.", "Uyari",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbYazici.SelectedItem == null)
            {
                MessageBox.Show("Lutfen bir yazici secin.", "Uyari",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string yaziciAdi = cmbYazici.SelectedItem.ToString();
            try
            {
                byte[] prnData = File.ReadAllBytes(_prnFilePath);
                bool sonuc = RawPrintHelper.SendBytesToPrinter(yaziciAdi, prnData);
                if (sonuc)
                    MessageBox.Show("Yazdirma islemi baslatildi.", "Basarili",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Yazdirma sirasinda bir hata olustu.", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (cmbTedarikci.SelectedItem == null && string.IsNullOrEmpty(cmbTedarikci.Text.Trim()))
            {
                MessageBox.Show("Lutfen Tedarikcı secin.", "Uyari",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string kabulKodu = txtKabulKodu.Text;
            string qrIcerik = "DEPO_KABUL|" + kabulKodu + "|" + DateTime.Now.ToString("yyyyMMddHHmm");

            using (QRCodeGenerator generator = new QRCodeGenerator())
            {
                QRCodeData data = generator.CreateQrCode(qrIcerik, QRCodeGenerator.ECCLevel.M);
                using (PngByteQRCode qrCode = new PngByteQRCode(data))
                {
                    byte[] pngBytes = qrCode.GetGraphic(10);
                    using (MemoryStream ms = new MemoryStream(pngBytes))
                    {
                        Image qrImage = Image.FromStream(ms);
                        QRForm qrForm = new QRForm(qrImage, kabulKodu);
                        qrForm.ShowDialog();
                    }
                }
            }
            txtKabulKodu.Text = UretKabulKodu();
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
    }

    internal static class RawPrintHelper
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        private class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)] public string pDocName = "RAW Document";
            [MarshalAs(UnmanagedType.LPStr)] public string pOutputFile = null;
            [MarshalAs(UnmanagedType.LPStr)] public string pDataType = "RAW";
        }

        [DllImport("winspool.Drv", EntryPoint="OpenPrinterA", SetLastError=true, CharSet=CharSet.Ansi, ExactSpelling=true, CallingConvention=CallingConvention.StdCall)]
        private static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint="ClosePrinter", SetLastError=true)]
        private static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint="StartDocPrinterA", SetLastError=true, CharSet=CharSet.Ansi, ExactSpelling=true, CallingConvention=CallingConvention.StdCall)]
        private static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint="EndDocPrinter", SetLastError=true)]
        private static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint="StartPagePrinter", SetLastError=true)]
        private static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint="EndPagePrinter", SetLastError=true)]
        private static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint="WritePrinter", SetLastError=true, ExactSpelling=true, CallingConvention=CallingConvention.StdCall)]
        private static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        public static bool SendBytesToPrinter(string printerName, byte[] bytes)
        {
            IntPtr hPrinter = IntPtr.Zero;
            bool bSuccess = false;
            if (!OpenPrinter(printerName, out hPrinter, IntPtr.Zero)) return false;
            try
            {
                DOCINFOA di = new DOCINFOA();
                if (!StartDocPrinter(hPrinter, 1, di)) return false;
                if (!StartPagePrinter(hPrinter)) { EndDocPrinter(hPrinter); return false; }
                IntPtr pBytes = Marshal.AllocCoTaskMem(bytes.Length);
                try
                {
                    Marshal.Copy(bytes, 0, pBytes, bytes.Length);
                    Int32 dwWritten = 0;
                    bSuccess = WritePrinter(hPrinter, pBytes, bytes.Length, out dwWritten);
                }
                finally { Marshal.FreeCoTaskMem(pBytes); }
                EndPagePrinter(hPrinter);
                EndDocPrinter(hPrinter);
            }
            finally { ClosePrinter(hPrinter); }
            return bSuccess;
        }
    }

    internal class QRForm : Form
    {
        private readonly Image _qrImage;
        private readonly string _kabulKodu;

        public QRForm(Image qrImage, string kabulKodu)
        {
            _qrImage = qrImage;
            _kabulKodu = kabulKodu;
            SetupUI();
        }

        private void SetupUI()
        {
            Text = "QR Kodu - " + _kabulKodu;
            Size = new Size(380, 460);
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            Label lblBaslik = new Label
            {
                Text = "Depo Kabul Kodu: " + _kabulKodu,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 45
            };

            PictureBox pbQR = new PictureBox
            {
                Image = _qrImage,
                SizeMode = PictureBoxSizeMode.Zoom,
                Width = 280,
                Height = 280,
                Left = 40,
                Top = 55,
                BackColor = Color.White
            };

            Button btnKaydet = new Button
            {
                Text = "PNG Olarak Kaydet",
                Width = 180,
                Height = 36,
                Left = 90,
                Top = 350,
                BackColor = Color.LimeGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            btnKaydet.FlatAppearance.BorderSize = 0;
            btnKaydet.Click += (s, e2) =>
            {
                using (SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "PNG Dosyasi (*.png)|*.png",
                    FileName = "QR_" + _kabulKodu + ".png"
                })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        _qrImage.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
                        MessageBox.Show("QR kodu kaydedildi.", "Basarili",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            };

            Controls.AddRange(new Control[] { lblBaslik, pbQR, btnKaydet });
        }
    }
}

