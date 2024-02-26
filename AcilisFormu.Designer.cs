namespace Sifas_Amortisman
{
    partial class AcilisFormu
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
            this.panelUst = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtDizin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pb = new DevExpress.XtraEditors.ProgressBarControl();
            this.btnKartlariAktar = new System.Windows.Forms.Button();
            this.btnHazirla = new System.Windows.Forms.Button();
            this.btnBelgeSec = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.belgeSec = new System.Windows.Forms.OpenFileDialog();
            this.dsAmortisman = new Sifas_Amortisman.dsAmortisman();
            this.geciciTabloBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sqlQueryler1 = new Sifas_Amortisman.dsAmortismanTableAdapters.SqlQueryler();
            this.panelUst.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAmortisman)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.geciciTabloBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelUst
            // 
            this.panelUst.Controls.Add(this.groupBox3);
            this.panelUst.Controls.Add(this.groupBox1);
            this.panelUst.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUst.Location = new System.Drawing.Point(0, 0);
            this.panelUst.Name = "panelUst";
            this.panelUst.Size = new System.Drawing.Size(802, 133);
            this.panelUst.TabIndex = 12;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtDizin);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(12, 59);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(778, 48);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            // 
            // txtDizin
            // 
            this.txtDizin.BackColor = System.Drawing.Color.Honeydew;
            this.txtDizin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDizin.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtDizin.Location = new System.Drawing.Point(124, 16);
            this.txtDizin.Name = "txtDizin";
            this.txtDizin.ReadOnly = true;
            this.txtDizin.Size = new System.Drawing.Size(648, 21);
            this.txtDizin.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(7, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 21);
            this.label2.TabIndex = 13;
            this.label2.Text = "Belge Dizini";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pb);
            this.groupBox1.Controls.Add(this.btnKartlariAktar);
            this.groupBox1.Controls.Add(this.btnHazirla);
            this.groupBox1.Controls.Add(this.btnBelgeSec);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(778, 45);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // pb
            // 
            this.pb.EditValue = "0";
            this.pb.Location = new System.Drawing.Point(124, 12);
            this.pb.Name = "pb";
            this.pb.Properties.ShowTitle = true;
            this.pb.Size = new System.Drawing.Size(359, 25);
            this.pb.TabIndex = 12;
            // 
            // btnKartlariAktar
            // 
            this.btnKartlariAktar.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKartlariAktar.Image = global::Sifas_Amortisman.Properties.Resources.Kaydet;
            this.btnKartlariAktar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKartlariAktar.Location = new System.Drawing.Point(652, 11);
            this.btnKartlariAktar.Name = "btnKartlariAktar";
            this.btnKartlariAktar.Size = new System.Drawing.Size(120, 26);
            this.btnKartlariAktar.TabIndex = 2;
            this.btnKartlariAktar.Text = "Kartları Aktar";
            this.btnKartlariAktar.UseVisualStyleBackColor = true;
            this.btnKartlariAktar.Click += new System.EventHandler(this.btnKartlariAktar_Click);
            // 
            // btnHazirla
            // 
            this.btnHazirla.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHazirla.Image = global::Sifas_Amortisman.Properties.Resources.hazirla;
            this.btnHazirla.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHazirla.Location = new System.Drawing.Point(564, 11);
            this.btnHazirla.Name = "btnHazirla";
            this.btnHazirla.Size = new System.Drawing.Size(82, 26);
            this.btnHazirla.TabIndex = 2;
            this.btnHazirla.Text = "Hazırla";
            this.btnHazirla.UseVisualStyleBackColor = true;
            this.btnHazirla.Click += new System.EventHandler(this.btnHazirla_Click);
            // 
            // btnBelgeSec
            // 
            this.btnBelgeSec.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBelgeSec.Image = global::Sifas_Amortisman.Properties.Resources.open;
            this.btnBelgeSec.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBelgeSec.Location = new System.Drawing.Point(482, 11);
            this.btnBelgeSec.Name = "btnBelgeSec";
            this.btnBelgeSec.Size = new System.Drawing.Size(82, 26);
            this.btnBelgeSec.TabIndex = 1;
            this.btnBelgeSec.Text = "Belge Seç";
            this.btnBelgeSec.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBelgeSec.UseVisualStyleBackColor = true;
            this.btnBelgeSec.Click += new System.EventHandler(this.btnBelgeSec_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(7, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Durumu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // belgeSec
            // 
            this.belgeSec.FileName = "openFileDialog1";
            this.belgeSec.Filter = "Excel Dosyaları |*.xls";
            // 
            // dsAmortisman
            // 
            this.dsAmortisman.DataSetName = "dsAmortisman";
            this.dsAmortisman.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // geciciTabloBindingSource
            // 
            this.geciciTabloBindingSource.DataMember = "geciciTablo";
            this.geciciTabloBindingSource.DataSource = this.dsAmortisman;
            // 
            // AcilisFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Sifas_Amortisman.Properties.Resources.logo___Kopya;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(802, 461);
            this.ControlBox = false;
            this.Controls.Add(this.panelUst);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "AcilisFormu";
            this.Text = "Demirbaş Kart Hazırlama";
            this.Load += new System.EventHandler(this.AcilisFormu_Load);
            this.panelUst.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAmortisman)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.geciciTabloBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelUst;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtDizin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.ProgressBarControl pb;
        private System.Windows.Forms.Button btnHazirla;
        private System.Windows.Forms.Button btnBelgeSec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog belgeSec;
        private dsAmortisman dsAmortisman;
        private System.Windows.Forms.BindingSource geciciTabloBindingSource;
        private dsAmortismanTableAdapters.SqlQueryler sqlQueryler1;
        private System.Windows.Forms.Button btnKartlariAktar;
    }
}