using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Spreadsheet;
using VenditaVeicoliDLLProject;
using UtilsVeicoliDLLProject;

namespace WindowsFormsAppProject
{
    public partial class FormDialogAggiungi : Form
    {
        BindingList<Veicolo> bindingListVeicoli;
        public int cilindrata;
        public int potenzaKW;
        public int KmPercorsi;
        public int nAirBag;
        public bool usato;
        public bool kmZero;
        public string[] Auto = { "MERCEDES", "JEEP"};
        public string[] Moto = { "DUCATI", "HONDA"};
        public string[] ModelloMERCEDES = { "G_Wagon", "Classe A" };
        public string[] ModelloJEEP = { "Wrangler", "Compass"};
        public string[] ModelloDUCATI = { "Monster","Diavel"};
        public string[] ModelloHONDA = { "Civic","Jazz" };

        public string[] ModelloMoto = { "AA", "BB", "CC" };
        private FormMain formMain;

        public FormDialogAggiungi()
        {
            InitializeComponent();
            cilindrata = 0;
            potenzaKW = 0;
            KmPercorsi = 0;
        }
        public FormDialogAggiungi(BindingList<Veicolo> bindingListVeicoli, FormMain formMain)
        {
            InitializeComponent();
            this.bindingListVeicoli = bindingListVeicoli;
            formMain.dgvVeicoli.DataSource = bindingListVeicoli;
            this.formMain = formMain;
        }

        private void FormDialogAggiungi_Load(object sender, EventArgs e)
        {
            this.cmbTipoVeicolo.SelectedIndex = 0;
            formMain = (FormMain)this.Owner;
        }
        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAggiungi_Click(object sender, EventArgs e)
        {
            MessageBox.Show("........Aggiunto Veicolo Correttamente........");
            cilindrata = Convert.ToInt32(txtCilindrata.Value);
            potenzaKW = Convert.ToInt32(txtPotenzakW.Value);
            if ((KMZeroNO.Checked) && (!KMZeroSI.Checked))
            {
                kmZero = false;
                KmPercorsi = Convert.ToInt32(txtKmPercorsi.Value);
            }
            else
            {
                if ((!KMZeroNO.Checked) && (KMZeroSI.Checked))
                {
                    kmZero = true;
                    KmPercorsi = 0;
                }

                else
                {
                    throw new Exception("Devi specificare se il veicolo è a km zero o no");
                }

            }
            if ((UsatoNO.Checked) && (!UsatoSI.Checked))
            {
                kmZero = false;
                KmPercorsi = Convert.ToInt32(txtKmPercorsi.Value);
            }
            else
            {
                if ((!UsatoNO.Checked) && (UsatoSI.Checked))
                {
                    kmZero = true;
                    KmPercorsi = 0;
                }
                else
                    throw new Exception("Devi specificare se il veicolo è usato o no")
            }

            if (cmbTipoVeicolo.SelectedItem.ToString() == "Moto")
            {
                Moto m;
                m = new Moto(cmbMarca.SelectedItem.ToString(), cmbModello.SelectedItem.ToString(), cmbColore.SelectedItem.ToString(), cilindrata, potenzaKW, Data_Time_Immatricolazione.Value, usato, kmZero, KmPercorsi, txtMarcaSella.Text, Convert.ToInt32(numUpDwPrice.Value));
                bindingListVeicoli.Add(m); //TRADIZIONALE
                //UtilsDatabase.AggiungiVeicolo(m); //TRAMITE DATABASE problemi di provider
            }
            else
            {
                nAirBag = Convert.ToInt32(txtN_Airbag.Value);
                Auto a;
                a = new Auto(cmbMarca.SelectedItem.ToString(), cmbModello.SelectedItem.ToString(), cmbColore.SelectedItem.ToString(), cilindrata, potenzaKW, Data_Time_Immatricolazione.Value, usato, kmZero, KmPercorsi, nAirBag, Convert.ToInt32(numUpDwPrice.Value));
                bindingListVeicoli.Add(a); /// TRADIZIONALE 
                //UtilsDatabase.AggiungiVeicolo(a); /// TRAMITE DATABASE problemi di provider
            }
            this.Close();
        }


        private void cmbTipoVeicolo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoVeicolo.Text == "AUTO")
            {
                cmbMarca.Items.Clear();
                cmbModello.Items.Clear();
                for (int i = 0; i < Auto.Length; i++)
                {
                    cmbMarca.Items.Add(Auto[i]);
                }
                lblMarcaSella.Visible = false;
                txtMarcaSella.Visible = false;
                lblAirbag.Visible = true;
                txtN_Airbag.Visible = true;
            }
            else if (cmbTipoVeicolo.Text == "MOTO")
            {
                cmbMarca.Items.Clear();
                cmbModello.Items.Clear();
                for (int i = 0; i < Moto.Length; i++)
                {
                    cmbMarca.Items.Add(Moto[i]);
                }

                lblAirbag.Visible = false;
                txtN_Airbag.Visible = false;
                txtMarcaSella.Visible = true;
                lblMarcaSella.Visible = true;
                lblMarcaSella.Location = lblAirbag.Location;
                txtMarcaSella.Location = txtN_Airbag.Location;
            }
        }

        private void KMZeroSI_CheckedChanged(object sender, EventArgs e)
        {
            if ((KMZeroSI.Checked) && (!KMZeroNO.Checked))
            {
                lblKmPercorsi.Visible = false;
                txtKmPercorsi.Visible = false;
            }
            else
            {
                lblKmPercorsi.Visible = true;
                txtKmPercorsi.Visible = true;
            }
        }

        private void Prezzo_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void cmbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbMarca.Text)
            {
                case "MERCEDES":
                    {
                        cmbModello.Items.Clear();
                        aggiungiModello(ModelloMERCEDES);
                        break;
                    }
                case "JEEP":
                    {
                        cmbModello.Items.Clear();
                        aggiungiModello(ModelloJEEP);
                        break;
                    }
                case "HONDA":
                    {
                        cmbModello.Items.Clear();
                        aggiungiModello(ModelloHONDA);
                        break;
                    }
                case "DUCATI":
                    {
                        cmbModello.Items.Clear();
                        aggiungiModello(ModelloDUCATI);
                        break;
                    }
            }
        }
        private void aggiungiModello(string[] models)
        {
            for (int i = 0; i < models.Length; i++)
            {
                cmbModello.Items.Add(models[i]);
            }
        }
    }
}
