namespace Sifas_Amortisman
{
    partial class TefeTufeOranlari
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
            DevExpress.XtraPivotGrid.PivotGridStyleFormatCondition pivotGridStyleFormatCondition3 = new DevExpress.XtraPivotGrid.PivotGridStyleFormatCondition();
            DevExpress.XtraPivotGrid.PivotGridStyleFormatCondition pivotGridStyleFormatCondition4 = new DevExpress.XtraPivotGrid.PivotGridStyleFormatCondition();
            this.oranlarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsAmortisman = new Sifas_Amortisman.dsAmortisman();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTufe = new System.Windows.Forms.TextBox();
            this.txtTefe = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtAy = new System.Windows.Forms.TextBox();
            this.txtYil = new System.Windows.Forms.TextBox();
            this.btnOranSil = new DevExpress.XtraEditors.SimpleButton();
            this.btnOranlariExceleAktar = new DevExpress.XtraEditors.SimpleButton();
            this.btnOranDuzenle = new DevExpress.XtraEditors.SimpleButton();
            this.btnOranlariEkle = new DevExpress.XtraEditors.SimpleButton();
            this.cmbAy = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblTufeOrani = new System.Windows.Forms.Label();
            this.lblTefeOrani = new System.Windows.Forms.Label();
            this.lblOranAy = new System.Windows.Forms.Label();
            this.lblOranYil = new System.Windows.Forms.Label();
            this.excelKaydet = new System.Windows.Forms.SaveFileDialog();
            this.oranlarTableAdapter = new Sifas_Amortisman.dsAmortismanTableAdapters.OranlarTableAdapter();
            this.sqlQueryler1 = new Sifas_Amortisman.dsAmortismanTableAdapters.SqlQueryler();
            this.tableAdapterManager1 = new Sifas_Amortisman.dsAmortismanTableAdapters.TableAdapterManager();
            this.panel2 = new System.Windows.Forms.Panel();
            this.fieldAy1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldTufeOrani1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldTefeOrani1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldYil1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pvtOranlar = new DevExpress.XtraPivotGrid.PivotGridControl();
            ((System.ComponentModel.ISupportInitialize)(this.oranlarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAmortisman)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAy.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pvtOranlar)).BeginInit();
            this.SuspendLayout();
            // 
            // oranlarBindingSource
            // 
            this.oranlarBindingSource.DataMember = "Oranlar";
            this.oranlarBindingSource.DataSource = this.dsAmortisman;
            // 
            // dsAmortisman
            // 
            this.dsAmortisman.DataSetName = "dsAmortisman";
            this.dsAmortisman.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtTufe);
            this.panel1.Controls.Add(this.txtTefe);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.txtAy);
            this.panel1.Controls.Add(this.txtYil);
            this.panel1.Controls.Add(this.btnOranSil);
            this.panel1.Controls.Add(this.btnOranlariExceleAktar);
            this.panel1.Controls.Add(this.btnOranDuzenle);
            this.panel1.Controls.Add(this.btnOranlariEkle);
            this.panel1.Controls.Add(this.cmbAy);
            this.panel1.Controls.Add(this.lblTufeOrani);
            this.panel1.Controls.Add(this.lblTefeOrani);
            this.panel1.Controls.Add(this.lblOranAy);
            this.panel1.Controls.Add(this.lblOranYil);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(890, 112);
            this.panel1.TabIndex = 1;
            // 
            // txtTufe
            // 
            this.txtTufe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTufe.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.oranlarBindingSource, "TufeOrani", true));
            this.txtTufe.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTufe.Location = new System.Drawing.Point(435, 58);
            this.txtTufe.Name = "txtTufe";
            this.txtTufe.Size = new System.Drawing.Size(138, 23);
            this.txtTufe.TabIndex = 47;
            // 
            // txtTefe
            // 
            this.txtTefe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTefe.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.oranlarBindingSource, "TefeOrani", true));
            this.txtTefe.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTefe.Location = new System.Drawing.Point(435, 22);
            this.txtTefe.Name = "txtTefe";
            this.txtTefe.Size = new System.Drawing.Size(138, 23);
            this.txtTefe.TabIndex = 46;
            // 
            // txtID
            // 
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtID.Location = new System.Drawing.Point(12, 81);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(138, 23);
            this.txtID.TabIndex = 45;
            this.txtID.Visible = false;
            // 
            // txtAy
            // 
            this.txtAy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAy.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAy.Location = new System.Drawing.Point(153, 81);
            this.txtAy.Name = "txtAy";
            this.txtAy.Size = new System.Drawing.Size(138, 23);
            this.txtAy.TabIndex = 45;
            this.txtAy.Visible = false;
            // 
            // txtYil
            // 
            this.txtYil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYil.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.oranlarBindingSource, "Yil", true));
            this.txtYil.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtYil.Location = new System.Drawing.Point(150, 22);
            this.txtYil.Name = "txtYil";
            this.txtYil.Size = new System.Drawing.Size(138, 23);
            this.txtYil.TabIndex = 45;
            // 
            // btnOranSil
            // 
            this.btnOranSil.Location = new System.Drawing.Point(624, 83);
            this.btnOranSil.Name = "btnOranSil";
            this.btnOranSil.Size = new System.Drawing.Size(175, 23);
            this.btnOranSil.TabIndex = 6;
            this.btnOranSil.Text = "&Oran Sil";
            this.btnOranSil.Click += new System.EventHandler(this.btnOranSil_Click);
            // 
            // btnOranlariExceleAktar
            // 
            this.btnOranlariExceleAktar.Location = new System.Drawing.Point(624, 58);
            this.btnOranlariExceleAktar.Name = "btnOranlariExceleAktar";
            this.btnOranlariExceleAktar.Size = new System.Drawing.Size(175, 23);
            this.btnOranlariExceleAktar.TabIndex = 5;
            this.btnOranlariExceleAktar.Text = "&Oranları Excel e Aktar";
            this.btnOranlariExceleAktar.Click += new System.EventHandler(this.btnOranlariExceleAktar_Click);
            // 
            // btnOranDuzenle
            // 
            this.btnOranDuzenle.Location = new System.Drawing.Point(624, 32);
            this.btnOranDuzenle.Name = "btnOranDuzenle";
            this.btnOranDuzenle.Size = new System.Drawing.Size(175, 23);
            this.btnOranDuzenle.TabIndex = 4;
            this.btnOranDuzenle.Text = "&Tefe - Tüfe Oranlarını Düzenle";
            this.btnOranDuzenle.Click += new System.EventHandler(this.btnOranDuzenle_Click);
            // 
            // btnOranlariEkle
            // 
            this.btnOranlariEkle.Location = new System.Drawing.Point(624, 5);
            this.btnOranlariEkle.Name = "btnOranlariEkle";
            this.btnOranlariEkle.Size = new System.Drawing.Size(175, 23);
            this.btnOranlariEkle.TabIndex = 4;
            this.btnOranlariEkle.Text = "&Tefe - Tüfe Oranlarını Ekle";
            this.btnOranlariEkle.Click += new System.EventHandler(this.btnOranlariEkle_Click);
            // 
            // cmbAy
            // 
            this.cmbAy.EditValue = "01-OCAK";
            this.cmbAy.EnterMoveNextControl = true;
            this.cmbAy.Location = new System.Drawing.Point(150, 56);
            this.cmbAy.Name = "cmbAy";
            this.cmbAy.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.cmbAy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbAy.Properties.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Standard;
            this.cmbAy.Properties.Items.AddRange(new object[] {
            "01-OCAK",
            "02-ŞUBAT",
            "03-MART",
            "04-NİSAN",
            "05-MAYIS",
            "06-HAZİRAN",
            "07-TEMMUZ",
            "08-AĞUSTOS",
            "09-EYLÜL",
            "10-EKİM",
            "11-KASIM",
            "12-ARALIK"});
            this.cmbAy.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbAy.Size = new System.Drawing.Size(138, 22);
            this.cmbAy.TabIndex = 1;
            // 
            // lblTufeOrani
            // 
            this.lblTufeOrani.BackColor = System.Drawing.Color.Silver;
            this.lblTufeOrani.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTufeOrani.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTufeOrani.Location = new System.Drawing.Point(297, 58);
            this.lblTufeOrani.Name = "lblTufeOrani";
            this.lblTufeOrani.Size = new System.Drawing.Size(138, 23);
            this.lblTufeOrani.TabIndex = 44;
            this.lblTufeOrani.Text = "Tüfe Oranı";
            this.lblTufeOrani.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTefeOrani
            // 
            this.lblTefeOrani.BackColor = System.Drawing.Color.Silver;
            this.lblTefeOrani.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTefeOrani.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTefeOrani.Location = new System.Drawing.Point(297, 22);
            this.lblTefeOrani.Name = "lblTefeOrani";
            this.lblTefeOrani.Size = new System.Drawing.Size(138, 23);
            this.lblTefeOrani.TabIndex = 44;
            this.lblTefeOrani.Text = "Tefe Oranı";
            this.lblTefeOrani.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOranAy
            // 
            this.lblOranAy.BackColor = System.Drawing.Color.Silver;
            this.lblOranAy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOranAy.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblOranAy.Location = new System.Drawing.Point(12, 55);
            this.lblOranAy.Name = "lblOranAy";
            this.lblOranAy.Size = new System.Drawing.Size(138, 23);
            this.lblOranAy.TabIndex = 44;
            this.lblOranAy.Text = "Ay";
            this.lblOranAy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOranYil
            // 
            this.lblOranYil.BackColor = System.Drawing.Color.Silver;
            this.lblOranYil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOranYil.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblOranYil.Location = new System.Drawing.Point(12, 22);
            this.lblOranYil.Name = "lblOranYil";
            this.lblOranYil.Size = new System.Drawing.Size(138, 23);
            this.lblOranYil.TabIndex = 44;
            this.lblOranYil.Text = "Yıl";
            this.lblOranYil.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // oranlarTableAdapter
            // 
            this.oranlarTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.AmortHesaplariTableAdapter = null;
            this.tableAdapterManager1.AmortismanlarTableAdapter = null;
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.DemirbasKartiTableAdapter = null;
            this.tableAdapterManager1.OranlarTableAdapter = this.oranlarTableAdapter;
            this.tableAdapterManager1.UpdateOrder = Sifas_Amortisman.dsAmortismanTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pvtOranlar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 112);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(890, 332);
            this.panel2.TabIndex = 2;
            // 
            // fieldAy1
            // 
            this.fieldAy1.Appearance.Cell.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fieldAy1.Appearance.Cell.Options.UseFont = true;
            this.fieldAy1.Appearance.Header.BackColor = System.Drawing.Color.DarkGray;
            this.fieldAy1.Appearance.Header.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fieldAy1.Appearance.Header.Options.UseBackColor = true;
            this.fieldAy1.Appearance.Header.Options.UseFont = true;
            this.fieldAy1.Appearance.Header.Options.UseTextOptions = true;
            this.fieldAy1.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldAy1.Appearance.Header.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.fieldAy1.Appearance.Value.BackColor = System.Drawing.Color.DarkGray;
            this.fieldAy1.Appearance.Value.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fieldAy1.Appearance.Value.Options.UseBackColor = true;
            this.fieldAy1.Appearance.Value.Options.UseFont = true;
            this.fieldAy1.Appearance.Value.Options.UseTextOptions = true;
            this.fieldAy1.Appearance.Value.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldAy1.Appearance.Value.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.fieldAy1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldAy1.AreaIndex = 0;
            this.fieldAy1.Caption = "Ay";
            this.fieldAy1.FieldName = "Ay";
            this.fieldAy1.Name = "fieldAy1";
            this.fieldAy1.Options.ReadOnly = true;
            this.fieldAy1.UnboundType = DevExpress.Data.UnboundColumnType.String;
            // 
            // fieldTufeOrani1
            // 
            this.fieldTufeOrani1.Appearance.Cell.Options.UseTextOptions = true;
            this.fieldTufeOrani1.Appearance.Cell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldTufeOrani1.Appearance.Cell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.fieldTufeOrani1.Appearance.Header.BackColor = System.Drawing.Color.SteelBlue;
            this.fieldTufeOrani1.Appearance.Header.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fieldTufeOrani1.Appearance.Header.Options.UseBackColor = true;
            this.fieldTufeOrani1.Appearance.Header.Options.UseFont = true;
            this.fieldTufeOrani1.Appearance.Value.BackColor = System.Drawing.Color.SteelBlue;
            this.fieldTufeOrani1.Appearance.Value.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fieldTufeOrani1.Appearance.Value.ForeColor = System.Drawing.Color.Black;
            this.fieldTufeOrani1.Appearance.Value.Options.UseBackColor = true;
            this.fieldTufeOrani1.Appearance.Value.Options.UseFont = true;
            this.fieldTufeOrani1.Appearance.Value.Options.UseForeColor = true;
            this.fieldTufeOrani1.Appearance.Value.Options.UseTextOptions = true;
            this.fieldTufeOrani1.Appearance.Value.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldTufeOrani1.Appearance.Value.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.fieldTufeOrani1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldTufeOrani1.AreaIndex = 1;
            this.fieldTufeOrani1.Caption = "Tüfe Oranı";
            this.fieldTufeOrani1.FieldName = "TufeOrani";
            this.fieldTufeOrani1.Name = "fieldTufeOrani1";
            this.fieldTufeOrani1.Options.ReadOnly = true;
            this.fieldTufeOrani1.UnboundType = DevExpress.Data.UnboundColumnType.String;
            // 
            // fieldTefeOrani1
            // 
            this.fieldTefeOrani1.Appearance.Cell.Options.UseTextOptions = true;
            this.fieldTefeOrani1.Appearance.Cell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldTefeOrani1.Appearance.Cell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.fieldTefeOrani1.Appearance.Header.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.fieldTefeOrani1.Appearance.Header.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fieldTefeOrani1.Appearance.Header.Options.UseBackColor = true;
            this.fieldTefeOrani1.Appearance.Header.Options.UseFont = true;
            this.fieldTefeOrani1.Appearance.Value.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.fieldTefeOrani1.Appearance.Value.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fieldTefeOrani1.Appearance.Value.ForeColor = System.Drawing.Color.Black;
            this.fieldTefeOrani1.Appearance.Value.Options.UseBackColor = true;
            this.fieldTefeOrani1.Appearance.Value.Options.UseFont = true;
            this.fieldTefeOrani1.Appearance.Value.Options.UseForeColor = true;
            this.fieldTefeOrani1.Appearance.Value.Options.UseTextOptions = true;
            this.fieldTefeOrani1.Appearance.Value.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldTefeOrani1.Appearance.Value.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.fieldTefeOrani1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldTefeOrani1.AreaIndex = 0;
            this.fieldTefeOrani1.Caption = "Tefe Oranı";
            this.fieldTefeOrani1.FieldName = "TefeOrani";
            this.fieldTefeOrani1.Name = "fieldTefeOrani1";
            this.fieldTefeOrani1.Options.ReadOnly = true;
            this.fieldTefeOrani1.UnboundType = DevExpress.Data.UnboundColumnType.String;
            // 
            // fieldYil1
            // 
            this.fieldYil1.Appearance.Cell.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fieldYil1.Appearance.Cell.Options.UseFont = true;
            this.fieldYil1.Appearance.Cell.Options.UseTextOptions = true;
            this.fieldYil1.Appearance.Cell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldYil1.Appearance.Cell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.fieldYil1.Appearance.Header.BackColor = System.Drawing.Color.DarkGray;
            this.fieldYil1.Appearance.Header.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fieldYil1.Appearance.Header.Options.UseBackColor = true;
            this.fieldYil1.Appearance.Header.Options.UseFont = true;
            this.fieldYil1.Appearance.Header.Options.UseTextOptions = true;
            this.fieldYil1.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldYil1.Appearance.Header.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.fieldYil1.Appearance.Value.BackColor = System.Drawing.Color.DarkGray;
            this.fieldYil1.Appearance.Value.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fieldYil1.Appearance.Value.Options.UseBackColor = true;
            this.fieldYil1.Appearance.Value.Options.UseFont = true;
            this.fieldYil1.Appearance.Value.Options.UseTextOptions = true;
            this.fieldYil1.Appearance.Value.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldYil1.Appearance.Value.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.fieldYil1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldYil1.AreaIndex = 0;
            this.fieldYil1.Caption = "Yil";
            this.fieldYil1.FieldName = "Yil";
            this.fieldYil1.Name = "fieldYil1";
            this.fieldYil1.Options.ReadOnly = true;
            this.fieldYil1.Width = 200;
            // 
            // pvtOranlar
            // 
            this.pvtOranlar.DataSource = this.oranlarBindingSource;
            this.pvtOranlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pvtOranlar.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.fieldYil1,
            this.fieldTefeOrani1,
            this.fieldTufeOrani1,
            this.fieldAy1});
            pivotGridStyleFormatCondition3.Appearance.BackColor = System.Drawing.Color.DarkOrange;
            pivotGridStyleFormatCondition3.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            pivotGridStyleFormatCondition3.Appearance.ForeColor = System.Drawing.Color.Black;
            pivotGridStyleFormatCondition3.Appearance.Options.UseBackColor = true;
            pivotGridStyleFormatCondition3.Appearance.Options.UseFont = true;
            pivotGridStyleFormatCondition3.Appearance.Options.UseForeColor = true;
            pivotGridStyleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            pivotGridStyleFormatCondition3.Expression = "[TefeOrani]  > 0";
            pivotGridStyleFormatCondition3.Field = this.fieldTefeOrani1;
            pivotGridStyleFormatCondition3.FieldName = "fieldTefeOrani1";
            pivotGridStyleFormatCondition4.Appearance.BackColor = System.Drawing.Color.DarkGreen;
            pivotGridStyleFormatCondition4.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            pivotGridStyleFormatCondition4.Appearance.ForeColor = System.Drawing.Color.White;
            pivotGridStyleFormatCondition4.Appearance.Options.UseBackColor = true;
            pivotGridStyleFormatCondition4.Appearance.Options.UseFont = true;
            pivotGridStyleFormatCondition4.Appearance.Options.UseForeColor = true;
            pivotGridStyleFormatCondition4.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            pivotGridStyleFormatCondition4.Expression = "[TufeOrani] > 0";
            pivotGridStyleFormatCondition4.Field = this.fieldTufeOrani1;
            pivotGridStyleFormatCondition4.FieldName = "fieldTufeOrani1";
            this.pvtOranlar.FormatConditions.AddRange(new DevExpress.XtraPivotGrid.PivotGridStyleFormatCondition[] {
            pivotGridStyleFormatCondition3,
            pivotGridStyleFormatCondition4});
            this.pvtOranlar.Location = new System.Drawing.Point(0, 0);
            this.pvtOranlar.Name = "pvtOranlar";
            this.pvtOranlar.OptionsSelection.EnableAppearanceFocusedCell = true;
            this.pvtOranlar.OptionsView.ShowColumnGrandTotalHeader = false;
            this.pvtOranlar.OptionsView.ShowColumnGrandTotals = false;
            this.pvtOranlar.OptionsView.ShowColumnTotals = false;
            this.pvtOranlar.OptionsView.ShowFilterHeaders = false;
            this.pvtOranlar.OptionsView.ShowRowGrandTotalHeader = false;
            this.pvtOranlar.OptionsView.ShowRowGrandTotals = false;
            this.pvtOranlar.Size = new System.Drawing.Size(890, 332);
            this.pvtOranlar.TabIndex = 0;
            this.pvtOranlar.CellClick += new DevExpress.XtraPivotGrid.PivotCellEventHandler(this.pvtOranlar_CellClick);
            // 
            // TefeTufeOranlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 444);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "TefeTufeOranlari";
            this.Text = "Tefe - Tüfe Oranları";
            this.Load += new System.EventHandler(this.TefeTufeOranlari_Load);
            ((System.ComponentModel.ISupportInitialize)(this.oranlarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAmortisman)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAy.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pvtOranlar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private dsAmortisman dsAmortisman;
        private System.Windows.Forms.BindingSource oranlarBindingSource;
        private dsAmortismanTableAdapters.OranlarTableAdapter oranlarTableAdapter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTufeOrani;
        private System.Windows.Forms.Label lblTefeOrani;
        private System.Windows.Forms.Label lblOranAy;
        private System.Windows.Forms.Label lblOranYil;
        private DevExpress.XtraEditors.SimpleButton btnOranlariExceleAktar;
        private DevExpress.XtraEditors.SimpleButton btnOranlariEkle;
        private DevExpress.XtraEditors.ComboBoxEdit cmbAy;
        private dsAmortismanTableAdapters.SqlQueryler sqlQueryler1;
        private System.Windows.Forms.SaveFileDialog excelKaydet;
        private DevExpress.XtraEditors.SimpleButton btnOranSil;
        private DevExpress.XtraEditors.SimpleButton btnOranDuzenle;
        private System.Windows.Forms.TextBox txtTefe;
        private System.Windows.Forms.TextBox txtYil;
        public System.Windows.Forms.TextBox txtTufe;
        private dsAmortismanTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtAy;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraPivotGrid.PivotGridControl pvtOranlar;
        private DevExpress.XtraPivotGrid.PivotGridField fieldYil1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldTefeOrani1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldTufeOrani1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldAy1;
    }
}