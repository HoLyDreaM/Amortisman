namespace Sifas_Amortisman
{
    partial class AnaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaForm));
            this.timerTarih = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblSirketName = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSirket = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblKayanYazi = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTarihAyari = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTarih = new System.Windows.Forms.ToolStripStatusLabel();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.btnTefeTufeOranlari = new DevExpress.XtraEditors.SimpleButton();
            this.btnAmortismanHesaplama = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.BarMenuStilAyari = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnLoginAyari = new DevExpress.XtraBars.BarButtonItem();
            this.btnGuncelle = new DevExpress.XtraBars.BarButtonItem();
            this.btnEmailAyarlari = new DevExpress.XtraBars.BarButtonItem();
            this.rbMenu = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.Login = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // timerTarih
            // 
            this.timerTarih.Enabled = true;
            this.timerTarih.Tick += new System.EventHandler(this.timerTarih_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSirketName,
            this.lblSirket,
            this.lblKayanYazi,
            this.lblTarihAyari,
            this.lblTarih});
            this.statusStrip1.Location = new System.Drawing.Point(220, 496);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(655, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblSirketName
            // 
            this.lblSirketName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSirketName.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblSirketName.Image = global::Sifas_Amortisman.Properties.Resources.sirket;
            this.lblSirketName.Name = "lblSirketName";
            this.lblSirketName.Size = new System.Drawing.Size(63, 17);
            this.lblSirketName.Text = "Şirket :";
            // 
            // lblSirket
            // 
            this.lblSirket.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSirket.Name = "lblSirket";
            this.lblSirket.Size = new System.Drawing.Size(0, 17);
            // 
            // lblKayanYazi
            // 
            this.lblKayanYazi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKayanYazi.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblKayanYazi.Name = "lblKayanYazi";
            this.lblKayanYazi.Size = new System.Drawing.Size(561, 17);
            this.lblKayanYazi.Spring = true;
            // 
            // lblTarihAyari
            // 
            this.lblTarihAyari.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTarihAyari.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTarihAyari.Image = global::Sifas_Amortisman.Properties.Resources.saat;
            this.lblTarihAyari.Name = "lblTarihAyari";
            this.lblTarihAyari.Size = new System.Drawing.Size(16, 17);
            // 
            // lblTarih
            // 
            this.lblTarih.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTarih.Name = "lblTarih";
            this.lblTarih.Size = new System.Drawing.Size(0, 17);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockManager = this.dockManager1;
            this.barManager1.Form = this;
            this.barManager1.MaxItemId = 0;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(875, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 518);
            this.barDockControlBottom.Size = new System.Drawing.Size(875, 21);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 518);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(875, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 518);
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.MenuManager = this.barManager1;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Appearance.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.dockPanel1.Appearance.Options.UseBackColor = true;
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("15b70545-8e6d-4ec4-a0e8-76f422682d28");
            this.dockPanel1.Location = new System.Drawing.Point(0, 140);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(220, 200);
            this.dockPanel1.Size = new System.Drawing.Size(220, 378);
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.btnTefeTufeOranlari);
            this.dockPanel1_Container.Controls.Add(this.btnAmortismanHesaplama);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 25);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(212, 349);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // btnTefeTufeOranlari
            // 
            this.btnTefeTufeOranlari.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnTefeTufeOranlari.Appearance.Options.UseFont = true;
            this.btnTefeTufeOranlari.Location = new System.Drawing.Point(4, 59);
            this.btnTefeTufeOranlari.Name = "btnTefeTufeOranlari";
            this.btnTefeTufeOranlari.Size = new System.Drawing.Size(205, 30);
            this.btnTefeTufeOranlari.TabIndex = 14;
            this.btnTefeTufeOranlari.Text = "&Tefe - Tufe Oranları";
            this.btnTefeTufeOranlari.Click += new System.EventHandler(this.btnTefeTufeOranlari_Click);
            // 
            // btnAmortismanHesaplama
            // 
            this.btnAmortismanHesaplama.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnAmortismanHesaplama.Appearance.Options.UseFont = true;
            this.btnAmortismanHesaplama.Location = new System.Drawing.Point(4, 23);
            this.btnAmortismanHesaplama.Name = "btnAmortismanHesaplama";
            this.btnAmortismanHesaplama.Size = new System.Drawing.Size(205, 30);
            this.btnAmortismanHesaplama.TabIndex = 13;
            this.btnAmortismanHesaplama.Text = "&Amortisman Hesaplama";
            this.btnAmortismanHesaplama.Click += new System.EventHandler(this.btnAmortismanHesaplama_Click);
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // BarMenuStilAyari
            // 
            this.BarMenuStilAyari.LookAndFeel.SkinName = "Office 2010 Silver";
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.Name = "";
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnLoginAyari,
            this.btnGuncelle,
            this.btnEmailAyarlari});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 6;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbMenu});
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(875, 140);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // btnLoginAyari
            // 
            this.btnLoginAyari.Caption = "Giriş Ayarı";
            this.btnLoginAyari.Id = 1;
            this.btnLoginAyari.LargeGlyph = global::Sifas_Amortisman.Properties.Resources.login;
            this.btnLoginAyari.LargeWidth = 80;
            this.btnLoginAyari.Name = "btnLoginAyari";
            this.btnLoginAyari.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLoginAyari_ItemClick);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Id = 5;
            this.btnGuncelle.Name = "btnGuncelle";
            // 
            // btnEmailAyarlari
            // 
            this.btnEmailAyarlari.Caption = "E-Mail Ayarları";
            this.btnEmailAyarlari.Id = 4;
            this.btnEmailAyarlari.Name = "btnEmailAyarlari";
            // 
            // rbMenu
            // 
            this.rbMenu.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.Login});
            this.rbMenu.Name = "rbMenu";
            this.rbMenu.Text = "Menü";
            // 
            // Login
            // 
            this.Login.ItemLinks.Add(this.btnLoginAyari);
            this.Login.Name = "Login";
            // 
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 539);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "AnaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Şifaş Amortisman Hesaplama Ve Giriş İşlemleri";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AnaForm_FormClosing);
            this.Load += new System.EventHandler(this.AnaForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerTarih;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel lblSirketName;
        public System.Windows.Forms.ToolStripStatusLabel lblSirket;
        private System.Windows.Forms.ToolStripStatusLabel lblKayanYazi;
        private System.Windows.Forms.ToolStripStatusLabel lblTarihAyari;
        private System.Windows.Forms.ToolStripStatusLabel lblTarih;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel BarMenuStilAyari;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbMenu;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup Login;
        private DevExpress.XtraBars.BarButtonItem btnLoginAyari;
        private DevExpress.XtraEditors.SimpleButton btnAmortismanHesaplama;
        private DevExpress.XtraBars.BarButtonItem btnGuncelle;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        private DevExpress.XtraEditors.SimpleButton btnTefeTufeOranlari;
        private DevExpress.XtraBars.BarButtonItem btnEmailAyarlari;
    }
}