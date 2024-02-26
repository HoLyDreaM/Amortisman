namespace Sifas_Amortisman
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.lblServerAdi = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtSirket = new System.Windows.Forms.TextBox();
            this.lblSirketAdi = new System.Windows.Forms.Label();
            this.oto = new System.Windows.Forms.CheckBox();
            this.btnBaglan = new System.Windows.Forms.Button();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.lblKullaniciAdi = new System.Windows.Forms.Label();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.lblSifre = new System.Windows.Forms.Label();
            this.lblOranlar = new System.Windows.Forms.Label();
            this.txtOranlar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblServerAdi
            // 
            this.lblServerAdi.BackColor = System.Drawing.Color.Silver;
            this.lblServerAdi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblServerAdi.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblServerAdi.Location = new System.Drawing.Point(8, 142);
            this.lblServerAdi.Name = "lblServerAdi";
            this.lblServerAdi.Size = new System.Drawing.Size(117, 20);
            this.lblServerAdi.TabIndex = 43;
            this.lblServerAdi.Text = "Server Adı";
            this.lblServerAdi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtServer
            // 
            this.txtServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtServer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.txtServer.Location = new System.Drawing.Point(125, 142);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(196, 22);
            this.txtServer.TabIndex = 0;
            // 
            // txtSirket
            // 
            this.txtSirket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSirket.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.txtSirket.Location = new System.Drawing.Point(125, 165);
            this.txtSirket.Name = "txtSirket";
            this.txtSirket.Size = new System.Drawing.Size(196, 22);
            this.txtSirket.TabIndex = 1;
            // 
            // lblSirketAdi
            // 
            this.lblSirketAdi.BackColor = System.Drawing.Color.Silver;
            this.lblSirketAdi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSirketAdi.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSirketAdi.Location = new System.Drawing.Point(8, 165);
            this.lblSirketAdi.Name = "lblSirketAdi";
            this.lblSirketAdi.Size = new System.Drawing.Size(117, 20);
            this.lblSirketAdi.TabIndex = 43;
            this.lblSirketAdi.Text = "Şirket Adı";
            this.lblSirketAdi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // oto
            // 
            this.oto.AutoSize = true;
            this.oto.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.oto.Location = new System.Drawing.Point(205, 294);
            this.oto.Name = "oto";
            this.oto.Size = new System.Drawing.Size(116, 18);
            this.oto.TabIndex = 6;
            this.oto.Text = "Otomatik Bağlan";
            this.oto.UseVisualStyleBackColor = true;
            // 
            // btnBaglan
            // 
            this.btnBaglan.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.btnBaglan.Location = new System.Drawing.Point(125, 264);
            this.btnBaglan.Name = "btnBaglan";
            this.btnBaglan.Size = new System.Drawing.Size(196, 23);
            this.btnBaglan.TabIndex = 5;
            this.btnBaglan.Text = "Bağlan";
            this.btnBaglan.UseVisualStyleBackColor = true;
            this.btnBaglan.Click += new System.EventHandler(this.btnBaglan_Click);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::Sifas_Amortisman.Properties.Resources.logo;
            this.pictureEdit1.Location = new System.Drawing.Point(9, 7);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.pictureEdit1.Size = new System.Drawing.Size(312, 128);
            this.pictureEdit1.TabIndex = 46;
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKullaniciAdi.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.txtKullaniciAdi.Location = new System.Drawing.Point(125, 213);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(196, 22);
            this.txtKullaniciAdi.TabIndex = 3;
            // 
            // lblKullaniciAdi
            // 
            this.lblKullaniciAdi.BackColor = System.Drawing.Color.Silver;
            this.lblKullaniciAdi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKullaniciAdi.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKullaniciAdi.Location = new System.Drawing.Point(8, 213);
            this.lblKullaniciAdi.Name = "lblKullaniciAdi";
            this.lblKullaniciAdi.Size = new System.Drawing.Size(117, 20);
            this.lblKullaniciAdi.TabIndex = 43;
            this.lblKullaniciAdi.Text = "Kullanıcı Adı";
            this.lblKullaniciAdi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSifre
            // 
            this.txtSifre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSifre.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.txtSifre.Location = new System.Drawing.Point(125, 237);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '*';
            this.txtSifre.Size = new System.Drawing.Size(196, 22);
            this.txtSifre.TabIndex = 4;
            // 
            // lblSifre
            // 
            this.lblSifre.BackColor = System.Drawing.Color.Silver;
            this.lblSifre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSifre.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSifre.Location = new System.Drawing.Point(8, 236);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new System.Drawing.Size(117, 20);
            this.lblSifre.TabIndex = 43;
            this.lblSifre.Text = "Şifre";
            this.lblSifre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOranlar
            // 
            this.lblOranlar.BackColor = System.Drawing.Color.Silver;
            this.lblOranlar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOranlar.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblOranlar.Location = new System.Drawing.Point(8, 189);
            this.lblOranlar.Name = "lblOranlar";
            this.lblOranlar.Size = new System.Drawing.Size(117, 20);
            this.lblOranlar.TabIndex = 43;
            this.lblOranlar.Text = "Oranlar Veritabanı";
            this.lblOranlar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtOranlar
            // 
            this.txtOranlar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOranlar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.txtOranlar.Location = new System.Drawing.Point(125, 188);
            this.txtOranlar.Name = "txtOranlar";
            this.txtOranlar.Size = new System.Drawing.Size(196, 22);
            this.txtOranlar.TabIndex = 2;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 339);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.oto);
            this.Controls.Add(this.btnBaglan);
            this.Controls.Add(this.lblSifre);
            this.Controls.Add(this.lblKullaniciAdi);
            this.Controls.Add(this.lblOranlar);
            this.Controls.Add(this.lblSirketAdi);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.txtKullaniciAdi);
            this.Controls.Add(this.txtOranlar);
            this.Controls.Add(this.txtSirket);
            this.Controls.Add(this.lblServerAdi);
            this.Controls.Add(this.txtServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sifaş Amortisman Giriş ";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblServerAdi;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtSirket;
        private System.Windows.Forms.Label lblSirketAdi;
        private System.Windows.Forms.CheckBox oto;
        private System.Windows.Forms.Button btnBaglan;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.Label lblKullaniciAdi;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Label lblSifre;
        private System.Windows.Forms.Label lblOranlar;
        private System.Windows.Forms.TextBox txtOranlar;
    }
}