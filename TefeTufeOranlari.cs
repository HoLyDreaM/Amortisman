using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.ViewInfo;

namespace Sifas_Amortisman
{
    public partial class TefeTufeOranlari : Form
    {
        public TefeTufeOranlari()
        {
            InitializeComponent();
        }

        public AnaForm anaFrm
        {
            get;
            set;
        }

        Thread Sorgula;
        SqlConnection Conn;
        SqlCommand cmd;
        public string Cs;

        private void TefeTufeOranlari_Load(object sender, EventArgs e)
        {
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            CheckForIllegalCrossThreadCalls = false;
            //txtYil.Text = Convert.ToString(DateTime.Now.Year);
            // TODO: This line of code loads data into the 'dsAmortisman.Oranlar' table. You can move, or remove it, as needed.
            this.oranlarTableAdapter.Fill(this.dsAmortisman.Oranlar);
        }

        private void btnOranlariEkle_Click(object sender, EventArgs e)
        {
            int OranYili = Convert.ToInt32(txtYil.Text);
            decimal TefeOrani = Convert.ToDecimal(txtTefe.Text);
            decimal TufeOrani = Convert.ToDecimal(txtTufe.Text);
            string OranAyi = cmbAy.SelectedItem.ToString();

            this.sqlQueryler1.TefeTufeOranEkle(OranYili, OranAyi, TefeOrani, TufeOrani);
            MessageBox.Show("Oranlar Başarılı Şekilde Eklenmiştir.","Tefe - Tüfe Oranları",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.oranlarTableAdapter.Fill(this.dsAmortisman.Oranlar);
        }

        private void btnOranlariExceleAktar_Click(object sender, EventArgs e)
        {
            excelKaydet.FileName = "Tefe - Tüfe Oranları";
            excelKaydet.Filter = "XLS Dosyaları (*.xls)|*.xls";

            if (excelKaydet.ShowDialog() == DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsExportOptions _Options = new DevExpress.XtraPrinting.XlsExportOptions();
                _Options.SheetName = "Tefe-Tufe-Oranlari";
                pvtOranlar.ExportToXls(excelKaydet.FileName,_Options);
            }
        }

        private void btnOranSil_Click(object sender, EventArgs e)
        {
            int OranYil = Convert.ToInt32(txtYil.Text);
            string OranAY = cmbAy.SelectedItem.ToString();

            if (MessageBox.Show("Belirttiğiniz Dönem Oranını Silmek İstediğinize Emin Misiniz?", "Oran Sil!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.sqlQueryler1.OranSil(OranYil, OranAY.ToString());
                MessageBox.Show("Seçtiğiniz Dönem Başarılı Şekilde Silinmiştir", "Tefe - Tüfe Oranı Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.oranlarTableAdapter.Fill(this.dsAmortisman.Oranlar);
            }
        }

        private void btnOranDuzenle_Click(object sender, EventArgs e)
        {
            this.sqlQueryler1.OranlariGuncelle(cmbAy.Text, Convert.ToInt32(txtYil.Text), Convert.ToDecimal(txtTefe.Text), Convert.ToDecimal(txtTufe.Text), Convert.ToInt32(txtID.Text), txtAy.Text);
            MessageBox.Show("İsteğiniz üzerine belirttiğiniz Oranlar güncellenmiştir");
            this.oranlarTableAdapter.Fill(this.dsAmortisman.Oranlar);
        }

        private void pvtOranlar_CellClick(object sender, PivotCellEventArgs e)
        {
            decimal OranKontrol = 0;

            if (string.IsNullOrEmpty(Convert.ToString(e.GetFieldValue(fieldTefeOrani1))))
            {
                OranKontrol = 0;
            }
            else
            {
                OranKontrol = 1;
            }

            if (OranKontrol > 0)
            {
                txtYil.Text = e.GetFieldValue(fieldYil1).ToString();
                txtTefe.Text = e.GetFieldValue(fieldTefeOrani1).ToString();
                txtTufe.Text = e.GetFieldValue(fieldTufeOrani1).ToString();
                cmbAy.Text = e.GetFieldValue(fieldAy1).ToString();
                txtAy.Text = e.GetFieldValue(fieldAy1).ToString();
                txtID.Text = Convert.ToString(this.sqlQueryler1.OranlarIDBul(Convert.ToInt32(txtYil.Text), cmbAy.Text));
            }
        }
    }
}