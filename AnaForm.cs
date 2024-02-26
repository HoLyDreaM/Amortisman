using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sifas_Amortisman
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        public AnaForm anaFrm
        {
            get;
            set;
        }

        iniOku.iniOku iniOku = new iniOku.iniOku(Application.StartupPath + "\\LoginSettings.ini");
        iniOku.iniOku uzakIni;
        string Cs = Properties.Settings.Default.DbConn;
        string Oranlar = Properties.Settings.Default.DbConnOranlar;
        SqlConnection con = new SqlConnection();
        public string sirketAdi;

        //Form Tanımları
        public LoginForm FrmGiris;
        public AmortismanHesaplama NrAmortisman;
        public TefeTufeOranlari TefeTufeOran;
        public Form1 deneme;

        #region Versiyon İşlemleri Classı

        private string _versiyon;
        public string Versiyon
        {
            get { return _versiyon; }
            set { _versiyon = value; }
        }

        private string _gelenVersion;
        public string GelenVersion
        {
            get { return _gelenVersion; }
            set { _gelenVersion = value; }
        }

        private string _aciklama;
        public string Aciklama
        {
            get { return _aciklama; }
            set { _aciklama = value; }
        }

        private string _dosyalar;
        public string Dosyalar
        {
            get { return _dosyalar; }
            set { _dosyalar = value; }
        }

        #endregion

        private void AnaForm_Load(object sender, EventArgs e)
        {
            #region Şirket Adı-Tarih Ve Adres Bilgi Tarafı

            lblSirket.Text = sirketAdi;
            lblKayanYazi.Text = "Editör Bilgi İşlem Elektronik San. ve Tic. Ltd. Şti.     Tel&&Faks : [224] 251 84 55      Web : www.editorgroup.net      E-mail : editor@editorgroup.net      Programmer : Mehmet ÖZDEMİR" +
                          "                                                                                                                                                        ";
            #endregion

            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            CheckForIllegalCrossThreadCalls = false;

            ilkForm frmacilis = new ilkForm();
            frmacilis.MdiParent = this;
            frmacilis.Show();

        }

        private void timerTarih_Tick(object sender, EventArgs e)
        {
            this.lblKayanYazi.Text = lblKayanYazi.Text.Substring(1) + lblKayanYazi.Text[0].ToString();
            lblTarih.Text = DateTime.Now.ToString();
        }

        private void AnaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnaForm anfrm = new AnaForm();
            anfrm.Close();
        }

        private void btnLoginAyari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (FrmGiris == null || FrmGiris.IsDisposed)
            {
                FrmGiris = new LoginForm();
                FrmGiris.kontrol = false;
                FrmGiris.Show();
            }
            else
            {
                FrmGiris.Activate();
            }
        }

        private void btnNormalHesapla_Click(object sender, EventArgs e)
        {

        }

        private void btnTefeTufeOranlari_Click(object sender, EventArgs e)
        {
            if (TefeTufeOran == null || TefeTufeOran.IsDisposed)
            {
                TefeTufeOran = new TefeTufeOranlari();
                TefeTufeOran.Owner = this;
                TefeTufeOran.MdiParent = this;
                TefeTufeOran.anaFrm = this;
                TefeTufeOran.Cs = Oranlar.ToString();
                TefeTufeOran.Show();
            }
            else
            {
                TefeTufeOran.Activate();
            }
        }

        private void btnAmortismanHesaplama_Click(object sender, EventArgs e)
        {
            if (NrAmortisman == null || NrAmortisman.IsDisposed)
            {
                NrAmortisman = new AmortismanHesaplama();
                NrAmortisman.Owner = this;
                NrAmortisman.MdiParent = this;
                NrAmortisman.anaFrm = this;
                NrAmortisman.Cs = Cs.ToString();
                NrAmortisman.CsOranlar = Oranlar.ToString();
                NrAmortisman.Show();
            }
            else
            {
                NrAmortisman.Activate();
            }
        }

        private void btnAzalanBakiyeler_Click(object sender, EventArgs e)
        {
            if (deneme == null || deneme.IsDisposed)
            {
                deneme = new Form1();
                deneme.Owner = this;
                deneme.MdiParent = this;
                deneme.anaFrm = this;
                deneme.Cs = Cs.ToString();
                deneme.CsOranlar = Oranlar.ToString();
                deneme.Show();
            }
            else
            {
                deneme.Activate();
            }
        }
    }
}
