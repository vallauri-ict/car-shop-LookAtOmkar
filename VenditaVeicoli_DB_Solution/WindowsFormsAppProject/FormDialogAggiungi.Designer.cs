namespace WindowsFormsAppProject
{
    partial class FormDialogAggiungi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDialogAggiungi));
            this.cmbTipoVeicolo = new System.Windows.Forms.ComboBox();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnAggiungi = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblModello = new System.Windows.Forms.Label();
            this.lblColore = new System.Windows.Forms.Label();
            this.lblPotenzaKW = new System.Windows.Forms.Label();
            this.lblKmPercorsi = new System.Windows.Forms.Label();
            this.Data_Time_Immatricolazione = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMarcaSella = new System.Windows.Forms.TextBox();
            this.lblMarcaSella = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.lblAirbag = new System.Windows.Forms.Label();
            this.lblKmZero = new System.Windows.Forms.Label();
            this.lblUsato = new System.Windows.Forms.Label();
            this.UsatoSI = new System.Windows.Forms.RadioButton();
            this.UsatoNO = new System.Windows.Forms.RadioButton();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.cmbModello = new System.Windows.Forms.ComboBox();
            this.cmbColore = new System.Windows.Forms.ComboBox();
            this.KMZeroSI = new System.Windows.Forms.RadioButton();
            this.KMZeroNO = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPrezzo = new System.Windows.Forms.Label();
            this.numUpDwPrice = new System.Windows.Forms.NumericUpDown();
            this.txtKmPercorsi = new System.Windows.Forms.NumericUpDown();
            this.txtPotenzakW = new System.Windows.Forms.NumericUpDown();
            this.txtCilindrata = new System.Windows.Forms.NumericUpDown();
            this.txtN_Airbag = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKmPercorsi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPotenzakW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCilindrata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtN_Airbag)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbTipoVeicolo
            // 
            this.cmbTipoVeicolo.FormattingEnabled = true;
            this.cmbTipoVeicolo.Items.AddRange(new object[] {
            "AUTO",
            "MOTO",
            "\t\t\t"});
            this.cmbTipoVeicolo.Location = new System.Drawing.Point(175, 12);
            this.cmbTipoVeicolo.Name = "cmbTipoVeicolo";
            this.cmbTipoVeicolo.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoVeicolo.TabIndex = 0;
            this.cmbTipoVeicolo.SelectedIndexChanged += new System.EventHandler(this.cmbTipoVeicolo_SelectedIndexChanged);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(118, 470);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 1;
            this.btnAnnulla.Text = "ANNULLA";
            this.btnAnnulla.UseVisualStyleBackColor = true;
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            // 
            // btnAggiungi
            // 
            this.btnAggiungi.Location = new System.Drawing.Point(215, 470);
            this.btnAggiungi.Name = "btnAggiungi";
            this.btnAggiungi.Size = new System.Drawing.Size(75, 23);
            this.btnAggiungi.TabIndex = 2;
            this.btnAggiungi.Text = "AGGIUNGI";
            this.btnAggiungi.UseVisualStyleBackColor = true;
            this.btnAggiungi.Click += new System.EventHandler(this.btnAggiungi_Click);
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(2, 50);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(48, 13);
            this.lblMarca.TabIndex = 8;
            this.lblMarca.Text = "MARCA:";
            // 
            // lblModello
            // 
            this.lblModello.AutoSize = true;
            this.lblModello.Location = new System.Drawing.Point(2, 88);
            this.lblModello.Name = "lblModello";
            this.lblModello.Size = new System.Drawing.Size(62, 13);
            this.lblModello.TabIndex = 9;
            this.lblModello.Text = "MODELLO:";
            // 
            // lblColore
            // 
            this.lblColore.AutoSize = true;
            this.lblColore.Location = new System.Drawing.Point(2, 127);
            this.lblColore.Name = "lblColore";
            this.lblColore.Size = new System.Drawing.Size(54, 13);
            this.lblColore.TabIndex = 10;
            this.lblColore.Text = "COLORE:";
            // 
            // lblPotenzaKW
            // 
            this.lblPotenzaKW.AutoSize = true;
            this.lblPotenzaKW.Location = new System.Drawing.Point(2, 165);
            this.lblPotenzaKW.Name = "lblPotenzaKW";
            this.lblPotenzaKW.Size = new System.Drawing.Size(82, 13);
            this.lblPotenzaKW.TabIndex = 11;
            this.lblPotenzaKW.Text = "POTENZA KW:";
            // 
            // lblKmPercorsi
            // 
            this.lblKmPercorsi.AutoSize = true;
            this.lblKmPercorsi.Location = new System.Drawing.Point(2, 209);
            this.lblKmPercorsi.Name = "lblKmPercorsi";
            this.lblKmPercorsi.Size = new System.Drawing.Size(84, 13);
            this.lblKmPercorsi.TabIndex = 12;
            this.lblKmPercorsi.Text = "KM PERCORSI:";
            // 
            // Data_Time_Immatricolazione
            // 
            this.Data_Time_Immatricolazione.Location = new System.Drawing.Point(96, 288);
            this.Data_Time_Immatricolazione.Name = "Data_Time_Immatricolazione";
            this.Data_Time_Immatricolazione.Size = new System.Drawing.Size(200, 20);
            this.Data_Time_Immatricolazione.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "TIPO DI VEICOLO:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "CILINDRATA:";
            // 
            // txtMarcaSella
            // 
            this.txtMarcaSella.Location = new System.Drawing.Point(96, 355);
            this.txtMarcaSella.Name = "txtMarcaSella";
            this.txtMarcaSella.Size = new System.Drawing.Size(185, 20);
            this.txtMarcaSella.TabIndex = 19;
            // 
            // lblMarcaSella
            // 
            this.lblMarcaSella.AutoSize = true;
            this.lblMarcaSella.Location = new System.Drawing.Point(2, 355);
            this.lblMarcaSella.Name = "lblMarcaSella";
            this.lblMarcaSella.Size = new System.Drawing.Size(84, 13);
            this.lblMarcaSella.TabIndex = 20;
            this.lblMarcaSella.Text = "MARCA SELLA:";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(2, 288);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(39, 13);
            this.lblData.TabIndex = 21;
            this.lblData.Text = "DATA:";
            // 
            // lblAirbag
            // 
            this.lblAirbag.AutoSize = true;
            this.lblAirbag.Location = new System.Drawing.Point(2, 329);
            this.lblAirbag.Name = "lblAirbag";
            this.lblAirbag.Size = new System.Drawing.Size(64, 13);
            this.lblAirbag.TabIndex = 22;
            this.lblAirbag.Text = "N. AIRBAG:";
            // 
            // lblKmZero
            // 
            this.lblKmZero.AutoSize = true;
            this.lblKmZero.Location = new System.Drawing.Point(2, 416);
            this.lblKmZero.Name = "lblKmZero";
            this.lblKmZero.Size = new System.Drawing.Size(59, 13);
            this.lblKmZero.TabIndex = 23;
            this.lblKmZero.Text = "KM ZERO:";
            // 
            // lblUsato
            // 
            this.lblUsato.AutoSize = true;
            this.lblUsato.Location = new System.Drawing.Point(2, 442);
            this.lblUsato.Name = "lblUsato";
            this.lblUsato.Size = new System.Drawing.Size(47, 13);
            this.lblUsato.TabIndex = 24;
            this.lblUsato.Text = "USATO:";
            // 
            // UsatoSI
            // 
            this.UsatoSI.AutoSize = true;
            this.UsatoSI.Location = new System.Drawing.Point(24, 8);
            this.UsatoSI.Name = "UsatoSI";
            this.UsatoSI.Size = new System.Drawing.Size(35, 17);
            this.UsatoSI.TabIndex = 27;
            this.UsatoSI.TabStop = true;
            this.UsatoSI.Text = "SI";
            this.UsatoSI.UseVisualStyleBackColor = true;
            // 
            // UsatoNO
            // 
            this.UsatoNO.AutoSize = true;
            this.UsatoNO.Location = new System.Drawing.Point(82, 8);
            this.UsatoNO.Name = "UsatoNO";
            this.UsatoNO.Size = new System.Drawing.Size(41, 17);
            this.UsatoNO.TabIndex = 28;
            this.UsatoNO.TabStop = true;
            this.UsatoNO.Text = "NO";
            this.UsatoNO.UseVisualStyleBackColor = true;
            // 
            // cmbMarca
            // 
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(94, 50);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(196, 21);
            this.cmbMarca.TabIndex = 29;
            this.cmbMarca.SelectedIndexChanged += new System.EventHandler(this.cmbMarca_SelectedIndexChanged);
            // 
            // cmbModello
            // 
            this.cmbModello.FormattingEnabled = true;
            this.cmbModello.Location = new System.Drawing.Point(94, 88);
            this.cmbModello.Name = "cmbModello";
            this.cmbModello.Size = new System.Drawing.Size(196, 21);
            this.cmbModello.TabIndex = 30;
            // 
            // cmbColore
            // 
            this.cmbColore.FormattingEnabled = true;
            this.cmbColore.Items.AddRange(new object[] {
            "Nero",
            "Rosso",
            "Giallo",
            "Bianco",
            "Grigio",
            "Blu"});
            this.cmbColore.Location = new System.Drawing.Point(96, 124);
            this.cmbColore.Name = "cmbColore";
            this.cmbColore.Size = new System.Drawing.Size(196, 21);
            this.cmbColore.TabIndex = 31;
            // 
            // KMZeroSI
            // 
            this.KMZeroSI.AutoSize = true;
            this.KMZeroSI.Location = new System.Drawing.Point(94, 411);
            this.KMZeroSI.Name = "KMZeroSI";
            this.KMZeroSI.Size = new System.Drawing.Size(35, 17);
            this.KMZeroSI.TabIndex = 32;
            this.KMZeroSI.TabStop = true;
            this.KMZeroSI.Text = "SI";
            this.KMZeroSI.UseVisualStyleBackColor = true;
            this.KMZeroSI.CheckedChanged += new System.EventHandler(this.KMZeroSI_CheckedChanged);
            // 
            // KMZeroNO
            // 
            this.KMZeroNO.AutoSize = true;
            this.KMZeroNO.Location = new System.Drawing.Point(152, 411);
            this.KMZeroNO.Name = "KMZeroNO";
            this.KMZeroNO.Size = new System.Drawing.Size(41, 17);
            this.KMZeroNO.TabIndex = 33;
            this.KMZeroNO.TabStop = true;
            this.KMZeroNO.Text = "NO";
            this.KMZeroNO.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.UsatoNO);
            this.groupBox1.Controls.Add(this.UsatoSI);
            this.groupBox1.Location = new System.Drawing.Point(70, 432);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(141, 25);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            // 
            // lblPrezzo
            // 
            this.lblPrezzo.AutoSize = true;
            this.lblPrezzo.Location = new System.Drawing.Point(2, 391);
            this.lblPrezzo.Name = "lblPrezzo";
            this.lblPrezzo.Size = new System.Drawing.Size(54, 13);
            this.lblPrezzo.TabIndex = 29;
            this.lblPrezzo.Text = "PREZZO:";
            // 
            // numUpDwPrice
            // 
            this.numUpDwPrice.Location = new System.Drawing.Point(94, 389);
            this.numUpDwPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numUpDwPrice.Name = "numUpDwPrice";
            this.numUpDwPrice.Size = new System.Drawing.Size(120, 20);
            this.numUpDwPrice.TabIndex = 35;
            // 
            // txtKmPercorsi
            // 
            this.txtKmPercorsi.Location = new System.Drawing.Point(94, 202);
            this.txtKmPercorsi.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtKmPercorsi.Name = "txtKmPercorsi";
            this.txtKmPercorsi.Size = new System.Drawing.Size(117, 20);
            this.txtKmPercorsi.TabIndex = 36;
            // 
            // txtPotenzakW
            // 
            this.txtPotenzakW.Location = new System.Drawing.Point(94, 158);
            this.txtPotenzakW.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtPotenzakW.Name = "txtPotenzakW";
            this.txtPotenzakW.Size = new System.Drawing.Size(117, 20);
            this.txtPotenzakW.TabIndex = 37;
            // 
            // txtCilindrata
            // 
            this.txtCilindrata.Location = new System.Drawing.Point(94, 240);
            this.txtCilindrata.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.txtCilindrata.Name = "txtCilindrata";
            this.txtCilindrata.Size = new System.Drawing.Size(117, 20);
            this.txtCilindrata.TabIndex = 38;
            // 
            // txtN_Airbag
            // 
            this.txtN_Airbag.Location = new System.Drawing.Point(94, 322);
            this.txtN_Airbag.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtN_Airbag.Name = "txtN_Airbag";
            this.txtN_Airbag.Size = new System.Drawing.Size(117, 20);
            this.txtN_Airbag.TabIndex = 39;
            // 
            // FormDialogAggiungi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAnnulla;
            this.ClientSize = new System.Drawing.Size(302, 505);
            this.Controls.Add(this.txtN_Airbag);
            this.Controls.Add(this.txtCilindrata);
            this.Controls.Add(this.txtPotenzakW);
            this.Controls.Add(this.txtKmPercorsi);
            this.Controls.Add(this.numUpDwPrice);
            this.Controls.Add(this.lblPrezzo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.KMZeroNO);
            this.Controls.Add(this.KMZeroSI);
            this.Controls.Add(this.cmbColore);
            this.Controls.Add(this.cmbModello);
            this.Controls.Add(this.cmbMarca);
            this.Controls.Add(this.lblUsato);
            this.Controls.Add(this.lblKmZero);
            this.Controls.Add(this.lblAirbag);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.lblMarcaSella);
            this.Controls.Add(this.txtMarcaSella);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Data_Time_Immatricolazione);
            this.Controls.Add(this.lblKmPercorsi);
            this.Controls.Add(this.lblPotenzaKW);
            this.Controls.Add(this.lblColore);
            this.Controls.Add(this.lblModello);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.btnAggiungi);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.cmbTipoVeicolo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDialogAggiungi";
            this.Text = "AGGIUNGI VEICOLO";
            this.Load += new System.EventHandler(this.FormDialogAggiungi_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKmPercorsi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPotenzakW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCilindrata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtN_Airbag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTipoVeicolo;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnAggiungi;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblModello;
        private System.Windows.Forms.Label lblColore;
        private System.Windows.Forms.Label lblPotenzaKW;
        private System.Windows.Forms.Label lblKmPercorsi;
        private System.Windows.Forms.DateTimePicker Data_Time_Immatricolazione;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMarcaSella;
        private System.Windows.Forms.Label lblMarcaSella;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblAirbag;
        private System.Windows.Forms.Label lblKmZero;
        private System.Windows.Forms.Label lblUsato;
        private System.Windows.Forms.RadioButton UsatoSI;
        private System.Windows.Forms.RadioButton UsatoNO;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.ComboBox cmbModello;
        private System.Windows.Forms.ComboBox cmbColore;
        private System.Windows.Forms.RadioButton KMZeroSI;
        private System.Windows.Forms.RadioButton KMZeroNO;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPrezzo;
        private System.Windows.Forms.NumericUpDown numUpDwPrice;
        private System.Windows.Forms.NumericUpDown txtKmPercorsi;
        private System.Windows.Forms.NumericUpDown txtPotenzakW;
        private System.Windows.Forms.NumericUpDown txtCilindrata;
        private System.Windows.Forms.NumericUpDown txtN_Airbag;
    }
}