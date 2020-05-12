namespace WindowsFormsAppProject
{
    partial class FormMain
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.NuovoVeicolo = new System.Windows.Forms.ToolStripButton();
            this.ApriVeicolo = new System.Windows.Forms.ToolStripButton();
            this.SalvaVeicolo = new System.Windows.Forms.ToolStripButton();
            this.StampaVeicolo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnWeb = new System.Windows.Forms.ToolStripButton();
            this.ExportWord = new System.Windows.Forms.ToolStripButton();
            this.ExporExcel = new System.Windows.Forms.ToolStripButton();
            this.dgvVeicoli = new System.Windows.Forms.DataGridView();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVeicoli)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NuovoVeicolo,
            this.ApriVeicolo,
            this.SalvaVeicolo,
            this.StampaVeicolo,
            this.toolStripSeparator,
            this.toolStripSeparator1,
            this.btnWeb,
            this.ExportWord,
            this.ExporExcel});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip.Size = new System.Drawing.Size(584, 32);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip";
            // 
            // NuovoVeicolo
            // 
            this.NuovoVeicolo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NuovoVeicolo.Image = ((System.Drawing.Image)(resources.GetObject("NuovoVeicolo.Image")));
            this.NuovoVeicolo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NuovoVeicolo.Name = "NuovoVeicolo";
            this.NuovoVeicolo.Size = new System.Drawing.Size(29, 29);
            this.NuovoVeicolo.Text = "&Nuovo";
            this.NuovoVeicolo.Click += new System.EventHandler(this.NuovoVeicolo_Click);
            // 
            // ApriVeicolo
            // 
            this.ApriVeicolo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ApriVeicolo.Image = ((System.Drawing.Image)(resources.GetObject("ApriVeicolo.Image")));
            this.ApriVeicolo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ApriVeicolo.Name = "ApriVeicolo";
            this.ApriVeicolo.Size = new System.Drawing.Size(29, 29);
            this.ApriVeicolo.Text = "&Apri";
            this.ApriVeicolo.Click += new System.EventHandler(this.ApriVeicolo_Click);
            // 
            // SalvaVeicolo
            // 
            this.SalvaVeicolo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SalvaVeicolo.Image = ((System.Drawing.Image)(resources.GetObject("SalvaVeicolo.Image")));
            this.SalvaVeicolo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SalvaVeicolo.Name = "SalvaVeicolo";
            this.SalvaVeicolo.Size = new System.Drawing.Size(29, 29);
            this.SalvaVeicolo.Text = "&Salva";
            this.SalvaVeicolo.Click += new System.EventHandler(this.SalvaVeicolo_Click);
            // 
            // StampaVeicolo
            // 
            this.StampaVeicolo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StampaVeicolo.Image = ((System.Drawing.Image)(resources.GetObject("StampaVeicolo.Image")));
            this.StampaVeicolo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StampaVeicolo.Name = "StampaVeicolo";
            this.StampaVeicolo.Size = new System.Drawing.Size(29, 29);
            this.StampaVeicolo.Text = "&Stampa";
            this.StampaVeicolo.Click += new System.EventHandler(this.StampaVeicolo_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // btnWeb
            // 
            this.btnWeb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnWeb.Image = ((System.Drawing.Image)(resources.GetObject("btnWeb.Image")));
            this.btnWeb.ImageTransparentColor = System.Drawing.Color.White;
            this.btnWeb.Name = "btnWeb";
            this.btnWeb.Size = new System.Drawing.Size(29, 29);
            this.btnWeb.Text = "WEB";
            this.btnWeb.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnWeb.Click += new System.EventHandler(this.btnWeb_Click);
            // 
            // ExportWord
            // 
            this.ExportWord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ExportWord.Image = ((System.Drawing.Image)(resources.GetObject("ExportWord.Image")));
            this.ExportWord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExportWord.Name = "ExportWord";
            this.ExportWord.Size = new System.Drawing.Size(29, 29);
            this.ExportWord.Text = "toolStripButton1";
            this.ExportWord.Click += new System.EventHandler(this.ExportWord_Click);
            // 
            // ExporExcel
            // 
            this.ExporExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ExporExcel.Image = ((System.Drawing.Image)(resources.GetObject("ExporExcel.Image")));
            this.ExporExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExporExcel.Name = "ExporExcel";
            this.ExporExcel.Size = new System.Drawing.Size(29, 29);
            this.ExporExcel.Text = "toolStripButton2";
            this.ExporExcel.Click += new System.EventHandler(this.ExporExcel_Click);
            // 
            // dgvVeicoli
            // 
            this.dgvVeicoli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVeicoli.Location = new System.Drawing.Point(0, 40);
            this.dgvVeicoli.Name = "dgvVeicoli";
            this.dgvVeicoli.Size = new System.Drawing.Size(584, 211);
            this.dgvVeicoli.TabIndex = 2;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.dgvVeicoli);
            this.Controls.Add(this.toolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "SALONE VENDITA VEICOLI NUOVI E USATI";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVeicoli)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton NuovoVeicolo;
        private System.Windows.Forms.ToolStripButton ApriVeicolo;
        private System.Windows.Forms.ToolStripButton SalvaVeicolo;
        private System.Windows.Forms.ToolStripButton StampaVeicolo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnWeb;
        public System.Windows.Forms.DataGridView dgvVeicoli;
        private System.Windows.Forms.ToolStripButton ExportWord;
        private System.Windows.Forms.ToolStripButton ExporExcel;
    }
}

