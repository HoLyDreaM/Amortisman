namespace Sifas_Amortisman
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.pnNormal = new System.Windows.Forms.Panel();
            this.chkEnflasyon = new DevExpress.XtraEditors.CheckEdit();
            this.rdEnflasyon = new DevExpress.XtraEditors.RadioGroup();
            this.cmbEnflasyonBitisAyi = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbEnflasyonBaslangicAyi = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbEnflasyonBitisYili = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbEnflasyonBaslangicYili = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbDonemAyi = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblEnflasyonBitisAyi = new System.Windows.Forms.Label();
            this.lblEnflasyonAyi = new System.Windows.Forms.Label();
            this.lblEnflasyonBitisYili = new System.Windows.Forms.Label();
            this.lblEnflasyonBYili = new System.Windows.Forms.Label();
            this.lblDonemYili = new System.Windows.Forms.Label();
            this.lblDonemAyi = new System.Windows.Forms.Label();
            this.txtDonemYili = new System.Windows.Forms.TextBox();
            this.btnTemizle = new DevExpress.XtraEditors.SimpleButton();
            this.btnExceleAktar = new DevExpress.XtraEditors.SimpleButton();
            this.btnKayitlariAktar = new DevExpress.XtraEditors.SimpleButton();
            this.btnDemirbaslariGetir = new DevExpress.XtraEditors.SimpleButton();
            this.gridAmortismanlar = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSabitKiymetKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSabitKiymetAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmortismanHesabi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMuhasebeHesabi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGiderHesabi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaslangicYili = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaslangicAyi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBitisYili = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBitisAyi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coliktisabDegeri = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndekseTabiDeger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndekseTabiAmortisman = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKatSayisi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndekslenmisDeger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndekslenmisAmortisman = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKalanDeger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCariYilAmortisman = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAylikAmortisman = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colToplamBirikmisAmortisman = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSabitKiymetEnflasyonFarki = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmortismanEnflasyonFarki = new DevExpress.XtraGrid.Columns.GridColumn();
            this.denemeamortismanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsAmortisman = new Sifas_Amortisman.dsAmortisman();
            this.denemeamortismanTableAdapter = new Sifas_Amortisman.dsAmortismanTableAdapters.denemeamortismanTableAdapter();
            this.sqlQueryler1 = new Sifas_Amortisman.dsAmortismanTableAdapters.SqlQueryler();
            this.amortHesaplariBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.amortHesaplariTableAdapter = new Sifas_Amortisman.dsAmortismanTableAdapters.AmortHesaplariTableAdapter();
            this.tumAmortismanHesaplariBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tumAmortismanHesaplariTableAdapter = new Sifas_Amortisman.dsAmortismanTableAdapters.TumAmortismanHesaplariTableAdapter();
            this.pnNormal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkEnflasyon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdEnflasyon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEnflasyonBitisAyi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEnflasyonBaslangicAyi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEnflasyonBitisYili.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEnflasyonBaslangicYili.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDonemAyi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAmortismanlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.denemeamortismanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAmortisman)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amortHesaplariBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tumAmortismanHesaplariBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pnNormal
            // 
            this.pnNormal.Controls.Add(this.chkEnflasyon);
            this.pnNormal.Controls.Add(this.rdEnflasyon);
            this.pnNormal.Controls.Add(this.cmbEnflasyonBitisAyi);
            this.pnNormal.Controls.Add(this.cmbEnflasyonBaslangicAyi);
            this.pnNormal.Controls.Add(this.cmbEnflasyonBitisYili);
            this.pnNormal.Controls.Add(this.cmbEnflasyonBaslangicYili);
            this.pnNormal.Controls.Add(this.cmbDonemAyi);
            this.pnNormal.Controls.Add(this.lblEnflasyonBitisAyi);
            this.pnNormal.Controls.Add(this.lblEnflasyonAyi);
            this.pnNormal.Controls.Add(this.lblEnflasyonBitisYili);
            this.pnNormal.Controls.Add(this.lblEnflasyonBYili);
            this.pnNormal.Controls.Add(this.lblDonemYili);
            this.pnNormal.Controls.Add(this.lblDonemAyi);
            this.pnNormal.Controls.Add(this.txtDonemYili);
            this.pnNormal.Controls.Add(this.btnTemizle);
            this.pnNormal.Controls.Add(this.btnExceleAktar);
            this.pnNormal.Controls.Add(this.btnKayitlariAktar);
            this.pnNormal.Controls.Add(this.btnDemirbaslariGetir);
            this.pnNormal.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnNormal.Location = new System.Drawing.Point(0, 0);
            this.pnNormal.Name = "pnNormal";
            this.pnNormal.Size = new System.Drawing.Size(1184, 155);
            this.pnNormal.TabIndex = 1;
            // 
            // chkEnflasyon
            // 
            this.chkEnflasyon.Location = new System.Drawing.Point(603, 22);
            this.chkEnflasyon.Name = "chkEnflasyon";
            this.chkEnflasyon.Properties.Caption = "Enflasyona Göre Hesapla";
            this.chkEnflasyon.Size = new System.Drawing.Size(146, 19);
            this.chkEnflasyon.TabIndex = 10;
            // 
            // rdEnflasyon
            // 
            this.rdEnflasyon.Location = new System.Drawing.Point(605, 43);
            this.rdEnflasyon.Name = "rdEnflasyon";
            this.rdEnflasyon.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Tefe Oranı", "Tefe Oranı"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Tüfe Oranı", "Tüfe Oranı")});
            this.rdEnflasyon.Size = new System.Drawing.Size(144, 45);
            this.rdEnflasyon.TabIndex = 9;
            // 
            // cmbEnflasyonBitisAyi
            // 
            this.cmbEnflasyonBitisAyi.EditValue = "Ocak";
            this.cmbEnflasyonBitisAyi.Location = new System.Drawing.Point(458, 68);
            this.cmbEnflasyonBitisAyi.Name = "cmbEnflasyonBitisAyi";
            this.cmbEnflasyonBitisAyi.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cmbEnflasyonBitisAyi.Properties.Appearance.Options.UseFont = true;
            this.cmbEnflasyonBitisAyi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbEnflasyonBitisAyi.Properties.Items.AddRange(new object[] {
            "Ocak",
            "Şubat",
            "Mart",
            "Nisan",
            "Mayıs",
            "Haziran",
            "Temmuz",
            "Ağustos",
            "Eylül",
            "Ekim",
            "Kasım",
            "Aralık"});
            this.cmbEnflasyonBitisAyi.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbEnflasyonBitisAyi.Size = new System.Drawing.Size(139, 20);
            this.cmbEnflasyonBitisAyi.TabIndex = 8;
            // 
            // cmbEnflasyonBaslangicAyi
            // 
            this.cmbEnflasyonBaslangicAyi.EditValue = "Ocak";
            this.cmbEnflasyonBaslangicAyi.Location = new System.Drawing.Point(158, 69);
            this.cmbEnflasyonBaslangicAyi.Name = "cmbEnflasyonBaslangicAyi";
            this.cmbEnflasyonBaslangicAyi.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cmbEnflasyonBaslangicAyi.Properties.Appearance.Options.UseFont = true;
            this.cmbEnflasyonBaslangicAyi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbEnflasyonBaslangicAyi.Properties.Items.AddRange(new object[] {
            "Ocak",
            "Şubat",
            "Mart",
            "Nisan",
            "Mayıs",
            "Haziran",
            "Temmuz",
            "Ağustos",
            "Eylül",
            "Ekim",
            "Kasım",
            "Aralık"});
            this.cmbEnflasyonBaslangicAyi.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbEnflasyonBaslangicAyi.Size = new System.Drawing.Size(139, 20);
            this.cmbEnflasyonBaslangicAyi.TabIndex = 8;
            // 
            // cmbEnflasyonBitisYili
            // 
            this.cmbEnflasyonBitisYili.EditValue = "";
            this.cmbEnflasyonBitisYili.Location = new System.Drawing.Point(458, 43);
            this.cmbEnflasyonBitisYili.Name = "cmbEnflasyonBitisYili";
            this.cmbEnflasyonBitisYili.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cmbEnflasyonBitisYili.Properties.Appearance.Options.UseFont = true;
            this.cmbEnflasyonBitisYili.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbEnflasyonBitisYili.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbEnflasyonBitisYili.Size = new System.Drawing.Size(139, 20);
            this.cmbEnflasyonBitisYili.TabIndex = 8;
            // 
            // cmbEnflasyonBaslangicYili
            // 
            this.cmbEnflasyonBaslangicYili.EditValue = "";
            this.cmbEnflasyonBaslangicYili.Location = new System.Drawing.Point(158, 45);
            this.cmbEnflasyonBaslangicYili.Name = "cmbEnflasyonBaslangicYili";
            this.cmbEnflasyonBaslangicYili.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cmbEnflasyonBaslangicYili.Properties.Appearance.Options.UseFont = true;
            this.cmbEnflasyonBaslangicYili.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbEnflasyonBaslangicYili.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbEnflasyonBaslangicYili.Size = new System.Drawing.Size(139, 20);
            this.cmbEnflasyonBaslangicYili.TabIndex = 8;
            // 
            // cmbDonemAyi
            // 
            this.cmbDonemAyi.EditValue = "Ocak";
            this.cmbDonemAyi.Location = new System.Drawing.Point(458, 19);
            this.cmbDonemAyi.Name = "cmbDonemAyi";
            this.cmbDonemAyi.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cmbDonemAyi.Properties.Appearance.Options.UseFont = true;
            this.cmbDonemAyi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDonemAyi.Properties.Items.AddRange(new object[] {
            "Ocak",
            "Şubat",
            "Mart",
            "Nisan",
            "Mayıs",
            "Haziran",
            "Temmuz",
            "Ağustos",
            "Eylül",
            "Ekim",
            "Kasım",
            "Aralık"});
            this.cmbDonemAyi.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbDonemAyi.Size = new System.Drawing.Size(139, 20);
            this.cmbDonemAyi.TabIndex = 4;
            // 
            // lblEnflasyonBitisAyi
            // 
            this.lblEnflasyonBitisAyi.BackColor = System.Drawing.Color.Silver;
            this.lblEnflasyonBitisAyi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEnflasyonBitisAyi.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblEnflasyonBitisAyi.Location = new System.Drawing.Point(303, 67);
            this.lblEnflasyonBitisAyi.Name = "lblEnflasyonBitisAyi";
            this.lblEnflasyonBitisAyi.Size = new System.Drawing.Size(155, 22);
            this.lblEnflasyonBitisAyi.TabIndex = 1;
            this.lblEnflasyonBitisAyi.Text = "Enflasyon Yeni Dönem Ayı";
            this.lblEnflasyonBitisAyi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEnflasyonAyi
            // 
            this.lblEnflasyonAyi.BackColor = System.Drawing.Color.Silver;
            this.lblEnflasyonAyi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEnflasyonAyi.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblEnflasyonAyi.Location = new System.Drawing.Point(14, 69);
            this.lblEnflasyonAyi.Name = "lblEnflasyonAyi";
            this.lblEnflasyonAyi.Size = new System.Drawing.Size(144, 22);
            this.lblEnflasyonAyi.TabIndex = 1;
            this.lblEnflasyonAyi.Text = "Son Dönem Enflasyon Ayı";
            this.lblEnflasyonAyi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEnflasyonBitisYili
            // 
            this.lblEnflasyonBitisYili.BackColor = System.Drawing.Color.Silver;
            this.lblEnflasyonBitisYili.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEnflasyonBitisYili.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblEnflasyonBitisYili.Location = new System.Drawing.Point(303, 43);
            this.lblEnflasyonBitisYili.Name = "lblEnflasyonBitisYili";
            this.lblEnflasyonBitisYili.Size = new System.Drawing.Size(155, 22);
            this.lblEnflasyonBitisYili.TabIndex = 1;
            this.lblEnflasyonBitisYili.Text = "Enflasyon Yeni Dönem Yılı";
            this.lblEnflasyonBitisYili.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEnflasyonBYili
            // 
            this.lblEnflasyonBYili.BackColor = System.Drawing.Color.Silver;
            this.lblEnflasyonBYili.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEnflasyonBYili.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblEnflasyonBYili.Location = new System.Drawing.Point(14, 44);
            this.lblEnflasyonBYili.Name = "lblEnflasyonBYili";
            this.lblEnflasyonBYili.Size = new System.Drawing.Size(144, 22);
            this.lblEnflasyonBYili.TabIndex = 1;
            this.lblEnflasyonBYili.Text = "Son Dönem Enflasyon Yılı";
            this.lblEnflasyonBYili.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDonemYili
            // 
            this.lblDonemYili.BackColor = System.Drawing.Color.Silver;
            this.lblDonemYili.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDonemYili.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDonemYili.Location = new System.Drawing.Point(14, 19);
            this.lblDonemYili.Name = "lblDonemYili";
            this.lblDonemYili.Size = new System.Drawing.Size(144, 22);
            this.lblDonemYili.TabIndex = 1;
            this.lblDonemYili.Text = "Dönem Yılı";
            this.lblDonemYili.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDonemAyi
            // 
            this.lblDonemAyi.BackColor = System.Drawing.Color.Silver;
            this.lblDonemAyi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDonemAyi.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDonemAyi.Location = new System.Drawing.Point(303, 19);
            this.lblDonemAyi.Name = "lblDonemAyi";
            this.lblDonemAyi.Size = new System.Drawing.Size(155, 22);
            this.lblDonemAyi.TabIndex = 3;
            this.lblDonemAyi.Text = "Dönem Ayı";
            this.lblDonemAyi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDonemYili
            // 
            this.txtDonemYili.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.txtDonemYili.Location = new System.Drawing.Point(158, 19);
            this.txtDonemYili.MaxLength = 4;
            this.txtDonemYili.Name = "txtDonemYili";
            this.txtDonemYili.Size = new System.Drawing.Size(139, 22);
            this.txtDonemYili.TabIndex = 2;
            // 
            // btnTemizle
            // 
            this.btnTemizle.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnTemizle.Appearance.Options.UseFont = true;
            this.btnTemizle.Location = new System.Drawing.Point(464, 114);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(133, 23);
            this.btnTemizle.TabIndex = 7;
            this.btnTemizle.Text = "&Temizle";
            // 
            // btnExceleAktar
            // 
            this.btnExceleAktar.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnExceleAktar.Appearance.Options.UseFont = true;
            this.btnExceleAktar.Location = new System.Drawing.Point(303, 114);
            this.btnExceleAktar.Name = "btnExceleAktar";
            this.btnExceleAktar.Size = new System.Drawing.Size(155, 23);
            this.btnExceleAktar.TabIndex = 7;
            this.btnExceleAktar.Text = "&Excel e Aktar";
            // 
            // btnKayitlariAktar
            // 
            this.btnKayitlariAktar.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnKayitlariAktar.Appearance.Options.UseFont = true;
            this.btnKayitlariAktar.Enabled = false;
            this.btnKayitlariAktar.Location = new System.Drawing.Point(164, 114);
            this.btnKayitlariAktar.Name = "btnKayitlariAktar";
            this.btnKayitlariAktar.Size = new System.Drawing.Size(133, 23);
            this.btnKayitlariAktar.TabIndex = 6;
            this.btnKayitlariAktar.Text = "&Hareketleri Aktar";
            this.btnKayitlariAktar.Click += new System.EventHandler(this.btnKayitlariAktar_Click);
            // 
            // btnDemirbaslariGetir
            // 
            this.btnDemirbaslariGetir.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnDemirbaslariGetir.Appearance.Options.UseFont = true;
            this.btnDemirbaslariGetir.Location = new System.Drawing.Point(14, 114);
            this.btnDemirbaslariGetir.Name = "btnDemirbaslariGetir";
            this.btnDemirbaslariGetir.Size = new System.Drawing.Size(144, 23);
            this.btnDemirbaslariGetir.TabIndex = 5;
            this.btnDemirbaslariGetir.Text = "&Demirbaşları Getir";
            this.btnDemirbaslariGetir.Click += new System.EventHandler(this.btnDemirbaslariGetir_Click);
            // 
            // gridAmortismanlar
            // 
            this.gridAmortismanlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAmortismanlar.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridAmortismanlar.Location = new System.Drawing.Point(0, 155);
            this.gridAmortismanlar.MainView = this.gridView1;
            this.gridAmortismanlar.Name = "gridAmortismanlar";
            this.gridAmortismanlar.Size = new System.Drawing.Size(1184, 330);
            this.gridAmortismanlar.TabIndex = 5;
            this.gridAmortismanlar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSabitKiymetKodu,
            this.colSabitKiymetAdi,
            this.colAmortismanHesabi,
            this.colMuhasebeHesabi,
            this.colGiderHesabi,
            this.colBaslangicYili,
            this.colBaslangicAyi,
            this.colBitisYili,
            this.colBitisAyi,
            this.coliktisabDegeri,
            this.colEndekseTabiDeger,
            this.colEndekseTabiAmortisman,
            this.colKatSayisi,
            this.colEndekslenmisDeger,
            this.colEndekslenmisAmortisman,
            this.colKalanDeger,
            this.colCariYilAmortisman,
            this.colAylikAmortisman,
            this.colToplamBirikmisAmortisman,
            this.colSabitKiymetEnflasyonFarki,
            this.colAmortismanEnflasyonFarki});
            this.gridView1.GridControl = this.gridAmortismanlar;
            this.gridView1.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "iktisabDegeri", this.coliktisabDegeri, "{0:n2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EndekseTabiDeger", this.colEndekseTabiDeger, "{0:n2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EndekseTabiAmortisman", this.colEndekseTabiAmortisman, "{0:n2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EndekslenmisDeger", this.colEndekslenmisDeger, "{0:n2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EndekslenmisAmortisman", this.colEndekslenmisAmortisman, "{0:n2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KalanDeger", this.colKalanDeger, "{0:n2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CariYilAmortisman", this.colCariYilAmortisman, "{0:n2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AylikAmortisman", this.colAylikAmortisman, "{0:n2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ToplamBirikmisAmortisman", this.colToplamBirikmisAmortisman, "{0:n2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SabitKiymetEnflasyonFarki", this.colSabitKiymetEnflasyonFarki, "{0:n2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmortismanEnflasyonFarki", this.colAmortismanEnflasyonFarki, "{0:n2}")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView1_RowStyle);
            // 
            // colSabitKiymetKodu
            // 
            this.colSabitKiymetKodu.FieldName = "SabitKiymetKodu";
            this.colSabitKiymetKodu.Name = "colSabitKiymetKodu";
            this.colSabitKiymetKodu.Visible = true;
            this.colSabitKiymetKodu.VisibleIndex = 0;
            // 
            // colSabitKiymetAdi
            // 
            this.colSabitKiymetAdi.FieldName = "SabitKiymetAdi";
            this.colSabitKiymetAdi.Name = "colSabitKiymetAdi";
            this.colSabitKiymetAdi.Visible = true;
            this.colSabitKiymetAdi.VisibleIndex = 1;
            // 
            // colAmortismanHesabi
            // 
            this.colAmortismanHesabi.FieldName = "AmortismanHesabi";
            this.colAmortismanHesabi.Name = "colAmortismanHesabi";
            this.colAmortismanHesabi.Visible = true;
            this.colAmortismanHesabi.VisibleIndex = 2;
            // 
            // colMuhasebeHesabi
            // 
            this.colMuhasebeHesabi.FieldName = "MuhasebeHesabi";
            this.colMuhasebeHesabi.Name = "colMuhasebeHesabi";
            this.colMuhasebeHesabi.Visible = true;
            this.colMuhasebeHesabi.VisibleIndex = 3;
            // 
            // colGiderHesabi
            // 
            this.colGiderHesabi.FieldName = "GiderHesabi";
            this.colGiderHesabi.Name = "colGiderHesabi";
            this.colGiderHesabi.Visible = true;
            this.colGiderHesabi.VisibleIndex = 4;
            // 
            // colBaslangicYili
            // 
            this.colBaslangicYili.FieldName = "BaslangicYili";
            this.colBaslangicYili.Name = "colBaslangicYili";
            this.colBaslangicYili.OptionsColumn.ReadOnly = true;
            this.colBaslangicYili.Visible = true;
            this.colBaslangicYili.VisibleIndex = 5;
            // 
            // colBaslangicAyi
            // 
            this.colBaslangicAyi.FieldName = "BaslangicAyi";
            this.colBaslangicAyi.Name = "colBaslangicAyi";
            this.colBaslangicAyi.OptionsColumn.ReadOnly = true;
            this.colBaslangicAyi.Visible = true;
            this.colBaslangicAyi.VisibleIndex = 6;
            // 
            // colBitisYili
            // 
            this.colBitisYili.FieldName = "BitisYili";
            this.colBitisYili.Name = "colBitisYili";
            this.colBitisYili.Visible = true;
            this.colBitisYili.VisibleIndex = 7;
            // 
            // colBitisAyi
            // 
            this.colBitisAyi.FieldName = "BitisAyi";
            this.colBitisAyi.Name = "colBitisAyi";
            this.colBitisAyi.OptionsColumn.ReadOnly = true;
            this.colBitisAyi.Visible = true;
            this.colBitisAyi.VisibleIndex = 8;
            // 
            // coliktisabDegeri
            // 
            this.coliktisabDegeri.DisplayFormat.FormatString = "n2";
            this.coliktisabDegeri.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.coliktisabDegeri.FieldName = "iktisabDegeri";
            this.coliktisabDegeri.Name = "coliktisabDegeri";
            this.coliktisabDegeri.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "iktisabDegeri", "{0:n4}")});
            this.coliktisabDegeri.Visible = true;
            this.coliktisabDegeri.VisibleIndex = 9;
            // 
            // colEndekseTabiDeger
            // 
            this.colEndekseTabiDeger.DisplayFormat.FormatString = "n2";
            this.colEndekseTabiDeger.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colEndekseTabiDeger.FieldName = "EndekseTabiDeger";
            this.colEndekseTabiDeger.Name = "colEndekseTabiDeger";
            this.colEndekseTabiDeger.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EndekseTabiDeger", "{0:n4}")});
            this.colEndekseTabiDeger.Visible = true;
            this.colEndekseTabiDeger.VisibleIndex = 10;
            // 
            // colEndekseTabiAmortisman
            // 
            this.colEndekseTabiAmortisman.DisplayFormat.FormatString = "n2";
            this.colEndekseTabiAmortisman.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colEndekseTabiAmortisman.FieldName = "EndekseTabiAmortisman";
            this.colEndekseTabiAmortisman.Name = "colEndekseTabiAmortisman";
            this.colEndekseTabiAmortisman.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EndekseTabiAmortisman", "{0:n4}")});
            this.colEndekseTabiAmortisman.Visible = true;
            this.colEndekseTabiAmortisman.VisibleIndex = 11;
            // 
            // colKatSayisi
            // 
            this.colKatSayisi.DisplayFormat.FormatString = "n2";
            this.colKatSayisi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colKatSayisi.FieldName = "KatSayisi";
            this.colKatSayisi.Name = "colKatSayisi";
            this.colKatSayisi.OptionsColumn.ReadOnly = true;
            this.colKatSayisi.Visible = true;
            this.colKatSayisi.VisibleIndex = 12;
            // 
            // colEndekslenmisDeger
            // 
            this.colEndekslenmisDeger.DisplayFormat.FormatString = "n2";
            this.colEndekslenmisDeger.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colEndekslenmisDeger.FieldName = "EndekslenmisDeger";
            this.colEndekslenmisDeger.Name = "colEndekslenmisDeger";
            this.colEndekslenmisDeger.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EndekslenmisDeger", "{0:n4}")});
            this.colEndekslenmisDeger.Visible = true;
            this.colEndekslenmisDeger.VisibleIndex = 13;
            // 
            // colEndekslenmisAmortisman
            // 
            this.colEndekslenmisAmortisman.DisplayFormat.FormatString = "n2";
            this.colEndekslenmisAmortisman.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colEndekslenmisAmortisman.FieldName = "EndekslenmisAmortisman";
            this.colEndekslenmisAmortisman.Name = "colEndekslenmisAmortisman";
            this.colEndekslenmisAmortisman.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EndekslenmisAmortisman", "{0:n4}")});
            this.colEndekslenmisAmortisman.Visible = true;
            this.colEndekslenmisAmortisman.VisibleIndex = 14;
            // 
            // colKalanDeger
            // 
            this.colKalanDeger.DisplayFormat.FormatString = "n2";
            this.colKalanDeger.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colKalanDeger.FieldName = "KalanDeger";
            this.colKalanDeger.Name = "colKalanDeger";
            this.colKalanDeger.OptionsColumn.ReadOnly = true;
            this.colKalanDeger.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KalanDeger", "{0:n4}")});
            this.colKalanDeger.Visible = true;
            this.colKalanDeger.VisibleIndex = 15;
            // 
            // colCariYilAmortisman
            // 
            this.colCariYilAmortisman.DisplayFormat.FormatString = "n2";
            this.colCariYilAmortisman.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colCariYilAmortisman.FieldName = "CariYilAmortisman";
            this.colCariYilAmortisman.Name = "colCariYilAmortisman";
            this.colCariYilAmortisman.OptionsColumn.ReadOnly = true;
            this.colCariYilAmortisman.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CariYilAmortisman", "{0:n4}")});
            this.colCariYilAmortisman.Visible = true;
            this.colCariYilAmortisman.VisibleIndex = 16;
            // 
            // colAylikAmortisman
            // 
            this.colAylikAmortisman.DisplayFormat.FormatString = "n2";
            this.colAylikAmortisman.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colAylikAmortisman.FieldName = "AylikAmortisman";
            this.colAylikAmortisman.Name = "colAylikAmortisman";
            this.colAylikAmortisman.OptionsColumn.ReadOnly = true;
            this.colAylikAmortisman.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AylikAmortisman", "{0:n4}")});
            this.colAylikAmortisman.Visible = true;
            this.colAylikAmortisman.VisibleIndex = 17;
            // 
            // colToplamBirikmisAmortisman
            // 
            this.colToplamBirikmisAmortisman.DisplayFormat.FormatString = "n2";
            this.colToplamBirikmisAmortisman.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colToplamBirikmisAmortisman.FieldName = "ToplamBirikmisAmortisman";
            this.colToplamBirikmisAmortisman.Name = "colToplamBirikmisAmortisman";
            this.colToplamBirikmisAmortisman.OptionsColumn.ReadOnly = true;
            this.colToplamBirikmisAmortisman.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ToplamBirikmisAmortisman", "{0:n4}")});
            this.colToplamBirikmisAmortisman.Visible = true;
            this.colToplamBirikmisAmortisman.VisibleIndex = 18;
            // 
            // colSabitKiymetEnflasyonFarki
            // 
            this.colSabitKiymetEnflasyonFarki.DisplayFormat.FormatString = "n2";
            this.colSabitKiymetEnflasyonFarki.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colSabitKiymetEnflasyonFarki.FieldName = "SabitKiymetEnflasyonFarki";
            this.colSabitKiymetEnflasyonFarki.Name = "colSabitKiymetEnflasyonFarki";
            this.colSabitKiymetEnflasyonFarki.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SabitKiymetEnflasyonFarki", "{0:n4}")});
            this.colSabitKiymetEnflasyonFarki.ToolTip = "Sabit Kıymet Enflasyon Farkı";
            this.colSabitKiymetEnflasyonFarki.Visible = true;
            this.colSabitKiymetEnflasyonFarki.VisibleIndex = 19;
            // 
            // colAmortismanEnflasyonFarki
            // 
            this.colAmortismanEnflasyonFarki.DisplayFormat.FormatString = "n2";
            this.colAmortismanEnflasyonFarki.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colAmortismanEnflasyonFarki.FieldName = "AmortismanEnflasyonFarki";
            this.colAmortismanEnflasyonFarki.Name = "colAmortismanEnflasyonFarki";
            this.colAmortismanEnflasyonFarki.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmortismanEnflasyonFarki", "{0:n4}")});
            this.colAmortismanEnflasyonFarki.ToolTip = "Amortisman Enflasyon Farkı";
            this.colAmortismanEnflasyonFarki.Visible = true;
            this.colAmortismanEnflasyonFarki.VisibleIndex = 20;
            // 
            // denemeamortismanBindingSource
            // 
            this.denemeamortismanBindingSource.DataMember = "denemeamortisman";
            this.denemeamortismanBindingSource.DataSource = this.dsAmortisman;
            // 
            // dsAmortisman
            // 
            this.dsAmortisman.DataSetName = "dsAmortisman";
            this.dsAmortisman.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // denemeamortismanTableAdapter
            // 
            this.denemeamortismanTableAdapter.ClearBeforeFill = true;
            // 
            // amortHesaplariBindingSource
            // 
            this.amortHesaplariBindingSource.DataMember = "AmortHesaplari";
            this.amortHesaplariBindingSource.DataSource = this.dsAmortisman;
            // 
            // amortHesaplariTableAdapter
            // 
            this.amortHesaplariTableAdapter.ClearBeforeFill = true;
            // 
            // tumAmortismanHesaplariBindingSource
            // 
            this.tumAmortismanHesaplariBindingSource.DataMember = "TumAmortismanHesaplari";
            this.tumAmortismanHesaplariBindingSource.DataSource = this.dsAmortisman;
            // 
            // tumAmortismanHesaplariTableAdapter
            // 
            this.tumAmortismanHesaplariTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 485);
            this.Controls.Add(this.gridAmortismanlar);
            this.Controls.Add(this.pnNormal);
            this.Name = "Form1";
            this.Text = "Amortisman Hesaplama";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnNormal.ResumeLayout(false);
            this.pnNormal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkEnflasyon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdEnflasyon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEnflasyonBitisAyi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEnflasyonBaslangicAyi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEnflasyonBitisYili.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEnflasyonBaslangicYili.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDonemAyi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAmortismanlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.denemeamortismanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAmortisman)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amortHesaplariBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tumAmortismanHesaplariBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnNormal;
        private DevExpress.XtraEditors.CheckEdit chkEnflasyon;
        private DevExpress.XtraEditors.RadioGroup rdEnflasyon;
        private DevExpress.XtraEditors.ComboBoxEdit cmbEnflasyonBitisAyi;
        private DevExpress.XtraEditors.ComboBoxEdit cmbEnflasyonBaslangicAyi;
        private DevExpress.XtraEditors.ComboBoxEdit cmbEnflasyonBitisYili;
        private DevExpress.XtraEditors.ComboBoxEdit cmbEnflasyonBaslangicYili;
        private DevExpress.XtraEditors.ComboBoxEdit cmbDonemAyi;
        private System.Windows.Forms.Label lblEnflasyonBitisAyi;
        private System.Windows.Forms.Label lblEnflasyonAyi;
        private System.Windows.Forms.Label lblEnflasyonBitisYili;
        private System.Windows.Forms.Label lblEnflasyonBYili;
        private System.Windows.Forms.Label lblDonemYili;
        private System.Windows.Forms.Label lblDonemAyi;
        private System.Windows.Forms.TextBox txtDonemYili;
        private DevExpress.XtraEditors.SimpleButton btnTemizle;
        private DevExpress.XtraEditors.SimpleButton btnExceleAktar;
        private DevExpress.XtraEditors.SimpleButton btnKayitlariAktar;
        private DevExpress.XtraEditors.SimpleButton btnDemirbaslariGetir;
        private DevExpress.XtraGrid.GridControl gridAmortismanlar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colSabitKiymetKodu;
        private DevExpress.XtraGrid.Columns.GridColumn colSabitKiymetAdi;
        private DevExpress.XtraGrid.Columns.GridColumn colAmortismanHesabi;
        private DevExpress.XtraGrid.Columns.GridColumn colMuhasebeHesabi;
        private DevExpress.XtraGrid.Columns.GridColumn colGiderHesabi;
        private DevExpress.XtraGrid.Columns.GridColumn colBaslangicYili;
        private DevExpress.XtraGrid.Columns.GridColumn colBaslangicAyi;
        private DevExpress.XtraGrid.Columns.GridColumn colBitisYili;
        private DevExpress.XtraGrid.Columns.GridColumn colBitisAyi;
        private DevExpress.XtraGrid.Columns.GridColumn coliktisabDegeri;
        private DevExpress.XtraGrid.Columns.GridColumn colEndekseTabiDeger;
        private DevExpress.XtraGrid.Columns.GridColumn colEndekseTabiAmortisman;
        private DevExpress.XtraGrid.Columns.GridColumn colKatSayisi;
        private DevExpress.XtraGrid.Columns.GridColumn colEndekslenmisDeger;
        private DevExpress.XtraGrid.Columns.GridColumn colEndekslenmisAmortisman;
        private DevExpress.XtraGrid.Columns.GridColumn colKalanDeger;
        private DevExpress.XtraGrid.Columns.GridColumn colCariYilAmortisman;
        private DevExpress.XtraGrid.Columns.GridColumn colAylikAmortisman;
        private DevExpress.XtraGrid.Columns.GridColumn colToplamBirikmisAmortisman;
        private DevExpress.XtraGrid.Columns.GridColumn colSabitKiymetEnflasyonFarki;
        private DevExpress.XtraGrid.Columns.GridColumn colAmortismanEnflasyonFarki;
        private dsAmortisman dsAmortisman;
        private System.Windows.Forms.BindingSource denemeamortismanBindingSource;
        private dsAmortismanTableAdapters.denemeamortismanTableAdapter denemeamortismanTableAdapter;
        private dsAmortismanTableAdapters.SqlQueryler sqlQueryler1;
        private System.Windows.Forms.BindingSource amortHesaplariBindingSource;
        private dsAmortismanTableAdapters.AmortHesaplariTableAdapter amortHesaplariTableAdapter;
        private System.Windows.Forms.BindingSource tumAmortismanHesaplariBindingSource;
        private dsAmortismanTableAdapters.TumAmortismanHesaplariTableAdapter tumAmortismanHesaplariTableAdapter;
    }
}