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
            this.listBoxVeicoli = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.NuovoVeicolo = new System.Windows.Forms.ToolStripButton();
            this.ApriVeicolo = new System.Windows.Forms.ToolStripButton();
            this.SalvaVeicolo = new System.Windows.Forms.ToolStripButton();
            this.StampaVeicolo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnWeb = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxVeicoli
            // 
            this.listBoxVeicoli.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listBoxVeicoli.FormattingEnabled = true;
            this.listBoxVeicoli.Location = new System.Drawing.Point(0, 32);
            this.listBoxVeicoli.Name = "listBoxVeicoli";
            this.listBoxVeicoli.Size = new System.Drawing.Size(584, 329);
            this.listBoxVeicoli.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NuovoVeicolo,
            this.ApriVeicolo,
            this.SalvaVeicolo,
            this.StampaVeicolo,
            this.toolStripSeparator,
            this.toolStripSeparator1,
            this.btnWeb});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(584, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // NuovoVeicolo
            // 
            this.NuovoVeicolo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NuovoVeicolo.Image = ((System.Drawing.Image)(resources.GetObject("NuovoVeicolo.Image")));
            this.NuovoVeicolo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NuovoVeicolo.Name = "NuovoVeicolo";
            this.NuovoVeicolo.Size = new System.Drawing.Size(23, 22);
            this.NuovoVeicolo.Text = "&Nuovo";
            this.NuovoVeicolo.Click += new System.EventHandler(this.NuovoVeicolo_Click);
            // 
            // ApriVeicolo
            // 
            this.ApriVeicolo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ApriVeicolo.Image = ((System.Drawing.Image)(resources.GetObject("ApriVeicolo.Image")));
            this.ApriVeicolo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ApriVeicolo.Name = "ApriVeicolo";
            this.ApriVeicolo.Size = new System.Drawing.Size(23, 22);
            this.ApriVeicolo.Text = "&Apri";
            this.ApriVeicolo.Click += new System.EventHandler(this.ApriVeicolo_Click);
            // 
            // SalvaVeicolo
            // 
            this.SalvaVeicolo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SalvaVeicolo.Image = ((System.Drawing.Image)(resources.GetObject("SalvaVeicolo.Image")));
            this.SalvaVeicolo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SalvaVeicolo.Name = "SalvaVeicolo";
            this.SalvaVeicolo.Size = new System.Drawing.Size(23, 22);
            this.SalvaVeicolo.Text = "&Salva";
            this.SalvaVeicolo.Click += new System.EventHandler(this.SalvaVeicolo_Click);
            // 
            // StampaVeicolo
            // 
            this.StampaVeicolo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StampaVeicolo.Image = ((System.Drawing.Image)(resources.GetObject("StampaVeicolo.Image")));
            this.StampaVeicolo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StampaVeicolo.Name = "StampaVeicolo";
            this.StampaVeicolo.Size = new System.Drawing.Size(23, 22);
            this.StampaVeicolo.Text = "&Stampa";
            this.StampaVeicolo.Click += new System.EventHandler(this.StampaVeicolo_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnWeb
            // 
            this.btnWeb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnWeb.Image = ((System.Drawing.Image)(resources.GetObject("btnWeb.Image")));
            this.btnWeb.ImageTransparentColor = System.Drawing.Color.White;
            this.btnWeb.Name = "btnWeb";
            this.btnWeb.Size = new System.Drawing.Size(23, 22);
            this.btnWeb.Text = "WEB";
            this.btnWeb.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnWeb.Click += new System.EventHandler(this.btnWeb_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.listBoxVeicoli);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormMain";
            this.Text = "SALONE VENDITA VEICOLI NUOVI E USATI";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox listBoxVeicoli;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton NuovoVeicolo;
        private System.Windows.Forms.ToolStripButton ApriVeicolo;
        private System.Windows.Forms.ToolStripButton SalvaVeicolo;
        private System.Windows.Forms.ToolStripButton StampaVeicolo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnWeb;
    }
}

