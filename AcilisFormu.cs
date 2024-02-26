using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
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
    public partial class AcilisFormu : Form
    {
        public AcilisFormu()
        {
            InitializeComponent();
        }

        OleDbDataAdapter da;
        Thread kanal;
        int DemirbasDurumu;
        decimal KdvTutari, AmortismanOrani, AlimMiktari, EndeksTabiDeger;
        int AlimTarihi, GirisTarihi, BitisTarihi, EkonomikOmur;
        string GirenKodu, Saatimiz, iktisapDeger, EndeksTabiAmortisman, DemirbasKodu, DemirbasAdi, KdvTutar;
        double TarihAlim, TarihBitis, TarihGiris;

        public AnaForm anaFrm
        {
            get;
            set;
        }

        private void btnBelgeSec_Click(object sender, EventArgs e)
        {
            belgeSec.Title = "Kaynak Dosyayı Seçiniz";
            belgeSec.FileName = "Kaynak dosya";
            belgeSec.Filter = "Excel dosyaları |*.xls";
            belgeSec.InitialDirectory = Application.ExecutablePath.ToString();
            belgeSec.FilterIndex = 1;
            belgeSec.RestoreDirectory = true;

            if (belgeSec.ShowDialog() == DialogResult.OK)
            {
                string belgeYolu = belgeSec.FileName;
                txtDizin.Text = belgeYolu;
                pb.Text = "0";
            }
        }

        private Boolean fnkBelgeyiTabloyaYukle(string belgeTamYolu)
        {
            string baglantiYolu = "";

            try
            {
                baglantiYolu = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + belgeTamYolu + ";Extended Properties='Excel 8.0'";
                OleDbConnection baglanti = new OleDbConnection(baglantiYolu);
                baglanti.Open();
                string sorgu = "SELECT * FROM [Amortisman$]";
                da = new OleDbDataAdapter(sorgu, baglanti);
                da.Fill(dsAmortisman.geciciTablo);

                pb.Properties.Minimum = 0;
                pb.Properties.Maximum = dsAmortisman.geciciTablo.Count();
                baglanti.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void fnkHazirla()
        {
            //dsAmortisman.geciciTablo.Clear();
            pb.Text = "0";
            if (File.Exists(txtDizin.Text))
            {
                if (fnkBelgeyiTabloyaYukle(txtDizin.Text))
                {
                    for (int i = 0; i < dsAmortisman.geciciTablo.Count; i++)
                    {
                        pb.PerformStep();
                        pb.Update();
                    }
                }
            }
            else
            {
                MessageBox.Show("Dosya Bulunamadı");
            }
        }

        private void fnkSQLeTopluKopyala()
        {
            try
            {
                SqlBulkCopy SQLTopluKopyala = new SqlBulkCopy(Properties.Settings.Default.DbConn);
                SQLTopluKopyala.BatchSize = 1000;
                SQLTopluKopyala.NotifyAfter = 1;
                SQLTopluKopyala.BulkCopyTimeout = 60;
                SQLTopluKopyala.DestinationTableName = "DEM002";

                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemKodu", "DEM002_DemKodu");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemAdi", "DEM002_DemAdi");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_OzelKodu", "DEM002_OzelKodu");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_IsyeriKodu", "DEM002_IsyeriKodu");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_BolumKodu", "DEM002_BolumKodu");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_AmortSekli", "DEM002_AmortSekli");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_AmortOrani", "DEM002_AmortOrani");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DegerFlag", "DEM002_DegerFlag");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_KDVOrani", "DEM002_KDVOrani");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_KDVTutari", "DEM002_KDVTutari");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_KDVYili", "DEM002_KDVYili");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_KDVBasYil", "DEM002_KDVBasYil");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_EkOmurKey1", "DEM002_EkOmurKey1");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_AlimDate", "DEM002_AlimDate");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_AlimEvrakNo", "DEM002_AlimEvrakNo");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_Satici", "DEM002_Satici");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_AlimTutari", "DEM002_AlimTutari");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_EkOmurKey2", "DEM002_EkOmurKey2");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SatisDate", "DEM002_SatisDate");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SatisEvrakNo", "DEM002_SatisEvrakNo");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_Musteri", "DEM002_Musteri");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SatisTutari", "DEM002_SatisTutari");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_MaliyetDeg", "DEM002_MaliyetDeg");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_GiderToplami", "DEM002_GiderToplami");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_BirikAmort", "DEM002_BirikAmort");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SonIslemYili", "DEM002_SonIslemYili");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_MHSHesapKodu", "DEM002_MHSHesapKodu");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_EkOmurKey4", "DEM002_EkOmurKey4");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_MHSFisType", "DEM002_MHSFisType");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_MHSFisNo", "DEM002_MHSFisNo");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_EkOmurKey3", "DEM002_EkOmurKey3");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_IthalDate", "DEM002_IthalDate");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_IthalMuhNo", "DEM002_IthalMuhNo");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_IthalDovCinsi", "DEM002_IthalDovCinsi");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_IthalDovTutari", "DEM002_IthalDovTutari");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemAciklama", "DEM002_DemAciklama");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_AmortAyirSekli", "DEM002_AmortAyirSekli");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_AmortDegYil", "DEM002_AmortDegYil");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_AmortDegOrani", "DEM002_AmortDegOrani");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DegmeAmort", "DEM002_DegmeAmort");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_IZFlag", "DEM002_IZFlag");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_BirYilKaAmort", "DEM002_BirYilKaAmort");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_AyrilmayanAmort", "DEM002_AyrilmayanAmort");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_AmortTabiKisim", "DEM002_AmortTabiKisim");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_AyYilAmortSek", "DEM002_AyYilAmortSek");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SatilAmort", "DEM002_SatilAmort");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemGirKaynak", "DEM002_DemGirKaynak");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemGirDate", "DEM002_DemGirDate");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemGirTime", "DEM002_DemGirTime");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemGirKodu", "DEM002_DemGirKodu");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemGirVers", "DEM002_DemGirVers");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemDegKaynak", "DEM002_DemDegKaynak");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemDegDate", "DEM002_DemDegDate");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemDegTime", "DEM002_DemDegTime");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemDegKodu", "DEM002_DemDegKodu");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemDegVers", "DEM002_DemDegVers");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_AmortDegFlag", "DEM002_AmortDegFlag");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_AmortOraniFlag", "DEM002_AmortOraniFlag");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemGiderTipi", "DEM002_DemGiderTipi");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_IlkYildanKalanROFM", "DEM002_IlkYildanKalanROFM");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_BitisYili", "DEM002_BitisYili");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SDMalDeg", "DEM002_SDMalDeg");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SDBirikAmort", "DEM002_SDBirikAmort");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SDBirYilKalAmort", "DEM002_SDBirYilKalAmort");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SDDegmeAmort", "DEM002_SDDegmeAmort");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SDAyrilAmort", "DEM002_SDAyrilAmort");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SDSatilAmort", "DEM002_SDSatilAmort");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SonDonIsYili", "DEM002_SonDonIsYili");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SonDonIsDon", "DEM002_SonDonIsDon");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_AmortAyirFlag", "DEM002_AmortAyirFlag");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_AlimMiktari", "DEM002_AlimMiktari");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SatisMiktari", "DEM002_SatisMiktari");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemKod1", "DEM002_DemKod1");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemKod2", "DEM002_DemKod2");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemKod3", "DEM002_DemKod3");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemKod4", "DEM002_DemKod4");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemKod5", "DEM002_DemKod5");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemFinansmanGideri", "DEM002_DemFinansmanGideri");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemKrediAlimTarihi", "DEM002_DemKrediAlimTarihi");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemKrediVadeTarihi", "DEM002_DemKrediVadeTarihi");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemVadeTarihi", "DEM002_DemVadeTarihi");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemVadeFarki", "DEM002_DemVadeFarki");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemKurFarki", "DEM002_DemKurFarki");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemKrediTutari", "DEM002_DemKrediTutari");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemMHSHesabi", "DEM002_DemMHSHesabi");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemMHSBirikAmortHesabi", "DEM002_DemMHSBirikAmortHesabi");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemMHSGiderHesabi", "DEM002_DemMHSGiderHesabi");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemArindirmaSekli", "DEM002_DemArindirmaSekli");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemReelOlmFinansMal", "DEM002_DemReelOlmFinansMal");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_MlyReelDeg", "DEM002_MlyReelDeg");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_MlyEkonomikOmur", "DEM002_MlyEkonomikOmur");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_MlySDMaliyetDeg", "DEM002_MlySDMaliyetDeg");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_MlySDBirikAmort", "DEM002_MlySDBirikAmort");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_MlySDBirYilKalAmort", "DEM002_MlySDBirYilKalAmort");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_MlySDDegmeAmort", "DEM002_MlySDDegmeAmort");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_MlySDAyrilAmort", "DEM002_MlySDAyrilAmort");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_MlySDSatilAmort", "DEM002_MlySDSatilAmort");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_MlySDGiderToplami", "DEM002_MlySDGiderToplami");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_MlySDReelDeger", "DEM002_MlySDReelDeger");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_MlySDReelGiderToplami", "DEM002_MlySDReelGiderToplami");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_MlySDIslemYili", "DEM002_MlySDIslemYili");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_MlySDIslemDonemi", "DEM002_MlySDIslemDonemi");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_MlySonIslemYili", "DEM002_MlySonIslemYili");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_MlyBirikAmort", "DEM002_MlyBirikAmort");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_MlyDegmeAmort", "DEM002_MlyDegmeAmort");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_MlyBirYilKalAmort", "DEM002_MlyBirYilKalAmort");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_MlyAyrilAmort", "DEM002_MlyAyrilAmort");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_MlySatilAmort", "DEM002_MlySatilAmort");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_MlyMaliyetDeg", "DEM002_MlyMaliyetDeg");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_MlyGiderToplami", "DEM002_MlyGiderToplami");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_MlySyReelDeger", "DEM002_MlySyReelDeger");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_MlySyReelGiderToplami", "DEM002_MlySyReelGiderToplami");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_MlyIZFlag", "DEM002_MlyIZFlag");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SPKReelDeg", "DEM002_SPKReelDeg");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SPKEkonomikOmur", "DEM002_SPKEkonomikOmur");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SPKSDMaliyetDeg", "DEM002_SPKSDMaliyetDeg");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SPKSDBirikAmort", "DEM002_SPKSDBirikAmort");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SPKSDDegmeAmort", "DEM002_SPKSDDegmeAmort");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SPKSDAyrilAmort", "DEM002_SPKSDAyrilAmort");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SPKSDSatilAmort", "DEM002_SPKSDSatilAmort");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SPKSDGiderToplami", "DEM002_SPKSDGiderToplami");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SPKSDReelDeger", "DEM002_SPKSDReelDeger");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SPKSDReelGiderToplami", "DEM002_SPKSDReelGiderToplami");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SPKSDIslemYili", "DEM002_SPKSDIslemYili");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SPKSDIslemDonemi", "DEM002_SPKSDIslemDonemi");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SPKSonIslemYili", "DEM002_SPKSonIslemYili");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SPKBitisYili", "DEM002_SPKBitisYili");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SPKBirikAmort", "DEM002_SPKBirikAmort");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SPKDegmeAmort", "DEM002_SPKDegmeAmort");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SPKBirYilKalAmort", "DEM002_SPKBirYilKalAmort");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SPKAyrilAmort", "DEM002_SPKAyrilAmort");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SPKSatilAmort", "DEM002_SPKSatilAmort");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SPKMaliyetDeg", "DEM002_SPKMaliyetDeg");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SPKGiderToplami", "DEM002_SPKGiderToplami");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SPKSyReelDeger", "DEM002_SPKSyReelDeger");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SPKSyReelGiderToplami", "DEM002_SPKSyReelGiderToplami");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SPKIZFlag", "DEM002_SPKIZFlag");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_MHSFlag", "DEM002_MHSFlag");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_MaliyetDegeriTarihi", "DEM002_MaliyetDegeriTarihi");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_MaliyetDegeriEnfFarki", "DEM002_MaliyetDegeriEnfFarki");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_BirikmisAmortismanTarihi", "DEM002_BirikmisAmortismanTarihi");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_BirikmisAmortismanEnfFarki", "DEM002_BirikmisAmortismanEnfFarki");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SDMaliyetDegeriTarihi", "DEM002_SDMaliyetDegeriTarihi");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SDMaliyetDegeriEnfFarki", "DEM002_SDMaliyetDegeriEnfFarki");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SDBirikmisAmortismanTarihi", "DEM002_SDBirikmisAmortismanTarihi");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_SDBirikmisAmortismanEnfFarki", "DEM002_SDBirikmisAmortismanEnfFarki");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemBaglantiHesapKodu", "DEM002_DemBaglantiHesapKodu");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_EskiEkOmurKey1", "DEM002_EskiEkOmurKey1");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_EskiEkOmurKey2", "DEM002_EskiEkOmurKey2");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_EskiEkOmurKey3", "DEM002_EskiEkOmurKey3");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_EskiEkOmurKey4", "DEM002_EskiEkOmurKey4");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_EskiAmortOrani", "DEM002_EskiAmortOrani");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_EskiMlyEkonomikOmur", "DEM002_EskiMlyEkonomikOmur");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_EskiMlyBitisYili", "DEM002_EskiMlyBitisYili");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_Vuk365AmortismanFlag", "DEM002_Vuk365AmortismanFlag");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_Vuk365AmortismanOrani", "DEM002_Vuk365AmortismanOrani");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemKod6", "DEM002_DemKod6");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemKod7", "DEM002_DemKod7");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemKod8", "DEM002_DemKod8");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemKod9", "DEM002_DemKod9");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_DemKartType", "DEM002_DemKartType");
                SQLTopluKopyala.ColumnMappings.Add("DEM002_OzelMaliyetSonDate", "DEM002_OzelMaliyetSonDate");


                SQLTopluKopyala.SqlRowsCopied += new SqlRowsCopiedEventHandler(KayitKopyalandi);
                SQLTopluKopyala.WriteToServer(dsAmortisman.DemirbasKarti);
                SQLTopluKopyala.Close();
                dsAmortisman.DemirbasKarti.AcceptChanges();
                MessageBox.Show("{ " + Convert.ToString(dsAmortisman.DemirbasKarti.Rows.Count) + " ADET } Demirbaş Kartı Aktarılmıştır");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata : " + ex);
            }
        }

        private void kanalIcin()
        {
            foreach (DataRow dr in dsAmortisman.geciciTablo.Rows)
            {
                DemirbasDurumu = (int)sqlQueryler1.DemirbasKodDurumu(dr[0].ToString());

                if (DemirbasDurumu == 0)
                {
                    EkonomikOmur = (Convert.ToInt32(dr[13].ToString()) - Convert.ToInt32(dr[11].ToString())) + 1;
                    //KdvTutari = (Convert.ToDecimal(dr[16].ToString()) * 18) / 100;
                    KdvTutar = "0";
                    iktisapDeger = dr[15].ToString();
                    EndeksTabiAmortisman = dr[17].ToString();
                    string AmortOran = dr[10].ToString();

                    if (!string.IsNullOrEmpty(AmortOran))
                    {
                        AmortismanOrani = Convert.ToDecimal(AmortOran);
                    }
                    else
                    {
                        AmortismanOrani = 0;
                    }

                    GirenKodu = Environment.UserName.ToString();

                    if (GirenKodu.ToString().Length > 10)
                    {
                        GirenKodu = GirenKodu.ToString().Substring(0, 10);
                    }

                    DateTime objGiris = new DateTime();
                    objGiris = Convert.ToDateTime(DateTime.Now);
                    string strGiris;
                    TarihGiris = 0;
                    TarihGiris = objGiris.ToOADate();
                    strGiris = TarihGiris.ToString().Substring(0, 5);
                    GirisTarihi = Convert.ToInt32(strGiris);

                    DateTime obj = new DateTime();
                    obj = Convert.ToDateTime(dr[8].ToString());
                    string str;
                    TarihAlim = 0;
                    TarihAlim = obj.ToOADate();
                    str = TarihAlim.ToString().Substring(0, 5);
                    AlimTarihi = Convert.ToInt32(str);

                    DateTime dtBit = new DateTime();
                    dtBit = Convert.ToDateTime(dr[8].ToString());
                    string BitGun = Convert.ToString(dtBit.Day);
                    string BitTarih = BitGun + "." + dr[14].ToString() + "." + dr[13].ToString();

                    DateTime obj2 = new DateTime();
                    obj2 = Convert.ToDateTime(BitTarih);
                    string str2;
                    TarihBitis = 0;
                    TarihBitis = obj2.ToOADate();
                    str2 = TarihBitis.ToString().Substring(0, 5);
                    BitisTarihi = Convert.ToInt32(str2);

                    Saatimiz = Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));

                    if (Saatimiz.ToString().Length == 18)
                    {
                        Saatimiz = Saatimiz.ToString().Substring(10, 8);
                    }
                    else if (Saatimiz.ToString().Length == 19)
                    {
                        Saatimiz = Saatimiz.ToString().Substring(11, 8);
                    }
                    Saatimiz = Saatimiz.ToString().Replace(":", "");

                    if (Saatimiz.ToString().Length > 8)
                    {
                        Saatimiz = Saatimiz.ToString().Substring(0, 8);
                    }

                    string AlmMiktar = dr[5].ToString();
                    string EndkTabDeger = dr[16].ToString();

                    if (string.IsNullOrEmpty(AlmMiktar))
                    {
                        AlimMiktari = 1;
                    }
                    else
                    {
                        AlimMiktari = Convert.ToDecimal(dr[5].ToString());
                    }

                    if (string.IsNullOrEmpty(EndkTabDeger))
                    {
                        EndeksTabiDeger = 0;
                    }
                    else
                    {
                        EndeksTabiDeger = Convert.ToDecimal(dr[16].ToString());
                    }

                    DemirbasKodu = dr[0].ToString();
                    DemirbasAdi = dr[1].ToString();

                    if (DemirbasKodu.ToString().Length > 16)
                    {
                        DemirbasKodu = DemirbasKodu.ToString().Substring(0, 16);
                    }
                    if (DemirbasAdi.ToString().Length > 30)
                    {
                        DemirbasAdi = DemirbasAdi.ToString().Substring(0, 30);
                    }

                    dsAmortisman.DemirbasKarti.AddDemirbasKartiRow(DemirbasKodu, DemirbasAdi, "", "", "", 1,
                        AmortismanOrani, 1, 18, Convert.ToDecimal(KdvTutar), 1, 0, "", AlimTarihi, dr[7].ToString(), dr[6].ToString(),
                        EndeksTabiDeger, "", 0, "", "", 0, 0, 0, 0, 0, "", "", "", 0, "", 0, "", "", 0, "", 0, 0, 0, 0,
                        0, 0, 0, 1, 2, 0, "Y9014", GirisTarihi, Saatimiz, GirenKodu, "6.1.10", "Y9014", GirisTarihi, Saatimiz, GirenKodu,
                        "6.1.10", 0, 1, 0, 0, dr[13].ToString(), 0, 0, 0, 0, 0, 0, 0, 0, 1, AlimMiktari,
                        0, "", "", "", "", "", 0, 0, 0, 0, 0, 0, 0, dr[2].ToString(), dr[3].ToString(), dr[4].ToString(),
                        0, 0, 0, Convert.ToInt16(EkonomikOmur), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0,
                        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", "", "", 0, 0,
                        0, 0, 0, "", "", Convert.ToDecimal(iktisapDeger), Convert.ToDecimal(EndeksTabiAmortisman), 0, 0);

                }
            }
            if (dsAmortisman.DemirbasKarti.Rows.Count > 0)
            {
                MessageBox.Show("Toplam Aktarılacak Demirbaş Kart Sayısı : {" + Convert.ToString(dsAmortisman.DemirbasKarti.Rows.Count) + " ADET } Lütfen Kapatmayın Aktarım İşlemi Başlayacaktır.", "Aktarılacak Demirbaş Kartları",MessageBoxButtons.OK,MessageBoxIcon.Information);
                fnkSQLeTopluKopyala();
            }
            else
            {
                MessageBox.Show("Aktarılacak Demirbaş Kaydı Bulunamadı", "Aktarılacak Demirbaş Kartları", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHazirla_Click(object sender, EventArgs e)
        {
            fnkHazirla();
        }

        void KayitKopyalandi(object sender, SqlRowsCopiedEventArgs e)
        {
            Thread.Sleep(0);
            pb.Increment(1);
        }

        private void btnKartlariAktar_Click(object sender, EventArgs e)
        {
            pb.Text = "0";

            kanal = new Thread(kanalIcin);
            kanal.Start();
            GC.Collect();
        }

        private void AcilisFormu_Load(object sender, EventArgs e)
        {

        }

    }
}
