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
using System.Drawing.Printing;

namespace WindowsFormsAppProject
{
    public partial class FormMain : Form
    {
        public static SerializableBindingList<Veicolo> BindingListVeicoli;

        private System.Drawing.Font printFont;
        private string stringToPrint;
        public static string filePath;
        private PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
        private PrintDocument pd = new PrintDocument();

        public FormMain()
        {
            InitializeComponent();
            BindingListVeicoli = new SerializableBindingList<Veicolo>();
            dgvVeicoli.AutoResizeColumns();
            dgvVeicoli.AutoResizeRows();
            dgvVeicoli.ClearSelection();
            dgvVeicoli.RowHeadersVisible = false;
            pd.PrintPage += new PrintPageEventHandler(this.printDoc_PrintPage);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            BindingListVeicoli.Clear();
            dgvVeicoli.DataSource = null;
            caricaDatiDiTest(); // TRADIZIONALE
            
            // A causa del provider, non mi permette alla connessione al database, il quale il motivo non so ancora, dopo aver consultato con alcuni.
            //UtilsDatabase.CreaTabella("Veicoli");
            //CaricaDati(); //TRAMITE IL DATABASE
        }

        private void caricaDatiDiTest()
        {
            Moto m = new Moto();
            BindingListVeicoli.Add(m);
            //UtilsDatabase.AggiungiVeicolo(m);// problemi di provider 
            m = new Moto("HONDA", "Tsunami", "Rosso", 1000, 120, DateTime.Now, false, false, 0, "Quintino", 15000);
            BindingListVeicoli.Add(m);
            //UtilsDatabase.AggiungiVeicolo(m); Problemi di provider.
            Auto a = new Auto("JEEP", "Compass", "Blue", 2400, 160.10, DateTime.Now, false, false, 0, 8, 30000);
            BindingListVeicoli.Add(a);

            //UtilsDatabase.AggiungiVeicolo(a); Problemi di provider, e per evitare che si interrompesse, l'ho messo come commento.

            dgvVeicoli.DataSource = BindingListVeicoli;

        }

        private void CaricaDati()
        {
            ///prendo i dati dal database  e li carico su bindinglistveicoli
            BindingListVeicoli = UtilsDatabase.OpenDataBaseToList(BindingListVeicoli);
            ///Carico su dgv
            dgvVeicoli.DataSource = BindingListVeicoli;
            
        }
        private void NuovoVeicolo_Click(object sender, EventArgs e)
        {
            FormDialogAggiungi dialogoAggiungi = new FormDialogAggiungi(BindingListVeicoli, this);
            dialogoAggiungi.ShowDialog();
        }

