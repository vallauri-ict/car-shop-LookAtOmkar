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
using UtilsVeicoliDLLProject;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Spreadsheet;

namespace WindowsFormsAppProject
{
    public partial class FormMain : Form
    {
        SerializableBindingList<Veicolo> BindingListVeicoli;
        public FormMain()
        {
            InitializeComponent();
            BindingListVeicoli = new SerializableBindingList<Veicolo>();
            dgvVeicoli.AutoResizeColumns();
            dgvVeicoli.AutoResizeRows();
            dgvVeicoli.ClearSelection();
            dgvVeicoli.RowHeadersVisible = false;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            caricaDatiDiTest();
        }

        private void caricaDatiDiTest()
        {
            //UtilsDatabase.CreaTabella();
            Moto m = new Moto();
            BindingListVeicoli.Add(m);
            m = new Moto("HONDA", "Tsunami", "Rosso", 1000, 120, DateTime.Now, false, false, 0, "Quintino", 15000);
            BindingListVeicoli.Add(m);
            //UtilsDatabase.AggiungiVeicolo(m);
            Auto a = new Auto("JEEP", "Compass", "Blue", 2400, 160.10, DateTime.Now, false, false, 0, 8, 30000);
            BindingListVeicoli.Add(a);
            //UtilsDatabase.AggiungiVeicolo(a);
            dgvVeicoli.DataSource = BindingListVeicoli;
            
        }
        private void NuovoVeicolo_Click(object sender, EventArgs e)
        {
            FormDialogAggiungi dialogoAggiungi = new FormDialogAggiungi(BindingListVeicoli, this);
            dialogoAggiungi.ShowDialog();
        }

        private void ApriVeicolo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Apri........");
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            try
            {
                StreamReader sr = new StreamReader(file.FileName);
                while (sr.Peek() > -1)
                {
                    ///
                }
                sr.Close();
            }
            catch
            {
                MessageBox.Show("File non selezionato");
            }
        }

        private void SalvaVeicolo_Click(object sender, EventArgs e)
        {
            Utils.SerializeToCsv(BindingListVeicoli, @".\Veicoli.csv");
            //Utils.SerializeToXml(BindingListVeicoli, @".\veicoli.xml");
            Utils.SerializeToJson(BindingListVeicoli, @".\veicoli.json");
            ///DEVO INSERIRE UNA FUNZIONE CHE MI PERMETTA DI SALVARE IL DATABASE DI VEICOLI
        }

        private void StampaVeicolo_Click(object sender, EventArgs e)
        {
            /// SALVATAGGIO LISTA IN JSON//
            string json = @".\www\index.json";
            Utils.SerializeToJson(BindingListVeicoli, json);
            MessageBox.Show("File salvato in json");

            //--------------------STAMPA-----------------------
        }
        private string immagine(string marca)
        {
            string s = "";
            switch (marca)
            {
                case "DUCATI":
                    {
                        s += "style='backgroud-image:url(../www/css/ducati1.jpg)';";
                        break;
                    }
                case "JEEP":
                    {
                        s += "style='backgroud-image:url(../www/css/jeep1.jpg)';";
                        break;
                    }
                case "HONDA":
                    {
                        s += "style='backgroud-image:url(../www/css/honda1.jpg)';";
                        break;
                    }
                case "MERCEDES":
                    {
                        s += "style='backgroud-image:url(../www/css/mercedes1.jpg)';";
                        break;
                    }
            }
            return s;
        }

        private string ScriviHTML(string html, int i)
        {
            string s = "";
            s += "<div class='Body-content'><div class='" + html + "'></div>";
            s += "<div class='Dettagli'><p> Marca:" +
                 BindingListVeicoli[i].Marca + "\n  MODELLO: "
                 + BindingListVeicoli[i].Modello + "\n  POTENZA KW: " +
                 BindingListVeicoli[i].PotenzaKw + "\n  KM PERCORSI:" +
                 BindingListVeicoli[i].KmPercorsi1 + "\n  CILINDRATA: " +
                 BindingListVeicoli[i].Cilindarata + "\n  COLORE: " +
                 BindingListVeicoli[i].Colore;
            if (BindingListVeicoli[i].IsUsato == false)
                s += "<br>USATO: NO";
            else
                s += "<br>USATO: SI";
            if (BindingListVeicoli[i].IsKmZero == false)
                s += "<br>KM ZERO: NO";
            else
                s += "<br>KM ZERO: SI</p>";
            s += "</div></div>";
            return s;
        }

        private void btnWeb_Click(object sender, EventArgs e)
        {
            string homepagePath = @".\www\index.html";
            //Utils.CreateHTML(BindingListVeicoli, homepagePath);
            string s = "";

            string html = File.ReadAllText(@".\www\index-Skeleton.html");

            html = html.Replace("{{head-title}}", "AUTOVALLAURI");
            html = html.Replace("{{body-title}}", "SALONE VALLAURI-VEICOLI NUOVI E USATI");
            html = html.Replace("{{body-subtitle}}", "le migliori occasioni al miglior prezzo");
            ///---------------Dati----------------
            for (int i = 0; i < BindingListVeicoli.Count; i++)
            {
                switch (BindingListVeicoli[i].Marca)
                {
                    case "DUCATI":
                        {
                            s += ScriviHTML("DUCATI", i);
                            break;
                        }
                    case "JEEP":
                        {
                            s += ScriviHTML("JEEP", i);
                            break;
                        }
                    case "MERCEDES":
                        {
                            s += ScriviHTML("MERCEDES", i);
                            break;
                        }
                    case "HONDA":
                        {
                            s += ScriviHTML("HONDA", i);
                            break;
                        }
                }
            }
            html = html.Replace("{{main-content}}", s);
            File.WriteAllText(homepagePath, html);
            System.Diagnostics.Process.Start(homepagePath);

        }

        private void ExportWord_Click(object sender, EventArgs e)
        {
            using(WordprocessingDocument doc = WordprocessingDocument.Create("Volantino_Veicoli.docx",WordprocessingDocumentType.Document))
            {
                ///CREATION AND STRUCTURE OF WORD DOC
                MainDocumentPart mainPart = doc.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body docBody = new Body();
                mainPart.Document.AppendChild(docBody);
                ///Description of doC
                ///TITLE
                Paragraph Header_p = UtilsWord.CreateParagraphWithStyle("Heading",JustificationValues.Center);
                UtilsWord.AddTextToParagraph(Header_p,"VOLANTINO VEICOLI NUOVI E USATI ");
                docBody.AppendChild(Header_p);

                ///SUBTITLE
                Paragraph SubHeader_p = UtilsWord.CreateParagraphWithStyle("Content",JustificationValues.Center);
                UtilsWord.AddTextToParagraph(SubHeader_p,"Qui troverete i dati di tutti i veicoli nuovi e usati che abbiamo in disposizione");
                docBody.AppendChild(SubHeader_p);
                
                ///CONTENT


            }
        }

        private void ExporExcel_Click(object sender, EventArgs e)
        {
            UtilsExcel.CreateExcelFile<Veicolo>(BindingListVeicoli.ToList(),"Cars_Details.xlsx"); ///HO CONVERTITO LA SERIALIZEBINDINGLIST IN LIST, DATO CHE NELLA LIBRERIA DI EXCEL, RICHIEDEVA COME PARAMETRO UNA LIST.
            MessageBox.Show("I Dati sono stati esportati in File Excel correttamente");
            System.Diagnostics.Process.Start("Cars_Details.xlsx");
                
        }
    }
}
