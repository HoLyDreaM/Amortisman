using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using System.Diagnostics;

namespace Sifas_Amortisman.Ayarlar
{
    public partial class Guncelleme : Form
    {
        public Guncelleme()
        {
            InitializeComponent();
        }

        private iniOku.iniOku iniOku = new iniOku.iniOku(Application.StartupPath + "\\LoginSettings.ini");
        private iniOku.iniOku serverdanOku;

        public AnaForm anaFrm
        {
            get;
            set;
        }

        Thread tRemoteVersiyonCek;
        Thread tClientVersiyonCek;
        private string aktifVersiyon;
        public string AktifVersiyon
        {
            get { return aktifVersiyon; }
            set
            {
                aktifVersiyon = value;
                ps_lblYaz(lblAktifVersiyon, aktifVersiyon);
            }
        }

        delegate void dlg(Label _lbl, string text);
        private void ps_lblYaz(Label _lbl, string text)
        {
            if (base.InvokeRequired)
            {
                base.Invoke(new dlg(ps_lblYaz), _lbl, text);
            }
            else
                _lbl.Text = text;
        }

        delegate void dlg1(TextBox _textbox, string text);
        private void ps_txtYaz(TextBox _textbox, string text)
        {
            if (base.InvokeRequired)
            {
                base.Invoke(new dlg1(ps_txtYaz), _textbox, text);
            }
            else
                _textbox.Text = text;
        }

        delegate void dlg2(DevExpress.XtraEditors.SimpleButton btn, Boolean text);
        private void ps_btnEnable(DevExpress.XtraEditors.SimpleButton btn, Boolean text)
        {
            if (base.InvokeRequired)
            {
                base.Invoke(new dlg2(ps_btnEnable), btn, text);
            }
            else
                btn.Enabled = text;
        }
        private string _gelenVersion;
        public string GelenVersion
        {
            get { return _gelenVersion; }
            set
            {
                _gelenVersion = value;
            }
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
            set
            {
                _dosyalar = value;
            }
        }

        DataSet ds;

        private void ps_remoteVersiyonCek()
        {
            try
            {
                ps_btnEnable(yenile, false);
                aktifVersiyon = iniOku.IniOku("Ayar", "version");
                ps_lblYaz(lblAktifVersiyon, AktifVersiyon);

                ds = new DataSet("guncelleme");
                ds.ReadXml("http://editorgroup.net/Programlar/Sifas/AmortismanHesaplama/version.xml");

                GelenVersion = ds.Tables[0].Rows[0]["Versiyon"].ToString();
                Aciklama = ds.Tables[0].Rows[0]["Aciklama"].ToString();
                Dosyalar = ds.Tables[0].Rows[0]["Dosya"].ToString();

                if (aktifVersiyon != GelenVersion)
                {
                    ps_txtYaz(TextBox1, "Yeni Güncelleme Bulundu!");
                    ps_lblYaz(lblAciklama, Aciklama);
                    ps_lblYaz(lblYeniVersiyon, GelenVersion);
                    ps_txtYaz(lblDosyalar, Dosyalar);
                    ps_btnEnable(indir, true);
                }
                else
                {
                    ps_txtYaz(TextBox1, "Yeni Güncelleme Bulunamadı!");
                    ps_btnEnable(indir, false);
                }
                ps_btnEnable(yenile, true);
            }
            catch (Exception ex)
            {
                ps_txtYaz(TextBox1, ex.Message.ToString());
            }
        }

        private void ps_threadremoteVersiyonCek()
        {
            tRemoteVersiyonCek = new Thread(new ThreadStart(ps_remoteVersiyonCek));
            tRemoteVersiyonCek.Start();
        }