        private void AggiornaPagina_Click(object sender, EventArgs e)
        {
            ///aggiornare la pagina
            DialogResult=MessageBox.Show("Desideri di Salvare i dati prima di aprire ?","Warning",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Warning);
            if(DialogResult == DialogResult.Yes)
            {
                Salva();
                MessageBox.Show("Apertura del file, Attendi");
                dgvVeicoli.DataSource = null;
                this.FormMain_Load(this,new EventArgs()); ///Ricarica la pagina
                MessageBox.Show("File Aperto", "Apertura",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void Salva()
        {

            Utils.SerializeToCsv(BindingListVeicoli, @".\Data\Veicoli.csv");
            Utils.SerializeToJson(BindingListVeicoli, @".\Data\veicoli.json");
            Utils.SalvaVeicoloInFileTXT<Veicolo>(BindingListVeicoli, @".\Data\Veicoli_Stampa.txt");
            /// SALVATAGGIO LISTA IN JSON , Nella Cartella wwww per il sito //
            string json = @".\www\index.json";
            Utils.SerializeToJson(BindingListVeicoli, json);
            MessageBox.Show("File salvato correttamente");
            ScriviPage(); /// carico i dati sulla pagina html
            ///DEVO INSERIRE UNA FUNZIONE CHE MI PERMETTA DI SALVARE IL DATABASE DI VEICOLI
            
            //UtilsDatabase.AggiornaDataBase("Veicoli"); // problemi con il provider
        }
        private void Salva_Veicolo_Click(object sender, EventArgs e)
        {
            Salva();
        }

        private void StampaVeicolo_Click(object sender, EventArgs e)
        {
            //--------------------STAMPA-----------------------

            //Prima di stampare un file, salvo la lista in file .txt
            Utils.SalvaVeicoloInFileTXT<Veicolo>(BindingListVeicoli, @".\Data\Veicoli_Stampa.txt");
            Stampa();
        }


        private void Stampa()
        {
            try
            {
                string docName = @".\Data\Veicoli_Stampa.txt";
                printFont = new System.Drawing.Font("Times new Romans", 18, FontStyle.Bold);
                pd.DocumentName = docName;
                using (FileStream stream = new FileStream(docName, FileMode.Open))
                using (StreamReader reader = new StreamReader(stream))
                {
                    stringToPrint = reader.ReadToEnd();
                }
                printPreviewDialog.Document = pd;
                printPreviewDialog.ShowDialog();

                ///STAMPO DEL DOCUMENTO
                if (printPreviewDialog.ShowDialog() == DialogResult.OK)
                    pd.Print();
                else
                    this.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            int charactersOnPage = 0;
            int linesPerPage = 0;

            // Sets the value of charactersOnPage to the number of characters
            // of stringToPrint that will fit within the bounds of the page.
            e.Graphics.MeasureString(stringToPrint, this.Font,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);

            // Draws the string within the bounds of the page.
            e.Graphics.DrawString(stringToPrint, this.Font, Brushes.Black,
            e.MarginBounds, StringFormat.GenericTypographic);

            // Remove the portion of the string that has been printed.
            stringToPrint = stringToPrint.Substring(charactersOnPage);

            // Check to see if more pages are to be printed.
            e.HasMorePages = (stringToPrint.Length > 0);

            // If there are no more pages, reset the string to be printed.
            if (!e.HasMorePages)
                stringToPrint = stringToPrint;
        }

        private string ScriviPage()
        {
            string homepagePath = @".\www\index.html";
            //Utils.CreateHTML(BindingListVeicoli, homepagePath);
            string s = "";

            string html = File.ReadAllText(@".\www\index-Skeleton.html");

            html = html.Replace("{{head-title}}", "AUTOVALLAURI");
            html = html.Replace("{{body-title}}", "SALONE VALLAURI-VEICOLI NUOVI E USATI");
            html = html.Replace("{{body-subtitle}}", "le migliori occasioni al miglior prezzo");
            ///---------------Dati----------------
            int nDucati = 0;
            int nJeep = 0;
            int nMercedes = 0;
            int nHonda = 0;
            for (int i = 0; i < BindingListVeicoli.Count; i++)
            {
                switch (BindingListVeicoli[i].Marca)
                {
                    case "DUCATI":
                        {
                            s += AggiungiDivHTML("DUCATI", nDucati, i);
                            nDucati++;
                            break;
                        }
                    case "JEEP":
                        {
                            s += AggiungiDivHTML("JEEP", nJeep, i);
                            nJeep++;
                            break;
                        }
                    case "MERCEDES":
                        {
                            s += AggiungiDivHTML("MERCEDES", nMercedes, i);
                            nMercedes++;
                            break;
                        }
                    case "HONDA":
                        {
                            s += AggiungiDivHTML("HONDA", nHonda, i);
                            nHonda++;
                            break;
                        }
                }
            }
            html = html.Replace("{{main-content}}", s);
            File.WriteAllText(homepagePath, html);
            return homepagePath;
        }
        

        private string AggiungiDivHTML(string html, int i,int vehicles)
        {
            string s = "";
            s += $"<div class='Body-content' id='{i}'><div class='{html}'></div>";
            s += "<div class='Dettagli'><p> Marca:" +
                 BindingListVeicoli[vehicles].Marca + "<br>  MODELLO: "
                 + BindingListVeicoli[vehicles].Modello + "<br>  POTENZA KW: " +
                 BindingListVeicoli[vehicles].PotenzaKw + "<br> KM PERCORSI:" +
                 BindingListVeicoli[vehicles].KmPercorsi1 + "<br> CILINDRATA: " +
                 BindingListVeicoli[vehicles].Cilindarata + "<br>  COLORE: " +
                 BindingListVeicoli[vehicles].Colore;
            if (BindingListVeicoli[vehicles].IsUsato == false)
                s += "<br>USATO: NO";
            else
                s += "<br>USATO: SI";
            if (BindingListVeicoli[vehicles].IsKmZero == false)
                s += "<br>KM ZERO: NO";
            else
                s += "<br>KM ZERO: SI</p>";
            s += "</div></div>";
            return s;
        }

        private void btnWeb_Click(object sender, EventArgs e)
        {
            string homepagePath = ScriviPage();
            System.Diagnostics.Process.Start(homepagePath);

        }

        private void ExportWord_Click(object sender, EventArgs e)
        {
            using (WordprocessingDocument doc = WordprocessingDocument.Create(@".\Data\Volantino_Veicoli.docx", WordprocessingDocumentType.Document))
            {
                ///CREATION AND STRUCTURE OF WORD DOC
                MainDocumentPart mainPart = doc.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body docBody = new Body();
                mainPart.Document.AppendChild(docBody);
                ///Description of doC
                ///TITLE
                Paragraph Header_p = UtilsWord.CreateParagraphWithStyle("Heading", JustificationValues.Center);
                UtilsWord.AddTextToParagraph(Header_p, "VOLANTINO VEICOLI NUOVI E USATI ");
                docBody.AppendChild(Header_p);

                ///SUBTITLE
                Paragraph SubHeader_p = UtilsWord.CreateParagraphWithStyle("Content", JustificationValues.Center);
                UtilsWord.AddTextToParagraph(SubHeader_p, "Qui troverete i dati di tutti i veicoli nuovi e usati che abbiamo in disposizione");
                docBody.AppendChild(SubHeader_p);

                ///CONTENT
                Paragraph content = UtilsWord.CreateParagraphWithStyle("Content", JustificationValues.Center);
                DocumentFormat.OpenXml.Wordprocessing.Table tabella = new DocumentFormat.OpenXml.Wordprocessing.Table();
                string[] cars = new string[12];
                tabella = UtilsWord.createTable(mainPart, true, false, false, cars, JustificationValues.Center, BindingListVeicoli.Count, cars.Length);
                for (int i = 0; i < BindingListVeicoli.Count; i++)
                {
                    cars = Utils.ConvertVeicoliToString(BindingListVeicoli, i);
                    tabella.Append(UtilsWord.CreateRow(mainPart, cars, false, false, false, JustificationValues.Center, cars.Length));
                }
                docBody.AppendChild(tabella);

                Paragraph footer = UtilsWord.CreateParagraphWithStyle("Footer", JustificationValues.Left);
                UtilsWord.AddTextToParagraph(footer, "Created by Omkar Singh Rathore \n 2019-20 School-Project");
                docBody.AppendChild(footer);
                //UtilsWord.CreateBulletOrNumberedList();
                MessageBox.Show("I dati sono stati esportati in Document Word, Correttamente");
                DialogResult response = MessageBox.Show("Desideri di aprire il file .docx ? ", "Dettagli", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (response == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(@".\Data\Volantino_Veicoli.docx");
                }

            }
        }

        private void ExportExcel_Click(object sender, EventArgs e)
        {
            using (SpreadsheetDocument doc = SpreadsheetDocument.Create(@".\Data\Cars_Details.xlsx", SpreadsheetDocumentType.Workbook))
            {
                //Add WorkbookPart to the document
                WorkbookPart mainpart = doc.AddWorkbookPart();
                mainpart.Workbook = new Workbook();

                // Add a WorksheetPart to the WorkbookPart
                SheetData SheetData = new SheetData();
                WorksheetPart worksheetpart = mainpart.AddNewPart<WorksheetPart>();
                worksheetpart.Worksheet = new Worksheet(SheetData);

                // Add Sheets to the Workbook.
                Sheets sheets = doc.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());

                // Append a new worksheet and associate it with the workbook.
                Sheet sheet = new Sheet()
                {
                    Id = doc.WorkbookPart.GetIdOfPart(worksheetpart),
                    SheetId = 1,
                    Name = "MySheet"
                };
                // Add Stylesheet on workbook
                WorkbookStylesPart stylesPart = UtilsExcel.addStylesheet(mainpart);
                UtilsExcel.CreateHeader(SheetData,mainpart);
                string[] car = new string[12];
                for (int i = 0; i < BindingListVeicoli.Count; i++)
                {
                    car =Utils.ConvertVeicoliToString(BindingListVeicoli,i);
                    UtilsExcel.CreateContent(SheetData,mainpart,car);
                }
                sheets.Append(sheet);
                mainpart.Workbook.Save();
                // Close the document.
                doc.Close();
                MessageBox.Show("I Dati sono stati esportati in File Excel correttamente");
                DialogResult = MessageBox.Show("Desideri di aprire il file .xlsx","Dettagli",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(DialogResult == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(@".\Data\Cars_Details.xlsx");
                }

            }
        }

        private void ToolInfo_Click(object sender, EventArgs e)
        {
            Form_Info frm = new Form_Info();
            this.AddOwnedForm(frm);
            frm.ShowDialog();
        }
    }
}
