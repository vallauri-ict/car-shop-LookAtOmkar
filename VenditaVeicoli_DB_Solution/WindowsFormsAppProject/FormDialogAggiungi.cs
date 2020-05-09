using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VenditaVeicoliDLLProject;

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
        public string[] Auto = { "MERCEDES","JEEP","AUDI"};
        public string[] Moto = {"DUCATI","HONDA","BMW" };
        public string[] ModelloAuto = {"Glx","Classe S","Classe A" };
        public string[] ModelloMoto = {"AA","BB","CC" };
        private FormMain formMain;

        public FormDialogAggiungi()
        {
            InitializeComponent();
            int cilindrata = 0;
            int potenzaKW = 0;
            int KmPercorsi = 0;
        }
        public FormDialogAggiungi(BindingList<Veicolo> bindingListVeicoli, FormMain formMain)
        {
            InitializeComponent();
            this.bindingListVeicoli = bindingListVeicoli;
            formMain.listBoxVeicoli.DataSource = bindingListVeicoli;
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
            MessageBox.Show("Aggiungi........");
            cilindrata = Convert.ToInt32(txtCilindrata.Text);
            potenzaKW = Convert.ToInt32(txtPotenzakW.Text);
            if((KMZeroNO.Checked)&&(!KMZeroSI.Checked))
            {
                kmZero = false;
                KmPercorsi = Convert.ToInt32(txtKmPercorsi.Text);
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
                    MessageBox.Show("Devi specificare se il veicolo è a km zero o no");
                }
                    
            }
            if ((UsatoNO.Checked) && (!UsatoSI.Checked))
            {
                kmZero = false;
                KmPercorsi = Convert.ToInt32(txtKmPercorsi.Text);
            }
            else
            {
                if ((!UsatoNO.Checked) && (UsatoSI.Checked))
                {
                    kmZero = true;
                    KmPercorsi = 0;
                }
                else
                    MessageBox.Show("Devi specificare se il veicolo è usato o no");
            }

            if (cmbTipoVeicolo.SelectedItem.ToString()=="Moto")
            {
                Moto m;
                m = new Moto(cmbMarca.SelectedItem.ToString(),cmbModello.SelectedItem.ToString(),cmbColore.SelectedItem.ToString(),cilindrata, potenzaKW,Data_Time_Immatricolazione.Value ,usato, kmZero, KmPercorsi,txtMarcaSella.Text);
                bindingListVeicoli.Add(m);
            }
            else
            {
                nAirBag = Convert.ToInt32(txtN_Airbag.Text);
                Auto a;
                a = new Auto(cmbMarca.SelectedItem.ToString(),cmbModello.SelectedItem.ToString(),cmbColore.SelectedItem.ToString(), cilindrata,potenzaKW, Data_Time_Immatricolazione.Value, usato, kmZero,KmPercorsi,nAirBag);
                bindingListVeicoli.Add(a);
            }
            
            this.Close();
        }

        private void btnColore_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
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
                    cmbModello.Items.Add(ModelloAuto[i]);
                }
                lblMarcaSella.Visible = false;
                txtMarcaSella.Visible = false;
                lblAirbag.Visible = true;
                txtN_Airbag.Visible = true;
            }
            else if(cmbTipoVeicolo.Text=="MOTO")
            {
                cmbMarca.Items.Clear();
                cmbModello.Items.Clear();
                for (int i = 0; i < Moto.Length; i++)
                {
                    cmbMarca.Items.Add(Moto[i]);
                    cmbModello.Items.Add(ModelloMoto[i]);
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
            if((KMZeroSI.Checked)&&(!KMZeroNO.Checked))
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
    }
}
