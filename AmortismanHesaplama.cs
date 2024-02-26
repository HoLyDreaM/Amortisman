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
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Excel;

namespace Sifas_Amortisman
{
    public partial class AmortismanHesaplama : Form
    {
        public AmortismanHesaplama()
        {
            InitializeComponent();
        }

        public AnaForm anaFrm
        {
            get;
            set;
        }

        Thread Sorgula;
        Task Kanal, Kanal2, KanalAktar, Kanal3,
            KanalAktarimAyarla, KanalAktarimAyarla2;
        SqlConnection Conn;
        SqlConnection ConOran;
        SqlCommand cmd;

        public string Cs, CsOranlar;
        int EskiHesapDurumu, YeniHesapDurumu, HareketDurumu, SonYil, CarpimAyi, CarpAy, AlimYili, SelectBitYil, CikisTarihi, AktarimAyi;
        string sonuc, AySonu, AyTarihi, SonTarih;
        decimal YillikAmortismanPayi, AylikAmortismanPayi, KalanYilAylikHesap;
        bool MesajDurumu;

        #region Değişken Tanımlarımız

        decimal AylikAmortisman, AmortismanOrani, iktisabDegeri, EndsTabiDeger, KalanDeger, EndekseTabiAmortismanTutari, KatSayisi,
            EndekslenmisDeger, EndekslenmisAmortisman, SabitKiymetEnfFarki, AmortismanEnfFarki, SonDonemEnflasyonOranimiz,
            DemirbasEnflasyonOranimiz, YeniEnflasyonOranimiz, YeniDegerim, AmrtOran, ToplamBAmortisman, YeniYilTotalAmortisman,
            RBul, TotalBirikAmortisman, CariDonemAmortisman;

        string demirbasKodu, demirbasAdi, AmortismanHesabi, MuhasebeHesabi, GiderHesabi, KodDurumu, DonAy, Tarihimiz;

        int BaslangicYili, BaslangicAyi, BitisYili, BitisAyi, carprakam, YeniCarpRakam, DonemAyi, DonemYil;

        #endregion

        private void AmortismanHesaplama_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsAmortisman.TumAmortismanHesaplari' table. You can move, or remove it, as needed.
            this.tumAmortismanHesaplariTableAdapter.TumAmortismanHesaplari(this.dsAmortisman.TumAmortismanHesaplari);
            // TODO: This line of code loads data into the 'dsAmortisman.AmortHesaplari' table. You can move, or remove it, as needed.
            //this.amortHesaplariTableAdapter.AmortHesaplar(this.dsAmortisman.AmortHesaplari);
            // TODO: This line of code loads data into the 'dsAmortisman.Amortismanlar' table. You can move, or remove it, as needed.
            //this.amortismanlarTableAdapter.Fill(this.dsAmortisman.Amortismanlar);
            gridView1.BestFitColumns();
            Conn = new SqlConnection(Cs);
            ConOran = new SqlConnection(CsOranlar);

            for (int i = 2000; i <= DateTime.Now.Year; i++)
            {
                cmbEnflasyonBaslangicYili.Properties.Items.Add(i.ToString());
                cmbEnflasyonBitisYili.Properties.Items.Add(i.ToString());
                SelectBitYil++;
            }
            cmbEnflasyonBaslangicYili.SelectedIndex = 4;
            cmbEnflasyonBitisYili.SelectedIndex = SelectBitYil - 1;

            pnKontrol.Visible = false;
        }

