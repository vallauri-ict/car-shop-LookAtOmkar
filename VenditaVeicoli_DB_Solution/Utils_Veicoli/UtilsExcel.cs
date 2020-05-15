using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using X14 = DocumentFormat.OpenXml.Office2010.Excel; //Obbligatoria
using X15 = DocumentFormat.OpenXml.Office2013.Excel; //Obbligatoria
using x16 = DocumentFormat.OpenXml.Office2016.Excel;
using System.IO;

namespace VenditaVeicoliDLLProject
{
    public class UtilsExcel
    {
        public static WorkbookStylesPart addStylesheet(WorkbookPart mainpart)
        {
            //Add a new workbooksylepart for the style of sheets
            WorkbookStylesPart stylesPart = mainpart.AddNewPart<WorkbookStylesPart>();
            stylesPart.Stylesheet = new Stylesheet();
            // blank font list
            stylesPart.Stylesheet.Fonts = new DocumentFormat.OpenXml.Spreadsheet.Fonts();
            stylesPart.Stylesheet.Fonts.Count = 1;
            stylesPart.Stylesheet.Fonts.AppendChild(new DocumentFormat.OpenXml.Spreadsheet.Font());
            // create fills
            stylesPart.Stylesheet.Fills = new Fills();
            // create a solid pattern
            var solid = new PatternFill() { PatternType = PatternValues.Solid };
            solid.ForegroundColor = new ForegroundColor { Rgb = HexBinaryValue.FromString("FFFF0000") };
            solid.BackgroundColor = new BackgroundColor { Indexed = 64 };

            stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = new PatternFill { PatternType = PatternValues.None } }); // required, reserved by Excel
            stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = new PatternFill { PatternType = PatternValues.Gray125 } }); // required, reserved by Excel
            stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = solid });
            stylesPart.Stylesheet.Fills.Count = 3;

            // blank border list
            stylesPart.Stylesheet.Borders = new Borders();
            stylesPart.Stylesheet.Borders.Count = 1;
            stylesPart.Stylesheet.Borders.AppendChild(new DocumentFormat.OpenXml.Spreadsheet.Border());

            // blank cell format list
            stylesPart.Stylesheet.CellStyleFormats = new CellStyleFormats();
            stylesPart.Stylesheet.CellStyleFormats.Count = 1;
            stylesPart.Stylesheet.CellStyleFormats.AppendChild(new CellFormat());

            // cell format list
            stylesPart.Stylesheet.CellFormats = new CellFormats();
            // empty one for index 0, seems to be required
            stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat());
            // cell format references style format 0, font 0, border 0, fill 2 and applies the fill
            stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 0, BorderId = 0, FillId = 2, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Center });
            stylesPart.Stylesheet.CellFormats.Count = 2;
            stylesPart.Stylesheet.Save();
            return stylesPart;
        }

        public static void CreateHeader(SheetData SheetData, WorkbookPart mainpart)
        {
            ///Add Header of Sheet
            Row tr = new Row() { RowIndex = 1 };
            string[] header = new string[] { "MARCA", "MODELLO", "COLORE", "CILINDRATA", "POTENZAKW", "IMMATRICOLAZIONE", "USATO", "KMZERO", "KM_PERCORSI", "NUMAIRBAG", "MARCASELLA", "PREZZO" };
            for (int i = 0; i < header.Length; i++)
            {
                Cell tc = new Cell() { CellValue = new CellValue(header[i]), DataType = CellValues.String };
                CellStyle style = new CellStyle();
                tc.AppendChild(style);
                tr.Append(tc);
            }
            SheetData.Append(tr);
        }

        public static void CreateContent(SheetData sheetData, WorkbookPart mainpart,string[] content)
        {
            Row tr = new Row();
            for (int i = 0; i < content.Length; i++)
            {
                Cell tc = new Cell() {CellValue = new CellValue(content[i]),DataType = CellValues.String};
                tr.Append(tc);
            }
            sheetData.Append(tr);
        }
    }
}