        private void ps_ClientVersiyonCek()
        {
            try
            {
                ps_btnEnable(yenile, false);
                aktifVersiyon = iniOku.IniOku("Ayar", "version");
                ps_lblYaz(lblAktifVersiyon, AktifVersiyon);

                serverdanOku = new global::iniOku.iniOku(txtIniYolu.Text + "\\LoginSettings.ini");
                Thread.Sleep(10);

                GelenVersion = serverdanOku.IniOku("Ayar", "version");

                if (!string.IsNullOrEmpty(GelenVersion))
                    if (aktifVersiyon != GelenVersion)
                    {
                        Aciklama = "Serverdan güncelleme alabilirsiniz!";
                        Dosyalar = "Sifas_Amortisman.Exe";

                        ps_txtYaz(TextBox1, "Yeni Güncelleme Bulundu!");
                        ps_lblYaz(lblAciklama, Aciklama);
                        ps_lblYaz(lblYeniVersiyon, GelenVersion);
                        ps_txtYaz(lblDosyalar, Dosyalar);
                        ps_btnEnable(indir, true);
                    }
                    else
                    {
                        ps_txtYaz(TextBox1, "Yeni Güncelleme Bulunamadı!");
                        ps_lblYaz(lblAciklama, "");
                        ps_lblYaz(lblYeniVersiyon, "");
                        ps_txtYaz(lblDosyalar, "");
                        ps_btnEnable(indir, false);
                    }
                ps_btnEnable(yenile, true);

            }
            catch (Exception ex)
            {
                ps_txtYaz(TextBox1, ex.Message.ToString());
            }
        }
        private void ps_threadClientVersiyonCek()
        {
            tClientVersiyonCek = new Thread(new ThreadStart(ps_threadClientVersiyonCek));
            tClientVersiyonCek.Start();
        }//İptal : Gecikmeden dolayı hatalı çalışabiliyor.

        private void guncelleme_Load(object sender, EventArgs e)
        {
            cmbGuncellemeTuru.SelectedIndex = 0;
            try
            {
                cmbGuncellemeTuru.SelectedIndex = Convert.ToInt16(iniOku.IniOku("Ayar", "GuncellemeTuru"));
                txtServerYolu.Text = iniOku.IniOku("Ayar", "ServerYolu");
                txtIniYolu.Text = iniOku.IniOku("Ayar", "InıYolu");
                if (string.IsNullOrEmpty(txtServerYolu.Text))
                {
                    txtServerYolu.Text = Application.StartupPath.ToString();
                }

                if (cmbGuncellemeTuru.SelectedIndex == 0)
                {
                    ps_btnEnable(indir, false);
                    ps_btnEnable(indir, false);
                    ps_threadremoteVersiyonCek();
                }
                else
                {
                    ps_btnEnable(indir, false);
                    ps_ClientVersiyonCek();
                    //ps_threadClientVersiyonCek();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void yenile_Click(object sender, EventArgs e)
        {
            if (cmbGuncellemeTuru.SelectedIndex == 0)
                ps_threadremoteVersiyonCek();
            else
                ps_ClientVersiyonCek();//ps_threadClientVersiyonCek();

        }

        private void indir_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Application.StartupPath + "\\ProgramGuncelleme.exe");
                indir.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void txtIniYolu_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (fbYolSec.ShowDialog() == DialogResult.OK)
            {
                txtIniYolu.Text = fbYolSec.SelectedPath.ToString();
            }
        }

        private void btnYolKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                iniOku.IniYaz("Ayar", "GuncellemeTuru", cmbGuncellemeTuru.SelectedIndex.ToString());
                iniOku.IniYaz("Ayar", "InıYolu", txtIniYolu.Text);
                iniOku.IniYaz("Ayar", "ServerYolu", txtServerYolu.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void cmbGuncellemeTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGuncellemeTuru.SelectedIndex == 0)
            {
                txtIniYolu.Enabled = false;
                txtServerYolu.Enabled = false;
                //btnYolKaydet.Enabled = false;
            }
            else
            {
                txtIniYolu.Enabled = true;
                txtServerYolu.Enabled = true;
                //btnYolKaydet.Enabled = true;
            }
        }

    }
}