        private void btnExceleAktar_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "*.xls|*.xls";
            dlg.FileName = "Amortisman Hesapları-" + DateTime.Now.ToString("dd-MM-yyyy");
            if (dlg.ShowDialog() == DialogResult.OK)
            {

                gridView1.ExportToXls(dlg.FileName);
                VerifyFileProduced(dlg.FileName, "Excel");
            }
        }

        private void VerifyFileProduced(string fileName, string TypeFile)
        {

            FileInfo fileInfo = new FileInfo(fileName);
            if (fileInfo.Exists)
            {
                string dashes = "-------------";
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Veriler Aktarılmıştır.");
                sb.AppendLine(dashes);
                sb.AppendLine("Dosya Adı: " + fileInfo.Name);
                sb.AppendLine(dashes);
                sb.AppendLine("Hazırlayan: " + fileInfo.DirectoryName);
                sb.AppendLine(dashes);
                sb.AppendLine("Dosya Full Adı: " + fileName);
                sb.AppendLine(dashes);
                sb.AppendLine("Dosya Tipi: " + TypeFile);
                sb.AppendLine(dashes);
                sb.AppendLine("Dosya Boyutu: " + fileInfo.Length);
                MessageBox.Show(sb.ToString(), "Veriler Aktarılmıştır", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Veriler Aktarılamadı", "Dosya Kaydedilemedi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDonemYili_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 47 && (int)e.KeyChar <= 58)
            {
                e.Handled = false;
            }
            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private string DonemZamani(string Donem)
        {
            switch (Donem)
            {
                case "Ocak": sonuc = "1"; break;
                case "Şubat": sonuc = "1"; break;
                case "Mart": sonuc = "1"; break;
                case "Nisan": sonuc = "2"; break;
                case "Mayıs": sonuc = "2"; break;
                case "Haziran": sonuc = "2"; break;
                case "Temmuz": sonuc = "3"; break;
                case "Ağustos": sonuc = "3"; break;
                case "Eylül": sonuc = "3"; break;
                case "Ekim": sonuc = "4"; break;
                case "Kasım": sonuc = "4"; break;
                case "Aralık": sonuc = "4"; break;
            }
            string Yeniislem = sonuc;
            return Yeniislem;
        }

        private string AylarinSonGunu(string Ay)
        {
            switch (Ay)
            {
                case "1": AySonu = "31"; break;
                case "2": AySonu = "28"; break;
                case "3": AySonu = "31"; break;
                case "4": AySonu = "30"; break;
                case "5": AySonu = "31"; break;
                case "6": AySonu = "30"; break;
                case "7": AySonu = "31"; break;
                case "8": AySonu = "31"; break;
                case "9": AySonu = "30"; break;
                case "10": AySonu = "31"; break;
                case "11": AySonu = "30"; break;
                case "12": AySonu = "31"; break;
            }
            string Yeniislem = AySonu;
            return Yeniislem;
        }

        private int DonemCarpimi(int Ayimiz)
        {
            switch (Ayimiz)
            {
                case 1: CarpimAyi = 12; break;
                case 2: CarpimAyi = 11; break;
                case 3: CarpimAyi = 10; break;
                case 4: CarpimAyi = 9; break;
                case 5: CarpimAyi = 8; break;
                case 6: CarpimAyi = 7; break;
                case 7: CarpimAyi = 6; break;
                case 8: CarpimAyi = 5; break;
                case 9: CarpimAyi = 4; break;
                case 10: CarpimAyi = 3; break;
                case 11: CarpimAyi = 2; break;
                case 12: CarpimAyi = 1; break;
            }
            int Yeniislem = CarpimAyi;
            return Yeniislem;
        }

        private string AylarinTarihi(string Ay)
        {
            switch (Ay)
            {
                case "Ocak": AyTarihi = "12"; break;
                case "Şubat": AyTarihi = "11"; break;
                case "Mart": AyTarihi = "10"; break;
                case "Nisan": AyTarihi = "9"; break;
                case "Mayıs": AyTarihi = "8"; break;
                case "Haziran": AyTarihi = "7"; break;
                case "Temmuz": AyTarihi = "6"; break;
                case "Ağustos": AyTarihi = "5"; break;
                case "Eylül": AyTarihi = "4"; break;
                case "Ekim": AyTarihi = "3"; break;
                case "Kasım": AyTarihi = "2"; break;
                case "Aralık": AyTarihi = "1"; break;
            }
            string Yeniislem = AyTarihi;
            return Yeniislem;
        }

        private string AylarinTarihi2(string Ay)
        {
            switch (Ay)
            {
                case "Ocak": AyTarihi = "1"; break;
                case "Şubat": AyTarihi = "2"; break;
                case "Mart": AyTarihi = "3"; break;
                case "Nisan": AyTarihi = "4"; break;
                case "Mayıs": AyTarihi = "5"; break;
                case "Haziran": AyTarihi = "6"; break;
                case "Temmuz": AyTarihi = "7"; break;
                case "Ağustos": AyTarihi = "8"; break;
                case "Eylül": AyTarihi = "9"; break;
                case "Ekim": AyTarihi = "10"; break;
                case "Kasım": AyTarihi = "11"; break;
                case "Aralık": AyTarihi = "12"; break;
            }
            string Yeniislem = AyTarihi;
            return Yeniislem;
        }

        private string SonIslemTarihi(string Ay)
        {
            switch (Ay)
            {
                case "Ocak": SonTarih = "2"; break;
                case "Şubat": SonTarih = "3"; break;
                case "Mart": SonTarih = "4"; break;
                case "Nisan": SonTarih = "5"; break;
                case "Mayıs": SonTarih = "6"; break;
                case "Haziran": SonTarih = "7"; break;
                case "Temmuz": SonTarih = "8"; break;
                case "Ağustos": SonTarih = "9"; break;
                case "Eylül": SonTarih = "10"; break;
                case "Ekim": SonTarih = "11"; break;
                case "Kasım": SonTarih = "12"; break;
                case "Aralık": SonTarih = "1"; break;
            }
            string Yeniislem = SonTarih;
            return Yeniislem;
        }

        void AmortismanOlustur()
        {
            if (Conn.State == ConnectionState.Closed)
                Conn.Open();

            this.dsAmortisman.Amortismanlar.Clear();
            //grdAmortHesap.Visible = true;
            //gridAmortismanlar.Visible = false;

            decimal MaliyetDegeri = 0;
            decimal AmortismanOrani = 0;

            foreach (DataRow dr in dsAmortisman.AmortHesaplari.Rows)
            {
                string DemirbasKod = dr[0].ToString();

                AlimYili = Convert.ToInt32(sqlQueryler1.AlimYili(DemirbasKod));

                HareketDurumu = (int)sqlQueryler1.DemirbasHareketDurumu(DemirbasKod);
                SonYil = (int)sqlQueryler1.SonDonemYili(DemirbasKod);

                string DonemAyimiz = cmbDonemAyi.SelectedItem.ToString();

                int DonemAyi = Convert.ToInt32(DonemZamani(DonemAyimiz));
                int DonYil = 0;

                string DonemYilimiz = txtDonemYili.Text;

                if (string.IsNullOrEmpty(DonemYilimiz))
                {
                    DonYil = Convert.ToInt32(DateTime.Now.Year);
                }
                else
                {
                    DonYil = Convert.ToInt32(DonemYilimiz);
                }

                AmortismanOrani = Convert.ToDecimal(dr[5].ToString());
                MaliyetDegeri = Convert.ToDecimal(dr[11].ToString());
                decimal BirikmisAmortisman = Convert.ToDecimal(dr[19].ToString());
                decimal CariYilAmortisman = Convert.ToDecimal(dr[17].ToString());
                decimal AylikAmortisman = 0;
                CarpAy = Convert.ToInt32(sqlQueryler1.BaslangicAyiBul(DemirbasKod));
                CarpAy = DonemCarpimi(CarpAy);

                double Tarih = 0;
                int TarihRakam = 0;
                double DegTarih = 0;
                int TarihDeg = 0;

                string EskiDemirbasTarih = AylarinSonGunu(AylarinTarihi2(cmbDonemAyi.Text.ToString())) + "." + AylarinTarihi2(cmbDonemAyi.Text.ToString()) + "." + txtDonemYili.Text;

                DateTime obj = new DateTime();
                obj = Convert.ToDateTime(EskiDemirbasTarih);
                string str;
                Tarih = 0;
                Tarih = obj.ToOADate();
                str = Tarih.ToString().Substring(0, 5);
                TarihRakam = Convert.ToInt32(str);

                DateTime obj2 = new DateTime();
                obj2 = Convert.ToDateTime(DateTime.Now);
                string str2;
                DegTarih = 0;
                DegTarih = obj2.ToOADate();
                str2 = DegTarih.ToString().Substring(0, 5);
                TarihDeg = Convert.ToInt32(str2);

                DateTime DtSaat = DateTime.Now;
                string Saatimiz = Convert.ToString(DtSaat);
                int saatuzunluk = Saatimiz.ToString().Length;

                if (saatuzunluk == 18)
                {
                    Saatimiz = Saatimiz.ToString().Substring(10, 8);
                }
                else if (saatuzunluk == 19)
                {
                    Saatimiz = Saatimiz.ToString().Substring(11, 8);
                }
                Saatimiz = Saatimiz.ToString().Replace(":", "");

                if (Saatimiz.ToString().Length > 8)
                {
                    Saatimiz = Saatimiz.ToString().Substring(0, 8);
                }

                string PcAdi = Environment.UserName.ToString();

                if (PcAdi.ToString().Length > 10)
                {
                    PcAdi = PcAdi.ToString().Substring(0, 10);
                }

                if (HareketDurumu == 0)
                {
                    CariYilAmortisman = Convert.ToDecimal(dr[17].ToString());
                    CariYilAmortisman = Math.Round(CariYilAmortisman, 2);

                    AylikAmortismanPayi = Convert.ToDecimal(dr[18].ToString());
                    AylikAmortismanPayi = Math.Round(AylikAmortismanPayi, 2);

                    YillikAmortismanPayi = Convert.ToDecimal(dr[17].ToString());
                    YillikAmortismanPayi = Math.Round(YillikAmortismanPayi, 2);

                    this.dsAmortisman.Amortismanlar.AddAmortismanlarRow(DemirbasKod, DonYil, Convert.ToInt16(DonemAyi), 2, 1, AmortismanOrani, 1, MaliyetDegeri,
                    0, CariYilAmortisman, 0, 0, 0, 1, 0, 0, 0, "Y9042", TarihRakam, Saatimiz, PcAdi, "6.1.10", "Y9042", TarihRakam, Saatimiz, PcAdi,
                    "6.1.10", 0, 0, 0, "", 0, 0, 0, "", 0, 0, 0, 0, 0, 0, 0, 0, "", "", 0, 0, "Yıllık", "Normal", "Ayrıldı", AylikAmortismanPayi, YillikAmortismanPayi);
                }
                else
                {
                    CariYilAmortisman = Convert.ToDecimal(dr[17].ToString());
                    CariYilAmortisman = Math.Round(CariYilAmortisman, 2);

                    AylikAmortismanPayi = Convert.ToDecimal(dr[18].ToString());
                    AylikAmortismanPayi = Math.Round(AylikAmortismanPayi, 2);

                    YillikAmortismanPayi = Convert.ToDecimal(dr[17].ToString());
                    YillikAmortismanPayi = Math.Round(YillikAmortismanPayi, 2);

                    this.dsAmortisman.Amortismanlar.AddAmortismanlarRow(DemirbasKod, DonYil, Convert.ToInt16(DonemAyi), 2, 1, AmortismanOrani, 1, MaliyetDegeri,
                    CariYilAmortisman, AylikAmortismanPayi, 0, 0, 0, 1, 0, 0, 0, "Y9042", TarihRakam, Saatimiz, PcAdi, "6.1.10", "Y9042", TarihRakam, Saatimiz, PcAdi,
                    "6.1.10", 0, 0, 0, "", 0, 0, 0, "", 0, 0, 0, 0, 0, 0, 0, 0, "", "", 0, 0, "Yıllık", "Normal", "Ayrıldı", AylikAmortismanPayi, YillikAmortismanPayi);
                }
            }
        }

        void KayitlariAktar()
        {
            foreach (DataRow dr in dsAmortisman.Amortismanlar.Rows)
            {
                string DemirbasKodu = dr["DEM008_DemKodu"].ToString();
                int Yil = Convert.ToInt32(dr["DEM008_Yil"].ToString());
                int Donem = Convert.ToInt32(dr["DEM008_Donem"].ToString());
                decimal AmortismanOrani = Convert.ToDecimal(dr["DEM008_AmortOrani"].ToString());
                decimal MaliyetDegeri = Convert.ToDecimal(dr["DEM008_MaliyetDegeri"].ToString());
                decimal BirikmisAmortismanlar = Convert.ToDecimal(dr["DEM008_BirikAmortisman"].ToString());
                decimal CariYilAmortisman = Convert.ToDecimal(dr["DEM008_CarYilAmort"].ToString());
                int Tarih = Convert.ToInt32(dr["DEM008_DemGirDate"].ToString());
                string Saatimiz = dr["DEM008_DemGirTime"].ToString();
                string PcAdi = dr["DEM008_DemGirisKodu"].ToString();
                string IslemYili = SonIslemTarihi(cmbDonemAyi.SelectedItem.ToString());

                HareketDurumu = (int)sqlQueryler1.DemirbasHareketDurumu(DemirbasKodu);
                SonYil = (int)sqlQueryler1.SonDonemYili(DemirbasKodu);

                double DegTarih = 0;
                int TarihDeg = 0;

                DateTime obj2 = new DateTime();
                obj2 = Convert.ToDateTime(DateTime.Now);
                string str2;
                DegTarih = 0;
                DegTarih = obj2.ToOADate();
                str2 = DegTarih.ToString().Substring(0, 5);
                TarihDeg = Convert.ToInt32(str2);
                string AyrilmayanAmort = "";
                decimal AyrilmayanAmortisman = 0;
                decimal YeniAyrilmayanAmortisman = 0;

                if (HareketDurumu == 0)
                {
                    sqlQueryler1.NormalAmortismanDemirbasKartiGuncelle(TarihDeg, Saatimiz, PcAdi, MaliyetDegeri, CariYilAmortisman,
                    Yil, Convert.ToInt16(Donem), 0, 0, 0, 0, 0, 0, 0, IslemYili, DemirbasKodu);
                }
                else
                {
                    if (SonYil == Yil)
                    {
                        string SonIslemAyimiz = cmbDonemAyi.SelectedText.ToString();
                        string SonIslemYiliYaz = "";
                        decimal MylBirikmisAmortisman = 0;
                        decimal ilkYilMaliyetDegeri = 0;
                        decimal MaliyetDegeriTarihi = 0;
                        decimal BirikmisAmortismanTarihi = 0;

                        if (SonIslemYiliYaz == "Aralık")
                        {
                            SonIslemYiliYaz = Convert.ToString(Yil);

                            MylBirikmisAmortisman = ((Convert.ToDecimal(dr[10].ToString()) * AmortismanOrani) / 100);
                            MylBirikmisAmortisman = Math.Round(MylBirikmisAmortisman, 2);

                            ilkYilMaliyetDegeri = MaliyetDegeri;
                            MaliyetDegeriTarihi = ilkYilMaliyetDegeri;

                            BirikmisAmortismanTarihi = ((Convert.ToDecimal(dr[10].ToString()) * AmortismanOrani) / 100);
                            BirikmisAmortismanTarihi = Math.Round(BirikmisAmortismanTarihi, 2);
                        }
                        else
                        {
                            SonIslemYiliYaz = Convert.ToString(sqlQueryler1.SonDonemYili(DemirbasKodu));
                            MylBirikmisAmortisman = Convert.ToDecimal(sqlQueryler1.MlyBirikmisAmortisman(DemirbasKodu));
                            MylBirikmisAmortisman = Math.Round(MylBirikmisAmortisman, 2);

                            ilkYilMaliyetDegeri = Convert.ToDecimal(sqlQueryler1.MlyMaliyetDeg(DemirbasKodu));
                            ilkYilMaliyetDegeri = Math.Round(ilkYilMaliyetDegeri, 2);
                            MaliyetDegeriTarihi = ilkYilMaliyetDegeri;

                            BirikmisAmortismanTarihi = 0;
                        }

                        sqlQueryler1.NormalAmortismanDemirbasKartiGuncelle(TarihDeg, Saatimiz, PcAdi, MaliyetDegeri, Math.Round(CariYilAmortisman, 2),
                        Yil, Convert.ToInt16(Donem), Convert.ToInt32(SonIslemYiliYaz), BirikmisAmortismanTarihi, ilkYilMaliyetDegeri,
                        ilkYilMaliyetDegeri, BirikmisAmortismanTarihi, MaliyetDegeri, Math.Round(CariYilAmortisman, 2), IslemYili, DemirbasKodu);
                    }
                    else
                    {
                        string SonIslemAyimiz = cmbDonemAyi.SelectedText.ToString();
                        string SonIslemYiliYaz = "";
                        decimal MylBirikmisAmortisman = 0;
                        decimal ilkYilMaliyetDegeri = 0;
                        decimal MaliyetDegeriTarihi = 0;
                        decimal BirikmisAmortismanTarihi = 0;

                        if (SonIslemYiliYaz == "Aralık")
                        {
                            SonIslemYiliYaz = Convert.ToString(Yil);

                            MylBirikmisAmortisman = ((Convert.ToDecimal(dr[10].ToString()) * AmortismanOrani) / 100);
                            MylBirikmisAmortisman = Math.Round(MylBirikmisAmortisman, 2);

                            ilkYilMaliyetDegeri = MaliyetDegeri;
                            MaliyetDegeriTarihi = ilkYilMaliyetDegeri;

                            BirikmisAmortismanTarihi = ((Convert.ToDecimal(dr[10].ToString()) * AmortismanOrani) / 100);
                            BirikmisAmortismanTarihi = Math.Round(BirikmisAmortismanTarihi, 2);
                        }
                        else
                        {
                            SonIslemYiliYaz = Convert.ToString(sqlQueryler1.SonDonemYili(DemirbasKodu));
                            MylBirikmisAmortisman = Convert.ToDecimal(sqlQueryler1.MlyBirikmisAmortisman(DemirbasKodu));
                            MylBirikmisAmortisman = Math.Round(MylBirikmisAmortisman, 2);

                            ilkYilMaliyetDegeri = Convert.ToDecimal(sqlQueryler1.MlyMaliyetDeg(DemirbasKodu));
                            ilkYilMaliyetDegeri = Math.Round(ilkYilMaliyetDegeri, 2);
                            MaliyetDegeriTarihi = ilkYilMaliyetDegeri;

                            BirikmisAmortismanTarihi = 0;
                        }

                        sqlQueryler1.NormalAmortismanDemirbasKartiGuncelle(TarihDeg, Saatimiz, PcAdi, MaliyetDegeri, Math.Round(CariYilAmortisman, 2),
                        Yil, Convert.ToInt16(Donem), Convert.ToInt32(SonIslemYiliYaz), BirikmisAmortismanTarihi, ilkYilMaliyetDegeri,
                        ilkYilMaliyetDegeri, BirikmisAmortismanTarihi, MaliyetDegeri, Math.Round(CariYilAmortisman, 2), IslemYili, DemirbasKodu);
                    }
                }

                AyrilmayanAmort = Convert.ToString(sqlQueryler1.AyrilmayanAmortisman(DemirbasKodu));

                if (string.IsNullOrEmpty(AyrilmayanAmort))
                {
                    AyrilmayanAmortisman = CariYilAmortisman;
                }
                else
                {
                    AyrilmayanAmortisman = Convert.ToDecimal(AyrilmayanAmort) + CariYilAmortisman;
                    AyrilmayanAmortisman = Math.Round(AyrilmayanAmortisman, 2);
                }

                decimal AmortismanSonundaKalanDeger = BirikmisAmortismanlar - Convert.ToDecimal("0,01");
                sqlQueryler1.DemirbasHareketiEkle(DemirbasKodu, Yil, Convert.ToInt16(Donem), AmortismanOrani, MaliyetDegeri,
                    BirikmisAmortismanlar, CariYilAmortisman, AyrilmayanAmortisman, Tarih, Saatimiz, PcAdi);

                //sqlQueryler1.EskiDemirbasKartlariGuncelle(Tarih, Saatimiz, PcAdi, MaliyetDegeri, AmortismanSonundaKalanDeger, Yil, 4,
                //    Yil, AmortismanSonundaKalanDeger, MaliyetDegeri, 1, MaliyetDegeri, DemirbasKodu);

            }
        }

        void KayitAktar()
        {
            string PcAdiDemKart = "";

            btnDemirbaslariGetir.Enabled = false;
            btnExceleAktar.Enabled = false;
            btnKayitlariAktar.Enabled = false;
            btnTemizle.Enabled = false;
            CheckForIllegalCrossThreadCalls = false;

            KanalAktar = Task.Factory.StartNew(() =>
            {
                foreach (DataRow dr in dsAmortisman.Hareketler.Rows)
                {
                    int BaslangicYili = Convert.ToInt32(dr["BaslangicYili"].ToString());
                    int BaslangicAyi = Convert.ToInt32(dr["BaslangicAyi"].ToString());
                    int BitisYili = Convert.ToInt32(dr["BitisYili"].ToString());
                    int BitisAyi = Convert.ToInt32(dr["BitisAyi"].ToString());

                    int DonemYil = 0;

                    if (string.IsNullOrEmpty(txtDonemYili.Text))
                    {
                        DonemYil = Convert.ToInt32(DateTime.Now.Year);
                    }
                    else
                    {
                        DonemYil = Convert.ToInt32(txtDonemYili.Text);
                    }

                    string DemirbasKodu = dr["SabitKiymetKodu"].ToString();
                    int IslemYili = Convert.ToInt32(txtDonemYili.Text);
                    string DonemAyimiz = cmbDonemAyi.SelectedItem.ToString();
                    int DonemAyi = Convert.ToInt32(DonemZamani(DonemAyimiz));

                    double Tarih = 0;
                    int TarihRakam = 0;
                    double DegTarih = 0;
                    int TarihDeg = 0;

                    string EskiDemirbasTarih = AylarinSonGunu(AylarinTarihi2(cmbDonemAyi.Text.ToString())) + "." + AylarinTarihi2(cmbDonemAyi.Text.ToString()) + "." + txtDonemYili.Text;

                    DateTime obj = new DateTime();
                    obj = Convert.ToDateTime(EskiDemirbasTarih);
                    string str;
                    Tarih = 0;
                    Tarih = obj.ToOADate();
                    str = Tarih.ToString().Substring(0, 5);
                    TarihRakam = Convert.ToInt32(str);

                    DateTime obj2 = new DateTime();
                    obj2 = Convert.ToDateTime(DateTime.Now);
                    string str2;
                    DegTarih = 0;
                    DegTarih = obj2.ToOADate();
                    str2 = DegTarih.ToString().Substring(0, 5);
                    TarihDeg = Convert.ToInt32(str2);

                    DateTime DtSaat = DateTime.Now;
                    string Saatimiz = Convert.ToString(DtSaat);
                    int saatuzunluk = Saatimiz.ToString().Length;

                    if (saatuzunluk == 18)
                    {
                        Saatimiz = Saatimiz.ToString().Substring(10, 8);
                    }
                    else if (saatuzunluk == 19)
                    {
                        Saatimiz = Saatimiz.ToString().Substring(11, 8);
                    }
                    else if (saatuzunluk == 17)
                    {
                        Saatimiz = Saatimiz.ToString().Substring(9, 8);
                    }
                    Saatimiz = Saatimiz.ToString().Replace(":", "");

                    if (Saatimiz.ToString().Length > 8)
                    {
                        Saatimiz = Saatimiz.ToString().Substring(0, 8);
                    }

                    string PcAdi = Environment.UserName.ToString();
                    PcAdiDemKart = PcAdi;

                    if (PcAdi.ToString().Length > 10)
                    {
                        PcAdi = PcAdi.ToString().Substring(0, 10);
                        PcAdiDemKart = PcAdi;
                    }

                    int KontrolMiktari = Convert.ToInt32(dr["Miktar"].ToString());

                    if (chkEnflasyon.Checked == false)
                    {
                        if (DemirbasKodu.Length > 13 && DemirbasKodu != "GENEL TOPLAM")
                        {
                            CikisTarihi = DemirbasCikisTarihineBakiyoruz(DemirbasKodu);

                            //if (CikisTarihi == 0)
                            //{
                            if (BitisYili >= DonemYil && BaslangicYili <= DonemYil && KontrolMiktari > 0)
                            {
                                int AktarimKontrol = Convert.ToInt32(this.sqlQueryler1.AktarimKontrol(DemirbasKodu, TarihRakam));

                                if (AktarimKontrol == 0)
                                {
                                    decimal AmortismanOrani = Convert.ToDecimal(dr["AmortismanOrani"].ToString());
                                    decimal MaliyetDegeri = Convert.ToDecimal(dr["EndekseTabiDeger"].ToString());
                                    decimal BirikenAmortisman = Convert.ToDecimal(dr["EndekslenmisAmortisman"].ToString());
                                    decimal CariYilAmortisman = Convert.ToDecimal(dr["CariYilAmortisman"].ToString());
                                    decimal AylAmortisman = Convert.ToDecimal(dr["AylikAmortisman"].ToString());
                                    decimal TotalAmorti = Convert.ToDecimal(dr["ToplamBirikmisAmortisman"].ToString());
                                    int AktarimAyi = Convert.ToInt32(AylarinTarihi2(cmbDonemAyi.Text.ToString()));

                                    AmortismanOrani = Math.Round(AmortismanOrani, 2);
                                    MaliyetDegeri = Math.Round(MaliyetDegeri, 2);
                                    BirikenAmortisman = Math.Round(BirikenAmortisman, 2);
                                    CariYilAmortisman = Math.Round(CariYilAmortisman, 2);
                                    AylAmortisman = Math.Round(AylAmortisman, 2);

                                    this.sqlQueryler1.DemHareket(DemirbasKodu, IslemYili, Convert.ToInt16(DonemAyi), AmortismanOrani, MaliyetDegeri, BirikenAmortisman, AylAmortisman,
                                        TarihRakam, Saatimiz, PcAdi, CariYilAmortisman, AktarimAyi);


                                    PcAdiDemKart = PcAdiDemKart.ToString().Substring(0, 5);

                                    string SonIslemAyimiz = cmbDonemAyi.Text.ToString();

                                    //this.sqlQueryler1.DemirbasKartNUpdate(TarihDeg, Saatimiz, PcAdiDemKart, AylAmortisman, IslemYili, Convert.ToInt16(DonemAyi)
                                    //, IslemYili - 1, BirikenAmortisman, MaliyetDegeri, DemirbasKodu);

                                    this.sqlQueryler1.DemirbasKartNUpdate(TarihDeg, Saatimiz, PcAdiDemKart, TotalAmorti, IslemYili, Convert.ToInt16(DonemAyi),
                                        IslemYili - 1, BirikenAmortisman, AylAmortisman, MaliyetDegeri, DemirbasKodu);
                                }
                            }
                            //}
                        }
                    }
                    else
                    {
                        if (DemirbasKodu.Length > 13 && DemirbasKodu != "GENEL TOPLAM")
                        {
                            CikisTarihi = DemirbasCikisTarihineBakiyoruz(DemirbasKodu);

                            //if (CikisTarihi == 0)
                            //{
                            if (BitisYili >= DonemYil && BaslangicYili <= DonemYil && KontrolMiktari > 0)
                            {
                                int AktarimKontrol = Convert.ToInt32(this.sqlQueryler1.AktarimKontrol(DemirbasKodu, TarihRakam));

                                if (AktarimKontrol == 0)
                                {
                                    decimal AmortismanOrani = Convert.ToDecimal(dr["AmortismanOrani"].ToString());
                                    decimal MaliyetDegeri = Convert.ToDecimal(dr["EndekseTabiDeger"].ToString());
                                    decimal BirikenAmortisman = Convert.ToDecimal(dr["EndekseTabiAmortisman"].ToString());
                                    decimal CariYilAmortisman = Convert.ToDecimal(dr["CariYilAmortisman"].ToString());
                                    decimal AylAmortisman = Convert.ToDecimal(dr["AylikAmortisman"].ToString());

                                    decimal EndekslenmisDeger = Convert.ToDecimal(dr["EndekslenmisDeger"].ToString());
                                    decimal EndekslenmisAmortisman = Convert.ToDecimal(dr["EndekslenmisAmortisman"].ToString());

                                    int AktarimAyi = Convert.ToInt32(AylarinTarihi2(cmbDonemAyi.Text.ToString()));

                                    AmortismanOrani = Math.Round(AmortismanOrani, 2);
                                    MaliyetDegeri = Math.Round(MaliyetDegeri, 2);
                                    BirikenAmortisman = Math.Round(BirikenAmortisman, 2);
                                    CariYilAmortisman = Math.Round(CariYilAmortisman, 2);
                                    EndekslenmisDeger = Math.Round(EndekslenmisDeger, 2);
                                    EndekslenmisAmortisman = Math.Round(EndekslenmisAmortisman, 2);
                                    AylAmortisman = Math.Round(AylAmortisman, 2);

                                    this.sqlQueryler1.DemHareket(DemirbasKodu, IslemYili, Convert.ToInt16(DonemAyi), AmortismanOrani, MaliyetDegeri, BirikenAmortisman, AylAmortisman,
                                        TarihRakam, Saatimiz, PcAdi, CariYilAmortisman, AktarimAyi);

                                    PcAdiDemKart = PcAdiDemKart.ToString().Substring(0, 5);
                                    string SonIslemAyimiz = cmbDonemAyi.Text.ToString();

                                    this.sqlQueryler1.EnflasyonaGöreDemirbasGuncelleme(TarihDeg, Saatimiz, PcAdi, EndekslenmisAmortisman,
                                        AylAmortisman, IslemYili, Convert.ToInt16(DonemAyi), IslemYili - 1, EndekslenmisDeger, DemirbasKodu);

                                }
                            }
                            else
                            {
                                int AktarimKontrol = Convert.ToInt32(this.sqlQueryler1.AktarimKontrol(DemirbasKodu, TarihRakam));

                                if (AktarimKontrol == 0)
                                {
                                    decimal AmortismanOrani = Convert.ToDecimal(dr["AmortismanOrani"].ToString());
                                    decimal MaliyetDegeri = Convert.ToDecimal(dr["EndekseTabiDeger"].ToString());
                                    decimal BirikenAmortisman = Convert.ToDecimal(dr["EndekseTabiAmortisman"].ToString());
                                    decimal CariYilAmortisman = Convert.ToDecimal(dr["CariYilAmortisman"].ToString());
                                    decimal AylAmortisman = Convert.ToDecimal(dr["AylikAmortisman"].ToString());

                                    decimal EndekslenmisDeger = Convert.ToDecimal(dr["EndekslenmisDeger"].ToString());
                                    decimal EndekslenmisAmortisman = Convert.ToDecimal(dr["EndekslenmisAmortisman"].ToString());

                                    AmortismanOrani = Math.Round(AmortismanOrani, 2);
                                    MaliyetDegeri = Math.Round(MaliyetDegeri, 2);
                                    BirikenAmortisman = Math.Round(BirikenAmortisman, 2);
                                    CariYilAmortisman = Math.Round(CariYilAmortisman, 2);
                                    EndekslenmisDeger = Math.Round(EndekslenmisDeger, 2);
                                    EndekslenmisAmortisman = Math.Round(EndekslenmisAmortisman, 2);

                                    PcAdiDemKart = PcAdiDemKart.ToString().Substring(0, 5);
                                    string SonIslemAyimiz = cmbDonemAyi.Text.ToString();

                                    this.sqlQueryler1.EnflasyonaGoreBitenDemirbasGuncelleme(TarihDeg, Saatimiz, PcAdi, EndekslenmisAmortisman, EndekslenmisDeger, DemirbasKodu);

                                }
                            }
                            //}
                        }
                    }
                }
            })
                .ContinueWith((Kanal3) =>
                {

                    //MessageBox.Show("Demirbaş Hareketleri Başarılı Bir Şekilde Aktarılmıştır.", "Demirbaş Hareket Durumu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.dsAmortisman.AmortHesaplari.Clear();

                    btnDemirbaslariGetir.Enabled = true;
                    btnExceleAktar.Enabled = true;
                    btnKayitlariAktar.Enabled = false;
                    btnTemizle.Enabled = true;
                });

        }

        void AktarimKayitAyarla()
        {
            btnDemirbaslariGetir.Enabled = false;
            btnExceleAktar.Enabled = false;
            btnKayitlariAktar.Enabled = false;
            btnTemizle.Enabled = false;
            CheckForIllegalCrossThreadCalls = false;

            dsAmortisman.AktarimHareketleri.Clear();
            dsAmortisman.KayitFarklari.Clear();

            KanalAktarimAyarla = Task.Factory.StartNew(() =>
               {
                   foreach (DataRow dr in dsAmortisman.Hareketler.Rows)
                   {
                       int BaslangicYili = Convert.ToInt32(dr["BaslangicYili"].ToString());
                       int BaslangicAyi = Convert.ToInt32(dr["BaslangicAyi"].ToString());
                       int BitisYili = Convert.ToInt32(dr["BitisYili"].ToString());
                       int BitisAyi = Convert.ToInt32(dr["BitisAyi"].ToString());
                       int KontrolMiktari = Convert.ToInt32(dr["Miktar"].ToString());
                       string DemirbasKodu = dr["SabitKiymetKodu"].ToString();
                       AktarimAyi = Convert.ToInt32(AylarinTarihi2(cmbDonemAyi.Text.ToString()));

                       double Tarih = 0;
                       int TarihRakam = 0;

                       string EskiDemirbasTarih = AylarinSonGunu(AylarinTarihi2(cmbDonemAyi.Text.ToString())) + "." + AylarinTarihi2(cmbDonemAyi.Text.ToString()) + "." + txtDonemYili.Text;

                       DateTime obj = new DateTime();
                       obj = Convert.ToDateTime(EskiDemirbasTarih);
                       string str;
                       Tarih = 0;
                       Tarih = obj.ToOADate();
                       str = Tarih.ToString().Substring(0, 5);
                       TarihRakam = Convert.ToInt32(str);

                       if (chkEnflasyon.Checked == false)
                       {
                           if (DemirbasKodu.Length > 13 && DemirbasKodu != "GENEL TOPLAM")
                           {
                               if (BitisYili >= DonemYil && BaslangicYili <= DonemYil && KontrolMiktari > 0)
                               {
                                   int AktarimKontrol = (int)this.sqlQueryler1.AktarimKontrol(DemirbasKodu, TarihRakam);

                                   if (AktarimKontrol == 0)
                                   {
                                       this.dsAmortisman.KayitFarklari.AddKayitFarklariRow(DemirbasKodu, Convert.ToDecimal(dr["EndekseTabiDeger"].ToString()),
                    Convert.ToDecimal(dr["EndekslenmisAmortisman"].ToString()), Convert.ToDecimal(1),
                    Convert.ToDecimal(dr["CariYilAmortisman"].ToString()), TarihRakam);
                                   }
                                   else
                                   {
                                       KayitFarklariBuluyoruz(DemirbasKodu, TarihRakam);
                                   }
                               }
                           }
                       }
                       else
                       {
                           if (DemirbasKodu.Length > 13 && DemirbasKodu != "GENEL TOPLAM")
                           {
                               if (BitisYili >= DonemYil && BaslangicYili <= DonemYil && KontrolMiktari > 0)
                               {
                                   int AktarimKontrol = (int)this.sqlQueryler1.AktarimKontrol(DemirbasKodu, TarihRakam);

                                   if (AktarimKontrol == 0)
                                   {
                                       this.dsAmortisman.KayitFarklari.AddKayitFarklariRow(DemirbasKodu, Convert.ToDecimal(dr["EndekseTabiDeger"].ToString()),
                    Convert.ToDecimal(dr["EndekslenmisAmortisman"].ToString()), Convert.ToDecimal(1),
                    Convert.ToDecimal(dr["CariYilAmortisman"].ToString()), TarihRakam);
                                   }
                                   else
                                   {
                                       KayitFarklariBuluyoruz(DemirbasKodu, TarihRakam);
                                   }
                               }
                               else
                               {
                                   int AktarimKontrol = (int)this.sqlQueryler1.AktarimKontrol(DemirbasKodu, TarihRakam);

                                   if (AktarimKontrol == 0)
                                   {
                                       this.dsAmortisman.KayitFarklari.AddKayitFarklariRow(DemirbasKodu, Convert.ToDecimal(dr["EndekseTabiDeger"].ToString()),
                    Convert.ToDecimal(dr["EndekslenmisAmortisman"].ToString()), Convert.ToDecimal(1),
                    Convert.ToDecimal(dr["CariYilAmortisman"].ToString()), TarihRakam);
                                   }
                                   else
                                   {
                                       KayitFarklariBuluyoruz(DemirbasKodu, TarihRakam);
                                   }
                               }
                           }
                       }
                   }
               })
                .ContinueWith((KanalAktarimAyarla2) =>
                {
                    foreach (DataRow dr in dsAmortisman.Hareketler.Rows)
                    {
                        int BaslangicYili = Convert.ToInt32(dr["BaslangicYili"].ToString());
                        int BaslangicAyi = Convert.ToInt32(dr["BaslangicAyi"].ToString());
                        int BitisYili = Convert.ToInt32(dr["BitisYili"].ToString());
                        int BitisAyi = Convert.ToInt32(dr["BitisAyi"].ToString());
                        int KontrolMiktari = Convert.ToInt32(dr["Miktar"].ToString());
                        string DemirbasKodu = dr["SabitKiymetKodu"].ToString();
                        AktarimAyi = Convert.ToInt32(AylarinTarihi2(cmbDonemAyi.Text.ToString()));

                        double Tarih = 0;
                        int TarihRakam = 0;
                        string EskiDemirbasTarih = AylarinSonGunu(AylarinTarihi2(cmbDonemAyi.Text.ToString())) + "." + AylarinTarihi2(cmbDonemAyi.Text.ToString()) + "." + txtDonemYili.Text;

                        DateTime obj = new DateTime();
                        obj = Convert.ToDateTime(EskiDemirbasTarih);
                        string str;
                        Tarih = 0;
                        Tarih = obj.ToOADate();
                        str = Tarih.ToString().Substring(0, 5);
                        TarihRakam = Convert.ToInt32(str);

                        foreach (DataRow dr2 in dsAmortisman.KayitFarklari.Rows)
                        {
                            string demKod = dr2["SabitKiymetKodu"].ToString();
                            int Tar2 = Convert.ToInt32(dr2["GirisTarihi"].ToString());

                            if (demKod == DemirbasKodu && Tar2 == TarihRakam)
                            {
                                decimal MaliyetDegeriFarki = Math.Round(Convert.ToDecimal(dr["EndekseTabiDeger"].ToString()), 2) - Math.Round(Convert.ToDecimal(dr2["MaliyetDegeri"].ToString()), 2);
                                decimal BirikmisAmortismanFarki = Math.Round(Convert.ToDecimal(dr["EndekslenmisAmortisman"].ToString()), 2) - Math.Round(Convert.ToDecimal(dr2["BirikmisAmortisman"].ToString()), 2);
                                decimal AylikAmortismanFarki = Math.Round(Convert.ToDecimal(dr["AylikAmortisman"].ToString()), 2) - Math.Round(Convert.ToDecimal(dr2["AylikAmortisman"].ToString()), 2);
                                decimal CariYilAmortismanFarki = Math.Round(Convert.ToDecimal(dr["CariYilAmortisman"].ToString()), 2) - Math.Round(Convert.ToDecimal(dr2["CariYilAmortisman"].ToString()), 2);

                                this.dsAmortisman.AktarimHareketleri.AddAktarimHareketleriRow(DemirbasKodu, dr["SabitKiymetAdi"].ToString(), dr["AmortismanHesabi"].ToString(),
            dr["MuhasebeHesabi"].ToString(), dr["GiderHesabi"].ToString(), Convert.ToDecimal(dr["AmortismanOrani"].ToString()), BaslangicYili,
            BaslangicAyi, BitisYili, BitisAyi, Convert.ToDecimal(dr["iktisabDegeri"].ToString()), Convert.ToDecimal(dr["EndekseTabiDeger"].ToString()),
            Convert.ToDecimal(dr["EndekseTabiAmortisman"].ToString()), Convert.ToDecimal(dr["KatSayisi"].ToString()), Convert.ToDecimal(dr["EndekslenmisDeger"].ToString()),
            Convert.ToDecimal(dr["EndekslenmisAmortisman"].ToString()), Convert.ToDecimal(dr["KalanDeger"].ToString()), Convert.ToDecimal(dr["CariYilAmortisman"].ToString()),
            Convert.ToDecimal(dr["AylikAmortisman"].ToString()), Convert.ToDecimal(dr["ToplamBirikmisAmortisman"].ToString()), Convert.ToDecimal(dr["SabitKiymetEnflasyonFarki"].ToString()),
            Convert.ToDecimal(dr["AmortismanEnflasyonFarki"].ToString()), dr["Durumu"].ToString(), KontrolMiktari, MaliyetDegeriFarki, 
            BirikmisAmortismanFarki, AylikAmortismanFarki, CariYilAmortismanFarki,AktarimAyi);
                            }
                        }
                    }

                    MessageBox.Show("Aktarıma Hazır Kayıt Sayısı : " + Convert.ToString(dsAmortisman.AktarimHareketleri.Rows.Count) + " Adettir.");

                });

            pnNormal.Dock = DockStyle.Fill;
            pnKontrol.Dock = DockStyle.Fill;
            gridAmortismanlar.Visible = false;
            pnKontrol.Visible = true;

            btnDemirbaslariGetir.Enabled = true;
            btnExceleAktar.Enabled = true;
            btnKayitlariAktar.Enabled = true;
            btnTemizle.Enabled = true;
        }

        private void btnKayitlariAktar_Click(object sender, EventArgs e)
        {
            //Sorgula.Abort();
            //Sorgula = new Thread(new ThreadStart(KayitAktar));
            //Sorgula.Priority = ThreadPriority.Highest;
            //Sorgula.Start();

            //KayitAktar();
            //this.dsAmortisman.Amortismanlar.Clear();

            AktarimKayitAyarla();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            this.dsAmortisman.AmortHesaplari.Clear();
            this.dsAmortisman.Hareketler.Clear();
        }

        private void btnDemirbaslariGetir_Click(object sender, EventArgs e)
        {
            //Kanal = new Thread(new ThreadStart(KayitGetiriyoruz));
            //Kanal.Priority = ThreadPriority.Highest;
            //Kanal.Start();

            KayitGetiriyoruz();
        }

        private decimal TefeTufeOranimiz(string Oran, int Yil, string Ay)
        {
            if (ConOran.State == ConnectionState.Closed)
                ConOran.Open();

            string sorgu = "SELECT (CASE '" + Oran.ToString() + "' " +
                                   "WHEN 'Tefe Oranı' THEN TefeOrani " +
                                   "WHEN 'Tüfe Oranı' THEN TufeOrani END) AS Oran FROM Oranlar " +
                                   "WHERE Yil=" + Yil + " AND Ay=(CASE  '" + Ay + "' " +
                                   "WHEN 'OCAK' THEN '01-OCAK' " +
                                   "WHEN 'ŞUBAT' THEN '02-ŞUBAT' " +
                                   "WHEN 'MART' THEN '03-MART' " +
                                   "WHEN 'NİSAN' THEN '04-NİSAN' " +
                                   "WHEN 'MAYIS' THEN '05-MAYIS' " +
                                   "WHEN 'HAZİRAN' THEN '06-HAZİRAN' " +
                                   "WHEN 'TEMMUZ' THEN '07-TEMMUZ' " +
                                   "WHEN 'AĞUSTOS' THEN '08-AĞUSTOS' " +
                                   "WHEN 'EYLÜL' THEN '09-EYLÜL' " +
                                   "WHEN 'EKİM' THEN '10-EKİM' " +
                                   "WHEN 'KASIM' THEN '11-KASIM' " +
                                   "WHEN 'ARALIK' THEN '12-ARALIK' END)";
            cmd = new SqlCommand(sorgu, ConOran);
            return (decimal)Convert.ToDecimal(cmd.ExecuteScalar());
        }

        private decimal SonDonemTefeTufeOraniGetir(string Oran, int Yil, string Ay)
        {
            if (ConOran.State == ConnectionState.Closed)
                ConOran.Open();

            string sorgu = "SELECT (CASE '" + Oran.ToString() + "' " +
                                   "WHEN 'Tefe Oranı' THEN TefeOrani " +
                                   "WHEN 'Tüfe Oranı' THEN TufeOrani END) AS Oran FROM Oranlar " +
                                   "WHERE Yil=" + Yil + " AND Ay=(CASE  '" + Ay + "' " +
                                   "WHEN 'OCAK' THEN '01-OCAK' " +
                                   "WHEN 'ŞUBAT' THEN '02-ŞUBAT' " +
                                   "WHEN 'MART' THEN '03-MART' " +
                                   "WHEN 'NİSAN' THEN '04-NİSAN' " +
                                   "WHEN 'MAYIS' THEN '05-MAYIS' " +
                                   "WHEN 'HAZİRAN' THEN '06-HAZİRAN' " +
                                   "WHEN 'TEMMUZ' THEN '07-TEMMUZ' " +
                                   "WHEN 'AĞUSTOS' THEN '08-AĞUSTOS' " +
                                   "WHEN 'EYLÜL' THEN '09-EYLÜL' " +
                                   "WHEN 'EKİM' THEN '10-EKİM' " +
                                   "WHEN 'KASIM' THEN '11-KASIM' " +
                                   "WHEN 'ARALIK' THEN '12-ARALIK' END)";

            cmd = new SqlCommand(sorgu, ConOran);
            return (decimal)Convert.ToDecimal(cmd.ExecuteScalar());

        }

        private decimal DemirbasTefeTufeOranimiz(string Oran, int Yil, int Ay)
        {
            if (ConOran.State == ConnectionState.Closed)
                ConOran.Open();

            string sorgu = "SELECT (CASE '" + Oran.ToString() + "' " +
                                   "WHEN 'Tefe Oranı' THEN TefeOrani " +
                                   "WHEN 'Tüfe Oranı' THEN TufeOrani END) AS Oran FROM Oranlar " +
                                   "WHERE Yil=" + Yil + " AND Ay=(CASE  " + Ay + " " +
                                   "WHEN 1 THEN '01-OCAK' " +
                                   "WHEN 2 THEN '02-ŞUBAT' " +
                                   "WHEN 3 THEN '03-MART' " +
                                   "WHEN 4 THEN '04-NİSAN' " +
                                   "WHEN 5 THEN '05-MAYIS' " +
                                   "WHEN 6 THEN '06-HAZİRAN' " +
                                   "WHEN 7 THEN '07-TEMMUZ' " +
                                   "WHEN 8 THEN '08-AĞUSTOS' " +
                                   "WHEN 9 THEN '09-EYLÜL' " +
                                   "WHEN 10 THEN '10-EKİM' " +
                                   "WHEN 11 THEN '11-KASIM' " +
                                   "WHEN 12 THEN '12-ARALIK' END)";
            cmd = new SqlCommand(sorgu, ConOran);
            return (decimal)Convert.ToDecimal(cmd.ExecuteScalar());
        }

        private int DemirbasCikisTarihineBakiyoruz(string DemirbasKodu)
        {
            if (Conn.State == ConnectionState.Closed)
                Conn.Open();

            string sorgu = "SELECT DEM002_SatisDate AS Tarih FROM DEM002 " +
                                "WHERE DEM002_DemKodu='" + DemirbasKodu + "'";

            cmd = new SqlCommand(sorgu, Conn);

            return (int)Convert.ToInt32(cmd.ExecuteScalar());
        }

        private void gridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            //if (e.RowHandle >= 0)
            //{
            //    DataRow drRow = gridView1.GetDataRow(e.RowHandle);
            //    string DemirbasKodu = drRow["SabitKiymetKodu"].ToString();
            //    int BitTar = Convert.ToInt32(drRow["BitisYili"].ToString());
            //    int BasTar = Convert.ToInt32(drRow["BaslangicYili"].ToString());
            //    int NowYil = Convert.ToInt32(txtDonemYili.Text);
            //    CikisTarihi = DemirbasCikisTarihineBakiyoruz(drRow["SabitKiymetKodu"].ToString());
            //    KodDurumu = drRow["Durumu"].ToString();

            //    if (DemirbasKodu.Length < 16)
            //    {
            //        if (DemirbasKodu.ToString().Length == 1)
            //        {
            //            e.Appearance.BackColor = Color.LightSteelBlue;
            //        }
            //        else if (DemirbasKodu.ToString().Length == 2)
            //        {
            //            e.Appearance.BackColor = Color.LightPink;
            //        }
            //        else if (DemirbasKodu.ToString().Length == 3)
            //        {
            //            e.Appearance.BackColor = Color.DarkSalmon;
            //        }
            //        else if (DemirbasKodu.ToString().Length == 6)
            //        {
            //            e.Appearance.BackColor = Color.DarkOrchid;
            //            e.Appearance.ForeColor = Color.White;
            //        }
            //        else if (DemirbasKodu.ToString().Length == 9)
            //        {
            //            e.Appearance.BackColor = Color.PaleTurquoise;
            //        }
            //        else if (DemirbasKodu.ToString().Length == 12)
            //        {
            //            e.Appearance.BackColor = Color.DarkGreen;
            //            e.Appearance.ForeColor = Color.White;
            //        }
            //    }
            //    else if (DemirbasKodu.Length == 16)
            //    {
            //        if (BitTar >= NowYil && BasTar <= NowYil)
            //        {
            //            if (KodDurumu == "KIST")
            //            {
            //                if (CikisTarihi == 0)
            //                {
            //                    e.Appearance.BackColor = Color.BurlyWood;
            //                }
            //                else
            //                {
            //                    e.Appearance.BackColor = Color.Honeydew;
            //                }
            //            }
            //            if (KodDurumu == "KALAN")
            //            {
            //                if (CikisTarihi == 0)
            //                {
            //                    e.Appearance.BackColor = Color.CadetBlue;
            //                }
            //                else
            //                {
            //                    e.Appearance.BackColor = Color.Honeydew;
            //                }
            //            }
            //            if (KodDurumu == "")
            //            {
            //                if (CikisTarihi == 0)
            //                {
            //                    e.Appearance.BackColor = Color.LightGreen;
            //                }
            //                else
            //                {
            //                    e.Appearance.BackColor = Color.Honeydew;
            //                }
            //            }
            //        }
            //        else
            //        {
            //            if (CikisTarihi == 0)
            //            {
            //                e.Appearance.BackColor = Color.Gold;
            //            }
            //            else
            //            {
            //                e.Appearance.BackColor = Color.IndianRed;
            //            }
            //        }
            //    }
            //}
        }

        private void KayitGetiriyoruz()
        {
            btnDemirbaslariGetir.Enabled = false;
            btnExceleAktar.Enabled = false;
            btnTemizle.Enabled = false;
            btnKayitlariAktar.Enabled = false;
            chkEnflasyon.Enabled = false;

            dsAmortisman.Hareketler.Clear();
            dsAmortisman.TumAmortismanHesaplari.Clear();
            dsAmortisman.AmortHesaplari.Clear();

            gridAmortismanlar.DataSource = null;
            gridAmortismanlar.DataSource = dsAmortisman.Hareketler;

            dsAmortisman.Hareketler.Clear();
            dsAmortisman.TumAmortismanHesaplari.Clear();
            dsAmortisman.AmortHesaplari.Clear();

            CariDonemAmortisman = 0;
            DonemAyi = Convert.ToInt32(DonemZamani(cmbDonemAyi.Text.ToString()));
            DonAy = Convert.ToString(AylarinTarihi2(cmbDonemAyi.SelectedItem.ToString()));

            //int DonemYil = 0;

            if (string.IsNullOrEmpty(txtDonemYili.Text))
            {
                DonemYil = Convert.ToInt32(DateTime.Now.Year);
            }
            else
            {
                DonemYil = Convert.ToInt32(txtDonemYili.Text);
            }

            Tarihimiz = Convert.ToString(DonemYil);

            //this.amortismanHesaplariTableAdapter.NormalAmortismanSorgu(dsAmortisman.AmortismanHesaplari, Tarihimiz, DonAy);
            this.tumAmortismanHesaplariTableAdapter.NormalAmortismanSorgu(dsAmortisman.TumAmortismanHesaplari, Tarihimiz);
            YeniHesapDurumu = (int)sqlQueryler1.YeniHesapCount(Tarihimiz);

            foreach (DataRow dr in dsAmortisman.TumAmortismanHesaplari)
            {
                this.dsAmortisman.AmortHesaplari.AddAmortHesaplariRow(dr["SabitKiymetKodu"].ToString(), dr["SabitKiymetAdi"].ToString(),
                dr["AmortismanHesabi"].ToString(), dr["MuhasebeHesabi"].ToString(), dr["GiderHesabi"].ToString(),
                Convert.ToDecimal(dr["AmortismanOrani"].ToString()), Convert.ToInt32(dr["BaslangicYili"].ToString()),
                Convert.ToInt32(dr["BaslangicAyi"].ToString()), dr["BitisYili"].ToString(),
                Convert.ToInt32(dr["BitisAyi"].ToString()), Convert.ToDecimal(dr["iktisabDegeri"].ToString()),
                Convert.ToDecimal(dr["EndekseTabiDeger"].ToString()), Convert.ToDecimal(dr["EndekseTabiAmortisman"].ToString()),
                Convert.ToDecimal(dr["KatSayisi"].ToString()), Convert.ToDecimal(dr["EndekslenmisDeger"].ToString()),
                Convert.ToDecimal(dr["EndekslenmisAmortisman"].ToString()), Convert.ToDecimal(dr["KalanDeger"].ToString()),
                Convert.ToDecimal(dr["CariYilAmortisman"].ToString()), Convert.ToDecimal(dr["AylikAmortisman"].ToString()),
                Convert.ToDecimal(dr["ToplamBirikmisAmortisman"].ToString()), Convert.ToDecimal(dr["SabitKiymetEnflasyonFarki"].ToString()),
                Convert.ToDecimal(dr["AmortismanEnflasyonFarki"].ToString()), dr["Durumu"].ToString(), Convert.ToInt32(dr["Miktar"].ToString()));

            }

            CheckForIllegalCrossThreadCalls = false;
            Kanal = Task.Factory.StartNew(() =>
            {
                #region Normal Hesaplama

                if (chkEnflasyon.Checked == false)
                {
                    foreach (DataRow dr in dsAmortisman.AmortHesaplari)
                    {
                        AylikAmortisman = Convert.ToDecimal(dr["AylikAmortisman"].ToString());
                        demirbasKodu = dr["SabitKiymetKodu"].ToString();
                        CikisTarihi = DemirbasCikisTarihineBakiyoruz(demirbasKodu);

                        demirbasAdi = dr["SabitKiymetAdi"].ToString();
                        AmortismanHesabi = dr["AmortismanHesabi"].ToString();
                        MuhasebeHesabi = dr["MuhasebeHesabi"].ToString();
                        GiderHesabi = dr["GiderHesabi"].ToString();
                        KodDurumu = dr["Durumu"].ToString();

                        BaslangicYili = Convert.ToInt32(dr["BaslangicYili"].ToString());
                        BaslangicAyi = Convert.ToInt32(dr["BaslangicAyi"].ToString());
                        BitisYili = Convert.ToInt32(dr["BitisYili"].ToString());
                        BitisAyi = Convert.ToInt32(dr["BitisAyi"].ToString());

                        decimal AmortismanOrani2 = (BitisYili - BaslangicYili) + 1;
                        AmortismanOrani = 100 / AmortismanOrani2;

                        iktisabDegeri = Convert.ToDecimal(dr["iktisabDegeri"].ToString());

                        EndsTabiDeger = Convert.ToDecimal(dr["EndekseTabiDeger"].ToString());
                        KalanDeger = 0;
                        EndekseTabiAmortismanTutari = Convert.ToDecimal(dr["EndekseTabiAmortisman"].ToString());
                        KatSayisi = Convert.ToDecimal(dr["KatSayisi"].ToString());
                        EndekslenmisDeger = 0;
                        EndekslenmisAmortisman = 0;
                        SabitKiymetEnfFarki = 0;
                        AmortismanEnfFarki = 0;
                        int KontrolMiktari = Convert.ToInt32(dr["Miktar"].ToString());

                        if (demirbasKodu.Length > 13)
                        {
                            if (BitisYili >= DonemYil && BaslangicYili <= DonemYil && KontrolMiktari > 0)
                            {
                                #region Kıst Hesaplama

                                if (KodDurumu == "KIST")
                                {
                                    if (DonemYil == BaslangicYili)
                                    {
                                        if (Convert.ToDecimal(DonAy) >= BaslangicAyi)
                                        {
                                            AylikAmortisman = ((iktisabDegeri * AmortismanOrani) / 100) / 12;
                                            carprakam = Convert.ToInt32((Convert.ToDecimal(DonAy) - BaslangicAyi) + 1);
                                            CariDonemAmortisman = AylikAmortisman * carprakam;
                                            dr["AylikAmortisman"] = AylikAmortisman.ToString();
                                            //}
                                            //else
                                            //{
                                            //    //int carprakam = Convert.ToInt32((BaslangicAyi - Convert.ToDecimal(DonAy)) + 1);
                                            //    AylikAmortisman = 0;
                                            //    CariDonemAmortisman = 0;// *carprakam;
                                            //    dr["AylikAmortisman"] = "0";
                                            //}

                                            dr["CariYilAmortisman"] = Convert.ToString(CariDonemAmortisman);
                                            dr["ToplamBirikmisAmortisman"] = Convert.ToString(CariDonemAmortisman);

                                            if (EndsTabiDeger == 0)
                                            {
                                                EndsTabiDeger = iktisabDegeri;
                                            }

                                            EndekslenmisDeger = KatSayisi * EndsTabiDeger;

                                            if (EndsTabiDeger == 0)
                                            {
                                                EndsTabiDeger = Convert.ToDecimal(dr["iktisabDegeri"].ToString());
                                            }

                                            dr["EndekslenmisDeger"] = Convert.ToString(EndekslenmisDeger);

                                            //EndekslenmisAmortisman = KatSayisi * EndekseTabiAmortismanTutari;
                                            EndekslenmisAmortisman = (((EndekslenmisDeger - EndsTabiDeger) / EndsTabiDeger) * CariDonemAmortisman) + CariDonemAmortisman;

                                            dr["EndekslenmisAmortisman"] = Convert.ToString(EndekslenmisAmortisman);
                                            dr["EndekseTabiAmortisman"] = Convert.ToString(EndekseTabiAmortismanTutari);

                                            KalanDeger = EndsTabiDeger - Convert.ToDecimal(dr["EndekseTabiAmortisman"].ToString());
                                            dr["KalanDeger"] = Convert.ToString(EndsTabiDeger - Convert.ToDecimal(dr["EndekseTabiAmortisman"].ToString()));

                                            //SabitKiymetEnfFarki = EndekslenmisDeger - EndsTabiDeger;
                                            //AmortismanEnfFarki = EndekslenmisAmortisman - EndekseTabiAmortismanTutari;

                                            SabitKiymetEnfFarki = 0;
                                            AmortismanEnfFarki = 0;

                                            //if (SabitKiymetEnfFarki < 0)
                                            //{
                                            //    SabitKiymetEnfFarki = SabitKiymetEnfFarki * -1;
                                            //}
                                            //if (AmortismanEnfFarki < 0)
                                            //{
                                            //    AmortismanEnfFarki = AmortismanEnfFarki * -1;
                                            //}

                                            dr["SabitKiymetEnflasyonFarki"] = Convert.ToString(SabitKiymetEnfFarki);
                                            dr["AmortismanEnflasyonFarki"] = Convert.ToString(AmortismanEnfFarki);

                                            this.dsAmortisman.Hareketler.AddHareketlerRow(demirbasKodu, demirbasAdi, AmortismanHesabi, MuhasebeHesabi, GiderHesabi,
                                                 AmortismanOrani, BaslangicYili, BaslangicAyi, BitisYili, BitisAyi, iktisabDegeri, EndsTabiDeger, EndekseTabiAmortismanTutari,
                                                 KatSayisi, EndekslenmisDeger, EndekslenmisAmortisman, KalanDeger, CariDonemAmortisman, AylikAmortisman,
                                                 Convert.ToDecimal(dr["ToplamBirikmisAmortisman"].ToString()), SabitKiymetEnfFarki, AmortismanEnfFarki, KodDurumu, KontrolMiktari);
                                        }
                                    }
                                    else
                                    {
                                        if (BitisYili == DonemYil)
                                        {
                                            AylikAmortisman = ((iktisabDegeri * AmortismanOrani) / 100) / 12;
                                            carprakam = Convert.ToInt32(Convert.ToDecimal(DonAy));
                                            YeniCarpRakam = Convert.ToInt32((12 - BaslangicAyi) + 1);

                                            if (EndsTabiDeger == 0)
                                            {
                                                EndsTabiDeger = Convert.ToDecimal(dr["iktisabDegeri"].ToString());
                                            }

                                            //decimal RBul = 0;
                                            if ((DonemYil - BaslangicYili) == 1)
                                            {
                                                RBul = ((DonemYil - BaslangicYili) * YeniCarpRakam) * AylikAmortisman;
                                            }
                                            else
                                            {
                                                RBul = ((((DonemYil - BaslangicYili) - 1) * 12 + YeniCarpRakam) * AylikAmortisman);
                                                //RBul = (YeniCarpRakam * AylikAmortisman) + (AylikAmortisman * ((12 * ((DonemYil - BaslangicYili) - 1))));
                                            }

                                            EndekseTabiAmortismanTutari = RBul;
                                            //EndekslenmisAmortisman = KatSayisi * EndekseTabiAmortismanTutari;

                                            EndekslenmisDeger = KatSayisi * EndsTabiDeger;
                                            AylikAmortisman = (EndsTabiDeger - RBul) / 12;
                                            CariDonemAmortisman = AylikAmortisman * carprakam;

                                            dr["EndekslenmisDeger"] = Convert.ToString(EndekslenmisDeger);

                                            dr["CariYilAmortisman"] = Convert.ToString(CariDonemAmortisman);

                                            if (Convert.ToDecimal(dr["EndekseTabiDeger"].ToString()) == 0)
                                            {
                                                dr["EndekseTabiDeger"] = dr["iktisabDegeri"].ToString();
                                            }

                                            YeniDegerim = Convert.ToDecimal(dr["EndekseTabiDeger"].ToString());
                                            AmrtOran = AmortismanOrani;
                                            ToplamBAmortisman = ((((YeniDegerim * AmrtOran) / 100) / 12) * YeniCarpRakam);
                                            YeniYilTotalAmortisman = AylikAmortisman * carprakam;
                                            ToplamBAmortisman = EndekseTabiAmortismanTutari + YeniYilTotalAmortisman;
                                            dr["ToplamBirikmisAmortisman"] = Convert.ToString(ToplamBAmortisman);

                                            EndekslenmisAmortisman = (((EndekslenmisDeger - EndsTabiDeger) / EndsTabiDeger) * ToplamBAmortisman) + ToplamBAmortisman;

                                            //KalanDeger = EndekslenmisDeger - EndekslenmisAmortisman;

                                            dr["EndekslenmisAmortisman"] = Convert.ToString(EndekslenmisAmortisman);
                                            dr["EndekseTabiAmortisman"] = Convert.ToString(EndekseTabiAmortismanTutari);

                                            KalanDeger = EndsTabiDeger - Convert.ToDecimal(dr["EndekseTabiAmortisman"].ToString());
                                            dr["KalanDeger"] = Convert.ToString(EndsTabiDeger - Convert.ToDecimal(dr["EndekseTabiAmortisman"].ToString()));

                                            //SabitKiymetEnfFarki = EndekslenmisDeger - EndsTabiDeger;
                                            //AmortismanEnfFarki = EndekslenmisAmortisman - EndekseTabiAmortismanTutari;

                                            SabitKiymetEnfFarki = 0;
                                            AmortismanEnfFarki = 0;

                                            //if (SabitKiymetEnfFarki < 0)
                                            //{
                                            //    SabitKiymetEnfFarki = SabitKiymetEnfFarki * -1;
                                            //}
                                            //if (AmortismanEnfFarki < 0)
                                            //{
                                            //    AmortismanEnfFarki = AmortismanEnfFarki * -1;
                                            //}

                                            dr["SabitKiymetEnflasyonFarki"] = Convert.ToString(SabitKiymetEnfFarki);
                                            dr["AmortismanEnflasyonFarki"] = Convert.ToString(AmortismanEnfFarki);

                                            this.dsAmortisman.Hareketler.AddHareketlerRow(demirbasKodu, demirbasAdi, AmortismanHesabi, MuhasebeHesabi, GiderHesabi,
                                                 AmortismanOrani, BaslangicYili, BaslangicAyi, BitisYili, BitisAyi, iktisabDegeri, EndsTabiDeger, EndekseTabiAmortismanTutari,
                                                 KatSayisi, EndekslenmisDeger, EndekslenmisAmortisman, KalanDeger, CariDonemAmortisman, AylikAmortisman,
                                                 Convert.ToDecimal(dr["ToplamBirikmisAmortisman"].ToString()), SabitKiymetEnfFarki, AmortismanEnfFarki, KodDurumu, KontrolMiktari);

                                        }
                                        else
                                        {
                                            if (EndsTabiDeger == 0)
                                            {
                                                EndsTabiDeger = Convert.ToDecimal(dr["iktisabDegeri"].ToString());
                                            }

                                            AylikAmortisman = (((EndsTabiDeger * AmortismanOrani) / 100) / 12);
                                            carprakam = Convert.ToInt32(Convert.ToDecimal(DonAy));
                                            CariDonemAmortisman = AylikAmortisman * carprakam;

                                            EndekslenmisDeger = KatSayisi * EndsTabiDeger;

                                            dr["EndekslenmisDeger"] = Convert.ToString(EndekslenmisDeger);

                                            dr["CariYilAmortisman"] = Convert.ToString(CariDonemAmortisman);

                                            if (Convert.ToDecimal(dr["EndekseTabiDeger"].ToString()) == 0)
                                            {
                                                dr["EndekseTabiDeger"] = dr["iktisabDegeri"].ToString();
                                            }

                                            YeniCarpRakam = Convert.ToInt32((12 - BaslangicAyi) + 1);
                                            YeniDegerim = Convert.ToDecimal(dr["EndekseTabiDeger"].ToString());
                                            AmrtOran = AmortismanOrani;
                                            ToplamBAmortisman = ((((YeniDegerim * AmrtOran) / 100) / 12) * YeniCarpRakam);
                                            YeniYilTotalAmortisman = AylikAmortisman * ((12 * ((DonemYil - BaslangicYili) - 1)) + Convert.ToDecimal(DonAy));
                                            ToplamBAmortisman = ToplamBAmortisman + YeniYilTotalAmortisman;
                                            dr["ToplamBirikmisAmortisman"] = Convert.ToString(ToplamBAmortisman);

                                            //decimal RBul = 0;
                                            if ((DonemYil - BaslangicYili) == 1)
                                            {
                                                RBul = ((DonemYil - BaslangicYili) * YeniCarpRakam) * AylikAmortisman;
                                            }
                                            else
                                            {
                                                RBul = (YeniCarpRakam * AylikAmortisman) + (AylikAmortisman * ((12 * ((DonemYil - BaslangicYili) - 1))));

                                            }

                                            EndekseTabiAmortismanTutari = RBul;
                                            //EndekslenmisAmortisman = KatSayisi * EndekseTabiAmortismanTutari;
                                            EndekslenmisAmortisman = (((EndekslenmisDeger - EndsTabiDeger) / EndsTabiDeger) * ToplamBAmortisman) + ToplamBAmortisman;

                                            dr["EndekslenmisAmortisman"] = Convert.ToString(EndekslenmisAmortisman);
                                            dr["EndekseTabiAmortisman"] = Convert.ToString(EndekseTabiAmortismanTutari);

                                            KalanDeger = EndekslenmisDeger - Convert.ToDecimal(dr["EndekseTabiAmortisman"].ToString());
                                            dr["KalanDeger"] = Convert.ToString(EndsTabiDeger - Convert.ToDecimal(dr["EndekseTabiAmortisman"].ToString()));

                                            //SabitKiymetEnfFarki = EndekslenmisDeger - EndsTabiDeger;
                                            //AmortismanEnfFarki = EndekslenmisAmortisman - EndekseTabiAmortismanTutari;

                                            SabitKiymetEnfFarki = 0;
                                            AmortismanEnfFarki = 0;

                                            //if (SabitKiymetEnfFarki < 0)
                                            //{
                                            //    SabitKiymetEnfFarki = SabitKiymetEnfFarki * -1;
                                            //}
                                            //if (AmortismanEnfFarki < 0)
                                            //{
                                            //    AmortismanEnfFarki = AmortismanEnfFarki * -1;
                                            //}

                                            dr["SabitKiymetEnflasyonFarki"] = Convert.ToString(SabitKiymetEnfFarki);
                                            dr["AmortismanEnflasyonFarki"] = Convert.ToString(AmortismanEnfFarki);

                                            this.dsAmortisman.Hareketler.AddHareketlerRow(demirbasKodu, demirbasAdi, AmortismanHesabi, MuhasebeHesabi, GiderHesabi,
                                                 AmortismanOrani, BaslangicYili, BaslangicAyi, BitisYili, BitisAyi, iktisabDegeri, EndsTabiDeger, EndekseTabiAmortismanTutari,
                                                 KatSayisi, EndekslenmisDeger, EndekslenmisAmortisman, KalanDeger, CariDonemAmortisman, AylikAmortisman,
                                                 Convert.ToDecimal(dr["ToplamBirikmisAmortisman"].ToString()), SabitKiymetEnfFarki, AmortismanEnfFarki, KodDurumu, KontrolMiktari);

                                        }
                                    }

                                    //this.dsAmortisman.Hareketler.AddHareketlerRow(demirbasKodu, demirbasAdi, AmortismanHesabi, MuhasebeHesabi, GiderHesabi,
                                    //     AmortismanOrani, BaslangicYili, BaslangicAyi, BitisYili, BitisAyi, iktisabDegeri, EndsTabiDeger, EndekseTabiAmortismanTutari,
                                    //     KatSayisi, EndekslenmisDeger, EndekslenmisAmortisman, KalanDeger, CariDonemAmortisman, AylikAmortisman,
                                    //     Convert.ToDecimal(dr["ToplamBirikmisAmortisman"].ToString()), SabitKiymetEnfFarki, AmortismanEnfFarki, KodDurumu);
                                }

                                #endregion

                                #region Kalan Yıl Hesaplama

                                if (KodDurumu == "KALAN")
                                {
                                    if (DonemYil == BaslangicYili)
                                    {
                                        if (EndsTabiDeger == 0)
                                        {
                                            EndsTabiDeger = iktisabDegeri;
                                        }

                                        if (Convert.ToDecimal(DonAy) >= BaslangicAyi)
                                        {
                                            EndekslenmisDeger = KatSayisi * EndsTabiDeger;

                                            if (EndsTabiDeger == 0)
                                            {
                                                EndsTabiDeger = Convert.ToDecimal(dr["iktisabDegeri"].ToString());
                                            }

                                            dr["EndekslenmisDeger"] = Convert.ToString(EndekslenmisDeger);

                                            EndekslenmisAmortisman = KatSayisi * EndekseTabiAmortismanTutari;
                                            dr["EndekslenmisAmortisman"] = Convert.ToString(EndekslenmisAmortisman);
                                            dr["EndekseTabiAmortisman"] = Convert.ToString(EndekseTabiAmortismanTutari);
                                            dr["KalanDeger"] = Convert.ToString(EndsTabiDeger - Convert.ToDecimal(dr["EndekseTabiAmortisman"].ToString()));

                                            //SabitKiymetEnfFarki = EndekslenmisDeger - EndsTabiDeger;
                                            //AmortismanEnfFarki = EndekslenmisAmortisman - EndekseTabiAmortismanTutari;

                                            SabitKiymetEnfFarki = 0;
                                            AmortismanEnfFarki = 0;

                                            dr["SabitKiymetEnflasyonFarki"] = Convert.ToString(SabitKiymetEnfFarki);
                                            dr["AmortismanEnflasyonFarki"] = Convert.ToString(AmortismanEnfFarki);

                                            KalanDeger = Convert.ToDecimal(dr["KalanDeger"].ToString());

                                            if (KalanDeger > 0)
                                            {
                                                if (BitisYili >= DonemYil)
                                                {
                                                    KalanYilAylikHesap = KalanDeger / ((BitisYili - DonemYil) + 1);
                                                }
                                                if (BaslangicYili < DonemYil)
                                                {
                                                    KalanYilAylikHesap = KalanDeger / ((BitisYili - DonemYil) + 1) / 12;
                                                }
                                                else
                                                {
                                                    KalanYilAylikHesap = KalanDeger / ((BitisYili - DonemYil) + 1) / ((BitisAyi - BaslangicAyi) + 1);
                                                }

                                                AylikAmortisman = KalanYilAylikHesap;
                                                carprakam = Convert.ToInt32((Convert.ToDecimal(DonAy) - BaslangicAyi) + 1);
                                                CariDonemAmortisman = AylikAmortisman * carprakam;
                                                dr["AylikAmortisman"] = AylikAmortisman.ToString();

                                                dr["CariYilAmortisman"] = Convert.ToString(CariDonemAmortisman);
                                                dr["ToplamBirikmisAmortisman"] = Convert.ToString(CariDonemAmortisman);
                                                EndekslenmisAmortisman = (((EndekslenmisDeger - EndsTabiDeger) / EndsTabiDeger) * CariDonemAmortisman) + CariDonemAmortisman;

                                            }

                                            this.dsAmortisman.Hareketler.AddHareketlerRow(demirbasKodu, demirbasAdi, AmortismanHesabi, MuhasebeHesabi, GiderHesabi,
                                                    AmortismanOrani, BaslangicYili, BaslangicAyi, BitisYili, BitisAyi, iktisabDegeri, EndsTabiDeger, EndekseTabiAmortismanTutari,
                                                    KatSayisi, EndekslenmisDeger, EndekslenmisAmortisman, KalanDeger, CariDonemAmortisman, AylikAmortisman,
                                                    Convert.ToDecimal(dr["ToplamBirikmisAmortisman"].ToString()), SabitKiymetEnfFarki, AmortismanEnfFarki, KodDurumu, KontrolMiktari);
                                        }
                                    }
                                    else
                                    {
                                        if (EndsTabiDeger == 0)
                                        {
                                            EndsTabiDeger = Convert.ToDecimal(dr["iktisabDegeri"].ToString());
                                        }

                                        if (EndekseTabiAmortismanTutari == 0)
                                        {

                                        }

                                        decimal dsa = EndsTabiDeger / ((BitisYili - BaslangicYili) + 1);
                                        KalanYilAylikHesap = (EndsTabiDeger - EndekseTabiAmortismanTutari) / ((BitisYili - DonemYil) + 1) / 12;


                                        AylikAmortisman = KalanYilAylikHesap;
                                        //AylikAmortisman = (((EndsTabiDeger * AmortismanOrani) / 100) / 12);
                                        carprakam = Convert.ToInt32(Convert.ToDecimal(DonAy));
                                        CariDonemAmortisman = AylikAmortisman * carprakam;

                                        EndekslenmisDeger = KatSayisi * EndsTabiDeger;

                                        dr["EndekslenmisDeger"] = Convert.ToString(EndekslenmisDeger);

                                        dr["CariYilAmortisman"] = Convert.ToString(CariDonemAmortisman);

                                        if (Convert.ToDecimal(dr["EndekseTabiDeger"].ToString()) == 0)
                                        {
                                            dr["EndekseTabiDeger"] = dr["iktisabDegeri"].ToString();
                                        }

                                        YeniCarpRakam = Convert.ToInt32((12 - BaslangicAyi) + 1);
                                        YeniDegerim = Convert.ToDecimal(dr["EndekseTabiDeger"].ToString());
                                        AmrtOran = AmortismanOrani;
                                        ToplamBAmortisman = ((((YeniDegerim * AmrtOran) / 100) / YeniCarpRakam) * YeniCarpRakam);
                                        YeniYilTotalAmortisman = AylikAmortisman * ((12 * ((DonemYil - BaslangicYili) - 1)) + Convert.ToDecimal(DonAy));
                                        ToplamBAmortisman = EndekseTabiAmortismanTutari + CariDonemAmortisman;
                                        dr["ToplamBirikmisAmortisman"] = Convert.ToString(ToplamBAmortisman);

                                        RBul = ((DonemYil - BaslangicYili) * 12) * AylikAmortisman;
                                        //EndekseTabiAmortismanTutari = RBul;
                                        EndekslenmisAmortisman = (((EndekslenmisDeger - EndsTabiDeger) / EndsTabiDeger) * ToplamBAmortisman) + ToplamBAmortisman;

                                        dr["EndekslenmisAmortisman"] = Convert.ToString(EndekslenmisAmortisman);
                                        dr["EndekseTabiAmortisman"] = Convert.ToString(EndekseTabiAmortismanTutari);
                                        dr["KalanDeger"] = Convert.ToString(EndsTabiDeger - EndekseTabiAmortismanTutari);

                                        //SabitKiymetEnfFarki = EndekslenmisDeger - EndsTabiDeger;
                                        //AmortismanEnfFarki = EndekslenmisAmortisman - ToplamBAmortisman;

                                        SabitKiymetEnfFarki = 0;
                                        AmortismanEnfFarki = 0;

                                        //if (SabitKiymetEnfFarki < 0)
                                        //{
                                        //    SabitKiymetEnfFarki = SabitKiymetEnfFarki * -1;
                                        //}
                                        //if (AmortismanEnfFarki < 0)
                                        //{
                                        //    AmortismanEnfFarki = AmortismanEnfFarki * -1;
                                        //}

                                        dr["SabitKiymetEnflasyonFarki"] = Convert.ToString(SabitKiymetEnfFarki);
                                        dr["AmortismanEnflasyonFarki"] = Convert.ToString(AmortismanEnfFarki);

                                        KalanDeger = EndsTabiDeger - EndekseTabiAmortismanTutari;

                                        //if (cmbDonemAyi.Text.ToString() == "Ocak")
                                        //{
                                        //    decimal yeniAmortTutarimiz = AylikAmortisman * 12;
                                        //    EndekseTabiAmortismanTutari = EndekseTabiAmortismanTutari + yeniAmortTutarimiz;
                                        //    EndekslenmisAmortisman = EndekslenmisAmortisman + yeniAmortTutarimiz;

                                        //}
                                        this.dsAmortisman.Hareketler.AddHareketlerRow(demirbasKodu, demirbasAdi, AmortismanHesabi, MuhasebeHesabi, GiderHesabi,
                                                    AmortismanOrani, BaslangicYili, BaslangicAyi, BitisYili, BitisAyi, iktisabDegeri, EndsTabiDeger, EndekseTabiAmortismanTutari,
                                                    KatSayisi, EndekslenmisDeger, EndekslenmisAmortisman, KalanDeger, CariDonemAmortisman, AylikAmortisman,
                                                    Convert.ToDecimal(dr["ToplamBirikmisAmortisman"].ToString()), SabitKiymetEnfFarki, AmortismanEnfFarki, KodDurumu, KontrolMiktari);
                                    }
                                }

                                #endregion

                                #region Normal Hesaplama

                                if (KodDurumu == "")
                                {
                                    if (DonemYil == BaslangicYili)
                                    {
                                        if (EndsTabiDeger == 0)
                                        {
                                            EndsTabiDeger = iktisabDegeri;
                                        }

                                        if (Convert.ToDecimal(DonAy) >= BaslangicAyi)
                                        {
                                            carprakam = Convert.ToInt32((Convert.ToDecimal(DonAy) - BaslangicAyi) + 1);

                                            AylikAmortisman = (((EndsTabiDeger * AmortismanOrani) / 100) / ((12 - BaslangicAyi) + 1));

                                            CariDonemAmortisman = AylikAmortisman * carprakam;

                                            dr["CariYilAmortisman"] = Convert.ToString(CariDonemAmortisman);
                                            dr["ToplamBirikmisAmortisman"] = Convert.ToString(CariDonemAmortisman);

                                            EndekslenmisDeger = KatSayisi * EndsTabiDeger;

                                            if (EndsTabiDeger == 0)
                                            {
                                                EndsTabiDeger = Convert.ToDecimal(dr["iktisabDegeri"].ToString());
                                            }

                                            dr["EndekslenmisDeger"] = Convert.ToString(EndekslenmisDeger);

                                            //EndekslenmisAmortisman = KatSayisi * EndekseTabiAmortismanTutari;
                                            EndekslenmisAmortisman = (((EndekslenmisDeger - EndsTabiDeger) / EndsTabiDeger) * CariDonemAmortisman) + CariDonemAmortisman;

                                            dr["EndekslenmisAmortisman"] = Convert.ToString(EndekslenmisAmortisman);
                                            dr["EndekseTabiAmortisman"] = Convert.ToString(EndekseTabiAmortismanTutari);
                                            dr["KalanDeger"] = Convert.ToString(EndsTabiDeger - Convert.ToDecimal(dr["EndekseTabiAmortisman"].ToString()));

                                            SabitKiymetEnfFarki = 0;
                                            AmortismanEnfFarki = 0;

                                            dr["SabitKiymetEnflasyonFarki"] = Convert.ToString(SabitKiymetEnfFarki);
                                            dr["AmortismanEnflasyonFarki"] = Convert.ToString(AmortismanEnfFarki);

                                            KalanDeger = Convert.ToDecimal(dr["KalanDeger"].ToString());

                                            this.dsAmortisman.Hareketler.AddHareketlerRow(demirbasKodu, demirbasAdi, AmortismanHesabi, MuhasebeHesabi, GiderHesabi,
                                                AmortismanOrani, BaslangicYili, BaslangicAyi, BitisYili, BitisAyi, iktisabDegeri, EndsTabiDeger, EndekseTabiAmortismanTutari,
                                                KatSayisi, EndekslenmisDeger, EndekslenmisAmortisman, KalanDeger, CariDonemAmortisman, AylikAmortisman,
                                                Convert.ToDecimal(dr["ToplamBirikmisAmortisman"].ToString()), SabitKiymetEnfFarki, AmortismanEnfFarki, KodDurumu, KontrolMiktari);

                                        }
                                    }
                                    else
                                    {
                                        if (DonemYil == BitisYili)
                                        {
                                            if (cmbDonemAyi.Text == "Aralık")
                                            {
                                                if (EndsTabiDeger == 0)
                                                {
                                                    EndsTabiDeger = Convert.ToDecimal(dr["iktisabDegeri"].ToString());
                                                }

                                                AylikAmortisman = (((EndsTabiDeger * AmortismanOrani) / 100) / 12);
                                                carprakam = Convert.ToInt32(Convert.ToDecimal(DonAy));
                                                CariDonemAmortisman = AylikAmortisman * carprakam;

                                                EndekslenmisDeger = KatSayisi * EndsTabiDeger;

                                                dr["EndekslenmisDeger"] = Convert.ToString(EndekslenmisDeger);

                                                dr["CariYilAmortisman"] = Convert.ToString(CariDonemAmortisman);

                                                if (Convert.ToDecimal(dr["EndekseTabiDeger"].ToString()) == 0)
                                                {
                                                    dr["EndekseTabiDeger"] = dr["iktisabDegeri"].ToString();
                                                }

                                                YeniCarpRakam = Convert.ToInt32((12 - BaslangicAyi) + 1);
                                                YeniDegerim = Convert.ToDecimal(dr["EndekseTabiDeger"].ToString());
                                                AmrtOran = AmortismanOrani;
                                                ToplamBAmortisman = ((((YeniDegerim * AmrtOran) / 100) / YeniCarpRakam) * YeniCarpRakam);
                                                YeniYilTotalAmortisman = AylikAmortisman * ((12 * ((DonemYil - BaslangicYili) - 1)) + Convert.ToDecimal(DonAy));
                                                ToplamBAmortisman = ToplamBAmortisman + YeniYilTotalAmortisman;
                                                //dr["ToplamBirikmisAmortisman"] = Convert.ToString(ToplamBAmortisman);
                                                ToplamBAmortisman = Math.Round(ToplamBAmortisman, 2);
                                                RBul = ((DonemYil - BaslangicYili) * 12) * AylikAmortisman;

                                                if (cmbDonemAyi.Text.ToString() == "Ocak")
                                                {
                                                    decimal yeniAmortismanimiz = AylikAmortisman * 12;
                                                }

                                                if (ToplamBAmortisman > Convert.ToDecimal(dr["iktisabDegeri"].ToString()))
                                                {
                                                    decimal FarkliToplamBirikmisAmortisman = ToplamBAmortisman - Convert.ToDecimal(dr["iktisabDegeri"].ToString());
                                                    dr["ToplamBirikmisAmortisman"] = Convert.ToString(FarkliToplamBirikmisAmortisman + Convert.ToDecimal(dr["iktisabDegeri"].ToString()));
                                                    AylikAmortisman = FarkliToplamBirikmisAmortisman;
                                                }
                                                else
                                                {
                                                    dr["ToplamBirikmisAmortisman"] = Convert.ToString(ToplamBAmortisman);
                                                }

                                                EndekseTabiAmortismanTutari = RBul;
                                                //EndekslenmisAmortisman = KatSayisi * EndekseTabiAmortismanTutari;
                                                //EndekslenmisAmortisman = RBul;
                                                //EndekslenmisAmortisman = EndekseTabiAmortismanTutari + CariDonemAmortisman;
                                                EndekslenmisAmortisman = (((EndekslenmisDeger - EndsTabiDeger) / EndsTabiDeger) * ToplamBAmortisman) + ToplamBAmortisman;

                                                dr["EndekslenmisAmortisman"] = Convert.ToString(EndekslenmisAmortisman);
                                                dr["EndekseTabiAmortisman"] = Convert.ToString(EndekseTabiAmortismanTutari);
                                                dr["KalanDeger"] = Convert.ToString(EndekslenmisDeger - Convert.ToDecimal(dr["EndekseTabiAmortisman"].ToString()));

                                                SabitKiymetEnfFarki = 0;
                                                AmortismanEnfFarki = 0;

                                                dr["SabitKiymetEnflasyonFarki"] = Convert.ToString(SabitKiymetEnfFarki);
                                                dr["AmortismanEnflasyonFarki"] = Convert.ToString(AmortismanEnfFarki);

                                                KalanDeger = Convert.ToDecimal(dr["KalanDeger"].ToString());

                                                this.dsAmortisman.Hareketler.AddHareketlerRow(demirbasKodu, demirbasAdi, AmortismanHesabi, MuhasebeHesabi, GiderHesabi,
                                                        AmortismanOrani, BaslangicYili, BaslangicAyi, BitisYili, BitisAyi, iktisabDegeri, EndsTabiDeger, EndekseTabiAmortismanTutari,
                                                        KatSayisi, EndekslenmisDeger, EndekslenmisAmortisman, KalanDeger, CariDonemAmortisman, AylikAmortisman,
                                                        Convert.ToDecimal(dr["ToplamBirikmisAmortisman"].ToString()), SabitKiymetEnfFarki, AmortismanEnfFarki, KodDurumu, KontrolMiktari);
                                            }
                                            //En Son Kontrolün Olduğu Yer
                                            else
                                            {
                                                if (EndsTabiDeger == 0)
                                                {
                                                    EndsTabiDeger = Convert.ToDecimal(dr["iktisabDegeri"].ToString());
                                                }

                                                AylikAmortisman = (((EndsTabiDeger * AmortismanOrani) / 100) / 12);
                                                carprakam = Convert.ToInt32(Convert.ToDecimal(DonAy));
                                                CariDonemAmortisman = AylikAmortisman * carprakam;

                                                EndekslenmisDeger = KatSayisi * EndsTabiDeger;

                                                dr["EndekslenmisDeger"] = Convert.ToString(EndekslenmisDeger);

                                                dr["CariYilAmortisman"] = Convert.ToString(CariDonemAmortisman);

                                                if (Convert.ToDecimal(dr["EndekseTabiDeger"].ToString()) == 0)
                                                {
                                                    dr["EndekseTabiDeger"] = dr["iktisabDegeri"].ToString();
                                                }

                                                YeniCarpRakam = Convert.ToInt32((12 - BaslangicAyi) + 1);
                                                YeniDegerim = Convert.ToDecimal(dr["EndekseTabiDeger"].ToString());
                                                AmrtOran = AmortismanOrani;
                                                ToplamBAmortisman = ((((YeniDegerim * AmrtOran) / 100) / YeniCarpRakam) * YeniCarpRakam);
                                                YeniYilTotalAmortisman = AylikAmortisman * ((12 * ((DonemYil - BaslangicYili) - 1)) + Convert.ToDecimal(DonAy));
                                                ToplamBAmortisman = ToplamBAmortisman + YeniYilTotalAmortisman;
                                                dr["ToplamBirikmisAmortisman"] = Convert.ToString(ToplamBAmortisman);

                                                RBul = ((DonemYil - BaslangicYili) * 12) * AylikAmortisman;

                                                if (cmbDonemAyi.Text.ToString() == "Ocak")
                                                {
                                                    decimal yeniAmortismanimiz = AylikAmortisman * 12;
                                                }

                                                EndekseTabiAmortismanTutari = RBul;
                                                //EndekslenmisAmortisman = KatSayisi * EndekseTabiAmortismanTutari;
                                                //EndekslenmisAmortisman = RBul;
                                                //EndekslenmisAmortisman = EndekseTabiAmortismanTutari + CariDonemAmortisman;
                                                EndekslenmisAmortisman = (((EndekslenmisDeger - EndsTabiDeger) / EndsTabiDeger) * ToplamBAmortisman) + ToplamBAmortisman;

                                                dr["EndekslenmisAmortisman"] = Convert.ToString(EndekslenmisAmortisman);
                                                dr["EndekseTabiAmortisman"] = Convert.ToString(EndekseTabiAmortismanTutari);
                                                dr["KalanDeger"] = Convert.ToString(EndekslenmisDeger - Convert.ToDecimal(dr["EndekseTabiAmortisman"].ToString()));

                                                SabitKiymetEnfFarki = 0;
                                                AmortismanEnfFarki = 0;

                                                dr["SabitKiymetEnflasyonFarki"] = Convert.ToString(SabitKiymetEnfFarki);
                                                dr["AmortismanEnflasyonFarki"] = Convert.ToString(AmortismanEnfFarki);

                                                KalanDeger = Convert.ToDecimal(dr["KalanDeger"].ToString());

                                                this.dsAmortisman.Hareketler.AddHareketlerRow(demirbasKodu, demirbasAdi, AmortismanHesabi, MuhasebeHesabi, GiderHesabi,
                                                        AmortismanOrani, BaslangicYili, BaslangicAyi, BitisYili, BitisAyi, iktisabDegeri, EndsTabiDeger, EndekseTabiAmortismanTutari,
                                                        KatSayisi, EndekslenmisDeger, EndekslenmisAmortisman, KalanDeger, CariDonemAmortisman, AylikAmortisman,
                                                        Convert.ToDecimal(dr["ToplamBirikmisAmortisman"].ToString()), SabitKiymetEnfFarki, AmortismanEnfFarki, KodDurumu, KontrolMiktari);
                                            }

                                        }
                                        else
                                        {
                                            if (EndsTabiDeger == 0)
                                            {
                                                EndsTabiDeger = Convert.ToDecimal(dr["iktisabDegeri"].ToString());
                                            }

                                            AylikAmortisman = (((EndsTabiDeger * AmortismanOrani) / 100) / 12);
                                            carprakam = Convert.ToInt32(Convert.ToDecimal(DonAy));
                                            CariDonemAmortisman = AylikAmortisman * carprakam;

                                            EndekslenmisDeger = KatSayisi * EndsTabiDeger;

                                            dr["EndekslenmisDeger"] = Convert.ToString(EndekslenmisDeger);

                                            dr["CariYilAmortisman"] = Convert.ToString(CariDonemAmortisman);

                                            if (Convert.ToDecimal(dr["EndekseTabiDeger"].ToString()) == 0)
                                            {
                                                dr["EndekseTabiDeger"] = dr["iktisabDegeri"].ToString();
                                            }

                                            YeniCarpRakam = Convert.ToInt32((12 - BaslangicAyi) + 1);
                                            YeniDegerim = Convert.ToDecimal(dr["EndekseTabiDeger"].ToString());
                                            AmrtOran = AmortismanOrani;
                                            ToplamBAmortisman = ((((YeniDegerim * AmrtOran) / 100) / YeniCarpRakam) * YeniCarpRakam);
                                            YeniYilTotalAmortisman = AylikAmortisman * ((12 * ((DonemYil - BaslangicYili) - 1)) + Convert.ToDecimal(DonAy));
                                            ToplamBAmortisman = ToplamBAmortisman + YeniYilTotalAmortisman;
                                            dr["ToplamBirikmisAmortisman"] = Convert.ToString(ToplamBAmortisman);

                                            RBul = ((DonemYil - BaslangicYili) * 12) * AylikAmortisman;

                                            if (cmbDonemAyi.Text.ToString() == "Ocak")
                                            {
                                                decimal yeniAmortismanimiz = AylikAmortisman * 12;
                                            }

                                            EndekseTabiAmortismanTutari = RBul;
                                            //EndekslenmisAmortisman = KatSayisi * EndekseTabiAmortismanTutari;
                                            //EndekslenmisAmortisman = RBul;
                                            //EndekslenmisAmortisman = EndekseTabiAmortismanTutari + CariDonemAmortisman;
                                            EndekslenmisAmortisman = (((EndekslenmisDeger - EndsTabiDeger) / EndsTabiDeger) * ToplamBAmortisman) + ToplamBAmortisman;

                                            dr["EndekslenmisAmortisman"] = Convert.ToString(EndekslenmisAmortisman);
                                            dr["EndekseTabiAmortisman"] = Convert.ToString(EndekseTabiAmortismanTutari);
                                            dr["KalanDeger"] = Convert.ToString(EndekslenmisDeger - Convert.ToDecimal(dr["EndekseTabiAmortisman"].ToString()));

                                            SabitKiymetEnfFarki = 0;
                                            AmortismanEnfFarki = 0;

                                            dr["SabitKiymetEnflasyonFarki"] = Convert.ToString(SabitKiymetEnfFarki);
                                            dr["AmortismanEnflasyonFarki"] = Convert.ToString(AmortismanEnfFarki);

                                            KalanDeger = Convert.ToDecimal(dr["KalanDeger"].ToString());

                                            this.dsAmortisman.Hareketler.AddHareketlerRow(demirbasKodu, demirbasAdi, AmortismanHesabi, MuhasebeHesabi, GiderHesabi,
                                                    AmortismanOrani, BaslangicYili, BaslangicAyi, BitisYili, BitisAyi, iktisabDegeri, EndsTabiDeger, EndekseTabiAmortismanTutari,
                                                    KatSayisi, EndekslenmisDeger, EndekslenmisAmortisman, KalanDeger, CariDonemAmortisman, AylikAmortisman,
                                                    Convert.ToDecimal(dr["ToplamBirikmisAmortisman"].ToString()), SabitKiymetEnfFarki, AmortismanEnfFarki, KodDurumu, KontrolMiktari);
                                        }
                                    }
                                }

                                #endregion
                            }
                            else
                            {
                                if (DonemYil >= BaslangicYili)
                                {
                                    if (KontrolMiktari > 0)
                                    {
                                        this.dsAmortisman.Hareketler.AddHareketlerRow(demirbasKodu, demirbasAdi, AmortismanHesabi, MuhasebeHesabi, GiderHesabi,
                                            AmortismanOrani, BaslangicYili, BaslangicAyi, BitisYili, BitisAyi, iktisabDegeri, EndsTabiDeger, Convert.ToDecimal(dr["EndekslenmisAmortisman"].ToString()),
                                            KatSayisi, EndsTabiDeger, Convert.ToDecimal(dr["EndekslenmisAmortisman"].ToString()), 0, 0, 0,
                                            Convert.ToDecimal(dr["EndekslenmisAmortisman"].ToString()), SabitKiymetEnfFarki, AmortismanEnfFarki, KodDurumu, KontrolMiktari);
                                    }
                                }
                            }
                        }//Demirbaş Kodu Kontrolünün Bittiği Yer
                        else
                        {
                            this.dsAmortisman.Hareketler.AddHareketlerRow(dr["SabitKiymetKodu"].ToString(), dr["SabitKiymetAdi"].ToString(),
                                    dr["AmortismanHesabi"].ToString(), dr["MuhasebeHesabi"].ToString(), dr["GiderHesabi"].ToString(),
                                    Convert.ToDecimal(dr["AmortismanOrani"].ToString()), Convert.ToInt32(dr["BaslangicYili"].ToString()),
                                    Convert.ToInt32(dr["BaslangicAyi"].ToString()), Convert.ToInt32(dr["BitisYili"].ToString()),
                                    Convert.ToInt32(dr["BitisAyi"].ToString()), Convert.ToDecimal(dr["iktisabDegeri"].ToString()),
                                    Convert.ToDecimal(dr["EndekseTabiDeger"].ToString()), Convert.ToDecimal(dr["EndekseTabiAmortisman"].ToString()),
                                    Convert.ToDecimal(dr["KatSayisi"].ToString()), Convert.ToDecimal(dr["EndekslenmisDeger"].ToString()),
                                    Convert.ToDecimal(dr["EndekslenmisAmortisman"].ToString()), Convert.ToDecimal(dr["KalanDeger"].ToString()),
                                    Convert.ToDecimal(dr["CariYilAmortisman"].ToString()), Convert.ToDecimal(dr["AylikAmortisman"].ToString()),
                                    Convert.ToDecimal(dr["ToplamBirikmisAmortisman"].ToString()), Convert.ToDecimal(dr["SabitKiymetEnflasyonFarki"].ToString()),
                                    Convert.ToDecimal(dr["AmortismanEnflasyonFarki"].ToString()), dr["Durumu"].ToString(), KontrolMiktari);
                        }
                    }
                }

                #endregion

                #region Enflasyon Hesaplaması

                else
                {
                    foreach (DataRow dr in dsAmortisman.AmortHesaplari)
                    {
                        AylikAmortisman = Convert.ToDecimal(dr["AylikAmortisman"].ToString());

                        demirbasKodu = dr["SabitKiymetKodu"].ToString();
                        CikisTarihi = DemirbasCikisTarihineBakiyoruz(demirbasKodu);

                        KodDurumu = dr["Durumu"].ToString();
                        demirbasAdi = dr["SabitKiymetAdi"].ToString();
                        AmortismanHesabi = dr["AmortismanHesabi"].ToString();
                        MuhasebeHesabi = dr["MuhasebeHesabi"].ToString();
                        GiderHesabi = dr["GiderHesabi"].ToString();

                        BaslangicYili = Convert.ToInt32(dr["BaslangicYili"].ToString());
                        BaslangicAyi = Convert.ToInt32(dr["BaslangicAyi"].ToString());
                        BitisYili = Convert.ToInt32(dr["BitisYili"].ToString());
                        BitisAyi = Convert.ToInt32(dr["BitisAyi"].ToString());

                        decimal AmortismanOrani2 = (BitisYili - BaslangicYili) + 1;
                        AmortismanOrani = 100 / AmortismanOrani2;

                        iktisabDegeri = Convert.ToDecimal(dr["iktisabDegeri"].ToString());

                        EndsTabiDeger = Convert.ToDecimal(dr["EndekseTabiDeger"].ToString());
                        KalanDeger = 0;
                        EndekseTabiAmortismanTutari = 0;
                        KatSayisi = 1;
                        EndekslenmisDeger = 0;
                        EndekslenmisAmortisman = 0;
                        SabitKiymetEnfFarki = 0;
                        AmortismanEnfFarki = 0;
                        SonDonemEnflasyonOranimiz = 0;
                        DemirbasEnflasyonOranimiz = 0;
                        YeniEnflasyonOranimiz = 0;
                        int KontrolMiktari = Convert.ToInt32(dr["Miktar"].ToString());

                        if (demirbasKodu.Length > 13)
                        {
                            if (BitisYili >= DonemYil && BaslangicYili <= DonemYil && KontrolMiktari > 0)
                            {
                                #region Kıst Enflasyon Hesaplama

                                if (KodDurumu == "KIST")
                                {
                                    if (DonemYil == BaslangicYili)
                                    {
                                        if (Convert.ToDecimal(DonAy) >= BaslangicAyi)
                                        {
                                            AylikAmortisman = ((iktisabDegeri * AmortismanOrani) / 100) / 12;
                                            carprakam = Convert.ToInt32((Convert.ToDecimal(DonAy) - BaslangicAyi) + 1);
                                            CariDonemAmortisman = AylikAmortisman * carprakam;
                                            dr["AylikAmortisman"] = AylikAmortisman.ToString();

                                            YeniEnflasyonOranimiz = TefeTufeOranimiz(rdEnflasyon.Text, Convert.ToInt32(cmbEnflasyonBitisYili.Text), cmbEnflasyonBitisAyi.Text);
                                            DemirbasEnflasyonOranimiz = DemirbasTefeTufeOranimiz(rdEnflasyon.Text, BaslangicYili, BaslangicAyi);

                                            if (EndsTabiDeger == 0)
                                            {
                                                EndsTabiDeger = Convert.ToDecimal(dr["iktisabDegeri"].ToString());
                                            }

                                            KatSayisi = YeniEnflasyonOranimiz / DemirbasEnflasyonOranimiz;
                                            dr["KatSayisi"] = KatSayisi;

                                            dr["CariYilAmortisman"] = Convert.ToString(CariDonemAmortisman);
                                            dr["ToplamBirikmisAmortisman"] = Convert.ToString(CariDonemAmortisman);

                                            EndekslenmisDeger = KatSayisi * EndsTabiDeger;
                                            dr["EndekslenmisDeger"] = Convert.ToString(EndekslenmisDeger);

                                            EndekslenmisAmortisman = ((((EndekslenmisDeger - EndsTabiDeger) / EndsTabiDeger) * CariDonemAmortisman) + CariDonemAmortisman);
                                            dr["EndekslenmisAmortisman"] = Convert.ToString(EndekslenmisAmortisman);
                                            dr["EndekseTabiAmortisman"] = Convert.ToString(EndekseTabiAmortismanTutari);
                                            dr["KalanDeger"] = Convert.ToString(EndsTabiDeger - EndekseTabiAmortismanTutari);
                                            SabitKiymetEnfFarki = EndekslenmisDeger - EndsTabiDeger;
                                            AmortismanEnfFarki = EndekslenmisAmortisman - CariDonemAmortisman;

                                            dr["SabitKiymetEnflasyonFarki"] = Convert.ToString(SabitKiymetEnfFarki);
                                            dr["AmortismanEnflasyonFarki"] = Convert.ToString(AmortismanEnfFarki);

                                            KalanDeger = Convert.ToDecimal(dr["KalanDeger"].ToString());

                                            this.dsAmortisman.Hareketler.AddHareketlerRow(demirbasKodu, demirbasAdi, AmortismanHesabi, MuhasebeHesabi, GiderHesabi,
                                                AmortismanOrani, BaslangicYili, BaslangicAyi, BitisYili, BitisAyi, iktisabDegeri, EndsTabiDeger, EndekseTabiAmortismanTutari,
                                                KatSayisi, EndekslenmisDeger, EndekslenmisAmortisman, KalanDeger, CariDonemAmortisman, AylikAmortisman,
                                                Convert.ToDecimal(dr["ToplamBirikmisAmortisman"].ToString()), SabitKiymetEnfFarki, AmortismanEnfFarki, KodDurumu, KontrolMiktari);
                                        }
                                    }
                                    else
                                    {
                                        if (DonemYil == BitisYili)
                                        {
                                            if (EndsTabiDeger == 0)
                                            {
                                                EndsTabiDeger = Convert.ToDecimal(dr["iktisabDegeri"].ToString());
                                            }

                                            carprakam = Convert.ToInt32(Convert.ToDecimal(DonAy));
                                            //
                                            YeniCarpRakam = Convert.ToInt32((12 - BaslangicAyi) + 1);
                                            CariDonemAmortisman = AylikAmortisman * carprakam;

                                            //decimal RBul = 0;
                                            if ((DonemYil - BaslangicYili) == 1)
                                            {
                                                RBul = ((DonemYil - BaslangicYili) * YeniCarpRakam) * AylikAmortisman;
                                            }
                                            else
                                            {
                                                RBul = (YeniCarpRakam * AylikAmortisman) + (AylikAmortisman * ((12 * ((DonemYil - BaslangicYili) - 1))));
                                            }

                                            dr["EndekseTabiAmortisman"] = Convert.ToString(RBul);
                                            EndekseTabiAmortismanTutari = Convert.ToDecimal(dr["EndekseTabiAmortisman"].ToString());

                                            YeniEnflasyonOranimiz = TefeTufeOranimiz(rdEnflasyon.Text, Convert.ToInt32(cmbEnflasyonBitisYili.Text), cmbEnflasyonBitisAyi.Text);
                                            DemirbasEnflasyonOranimiz = DemirbasTefeTufeOranimiz(rdEnflasyon.Text, BaslangicYili, BaslangicAyi);

                                            KatSayisi = YeniEnflasyonOranimiz / DemirbasEnflasyonOranimiz;
                                            dr["KatSayisi"] = KatSayisi;

                                            EndekslenmisDeger = KatSayisi * EndsTabiDeger;
                                            dr["EndekslenmisDeger"] = Convert.ToString(EndekslenmisDeger);


                                            AylikAmortisman = (EndsTabiDeger - RBul) / 12;
                                            CariDonemAmortisman = AylikAmortisman * carprakam;
                                            dr["CariYilAmortisman"] = Convert.ToString(CariDonemAmortisman);

                                            if (Convert.ToDecimal(dr["EndekseTabiDeger"].ToString()) == 0)
                                            {
                                                dr["EndekseTabiDeger"] = dr["iktisabDegeri"].ToString();
                                            }

                                            YeniCarpRakam = Convert.ToInt32((12 - BaslangicAyi) + 1);
                                            YeniDegerim = Convert.ToDecimal(dr["EndekseTabiDeger"].ToString());
                                            AmrtOran = AmortismanOrani;
                                            ToplamBAmortisman = ((((YeniDegerim * AmrtOran) / 100) / 12) * YeniCarpRakam);
                                            YeniYilTotalAmortisman = AylikAmortisman * carprakam;
                                            ToplamBAmortisman = EndekseTabiAmortismanTutari + YeniYilTotalAmortisman;
                                            dr["ToplamBirikmisAmortisman"] = Convert.ToString(ToplamBAmortisman);

                                            EndekseTabiAmortismanTutari = RBul;
                                            EndekslenmisAmortisman = ((((EndekslenmisDeger - EndsTabiDeger) / EndsTabiDeger) * ToplamBAmortisman) + ToplamBAmortisman);
                                            dr["EndekslenmisAmortisman"] = Convert.ToString(EndekslenmisAmortisman);
                                            dr["EndekseTabiAmortisman"] = Convert.ToString(EndekseTabiAmortismanTutari);
                                            dr["KalanDeger"] = Convert.ToString(EndsTabiDeger - EndekseTabiAmortismanTutari);
                                            //KalanDeger = EndsTabiDeger - EndekseTabiAmortismanTutari;

                                            SabitKiymetEnfFarki = EndekslenmisDeger - EndsTabiDeger;
                                            AmortismanEnfFarki = EndekslenmisAmortisman - ToplamBAmortisman;

                                            dr["SabitKiymetEnflasyonFarki"] = Convert.ToString(SabitKiymetEnfFarki);
                                            dr["AmortismanEnflasyonFarki"] = Convert.ToString(AmortismanEnfFarki);

                                            KalanDeger = Convert.ToDecimal(dr["KalanDeger"].ToString());

                                            this.dsAmortisman.Hareketler.AddHareketlerRow(demirbasKodu, demirbasAdi, AmortismanHesabi, MuhasebeHesabi, GiderHesabi,
                                                AmortismanOrani, BaslangicYili, BaslangicAyi, BitisYili, BitisAyi, iktisabDegeri, EndsTabiDeger, EndekseTabiAmortismanTutari,
                                                KatSayisi, EndekslenmisDeger, EndekslenmisAmortisman, KalanDeger, CariDonemAmortisman, AylikAmortisman,
                                                Convert.ToDecimal(dr["ToplamBirikmisAmortisman"].ToString()), SabitKiymetEnfFarki, AmortismanEnfFarki, KodDurumu, KontrolMiktari);

                                        }
                                        else
                                        {
                                            if (EndsTabiDeger == 0)
                                            {
                                                EndsTabiDeger = Convert.ToDecimal(dr["iktisabDegeri"].ToString());
                                            }
                                            EndekseTabiAmortismanTutari = Convert.ToDecimal(dr["EndekseTabiAmortisman"].ToString());
                                            carprakam = Convert.ToInt32(Convert.ToDecimal(DonAy));
                                            CariDonemAmortisman = AylikAmortisman * carprakam;

                                            YeniEnflasyonOranimiz = TefeTufeOranimiz(rdEnflasyon.Text, Convert.ToInt32(cmbEnflasyonBitisYili.Text), cmbEnflasyonBitisAyi.Text);
                                            DemirbasEnflasyonOranimiz = DemirbasTefeTufeOranimiz(rdEnflasyon.Text, BaslangicYili, BaslangicAyi);

                                            KatSayisi = YeniEnflasyonOranimiz / DemirbasEnflasyonOranimiz;
                                            dr["KatSayisi"] = KatSayisi;

                                            EndekslenmisDeger = KatSayisi * EndsTabiDeger;
                                            dr["EndekslenmisDeger"] = Convert.ToString(EndekslenmisDeger);

                                            dr["CariYilAmortisman"] = Convert.ToString(CariDonemAmortisman);

                                            if (Convert.ToDecimal(dr["EndekseTabiDeger"].ToString()) == 0)
                                            {
                                                dr["EndekseTabiDeger"] = dr["iktisabDegeri"].ToString();
                                            }

                                            YeniCarpRakam = Convert.ToInt32((12 - BaslangicAyi) + 1);
                                            YeniDegerim = Convert.ToDecimal(dr["EndekseTabiDeger"].ToString());
                                            AmrtOran = AmortismanOrani;
                                            ToplamBAmortisman = ((((YeniDegerim * AmrtOran) / 100) / 12) * YeniCarpRakam);
                                            YeniYilTotalAmortisman = AylikAmortisman * ((12 * ((DonemYil - BaslangicYili) - 1)) + Convert.ToDecimal(DonAy));
                                            ToplamBAmortisman = ToplamBAmortisman + YeniYilTotalAmortisman;
                                            dr["ToplamBirikmisAmortisman"] = Convert.ToString(ToplamBAmortisman);

                                            //decimal RBul = 0;
                                            if ((DonemYil - BaslangicYili) == 1)
                                            {
                                                RBul = ((DonemYil - BaslangicYili) * YeniCarpRakam) * AylikAmortisman;
                                            }
                                            else
                                            {
                                                RBul = (YeniCarpRakam * AylikAmortisman) + (AylikAmortisman * ((12 * ((DonemYil - BaslangicYili) - 1))));
                                            }

                                            EndekseTabiAmortismanTutari = RBul;
                                            EndekslenmisAmortisman = ((((EndekslenmisDeger - EndsTabiDeger) / EndsTabiDeger) * ToplamBAmortisman) + ToplamBAmortisman);
                                            dr["EndekslenmisAmortisman"] = Convert.ToString(EndekslenmisAmortisman);
                                            dr["EndekseTabiAmortisman"] = Convert.ToString(EndekseTabiAmortismanTutari);
                                            dr["KalanDeger"] = Convert.ToString(EndsTabiDeger - EndekseTabiAmortismanTutari);

                                            SabitKiymetEnfFarki = EndekslenmisDeger - EndsTabiDeger;
                                            AmortismanEnfFarki = EndekslenmisAmortisman - ToplamBAmortisman;

                                            dr["SabitKiymetEnflasyonFarki"] = Convert.ToString(SabitKiymetEnfFarki);
                                            dr["AmortismanEnflasyonFarki"] = Convert.ToString(AmortismanEnfFarki);

                                            KalanDeger = Convert.ToDecimal(dr["KalanDeger"].ToString());

                                            this.dsAmortisman.Hareketler.AddHareketlerRow(demirbasKodu, demirbasAdi, AmortismanHesabi, MuhasebeHesabi, GiderHesabi,
                                                AmortismanOrani, BaslangicYili, BaslangicAyi, BitisYili, BitisAyi, iktisabDegeri, EndsTabiDeger, EndekseTabiAmortismanTutari,
                                                KatSayisi, EndekslenmisDeger, EndekslenmisAmortisman, KalanDeger, CariDonemAmortisman, AylikAmortisman,
                                                Convert.ToDecimal(dr["ToplamBirikmisAmortisman"].ToString()), SabitKiymetEnfFarki, AmortismanEnfFarki, KodDurumu, KontrolMiktari);
                                        }
                                    }
                                }

                                #endregion

                                #region Kalan Yıl Enflasyon Hesaplama

                                if (KodDurumu == "KALAN")
                                {
                                    if (DonemYil == BaslangicYili)
                                    {
                                        if (EndsTabiDeger == 0)
                                        {
                                            EndsTabiDeger = iktisabDegeri;
                                        }

                                        if (Convert.ToDecimal(DonAy) >= BaslangicAyi)
                                        {
                                            //carprakam = Convert.ToInt32((Convert.ToDecimal(DonAy) - BaslangicAyi) + 1);

                                            //AylikAmortisman = (((EndsTabiDeger * AmortismanOrani) / 100) / ((12 - BaslangicAyi) + 1));

                                            if (BitisYili >= DonemYil)
                                            {
                                                KalanYilAylikHesap = EndsTabiDeger / ((BitisYili - DonemYil) + 1);
                                            }
                                            if (BaslangicYili < DonemYil)
                                            {
                                                KalanYilAylikHesap = EndsTabiDeger / ((BitisYili - DonemYil) + 1) / 12;
                                            }
                                            else
                                            {
                                                KalanYilAylikHesap = EndsTabiDeger / ((BitisYili - DonemYil) + 1) / ((BitisAyi - BaslangicAyi) + 1);
                                            }

                                            AylikAmortisman = KalanYilAylikHesap;
                                            carprakam = Convert.ToInt32((Convert.ToDecimal(DonAy) - BaslangicAyi) + 1);
                                            CariDonemAmortisman = AylikAmortisman * carprakam;
                                            dr["AylikAmortisman"] = AylikAmortisman.ToString();

                                            dr["CariYilAmortisman"] = Convert.ToString(CariDonemAmortisman);
                                            dr["ToplamBirikmisAmortisman"] = Convert.ToString(CariDonemAmortisman);


                                            YeniEnflasyonOranimiz = TefeTufeOranimiz(rdEnflasyon.Text, Convert.ToInt32(cmbEnflasyonBitisYili.Text), cmbEnflasyonBitisAyi.Text);
                                            DemirbasEnflasyonOranimiz = DemirbasTefeTufeOranimiz(rdEnflasyon.Text, BaslangicYili, BaslangicAyi);

                                            if (EndsTabiDeger == 0)
                                            {
                                                EndsTabiDeger = Convert.ToDecimal(dr["iktisabDegeri"].ToString());
                                            }

                                            KatSayisi = YeniEnflasyonOranimiz / DemirbasEnflasyonOranimiz;
                                            dr["KatSayisi"] = KatSayisi;

                                            dr["CariYilAmortisman"] = Convert.ToString(CariDonemAmortisman);
                                            dr["ToplamBirikmisAmortisman"] = Convert.ToString(CariDonemAmortisman);

                                            EndekslenmisDeger = KatSayisi * EndsTabiDeger;
                                            dr["EndekslenmisDeger"] = Convert.ToString(EndekslenmisDeger);

                                            EndekslenmisAmortisman = ((((EndekslenmisDeger - EndsTabiDeger) / EndsTabiDeger) * CariDonemAmortisman) + CariDonemAmortisman);
                                            dr["EndekslenmisAmortisman"] = Convert.ToString(EndekslenmisAmortisman);
                                            dr["EndekseTabiAmortisman"] = Convert.ToString(EndekseTabiAmortismanTutari);
                                            dr["KalanDeger"] = Convert.ToString(EndsTabiDeger - Convert.ToDecimal(dr["EndekseTabiAmortisman"].ToString()));
                                            SabitKiymetEnfFarki = EndekslenmisDeger - EndsTabiDeger;
                                            AmortismanEnfFarki = EndekslenmisAmortisman - CariDonemAmortisman;


                                            dr["SabitKiymetEnflasyonFarki"] = Convert.ToString(SabitKiymetEnfFarki);
                                            dr["AmortismanEnflasyonFarki"] = Convert.ToString(AmortismanEnfFarki);

                                            //AylikAmortisman = Convert.ToDecimal(dr["AylikAmortisman"].ToString());
                                            KalanDeger = Convert.ToDecimal(dr["KalanDeger"].ToString());

                                            this.dsAmortisman.Hareketler.AddHareketlerRow(demirbasKodu, demirbasAdi, AmortismanHesabi, MuhasebeHesabi, GiderHesabi,
                                                AmortismanOrani, BaslangicYili, BaslangicAyi, BitisYili, BitisAyi, iktisabDegeri, EndsTabiDeger, EndekseTabiAmortismanTutari,
                                                KatSayisi, EndekslenmisDeger, EndekslenmisAmortisman, KalanDeger, CariDonemAmortisman, AylikAmortisman,
                                                Convert.ToDecimal(dr["ToplamBirikmisAmortisman"].ToString()), SabitKiymetEnfFarki, AmortismanEnfFarki, KodDurumu, KontrolMiktari);
                                        }
                                    }
                                    else
                                    {
                                        if (EndsTabiDeger == 0)
                                        {
                                            EndsTabiDeger = Convert.ToDecimal(dr["iktisabDegeri"].ToString());
                                        }

                                        EndekseTabiAmortismanTutari = Convert.ToDecimal(dr["EndekseTabiAmortisman"].ToString());
                                        KalanYilAylikHesap = EndsTabiDeger / ((BitisYili - BaslangicYili) + 1) / 12;
                                        //AylikAmortisman = (((EndsTabiDeger * AmortismanOrani) / 100) / 12);
                                        carprakam = Convert.ToInt32(Convert.ToDecimal(DonAy));
                                        CariDonemAmortisman = AylikAmortisman * carprakam;

                                        ////
                                        //if (EndsTabiDeger == 0)
                                        //{
                                        //    EndsTabiDeger = Convert.ToDecimal(dr["iktisabDegeri"].ToString());
                                        //}
                                        //EndekseTabiAmortismanTutari = Convert.ToDecimal(dr["EndekseTabiAmortisman"].ToString());
                                        //carprakam = Convert.ToInt32(Convert.ToDecimal(DonAy));
                                        //CariDonemAmortisman = AylikAmortisman * carprakam;

                                        YeniEnflasyonOranimiz = TefeTufeOranimiz(rdEnflasyon.Text, Convert.ToInt32(cmbEnflasyonBitisYili.Text), cmbEnflasyonBitisAyi.Text);
                                        DemirbasEnflasyonOranimiz = DemirbasTefeTufeOranimiz(rdEnflasyon.Text, BaslangicYili, BaslangicAyi);
                                        
                                        KatSayisi = YeniEnflasyonOranimiz / DemirbasEnflasyonOranimiz;
                                        dr["KatSayisi"] = KatSayisi;

                                        EndekslenmisDeger = KatSayisi * EndsTabiDeger;
                                        dr["EndekslenmisDeger"] = Convert.ToString(EndekslenmisDeger);

                                        dr["CariYilAmortisman"] = Convert.ToString(CariDonemAmortisman);

                                        YeniCarpRakam = Convert.ToInt32((12 - BaslangicAyi) + 1);
                                        YeniDegerim = EndsTabiDeger;
                                        AmrtOran = AmortismanOrani;
                                        ToplamBAmortisman = ((((YeniDegerim * AmrtOran) / 100) / YeniCarpRakam) * YeniCarpRakam);
                                        YeniYilTotalAmortisman = AylikAmortisman * ((12 * ((DonemYil - BaslangicYili) - 1)) + Convert.ToDecimal(DonAy));
                                        ToplamBAmortisman = ToplamBAmortisman + YeniYilTotalAmortisman;
                                        dr["ToplamBirikmisAmortisman"] = Convert.ToString(ToplamBAmortisman);

                                        RBul = ((DonemYil - BaslangicYili) * 12) * AylikAmortisman;
                                        EndekseTabiAmortismanTutari = RBul;
                                        EndekslenmisAmortisman = ((((EndekslenmisDeger - EndsTabiDeger) / EndsTabiDeger) * ToplamBAmortisman) + ToplamBAmortisman);
                                        dr["EndekslenmisAmortisman"] = Convert.ToString(EndekslenmisAmortisman);
                                        dr["EndekseTabiAmortisman"] = Convert.ToString(EndekseTabiAmortismanTutari);
                                        dr["KalanDeger"] = Convert.ToString(EndsTabiDeger - EndekseTabiAmortismanTutari);

                                        SabitKiymetEnfFarki = EndekslenmisDeger - EndsTabiDeger;
                                        AmortismanEnfFarki = EndekslenmisAmortisman - ToplamBAmortisman;

                                        dr["SabitKiymetEnflasyonFarki"] = Convert.ToString(SabitKiymetEnfFarki);
                                        dr["AmortismanEnflasyonFarki"] = Convert.ToString(AmortismanEnfFarki);

                                        KalanDeger = Convert.ToDecimal(dr["KalanDeger"].ToString());

                                        this.dsAmortisman.Hareketler.AddHareketlerRow(demirbasKodu, demirbasAdi, AmortismanHesabi, MuhasebeHesabi, GiderHesabi,
                                            AmortismanOrani, BaslangicYili, BaslangicAyi, BitisYili, BitisAyi, iktisabDegeri, EndsTabiDeger, EndekseTabiAmortismanTutari,
                                            KatSayisi, EndekslenmisDeger, EndekslenmisAmortisman, KalanDeger, CariDonemAmortisman, AylikAmortisman,
                                            Convert.ToDecimal(dr["ToplamBirikmisAmortisman"].ToString()), SabitKiymetEnfFarki, AmortismanEnfFarki, KodDurumu, KontrolMiktari);
                                    }

                                }

                                #endregion

                                #region Normal Enflasyon Hesaplama

                                if (KodDurumu == "")
                                {
                                    if (DonemYil == BaslangicYili)
                                    {
                                        if (EndsTabiDeger == 0)
                                        {
                                            EndsTabiDeger = iktisabDegeri;
                                        }

                                        if (Convert.ToDecimal(DonAy) >= BaslangicAyi)
                                        {
                                            carprakam = Convert.ToInt32((Convert.ToDecimal(DonAy) - BaslangicAyi) + 1);

                                            AylikAmortisman = (((EndsTabiDeger * AmortismanOrani) / 100) / ((12 - BaslangicAyi) + 1));

                                            CariDonemAmortisman = AylikAmortisman * carprakam;
                                            //}
                                            //else
                                            //{
                                            //    //int carprakam = Convert.ToInt32((BaslangicAyi - Convert.ToDecimal(DonAy)) + 1);
                                            //    CariDonemAmortisman = 0;// *carprakam;
                                            //    dr["AylikAmortisman"] = "0";
                                            //}

                                            //SonDonemEnflasyonOranimiz = SonDonemTefeTufeOraniGetir(rdEnflasyon.Text, Convert.ToInt32(cmbEnflasyonBaslangicYili.Text), cmbEnflasyonBaslangicAyi.Text);
                                            YeniEnflasyonOranimiz = TefeTufeOranimiz(rdEnflasyon.Text, Convert.ToInt32(cmbEnflasyonBitisYili.Text), cmbEnflasyonBitisAyi.Text);
                                            DemirbasEnflasyonOranimiz = DemirbasTefeTufeOranimiz(rdEnflasyon.Text, BaslangicYili, BaslangicAyi);

                                            if (EndsTabiDeger == 0)
                                            {
                                                EndsTabiDeger = Convert.ToDecimal(dr["iktisabDegeri"].ToString());
                                            }

                                            KatSayisi = YeniEnflasyonOranimiz / DemirbasEnflasyonOranimiz;
                                            dr["KatSayisi"] = KatSayisi;

                                            dr["CariYilAmortisman"] = Convert.ToString(CariDonemAmortisman);
                                            dr["ToplamBirikmisAmortisman"] = Convert.ToString(CariDonemAmortisman);

                                            EndekslenmisDeger = KatSayisi * EndsTabiDeger;
                                            dr["EndekslenmisDeger"] = Convert.ToString(EndekslenmisDeger);

                                            EndekslenmisAmortisman = ((((EndekslenmisDeger - EndsTabiDeger) / EndsTabiDeger) * CariDonemAmortisman) + CariDonemAmortisman);
                                            dr["EndekslenmisAmortisman"] = Convert.ToString(EndekslenmisAmortisman);
                                            dr["EndekseTabiAmortisman"] = Convert.ToString(EndekseTabiAmortismanTutari);
                                            dr["KalanDeger"] = Convert.ToString(EndsTabiDeger - Convert.ToDecimal(dr["EndekseTabiAmortisman"].ToString()));
                                            SabitKiymetEnfFarki = EndekslenmisDeger - EndsTabiDeger;
                                            AmortismanEnfFarki = EndekslenmisAmortisman - CariDonemAmortisman;

                                            //if (SabitKiymetEnfFarki < 0)
                                            //{
                                            //    SabitKiymetEnfFarki = SabitKiymetEnfFarki * -1;
                                            //}
                                            //if (AmortismanEnfFarki < 0)
                                            //{
                                            //    AmortismanEnfFarki = AmortismanEnfFarki * -1;
                                            //}

                                            dr["SabitKiymetEnflasyonFarki"] = Convert.ToString(SabitKiymetEnfFarki);
                                            dr["AmortismanEnflasyonFarki"] = Convert.ToString(AmortismanEnfFarki);

                                            //AylikAmortisman = Convert.ToDecimal(dr["AylikAmortisman"].ToString());
                                            KalanDeger = Convert.ToDecimal(dr["KalanDeger"].ToString());

                                            this.dsAmortisman.Hareketler.AddHareketlerRow(demirbasKodu, demirbasAdi, AmortismanHesabi, MuhasebeHesabi, GiderHesabi,
                                                AmortismanOrani, BaslangicYili, BaslangicAyi, BitisYili, BitisAyi, iktisabDegeri, EndsTabiDeger, EndekseTabiAmortismanTutari,
                                                KatSayisi, EndekslenmisDeger, EndekslenmisAmortisman, KalanDeger, CariDonemAmortisman, AylikAmortisman,
                                                Convert.ToDecimal(dr["ToplamBirikmisAmortisman"].ToString()), SabitKiymetEnfFarki, AmortismanEnfFarki, KodDurumu, KontrolMiktari);
                                        }
                                    }
                                    else
                                    {
                                        if (EndsTabiDeger == 0)
                                        {
                                            EndsTabiDeger = Convert.ToDecimal(dr["iktisabDegeri"].ToString());
                                        }

                                        EndekseTabiAmortismanTutari = Convert.ToDecimal(dr["EndekseTabiAmortisman"].ToString());
                                        AylikAmortisman = (((EndsTabiDeger * AmortismanOrani) / 100) / 12);
                                        carprakam = Convert.ToInt32(Convert.ToDecimal(DonAy));
                                        CariDonemAmortisman = AylikAmortisman * carprakam;

                                        ////
                                        //if (EndsTabiDeger == 0)
                                        //{
                                        //    EndsTabiDeger = Convert.ToDecimal(dr["iktisabDegeri"].ToString());
                                        //}
                                        //EndekseTabiAmortismanTutari = Convert.ToDecimal(dr["EndekseTabiAmortisman"].ToString());
                                        //carprakam = Convert.ToInt32(Convert.ToDecimal(DonAy));
                                        //CariDonemAmortisman = AylikAmortisman * carprakam;

                                        YeniEnflasyonOranimiz = TefeTufeOranimiz(rdEnflasyon.Text, Convert.ToInt32(cmbEnflasyonBitisYili.Text), cmbEnflasyonBitisAyi.Text);
                                        DemirbasEnflasyonOranimiz = DemirbasTefeTufeOranimiz(rdEnflasyon.Text, BaslangicYili, BaslangicAyi);

                                        KatSayisi = YeniEnflasyonOranimiz / DemirbasEnflasyonOranimiz;
                                        dr["KatSayisi"] = KatSayisi;

                                        EndekslenmisDeger = KatSayisi * EndsTabiDeger;
                                        dr["EndekslenmisDeger"] = Convert.ToString(EndekslenmisDeger);

                                        dr["CariYilAmortisman"] = Convert.ToString(CariDonemAmortisman);

                                        YeniCarpRakam = Convert.ToInt32((12 - BaslangicAyi) + 1);
                                        YeniDegerim = EndsTabiDeger;
                                        AmrtOran = AmortismanOrani;
                                        ToplamBAmortisman = ((((YeniDegerim * AmrtOran) / 100) / YeniCarpRakam) * YeniCarpRakam);
                                        YeniYilTotalAmortisman = AylikAmortisman * ((12 * ((DonemYil - BaslangicYili) - 1)) + Convert.ToDecimal(DonAy));
                                        ToplamBAmortisman = ToplamBAmortisman + YeniYilTotalAmortisman;
                                        dr["ToplamBirikmisAmortisman"] = Convert.ToString(ToplamBAmortisman);

                                        RBul = ((DonemYil - BaslangicYili) * 12) * AylikAmortisman;
                                        EndekseTabiAmortismanTutari = RBul;
                                        EndekslenmisAmortisman = ((((EndekslenmisDeger - EndsTabiDeger) / EndsTabiDeger) * ToplamBAmortisman) + ToplamBAmortisman);
                                        dr["EndekslenmisAmortisman"] = Convert.ToString(EndekslenmisAmortisman);
                                        dr["EndekseTabiAmortisman"] = Convert.ToString(EndekseTabiAmortismanTutari);
                                        dr["KalanDeger"] = Convert.ToString(EndsTabiDeger - EndekseTabiAmortismanTutari);

                                        SabitKiymetEnfFarki = EndekslenmisDeger - EndsTabiDeger;
                                        AmortismanEnfFarki = EndekslenmisAmortisman - ToplamBAmortisman;

                                        //if (SabitKiymetEnfFarki < 0)
                                        //{
                                        //    SabitKiymetEnfFarki = SabitKiymetEnfFarki * -1;
                                        //}
                                        //if (AmortismanEnfFarki < 0)
                                        //{
                                        //    AmortismanEnfFarki = AmortismanEnfFarki * -1;
                                        //}

                                        dr["SabitKiymetEnflasyonFarki"] = Convert.ToString(SabitKiymetEnfFarki);
                                        dr["AmortismanEnflasyonFarki"] = Convert.ToString(AmortismanEnfFarki);

                                        //AylikAmortisman = Convert.ToDecimal(dr["AylikAmortisman"].ToString());
                                        KalanDeger = Convert.ToDecimal(dr["KalanDeger"].ToString());

                                        this.dsAmortisman.Hareketler.AddHareketlerRow(demirbasKodu, demirbasAdi, AmortismanHesabi, MuhasebeHesabi, GiderHesabi,
                                            AmortismanOrani, BaslangicYili, BaslangicAyi, BitisYili, BitisAyi, iktisabDegeri, EndsTabiDeger, EndekseTabiAmortismanTutari,
                                            KatSayisi, EndekslenmisDeger, EndekslenmisAmortisman, KalanDeger, CariDonemAmortisman, AylikAmortisman,
                                            Convert.ToDecimal(dr["ToplamBirikmisAmortisman"].ToString()), SabitKiymetEnfFarki, AmortismanEnfFarki, KodDurumu, KontrolMiktari);
                                    }

                                    //AylikAmortisman = Convert.ToDecimal(dr["AylikAmortisman"].ToString());
                                    //KalanDeger = Convert.ToDecimal(dr["KalanDeger"].ToString());

                                    //this.dsAmortisman.Hareketler.AddHareketlerRow(demirbasKodu, demirbasAdi, AmortismanHesabi, MuhasebeHesabi, GiderHesabi,
                                    //    AmortismanOrani, BaslangicYili, BaslangicAyi, BitisYili, BitisAyi, iktisabDegeri, EndsTabiDeger, EndekseTabiAmortismanTutari,
                                    //    KatSayisi, EndekslenmisDeger, EndekslenmisAmortisman, KalanDeger, CariDonemAmortisman, AylikAmortisman,
                                    //    Convert.ToDecimal(dr["ToplamBirikmisAmortisman"].ToString()), SabitKiymetEnfFarki, AmortismanEnfFarki, KodDurumu);
                                }

                                #endregion
                            }
                            else
                            {
                                if (DonemYil >= BaslangicYili)
                                {
                                    SonDonemEnflasyonOranimiz = SonDonemTefeTufeOraniGetir(rdEnflasyon.Text, Convert.ToInt32(cmbEnflasyonBaslangicYili.Text), cmbEnflasyonBaslangicAyi.Text);
                                    YeniEnflasyonOranimiz = TefeTufeOranimiz(rdEnflasyon.Text, Convert.ToInt32(cmbEnflasyonBitisYili.Text), cmbEnflasyonBitisAyi.Text);

                                    KatSayisi = YeniEnflasyonOranimiz / SonDonemEnflasyonOranimiz;
                                    dr["KatSayisi"] = KatSayisi;

                                    EndsTabiDeger = Convert.ToDecimal(dr["EndekseTabiDeger"].ToString());

                                    if (EndsTabiDeger == 0)
                                    {
                                        EndsTabiDeger = Convert.ToDecimal(dr["iktisabDegeri"].ToString());
                                    }

                                    EndekslenmisDeger = KatSayisi * EndsTabiDeger;
                                    dr["EndekslenmisDeger"] = Convert.ToString(EndekslenmisDeger);
                                    TotalBirikAmortisman = Convert.ToDecimal(dr["EndekseTabiDeger"].ToString());

                                    if (EndsTabiDeger <= 0)
                                    {
                                        EndekslenmisAmortisman = 0;
                                    }
                                    else
                                    {
                                        EndekslenmisAmortisman = ((((EndekslenmisDeger - EndsTabiDeger) / EndsTabiDeger) * TotalBirikAmortisman) + TotalBirikAmortisman);
                                    } 
                                    
                                    dr["EndekslenmisAmortisman"] = Convert.ToString(EndekslenmisAmortisman);
                                    dr["EndekseTabiAmortisman"] = dr["EndekseTabiDeger"].ToString();
                                    dr["KalanDeger"] = Convert.ToString(EndsTabiDeger - Convert.ToDecimal(dr["EndekseTabiAmortisman"].ToString()));
                                    SabitKiymetEnfFarki = EndekslenmisDeger - EndsTabiDeger;
                                    AmortismanEnfFarki = EndekslenmisAmortisman - Convert.ToDecimal(dr["EndekseTabiDeger"].ToString());


                                    this.dsAmortisman.Hareketler.AddHareketlerRow(demirbasKodu, demirbasAdi, AmortismanHesabi, MuhasebeHesabi, GiderHesabi,
                                        AmortismanOrani, BaslangicYili, BaslangicAyi, BitisYili, BitisAyi, iktisabDegeri, EndsTabiDeger, Convert.ToDecimal(dr["EndekseTabiAmortisman"].ToString()),
                                        KatSayisi, EndekslenmisDeger, Convert.ToDecimal(dr["EndekslenmisAmortisman"].ToString()), Convert.ToDecimal(dr["KalanDeger"].ToString()), 0, 0,
                                        Convert.ToDecimal(dr["EndekseTabiDeger"].ToString()), SabitKiymetEnfFarki, AmortismanEnfFarki, KodDurumu, KontrolMiktari);
                                }
                            }
                        }//Demirbaş Kodunun Bittiği Yer
                        else
                        {
                            this.dsAmortisman.Hareketler.AddHareketlerRow(dr["SabitKiymetKodu"].ToString(), dr["SabitKiymetAdi"].ToString(),
                                    dr["AmortismanHesabi"].ToString(), dr["MuhasebeHesabi"].ToString(), dr["GiderHesabi"].ToString(),
                                    Convert.ToDecimal(dr["AmortismanOrani"].ToString()), Convert.ToInt32(dr["BaslangicYili"].ToString()),
                                    Convert.ToInt32(dr["BaslangicAyi"].ToString()), Convert.ToInt32(dr["BitisYili"].ToString()),
                                    Convert.ToInt32(dr["BitisAyi"].ToString()), Convert.ToDecimal(dr["iktisabDegeri"].ToString()),
                                    Convert.ToDecimal(dr["EndekseTabiDeger"].ToString()), Convert.ToDecimal(dr["EndekseTabiAmortisman"].ToString()),
                                    Convert.ToDecimal(dr["KatSayisi"].ToString()), Convert.ToDecimal(dr["EndekslenmisDeger"].ToString()),
                                    Convert.ToDecimal(dr["EndekslenmisAmortisman"].ToString()), Convert.ToDecimal(dr["KalanDeger"].ToString()),
                                    Convert.ToDecimal(dr["CariYilAmortisman"].ToString()), Convert.ToDecimal(dr["AylikAmortisman"].ToString()),
                                    Convert.ToDecimal(dr["ToplamBirikmisAmortisman"].ToString()), Convert.ToDecimal(dr["SabitKiymetEnflasyonFarki"].ToString()),
                                    Convert.ToDecimal(dr["AmortismanEnflasyonFarki"].ToString()), dr["Durumu"].ToString(), KontrolMiktari);
                        }
                    }
                }

                #endregion


                decimal iktisabDeg = 0;
                decimal EndekseTabiDeg = 0;
                decimal EndekseTabiAmortismanDeg = 0;
                decimal EndekslenmisDeg = 0;
                decimal EndekslenmisAmortismanDeg = 0;
                decimal KalanDegerDeg = 0;
                decimal CariYilTotalDeg = 0;
                decimal AylikTotalDeg = 0;
                decimal ToplamBirikmisAmortismanDeg = 0;
                decimal SabitKiymetEnflasyonFarkiDeg = 0;
                decimal AmortismanEnflasyonFarkıDeg = 0;
                bool onaltiSatirToplami = false;


                #region Tek Satır

                foreach (DataRow drRapor in dsAmortisman.Hareketler)
                {
                    string ilkKodu = drRapor["SabitKiymetKodu"].ToString();

                    if (ilkKodu.Length == 1)
                    {
                        foreach (DataRow drRapor2 in dsAmortisman.Hareketler)
                        {
                            string ikinciKodu = drRapor2["SabitKiymetKodu"].ToString();

                            if (ikinciKodu.ToString().Length == 2)
                            {
                                foreach (DataRow drRapor3 in dsAmortisman.Hareketler)
                                {
                                    string ucuncuKodu = drRapor3["SabitKiymetKodu"].ToString();

                                    if (ucuncuKodu.Length == 3)
                                    {
                                        foreach (DataRow drRapor4 in dsAmortisman.Hareketler)
                                        {
                                            string dorduncuKodu = drRapor4["SabitKiymetKodu"].ToString();

                                            if (dorduncuKodu.Length == 6)
                                            {
                                                foreach (DataRow drRapor5 in dsAmortisman.Hareketler)
                                                {
                                                    string altinciKodu = drRapor5["SabitKiymetKodu"].ToString();

                                                    if (altinciKodu.Length == 9)
                                                    {
                                                        foreach (DataRow drRapor6 in dsAmortisman.Hareketler)
                                                        {
                                                            string dokuzuncuKodu = drRapor6["SabitKiymetKodu"].ToString();

                                                            if (dokuzuncuKodu.Length == 16)
                                                            {
                                                                if (onaltiSatirToplami == false)
                                                                {
                                                                    iktisabDeg += Math.Round(Convert.ToDecimal(drRapor6["iktisabDegeri"].ToString()), 2);
                                                                    EndekseTabiDeg += Math.Round(Convert.ToDecimal(drRapor6["EndekseTabiDeger"].ToString()), 2);
                                                                    EndekseTabiAmortismanDeg += Math.Round(Convert.ToDecimal(drRapor6["EndekseTabiAmortisman"].ToString()), 2);
                                                                    EndekslenmisDeg += Math.Round(Convert.ToDecimal(drRapor6["EndekslenmisDeger"].ToString()), 2);
                                                                    EndekslenmisAmortismanDeg += Math.Round(Convert.ToDecimal(drRapor6["EndekslenmisAmortisman"].ToString()), 2);
                                                                    KalanDegerDeg += Math.Round(Convert.ToDecimal(drRapor6["KalanDeger"].ToString()), 2);
                                                                    CariYilTotalDeg += Math.Round(Convert.ToDecimal(drRapor6["CariYilAmortisman"].ToString()), 2);
                                                                    AylikTotalDeg += Math.Round(Convert.ToDecimal(drRapor6["AylikAmortisman"].ToString()), 2);
                                                                    ToplamBirikmisAmortismanDeg += Math.Round(Convert.ToDecimal(drRapor6["ToplamBirikmisAmortisman"].ToString()), 2);
                                                                    SabitKiymetEnflasyonFarkiDeg += Math.Round(Convert.ToDecimal(drRapor6["SabitKiymetEnflasyonFarki"].ToString()), 2);
                                                                    AmortismanEnflasyonFarkıDeg += Math.Round(Convert.ToDecimal(drRapor6["AmortismanEnflasyonFarki"].ToString()), 2);
                                                                }
                                                            }
                                                        }
                                                        onaltiSatirToplami = true;
                                                    }
                                                }
                                                //dokuzlarSatirToplami = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        drRapor["iktisabDegeri"] = iktisabDeg;
                        drRapor["EndekseTabiDeger"] = EndekseTabiDeg;
                        drRapor["EndekseTabiAmortisman"] = EndekseTabiAmortismanDeg;
                        drRapor["EndekslenmisDeger"] = EndekslenmisDeg;
                        drRapor["EndekslenmisAmortisman"] = EndekslenmisAmortismanDeg;
                        drRapor["CariYilAmortisman"] = CariYilTotalDeg;
                        drRapor["AylikAmortisman"] = AylikTotalDeg;
                        drRapor["ToplamBirikmisAmortisman"] = ToplamBirikmisAmortismanDeg;
                        drRapor["SabitKiymetEnflasyonFarki"] = SabitKiymetEnflasyonFarkiDeg;
                        drRapor["AmortismanEnflasyonFarki"] = AmortismanEnflasyonFarkıDeg;
                        drRapor["KalanDeger"] = KalanDegerDeg;

                        KalanDegerDeg = 0;
                        iktisabDeg = 0;
                        EndekseTabiDeg = 0;
                        EndekseTabiAmortismanDeg = 0;
                        CariYilTotalDeg = 0;
                        AylikTotalDeg = 0;
                        EndekslenmisDeg = 0;
                        EndekslenmisAmortismanDeg = 0;
                        ToplamBirikmisAmortismanDeg = 0;
                        SabitKiymetEnflasyonFarkiDeg = 0;
                        AmortismanEnflasyonFarkıDeg = 0;
                        onaltiSatirToplami = false;
                    }
                }

                #endregion

                #region İki Satır

                foreach (DataRow drRapor in dsAmortisman.Hareketler)
                {
                    string ilkKodu = drRapor["SabitKiymetKodu"].ToString();

                    if (ilkKodu.Length == 2)
                    {
                        foreach (DataRow drRapor3 in dsAmortisman.Hareketler)
                        {
                            string ucuncuKodu = drRapor3["SabitKiymetKodu"].ToString();

                            if (ucuncuKodu.Length == 3)
                            {
                                foreach (DataRow drRapor4 in dsAmortisman.Hareketler)
                                {
                                    string dorduncuKodu = drRapor4["SabitKiymetKodu"].ToString();

                                    if (dorduncuKodu.Length == 6)
                                    {
                                        foreach (DataRow drRapor5 in dsAmortisman.Hareketler)
                                        {
                                            string altinciKodu = drRapor5["SabitKiymetKodu"].ToString();

                                            if (altinciKodu.Length == 9)
                                            {
                                                foreach (DataRow drRapor6 in dsAmortisman.Hareketler)
                                                {
                                                    string dokuzuncuKodu = drRapor6["SabitKiymetKodu"].ToString();

                                                    if (dokuzuncuKodu.Length == 16)
                                                    {
                                                        if (onaltiSatirToplami == false)
                                                        {
                                                            iktisabDeg += Math.Round(Convert.ToDecimal(drRapor6["iktisabDegeri"].ToString()), 2);
                                                            EndekseTabiDeg += Math.Round(Convert.ToDecimal(drRapor6["EndekseTabiDeger"].ToString()), 2);
                                                            EndekseTabiAmortismanDeg += Math.Round(Convert.ToDecimal(drRapor6["EndekseTabiAmortisman"].ToString()), 2);
                                                            EndekslenmisDeg += Math.Round(Convert.ToDecimal(drRapor6["EndekslenmisDeger"].ToString()), 2);
                                                            EndekslenmisAmortismanDeg += Math.Round(Convert.ToDecimal(drRapor6["EndekslenmisAmortisman"].ToString()), 2);
                                                            KalanDegerDeg += Math.Round(Convert.ToDecimal(drRapor6["KalanDeger"].ToString()), 2);
                                                            CariYilTotalDeg += Math.Round(Convert.ToDecimal(drRapor6["CariYilAmortisman"].ToString()), 2);
                                                            AylikTotalDeg += Math.Round(Convert.ToDecimal(drRapor6["AylikAmortisman"].ToString()), 2);
                                                            ToplamBirikmisAmortismanDeg += Math.Round(Convert.ToDecimal(drRapor6["ToplamBirikmisAmortisman"].ToString()), 2);
                                                            SabitKiymetEnflasyonFarkiDeg += Math.Round(Convert.ToDecimal(drRapor6["SabitKiymetEnflasyonFarki"].ToString()), 2);
                                                            AmortismanEnflasyonFarkıDeg += Math.Round(Convert.ToDecimal(drRapor6["AmortismanEnflasyonFarki"].ToString()), 2);
                                                        }
                                                    }
                                                }
                                                onaltiSatirToplami = true;
                                            }
                                        }
                                        //dokuzlarSatirToplami = true;
                                    }
                                }
                            }
                        }

                        drRapor["iktisabDegeri"] = iktisabDeg;
                        drRapor["EndekseTabiDeger"] = EndekseTabiDeg;
                        drRapor["EndekseTabiAmortisman"] = EndekseTabiAmortismanDeg;
                        drRapor["EndekslenmisDeger"] = EndekslenmisDeg;
                        drRapor["EndekslenmisAmortisman"] = EndekslenmisAmortismanDeg;
                        drRapor["CariYilAmortisman"] = CariYilTotalDeg;
                        drRapor["AylikAmortisman"] = AylikTotalDeg;
                        drRapor["ToplamBirikmisAmortisman"] = ToplamBirikmisAmortismanDeg;
                        drRapor["SabitKiymetEnflasyonFarki"] = SabitKiymetEnflasyonFarkiDeg;
                        drRapor["AmortismanEnflasyonFarki"] = AmortismanEnflasyonFarkıDeg;
                        drRapor["KalanDeger"] = KalanDegerDeg;

                        KalanDegerDeg = 0;
                        iktisabDeg = 0;
                        EndekseTabiDeg = 0;
                        EndekseTabiAmortismanDeg = 0;
                        CariYilTotalDeg = 0;
                        AylikTotalDeg = 0;
                        EndekslenmisDeg = 0;
                        EndekslenmisAmortismanDeg = 0;
                        ToplamBirikmisAmortismanDeg = 0;
                        SabitKiymetEnflasyonFarkiDeg = 0;
                        AmortismanEnflasyonFarkıDeg = 0;
                        onaltiSatirToplami = false;
                    }
                }

                #endregion

                #region Üç Satırlı

                foreach (DataRow drRapor in dsAmortisman.Hareketler)
                {
                    string ilkKodu = drRapor["SabitKiymetKodu"].ToString();

                    if (ilkKodu.Length == 3)
                    {
                        foreach (DataRow drRapor4 in dsAmortisman.Hareketler)
                        {
                            string dorduncuKodu = drRapor4["SabitKiymetKodu"].ToString();
                            string test2 = drRapor4["SabitKiymetKodu"].ToString();

                            if (test2.IndexOf(ilkKodu) != -1)
                            {
                                if (dorduncuKodu.Length == 6)
                                {
                                    foreach (DataRow drRapor5 in dsAmortisman.Hareketler)
                                    {
                                        string altinciKodu = drRapor5["SabitKiymetKodu"].ToString();

                                        if (altinciKodu.Length == 9)
                                        {
                                            foreach (DataRow drRapor6 in dsAmortisman.Hareketler)
                                            {
                                                string dokuzuncuKodu = drRapor6["SabitKiymetKodu"].ToString();

                                                if (dokuzuncuKodu.Length == 16)
                                                {
                                                    if (dokuzuncuKodu.Substring(0, 3) == ilkKodu)
                                                    {
                                                        if (onaltiSatirToplami == false)
                                                        {
                                                            iktisabDeg += Math.Round(Convert.ToDecimal(drRapor6["iktisabDegeri"].ToString()), 2);
                                                            EndekseTabiDeg += Math.Round(Convert.ToDecimal(drRapor6["EndekseTabiDeger"].ToString()), 2);
                                                            EndekseTabiAmortismanDeg += Math.Round(Convert.ToDecimal(drRapor6["EndekseTabiAmortisman"].ToString()), 2);
                                                            EndekslenmisDeg += Math.Round(Convert.ToDecimal(drRapor6["EndekslenmisDeger"].ToString()), 2);
                                                            EndekslenmisAmortismanDeg += Math.Round(Convert.ToDecimal(drRapor6["EndekslenmisAmortisman"].ToString()), 2);
                                                            KalanDegerDeg += Math.Round(Convert.ToDecimal(drRapor6["KalanDeger"].ToString()), 2);
                                                            CariYilTotalDeg += Math.Round(Convert.ToDecimal(drRapor6["CariYilAmortisman"].ToString()), 2);
                                                            AylikTotalDeg += Math.Round(Convert.ToDecimal(drRapor6["AylikAmortisman"].ToString()), 2);
                                                            ToplamBirikmisAmortismanDeg += Math.Round(Convert.ToDecimal(drRapor6["ToplamBirikmisAmortisman"].ToString()), 2);
                                                            SabitKiymetEnflasyonFarkiDeg += Math.Round(Convert.ToDecimal(drRapor6["SabitKiymetEnflasyonFarki"].ToString()), 2);
                                                            AmortismanEnflasyonFarkıDeg += Math.Round(Convert.ToDecimal(drRapor6["AmortismanEnflasyonFarki"].ToString()), 2);
                                                        }
                                                    }
                                                }
                                            }

                                            drRapor["iktisabDegeri"] = iktisabDeg;
                                            drRapor["EndekseTabiDeger"] = EndekseTabiDeg;
                                            drRapor["EndekseTabiAmortisman"] = EndekseTabiAmortismanDeg;
                                            drRapor["EndekslenmisDeger"] = EndekslenmisDeg;
                                            drRapor["EndekslenmisAmortisman"] = EndekslenmisAmortismanDeg;
                                            drRapor["CariYilAmortisman"] = CariYilTotalDeg;
                                            drRapor["AylikAmortisman"] = AylikTotalDeg;
                                            drRapor["ToplamBirikmisAmortisman"] = ToplamBirikmisAmortismanDeg;
                                            drRapor["SabitKiymetEnflasyonFarki"] = SabitKiymetEnflasyonFarkiDeg;
                                            drRapor["AmortismanEnflasyonFarki"] = AmortismanEnflasyonFarkıDeg;
                                            drRapor["KalanDeger"] = KalanDegerDeg;

                                            KalanDegerDeg = 0;
                                            iktisabDeg = 0;
                                            EndekseTabiDeg = 0;
                                            EndekseTabiAmortismanDeg = 0;
                                            CariYilTotalDeg = 0;
                                            AylikTotalDeg = 0;
                                            EndekslenmisDeg = 0;
                                            EndekslenmisAmortismanDeg = 0;
                                            ToplamBirikmisAmortismanDeg = 0;
                                            SabitKiymetEnflasyonFarkiDeg = 0;
                                            AmortismanEnflasyonFarkıDeg = 0;
                                        }
                                    }
                                }
                            }
                        }
                        onaltiSatirToplami = false;
                    }
                }

                #endregion

                #region Altı Satırlı

                foreach (DataRow drRapor in dsAmortisman.Hareketler)
                {
                    string ilkKodu = drRapor["SabitKiymetKodu"].ToString();

                    if (ilkKodu.Length == 6)
                    {
                        foreach (DataRow drRapor4 in dsAmortisman.Hareketler)
                        {
                            string dorduncuKodu = drRapor4["SabitKiymetKodu"].ToString();

                            if (dorduncuKodu.IndexOf(ilkKodu) != -1)
                            {
                                if (dorduncuKodu.Length == 9)
                                {
                                    foreach (DataRow drRapor6 in dsAmortisman.Hareketler)
                                    {
                                        string dokuzuncuKodu = drRapor6["SabitKiymetKodu"].ToString();

                                        if (dokuzuncuKodu.Length == 16)
                                        {
                                            if (dokuzuncuKodu.IndexOf(ilkKodu) != -1)
                                            {
                                                if (onaltiSatirToplami == false)
                                                {
                                                    iktisabDeg += Math.Round(Convert.ToDecimal(drRapor6["iktisabDegeri"].ToString()), 2);
                                                    EndekseTabiDeg += Math.Round(Convert.ToDecimal(drRapor6["EndekseTabiDeger"].ToString()), 2);
                                                    EndekseTabiAmortismanDeg += Math.Round(Convert.ToDecimal(drRapor6["EndekseTabiAmortisman"].ToString()), 2);
                                                    EndekslenmisDeg += Math.Round(Convert.ToDecimal(drRapor6["EndekslenmisDeger"].ToString()), 2);
                                                    EndekslenmisAmortismanDeg += Math.Round(Convert.ToDecimal(drRapor6["EndekslenmisAmortisman"].ToString()), 2);
                                                    KalanDegerDeg += Math.Round(Convert.ToDecimal(drRapor6["KalanDeger"].ToString()), 2);
                                                    CariYilTotalDeg += Math.Round(Convert.ToDecimal(drRapor6["CariYilAmortisman"].ToString()), 2);
                                                    AylikTotalDeg += Math.Round(Convert.ToDecimal(drRapor6["AylikAmortisman"].ToString()), 2);
                                                    ToplamBirikmisAmortismanDeg += Math.Round(Convert.ToDecimal(drRapor6["ToplamBirikmisAmortisman"].ToString()), 2);
                                                    SabitKiymetEnflasyonFarkiDeg += Math.Round(Convert.ToDecimal(drRapor6["SabitKiymetEnflasyonFarki"].ToString()), 2);
                                                    AmortismanEnflasyonFarkıDeg += Math.Round(Convert.ToDecimal(drRapor6["AmortismanEnflasyonFarki"].ToString()), 2);
                                                }
                                            }
                                        }
                                    }

                                }
                                if (iktisabDeg > 0)
                                {
                                    drRapor["iktisabDegeri"] = iktisabDeg;
                                    drRapor["EndekseTabiDeger"] = EndekseTabiDeg;
                                    drRapor["EndekseTabiAmortisman"] = EndekseTabiAmortismanDeg;
                                    drRapor["EndekslenmisDeger"] = EndekslenmisDeg;
                                    drRapor["EndekslenmisAmortisman"] = EndekslenmisAmortismanDeg;
                                    drRapor["CariYilAmortisman"] = CariYilTotalDeg;
                                    drRapor["AylikAmortisman"] = AylikTotalDeg;
                                    drRapor["ToplamBirikmisAmortisman"] = ToplamBirikmisAmortismanDeg;
                                    drRapor["SabitKiymetEnflasyonFarki"] = SabitKiymetEnflasyonFarkiDeg;
                                    drRapor["AmortismanEnflasyonFarki"] = AmortismanEnflasyonFarkıDeg;
                                    drRapor["KalanDeger"] = KalanDegerDeg;

                                    KalanDegerDeg = 0;
                                    iktisabDeg = 0;
                                    EndekseTabiDeg = 0;
                                    EndekseTabiAmortismanDeg = 0;
                                    CariYilTotalDeg = 0;
                                    AylikTotalDeg = 0;
                                    EndekslenmisDeg = 0;
                                    EndekslenmisAmortismanDeg = 0;
                                    ToplamBirikmisAmortismanDeg = 0;
                                    SabitKiymetEnflasyonFarkiDeg = 0;
                                    AmortismanEnflasyonFarkıDeg = 0;
                                }
                            }
                        }
                    }
                    onaltiSatirToplami = false;
                }

                #endregion

                #region Dokuz Satırlı

                foreach (DataRow drRapor in dsAmortisman.Hareketler)
                {
                    string ilkKodu = drRapor["SabitKiymetKodu"].ToString();

                    if (ilkKodu.Length == 9)
                    {
                        foreach (DataRow drRapor4 in dsAmortisman.Hareketler)
                        {
                            string dorduncuKodu = drRapor4["SabitKiymetKodu"].ToString();

                            if (dorduncuKodu.Length == 16)
                            {
                                if (dorduncuKodu.IndexOf(ilkKodu) != -1)
                                {
                                    if (onaltiSatirToplami == false)
                                    {
                                        iktisabDeg += Math.Round(Convert.ToDecimal(drRapor4["iktisabDegeri"].ToString()), 2);
                                        EndekseTabiDeg += Math.Round(Convert.ToDecimal(drRapor4["EndekseTabiDeger"].ToString()), 2);
                                        EndekseTabiAmortismanDeg += Math.Round(Convert.ToDecimal(drRapor4["EndekseTabiAmortisman"].ToString()), 2);
                                        EndekslenmisDeg += Math.Round(Convert.ToDecimal(drRapor4["EndekslenmisDeger"].ToString()), 2);
                                        EndekslenmisAmortismanDeg += Math.Round(Convert.ToDecimal(drRapor4["EndekslenmisAmortisman"].ToString()), 2);
                                        KalanDegerDeg += Math.Round(Convert.ToDecimal(drRapor4["KalanDeger"].ToString()), 2);
                                        CariYilTotalDeg += Math.Round(Convert.ToDecimal(drRapor4["CariYilAmortisman"].ToString()), 2);
                                        AylikTotalDeg += Math.Round(Convert.ToDecimal(drRapor4["AylikAmortisman"].ToString()), 2);
                                        ToplamBirikmisAmortismanDeg += Math.Round(Convert.ToDecimal(drRapor4["ToplamBirikmisAmortisman"].ToString()), 2);
                                        SabitKiymetEnflasyonFarkiDeg += Math.Round(Convert.ToDecimal(drRapor4["SabitKiymetEnflasyonFarki"].ToString()), 2);
                                        AmortismanEnflasyonFarkıDeg += Math.Round(Convert.ToDecimal(drRapor4["AmortismanEnflasyonFarki"].ToString()), 2);
                                    }
                                }
                            }
                        }
                        drRapor["iktisabDegeri"] = iktisabDeg;
                        drRapor["EndekseTabiDeger"] = EndekseTabiDeg;
                        drRapor["EndekseTabiAmortisman"] = EndekseTabiAmortismanDeg;
                        drRapor["EndekslenmisDeger"] = EndekslenmisDeg;
                        drRapor["EndekslenmisAmortisman"] = EndekslenmisAmortismanDeg;
                        drRapor["CariYilAmortisman"] = CariYilTotalDeg;
                        drRapor["AylikAmortisman"] = AylikTotalDeg;
                        drRapor["ToplamBirikmisAmortisman"] = ToplamBirikmisAmortismanDeg;
                        drRapor["SabitKiymetEnflasyonFarki"] = SabitKiymetEnflasyonFarkiDeg;
                        drRapor["AmortismanEnflasyonFarki"] = AmortismanEnflasyonFarkıDeg;
                        drRapor["KalanDeger"] = KalanDegerDeg;

                        KalanDegerDeg = 0;
                        iktisabDeg = 0;
                        EndekseTabiDeg = 0;
                        EndekseTabiAmortismanDeg = 0;
                        CariYilTotalDeg = 0;
                        AylikTotalDeg = 0;
                        EndekslenmisDeg = 0;
                        EndekslenmisAmortismanDeg = 0;
                        ToplamBirikmisAmortismanDeg = 0;
                        SabitKiymetEnflasyonFarkiDeg = 0;
                        AmortismanEnflasyonFarkıDeg = 0;
                    }
                    onaltiSatirToplami = false;
                }

                #endregion

                #region On Üç Satırlı

                foreach (DataRow drRapor in dsAmortisman.Hareketler)
                {
                    string ilkKodu = drRapor["SabitKiymetKodu"].ToString();

                    if (ilkKodu.Length == 13)
                    {
                        foreach (DataRow drRapor4 in dsAmortisman.Hareketler)
                        {
                            string dorduncuKodu = drRapor4["SabitKiymetKodu"].ToString();

                            if (dorduncuKodu.Length == 16)
                            {
                                if (dorduncuKodu.IndexOf(ilkKodu) != -1)
                                {
                                    if (onaltiSatirToplami == false)
                                    {
                                        iktisabDeg += Math.Round(Convert.ToDecimal(drRapor4["iktisabDegeri"].ToString()), 2);
                                        EndekseTabiDeg += Math.Round(Convert.ToDecimal(drRapor4["EndekseTabiDeger"].ToString()), 2);
                                        EndekseTabiAmortismanDeg += Math.Round(Convert.ToDecimal(drRapor4["EndekseTabiAmortisman"].ToString()), 2);
                                        EndekslenmisDeg += Math.Round(Convert.ToDecimal(drRapor4["EndekslenmisDeger"].ToString()), 2);
                                        EndekslenmisAmortismanDeg += Math.Round(Convert.ToDecimal(drRapor4["EndekslenmisAmortisman"].ToString()), 2);
                                        KalanDegerDeg += Math.Round(Convert.ToDecimal(drRapor4["KalanDeger"].ToString()), 2);
                                        CariYilTotalDeg += Math.Round(Convert.ToDecimal(drRapor4["CariYilAmortisman"].ToString()), 2);
                                        AylikTotalDeg += Math.Round(Convert.ToDecimal(drRapor4["AylikAmortisman"].ToString()), 2);
                                        ToplamBirikmisAmortismanDeg += Math.Round(Convert.ToDecimal(drRapor4["ToplamBirikmisAmortisman"].ToString()), 2);
                                        SabitKiymetEnflasyonFarkiDeg += Math.Round(Convert.ToDecimal(drRapor4["SabitKiymetEnflasyonFarki"].ToString()), 2);
                                        AmortismanEnflasyonFarkıDeg += Math.Round(Convert.ToDecimal(drRapor4["AmortismanEnflasyonFarki"].ToString()), 2);

                                        AmortismanHesabi = "";
                                        GiderHesabi = "";
                                        MuhasebeHesabi = "";

                                        AmortismanHesabi = drRapor4["AmortismanHesabi"].ToString();
                                        GiderHesabi = drRapor4["GiderHesabi"].ToString();
                                        MuhasebeHesabi = drRapor4["MuhasebeHesabi"].ToString();
                                    }
                                }
                            }
                        }
                        drRapor["iktisabDegeri"] = iktisabDeg;
                        drRapor["EndekseTabiDeger"] = EndekseTabiDeg;
                        drRapor["EndekseTabiAmortisman"] = EndekseTabiAmortismanDeg;
                        drRapor["EndekslenmisDeger"] = EndekslenmisDeg;
                        drRapor["EndekslenmisAmortisman"] = EndekslenmisAmortismanDeg;
                        drRapor["CariYilAmortisman"] = CariYilTotalDeg;
                        drRapor["AylikAmortisman"] = AylikTotalDeg;
                        drRapor["ToplamBirikmisAmortisman"] = ToplamBirikmisAmortismanDeg;
                        drRapor["SabitKiymetEnflasyonFarki"] = SabitKiymetEnflasyonFarkiDeg;
                        drRapor["AmortismanEnflasyonFarki"] = AmortismanEnflasyonFarkıDeg;
                        drRapor["KalanDeger"] = KalanDegerDeg;

                        drRapor["AmortismanHesabi"] = AmortismanHesabi;
                        drRapor["GiderHesabi"] = GiderHesabi;
                        drRapor["MuhasebeHesabi"] = MuhasebeHesabi;

                        KalanDegerDeg = 0;
                        iktisabDeg = 0;
                        EndekseTabiDeg = 0;
                        EndekseTabiAmortismanDeg = 0;
                        CariYilTotalDeg = 0;
                        AylikTotalDeg = 0;
                        EndekslenmisDeg = 0;
                        EndekslenmisAmortismanDeg = 0;
                        ToplamBirikmisAmortismanDeg = 0;
                        SabitKiymetEnflasyonFarkiDeg = 0;
                        AmortismanEnflasyonFarkıDeg = 0;
                    }
                    onaltiSatirToplami = false;
                }

                #endregion

                decimal GenelIktisabToplami = 0;
                decimal GenelEndekseTabiDegerToplami = 0;
                decimal GenelEndekseTabiAmortismanToplami = 0;
                decimal GenelEndekslenmisDegerToplami = 0;
                decimal GenelEndekslenmisAmortismanToplamiToplami = 0;
                decimal GenelKalanDegerToplami = 0;
                decimal GenelCariYilAmortismanToplami = 0;
                decimal GenelAylikAmortismanToplami = 0;
                decimal GenelToplamBirikmisAmortismanToplami = 0;
                decimal GenelSabitKiymetEnflasyonFarkiToplami = 0;
                decimal GenelAmortismanEnflasyonFarkiToplami = 0;

                GenelIktisabToplami = this.dsAmortisman.Hareketler.Where(f => f.SabitKiymetKodu.Length > 13).Sum(p => p.iktisabDegeri);
                GenelEndekseTabiDegerToplami = this.dsAmortisman.Hareketler.Where(f => f.SabitKiymetKodu.Length > 13).Sum(p => p.EndekseTabiDeger);
                GenelEndekseTabiAmortismanToplami = this.dsAmortisman.Hareketler.Where(f => f.SabitKiymetKodu.Length > 13).Sum(p => p.EndekseTabiAmortisman);
                GenelEndekslenmisDegerToplami = this.dsAmortisman.Hareketler.Where(f => f.SabitKiymetKodu.Length > 13).Sum(p => p.EndekslenmisDeger);
                GenelEndekslenmisAmortismanToplamiToplami = this.dsAmortisman.Hareketler.Where(f => f.SabitKiymetKodu.Length > 13).Sum(p => p.EndekslenmisAmortisman);
                GenelKalanDegerToplami = this.dsAmortisman.Hareketler.Where(f => f.SabitKiymetKodu.Length > 13).Sum(p => p.KalanDeger);
                GenelCariYilAmortismanToplami = this.dsAmortisman.Hareketler.Where(f => f.SabitKiymetKodu.Length > 13).Sum(p => p.CariYilAmortisman);
                GenelAylikAmortismanToplami = this.dsAmortisman.Hareketler.Where(f => f.SabitKiymetKodu.Length > 13).Sum(p => p.AylikAmortisman);
                GenelToplamBirikmisAmortismanToplami = this.dsAmortisman.Hareketler.Where(f => f.SabitKiymetKodu.Length > 13).Sum(p => p.ToplamBirikmisAmortisman);
                GenelSabitKiymetEnflasyonFarkiToplami = this.dsAmortisman.Hareketler.Where(f => f.SabitKiymetKodu.Length > 13).Sum(p => p.SabitKiymetEnflasyonFarki);
                GenelAmortismanEnflasyonFarkiToplami = this.dsAmortisman.Hareketler.Where(f => f.SabitKiymetKodu.Length > 13).Sum(p => p.AmortismanEnflasyonFarki);

                this.dsAmortisman.Hareketler.AddHareketlerRow("GENEL TOPLAM", " ", "-", "-", "-",
                                            0, 0, 0, 0, 0, GenelIktisabToplami, GenelEndekseTabiDegerToplami, GenelEndekseTabiAmortismanToplami,
                                            0, GenelEndekslenmisDegerToplami, GenelEndekslenmisAmortismanToplamiToplami, GenelKalanDegerToplami,
                                            GenelCariYilAmortismanToplami, GenelAylikAmortismanToplami, GenelToplamBirikmisAmortismanToplami,
                                            GenelSabitKiymetEnflasyonFarkiToplami, GenelAmortismanEnflasyonFarkiToplami, "", 0);

                btnKayitlariAktar.Enabled = true;
                btnDemirbaslariGetir.Enabled = true;
                btnExceleAktar.Enabled = true;
                btnTemizle.Enabled = true;
                chkEnflasyon.Enabled = true;
            })
                .ContinueWith((Kanal2) =>
                {

                    string ToplamKayitSayisi = Convert.ToString(dsAmortisman.Hareketler.Rows.Count);

                    MessageBox.Show("Toplam " + ToplamKayitSayisi + " Demirbaş Kaydı Bulunmuştur.");
                });
        }

        private void AmortismanHesaplama_FormClosing(object sender, FormClosingEventArgs e)
        {
            AmortismanHesaplama amortHesapla = new AmortismanHesaplama();
            amortHesapla.Close();

            if (Sorgula != null)
            {
                Sorgula.Abort();
            }
        }

        private void KayitFarklariBuluyoruz(string DemirbasKodu, int Tarih)
        {
            if (Conn.State == ConnectionState.Closed)
                Conn.Open();

            string sorgu = @"SELECT DEM008_DemKodu AS SabitKiymetKodu,DEM008_MaliyetDegeri AS MaliyetDegeri,
                    DEM008_BirikAmortisman AS BirikmisAmortisman,DEM008_CarYilAmort AS AylikAmortisman,
                    DEM008_ReelGiderTutari AS CariYilAmortisman,DEM008_DemGirDate AS GirisTarihi
                    FROM DEM008
                    WHERE DEM008_DemKodu='" + DemirbasKodu + "' AND DEM008_DemGirDate=" + Tarih + "";

            SqlCommand cmdFark = new SqlCommand(sorgu, Conn);
            SqlDataReader drFark = cmdFark.ExecuteReader(CommandBehavior.CloseConnection);

            if (drFark.Read())
            {
                this.dsAmortisman.KayitFarklari.AddKayitFarklariRow(drFark["SabitKiymetKodu"].ToString(), Convert.ToDecimal(drFark["MaliyetDegeri"].ToString()),
                    Convert.ToDecimal(drFark["BirikmisAmortisman"].ToString()), Convert.ToDecimal(drFark["AylikAmortisman"].ToString()),
                    Convert.ToDecimal(drFark["CariYilAmortisman"].ToString()), Convert.ToInt32(drFark["GirisTarihi"].ToString()));
            }

            drFark.Dispose();
            drFark.Close();
        }

        private void btnHazirlamaEkrani_Click(object sender, EventArgs e)
        {
            pnNormal.Dock = DockStyle.Top;
            pnKontrol.Dock = DockStyle.Fill;
            gridAmortismanlar.Visible = true;
            pnKontrol.Visible = false;

            dsAmortisman.AktarimHareketleri.Clear();
        }

        private void btnKontrolKayitAktar_Click(object sender, EventArgs e)
        {
            btnKontrolKayitAktar.Enabled = false;
            btnHazirlamaEkrani.Enabled = false;
            string PcAdiDemKart = "";
            int AktarilanKayitSayisi = 0;
            int MuhasebeDurumu = 0;

            KanalAktar = Task.Factory.StartNew(() =>
            {
                foreach (DataRow dr in dsAmortisman.AktarimHareketleri.Rows)
                {
                    int BaslangicYili = Convert.ToInt32(dr["BaslangicYili"].ToString());
                    int BaslangicAyi = Convert.ToInt32(dr["BaslangicAyi"].ToString());
                    int BitisYili = Convert.ToInt32(dr["BitisYili"].ToString());
                    int BitisAyi = Convert.ToInt32(dr["BitisAyi"].ToString());

                    int DonemYil = 0;

                    if (string.IsNullOrEmpty(txtDonemYili.Text))
                    {
                        DonemYil = Convert.ToInt32(DateTime.Now.Year);
                    }
                    else
                    {
                        DonemYil = Convert.ToInt32(txtDonemYili.Text);
                    }

                    string DemirbasKodu = dr["SabitKiymetKodu"].ToString();
                    int IslemYili = Convert.ToInt32(txtDonemYili.Text);
                    string DonemAyimiz = cmbDonemAyi.SelectedItem.ToString();
                    int DonemAyi = Convert.ToInt32(DonemZamani(DonemAyimiz));

                    double Tarih = 0;
                    int TarihRakam = 0;
                    double DegTarih = 0;
                    int TarihDeg = 0;

                    string EskiDemirbasTarih = AylarinSonGunu(AylarinTarihi2(cmbDonemAyi.Text.ToString())) + "." + AylarinTarihi2(cmbDonemAyi.Text.ToString()) + "." + txtDonemYili.Text;

                    DateTime obj = new DateTime();
                    obj = Convert.ToDateTime(EskiDemirbasTarih);
                    string str;
                    Tarih = 0;
                    Tarih = obj.ToOADate();
                    str = Tarih.ToString().Substring(0, 5);
                    TarihRakam = Convert.ToInt32(str);

                    DateTime obj2 = new DateTime();
                    obj2 = Convert.ToDateTime(DateTime.Now);
                    string str2;
                    DegTarih = 0;
                    DegTarih = obj2.ToOADate();
                    str2 = DegTarih.ToString().Substring(0, 5);
                    TarihDeg = Convert.ToInt32(str2);

                    DateTime DtSaat = DateTime.Now;
                    string Saatimiz = Convert.ToString(DtSaat);
                    int saatuzunluk = Saatimiz.ToString().Length;

                    if (saatuzunluk == 18)
                    {
                        Saatimiz = Saatimiz.ToString().Substring(10, 8);
                    }
                    else if (saatuzunluk == 19)
                    {
                        Saatimiz = Saatimiz.ToString().Substring(11, 8);
                    }
                    else if (saatuzunluk == 17)
                    {
                        Saatimiz = Saatimiz.ToString().Substring(9, 8);
                    }
                    Saatimiz = Saatimiz.ToString().Replace(":", "");

                    if (Saatimiz.ToString().Length > 8)
                    {
                        Saatimiz = Saatimiz.ToString().Substring(0, 8);
                    }

                    string PcAdi = Environment.UserName.ToString();
                    PcAdiDemKart = PcAdi;

                    if (PcAdi.ToString().Length > 10)
                    {
                        PcAdi = PcAdi.ToString().Substring(0, 10);
                        PcAdiDemKart = PcAdi;
                    }

                    int KontrolMiktari = Convert.ToInt32(dr["Miktar"].ToString());

                    if (chkEnflasyon.Checked == false)
                    {
                        #region Checked False Ve Farklar ile Yeni Kayıt Yeri

                        decimal AylikAmortismanFarki = Convert.ToDecimal(dr["AylikAmortismanFarki"].ToString());
                        int AktarimKontrol = Convert.ToInt32(this.sqlQueryler1.AktarimKontrol(DemirbasKodu, TarihRakam));

                        if (AylikAmortismanFarki != 0)
                        {
                            if (AktarimKontrol == 0)
                            {
                                decimal AmortismanOrani = Convert.ToDecimal(dr["AmortismanOrani"].ToString());
                                decimal MaliyetDegeri = Convert.ToDecimal(dr["EndekseTabiDeger"].ToString());
                                decimal BirikenAmortisman = Convert.ToDecimal(dr["EndekslenmisAmortisman"].ToString());
                                decimal CariYilAmortisman = Convert.ToDecimal(dr["CariYilAmortisman"].ToString());
                                decimal AylAmortisman = Convert.ToDecimal(dr["AylikAmortisman"].ToString());
                                decimal TotalAmorti = Convert.ToDecimal(dr["ToplamBirikmisAmortisman"].ToString());
                                int AktarimDonemAyi = Convert.ToInt32(dr["AktarimAyi"].ToString());

                                AmortismanOrani = Math.Round(AmortismanOrani, 2);
                                MaliyetDegeri = Math.Round(MaliyetDegeri, 2);
                                BirikenAmortisman = Math.Round(BirikenAmortisman, 2);
                                CariYilAmortisman = Math.Round(CariYilAmortisman, 2);
                                AylAmortisman = Math.Round(AylAmortisman, 2);

                                this.sqlQueryler1.DemHareket(DemirbasKodu, IslemYili, Convert.ToInt16(DonemAyi), 
                                    AmortismanOrani, MaliyetDegeri, BirikenAmortisman, AylAmortisman,
                                    TarihRakam, Saatimiz, PcAdi, CariYilAmortisman, AktarimDonemAyi);

                                PcAdiDemKart = PcAdiDemKart.ToString().Substring(0, 5);

                                string SonIslemAyimiz = cmbDonemAyi.Text.ToString();

                                if (AktarimDonemAyi == 12)
                                {
                                    if (dr["Durumu"].ToString() == "KALAN")
                                    {
                                        this.sqlQueryler1.EndekseTabiAmortismanGuncelle(TotalAmorti, dr["SabitKiymetKodu"].ToString());
                                    }
                                    else if (dr["Durumu"].ToString() == "")
                                    {
                                        this.sqlQueryler1.AralikAyiDemirbasKartiUpdate(TotalAmorti, dr["SabitKiymetKodu"].ToString());
                                    }
                                }

                                this.sqlQueryler1.DemirbasKartNUpdate(TarihDeg, Saatimiz, PcAdiDemKart, TotalAmorti, IslemYili, Convert.ToInt16(DonemAyi),
                                    IslemYili - 1, AylAmortisman, BirikenAmortisman, MaliyetDegeri, DemirbasKodu);
                            }
                            else
                            {
                                decimal AmortismanOrani = Convert.ToDecimal(dr["AmortismanOrani"].ToString());
                                decimal MaliyetDegeriFarki = Convert.ToDecimal(dr["MaliyetDegeriFarki"].ToString());
                                decimal BirikenAmortismanFarki = Convert.ToDecimal(dr["BirikmisAmortismanFarki"].ToString());
                                decimal CariYilAmortismanFarki = Convert.ToDecimal(dr["CariYilAmortismanFarki"].ToString());
                                decimal AylAmortismanFarki = Convert.ToDecimal(dr["AylikAmortismanFarki"].ToString());
                                decimal TotalAmorti = Convert.ToDecimal(dr["ToplamBirikmisAmortisman"].ToString());
                                int AktarimDonemAyi = Convert.ToInt32(dr["AktarimAyi"].ToString());

                                AmortismanOrani = Math.Round(AmortismanOrani, 2);
                                MaliyetDegeriFarki = Math.Round(MaliyetDegeriFarki, 2);
                                BirikenAmortismanFarki = Math.Round(BirikenAmortismanFarki, 2);
                                CariYilAmortismanFarki = Math.Round(CariYilAmortismanFarki, 2);
                                AylAmortismanFarki = Math.Round(AylAmortismanFarki, 2);

                                if (chkMuhasebeDurumu.Checked == true)
                                {
                                    MuhasebeDurumu = 1;
                                }

                                if (MuhasebeDurumu == 0)
                                {
                                    this.sqlQueryler1.DemirbasHareketiSatiriGuncelleFisYok(MaliyetDegeriFarki, BirikenAmortismanFarki, AylAmortismanFarki,
                                        TarihRakam, Saatimiz, PcAdi, CariYilAmortismanFarki, DemirbasKodu);
                                }
                                else
                                {
                                    this.sqlQueryler1.DemirbasHareketiSatiriGuncelleFisVar(MaliyetDegeriFarki, BirikenAmortismanFarki, AylAmortismanFarki,
                                        TarihRakam, Saatimiz, PcAdi, CariYilAmortismanFarki, 0, DemirbasKodu);
                                }

                                PcAdiDemKart = PcAdiDemKart.ToString().Substring(0, 5);

                                string SonIslemAyimiz = cmbDonemAyi.Text.ToString();

                                if (AktarimDonemAyi == 12)
                                {
                                    if (dr["Durumu"].ToString() == "KALAN")
                                    {
                                        this.sqlQueryler1.EndekseTabiAmortismanGuncelle(TotalAmorti, dr["SabitKiymetKodu"].ToString());
                                    }
                                    else if (dr["Durumu"].ToString() == "")
                                    {
                                        this.sqlQueryler1.AralikAyiDemirbasKartiUpdate(TotalAmorti, dr["SabitKiymetKodu"].ToString());
                                    }
                                }

                                this.sqlQueryler1.DemirbasKartiFarkGuncelleme(TarihDeg, Saatimiz, PcAdiDemKart, TotalAmorti, IslemYili, Convert.ToInt16(DonemAyi),
                                    IslemYili - 1, AylAmortismanFarki, BirikenAmortismanFarki, MaliyetDegeriFarki, DemirbasKodu);
                            }

                            AktarilanKayitSayisi++;
                        }

                        #endregion
                    }
                    else
                    {
                        decimal AylikAmortismanFarki = Convert.ToDecimal(dr["AylikAmortismanFarki"].ToString());
                        int AktarimKontrol = Convert.ToInt32(this.sqlQueryler1.AktarimKontrol(DemirbasKodu, TarihRakam));

                        if (AylikAmortismanFarki != 0)
                        {
                            #region Amortisman Farkı O değilse işlemi

                            if (BitisYili >= DonemYil && BaslangicYili <= DonemYil && KontrolMiktari > 0)
                            {
                                if (AktarimKontrol == 0)
                                {
                                    decimal AmortismanOrani = Convert.ToDecimal(dr["AmortismanOrani"].ToString());
                                    decimal MaliyetDegeri = Convert.ToDecimal(dr["EndekseTabiDeger"].ToString());
                                    decimal BirikenAmortisman = Convert.ToDecimal(dr["EndekseTabiAmortisman"].ToString());
                                    decimal CariYilAmortisman = Convert.ToDecimal(dr["CariYilAmortisman"].ToString());
                                    decimal AylAmortisman = Convert.ToDecimal(dr["AylikAmortisman"].ToString());
                                    int AktarimDonemAyi = Convert.ToInt32(dr["AktarimAyi"].ToString());

                                    decimal EndekslenmisDeger = Convert.ToDecimal(dr["EndekslenmisDeger"].ToString());
                                    decimal EndekslenmisAmortisman = Convert.ToDecimal(dr["EndekslenmisAmortisman"].ToString());

                                    AmortismanOrani = Math.Round(AmortismanOrani, 2);
                                    MaliyetDegeri = Math.Round(MaliyetDegeri, 2);
                                    BirikenAmortisman = Math.Round(BirikenAmortisman, 2);
                                    CariYilAmortisman = Math.Round(CariYilAmortisman, 2);
                                    EndekslenmisDeger = Math.Round(EndekslenmisDeger, 2);
                                    EndekslenmisAmortisman = Math.Round(EndekslenmisAmortisman, 2);
                                    AylAmortisman = Math.Round(AylAmortisman, 2);

                                    this.sqlQueryler1.DemHareket(DemirbasKodu, IslemYili, Convert.ToInt16(DonemAyi), AmortismanOrani, MaliyetDegeri, BirikenAmortisman, AylAmortisman,
                                        TarihRakam, Saatimiz, PcAdi, CariYilAmortisman, AktarimDonemAyi);

                                    PcAdiDemKart = PcAdiDemKart.ToString().Substring(0, 5);
                                    string SonIslemAyimiz = cmbDonemAyi.Text.ToString();

                                    if (AktarimDonemAyi == 12)
                                    {
                                        if (dr["Durumu"].ToString() == "KALAN")
                                        {
                                            this.sqlQueryler1.EndekseTabiAmortismanGuncelle(BirikenAmortisman, dr["SabitKiymetKodu"].ToString());
                                        }
                                        else if (dr["Durumu"].ToString() == "")
                                        {
                                            this.sqlQueryler1.AralikAyiDemirbasKartiUpdate(BirikenAmortisman, dr["SabitKiymetKodu"].ToString());
                                        }
                                    }

                                    this.sqlQueryler1.EnflasyonaGöreDemirbasGuncelleme(TarihDeg, Saatimiz, PcAdi, EndekslenmisAmortisman,
                                        AylAmortisman, IslemYili, Convert.ToInt16(DonemAyi), IslemYili - 1, EndekslenmisDeger, DemirbasKodu);

                                }
                                else
                                {
                                    decimal AmortismanOrani = Convert.ToDecimal(dr["AmortismanOrani"].ToString());
                                    decimal MaliyetDegeri = Convert.ToDecimal(dr["EndekseTabiDeger"].ToString());
                                    decimal MaliyetDegeriFarki = Convert.ToDecimal(dr["MaliyetDegeriFarki"].ToString());
                                    decimal BirikenAmortisman = Convert.ToDecimal(dr["EndekseTabiAmortisman"].ToString());
                                    decimal BirikenAmortismanFarki = Convert.ToDecimal(dr["BirikmisAmortismanFarki"].ToString());
                                    decimal CariYilAmortisman = Convert.ToDecimal(dr["CariYilAmortisman"].ToString());
                                    decimal CariYilAmortismanFarki = Convert.ToDecimal(dr["CariYilAmortismanFarki"].ToString());
                                    decimal AylAmortismanFarki = Convert.ToDecimal(dr["AylikAmortismanFarki"].ToString());

                                    decimal EndekslenmisDeger = Convert.ToDecimal(dr["EndekslenmisDeger"].ToString());
                                    decimal EndekslenmisAmortisman = Convert.ToDecimal(dr["EndekslenmisAmortisman"].ToString());

                                    AmortismanOrani = Math.Round(AmortismanOrani, 2);
                                    MaliyetDegeri = Math.Round(MaliyetDegeri, 2);
                                    BirikenAmortisman = Math.Round(BirikenAmortisman, 2);
                                    CariYilAmortisman = Math.Round(CariYilAmortisman, 2);
                                    EndekslenmisDeger = Math.Round(EndekslenmisDeger, 2);
                                    EndekslenmisAmortisman = Math.Round(EndekslenmisAmortisman, 2);

                                    MaliyetDegeriFarki = Math.Round(MaliyetDegeriFarki, 2);
                                    BirikenAmortismanFarki = Math.Round(BirikenAmortismanFarki, 2);
                                    CariYilAmortismanFarki = Math.Round(CariYilAmortismanFarki, 2);
                                    AylAmortismanFarki = Math.Round(AylAmortismanFarki, 2);

                                    int AktarimDonemAyi = Convert.ToInt32(dr["AktarimAyi"].ToString());

                                    if (chkMuhasebeDurumu.Checked == true)
                                    {
                                        MuhasebeDurumu = 1;
                                    }

                                    if (MuhasebeDurumu == 0)
                                    {
                                        this.sqlQueryler1.DemirbasHareketiSatiriGuncelleFisYok(MaliyetDegeriFarki, BirikenAmortismanFarki, AylAmortismanFarki,
                                            TarihRakam, Saatimiz, PcAdi, CariYilAmortismanFarki, DemirbasKodu);
                                    }
                                    else
                                    {
                                        this.sqlQueryler1.DemirbasHareketiSatiriGuncelleFisVar(MaliyetDegeriFarki, BirikenAmortismanFarki, AylAmortismanFarki,
                                            TarihRakam, Saatimiz, PcAdi, CariYilAmortismanFarki, 0, DemirbasKodu);
                                    }

                                    PcAdiDemKart = PcAdiDemKart.ToString().Substring(0, 5);
                                    string SonIslemAyimiz = cmbDonemAyi.Text.ToString();

                                    if (AktarimDonemAyi == 12)
                                    {
                                        if (dr["Durumu"].ToString() == "KALAN")
                                        {
                                            this.sqlQueryler1.EndekseTabiAmortismanGuncelle(BirikenAmortisman, dr["SabitKiymetKodu"].ToString());
                                        }
                                        else if (dr["Durumu"].ToString() == "")
                                        {
                                            this.sqlQueryler1.AralikAyiDemirbasKartiUpdate(BirikenAmortisman, dr["SabitKiymetKodu"].ToString());
                                        }
                                    }

                                    this.sqlQueryler1.EnflasyonaGoreDemirbasKartiFarkGuncelleme(TarihDeg, Saatimiz, PcAdi, EndekslenmisAmortisman,
                                    AylAmortismanFarki, IslemYili, Convert.ToInt16(DonemAyi), IslemYili - 1, EndekslenmisDeger, DemirbasKodu);
                                }

                                AktarilanKayitSayisi++;
                            }
                            else
                            {
                                decimal AmortismanOrani = Convert.ToDecimal(dr["AmortismanOrani"].ToString());
                                decimal MaliyetDegeri = Convert.ToDecimal(dr["EndekseTabiDeger"].ToString());
                                decimal BirikenAmortisman = Convert.ToDecimal(dr["EndekseTabiAmortisman"].ToString());
                                decimal CariYilAmortisman = Convert.ToDecimal(dr["CariYilAmortisman"].ToString());
                                decimal AylAmortisman = Convert.ToDecimal(dr["AylikAmortisman"].ToString());

                                decimal EndekslenmisDeger = Convert.ToDecimal(dr["EndekslenmisDeger"].ToString());
                                decimal EndekslenmisAmortisman = Convert.ToDecimal(dr["EndekslenmisAmortisman"].ToString());

                                int AktarimDonemAyi = Convert.ToInt32(dr["AktarimAyi"].ToString());

                                AmortismanOrani = Math.Round(AmortismanOrani, 2);
                                MaliyetDegeri = Math.Round(MaliyetDegeri, 2);
                                BirikenAmortisman = Math.Round(BirikenAmortisman, 2);
                                CariYilAmortisman = Math.Round(CariYilAmortisman, 2);
                                EndekslenmisDeger = Math.Round(EndekslenmisDeger, 2);
                                EndekslenmisAmortisman = Math.Round(EndekslenmisAmortisman, 2);

                                PcAdiDemKart = PcAdiDemKart.ToString().Substring(0, 5);
                                string SonIslemAyimiz = cmbDonemAyi.Text.ToString();

                                if (AktarimDonemAyi == 12)
                                {
                                    if (dr["Durumu"].ToString() == "KALAN")
                                    {
                                        this.sqlQueryler1.EndekseTabiAmortismanGuncelle(BirikenAmortisman, dr["SabitKiymetKodu"].ToString());
                                    }
                                }

                                this.sqlQueryler1.EnflasyonaGoreBitenDemirbasGuncelleme(TarihDeg, Saatimiz, PcAdi, EndekslenmisAmortisman, EndekslenmisDeger, DemirbasKodu);
                            }

                            AktarilanKayitSayisi++;

                            #endregion
                        }
                    }
                }
            })
                .ContinueWith((Kanal3) =>
                {
                    MessageBox.Show("Aktarılan Toplam Kayıt Sayisi " + Convert.ToString(AktarilanKayitSayisi) + " Adettir");

                    dsAmortisman.AktarimHareketleri.Clear();
                    btnHazirlamaEkrani.Enabled = true;
                });
        }
    }
}
