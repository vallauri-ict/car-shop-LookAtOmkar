using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.ComponentModel;
using System.Reflection;
using Newtonsoft.Json;
using System.Xml;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using UtilsVeicoliDLLProject;
using VenditaVeicoliDLLProject;

namespace UtilsVeicoliDLLProject
{

    [Serializable]
    public  class  SerializableBindingList<T> : BindingList<T> { }

    public class Utils
    {
        public static IEnumerable<string> ToCsv<T>(IEnumerable<T> objectlist, string separator = "|")
        {
            foreach (var o in objectlist)
            {
                FieldInfo[] fields = o.GetType().GetFields();
                PropertyInfo[] properties = o.GetType().GetProperties();

                yield return string.Join(separator, fields.Select(f => (f.GetValue(o) ?? "").ToString())
                    .Concat(properties.Select(p => (p.GetValue(o, null) ?? "").ToString())).ToArray());
            }
        }

        public static string ToCsvString<T>(IEnumerable<T> objectlist, string separator = "|")
        {
            StringBuilder csvdata = new StringBuilder();
            foreach (var o in objectlist)
            {
                FieldInfo[] fields = o.GetType().GetFields();
                PropertyInfo[] properties = o.GetType().GetProperties();

                csvdata.AppendLine(string.Join(separator, fields.Select(f => (f.GetValue(o) ?? "").ToString())
                    .Concat(properties.Select(p => (p.GetValue(o, null) ?? "").ToString())).ToArray()));
            }
            return csvdata.ToString();
        }

        public static void SerializeToCsv<T>(IEnumerable<T> objectlist, string pathName, string separator = "|")
        {
            IEnumerable<string> dataToSave = Utils.ToCsv(objectlist, separator);
            File.WriteAllLines(pathName, dataToSave);
        }

        public static void SerializeToXml<T>(SerializableBindingList<T> objectlist, string pathName)
        {
            XmlSerializer x = new XmlSerializer(typeof(SerializableBindingList<T>));
            TextWriter writer = new StreamWriter(pathName);
            x.Serialize(writer, objectlist);
        }

        public static void SerializeToJson<T>(IEnumerable<T> objectlist, string pathName)
        {
            string json = JsonConvert.SerializeObject(objectlist, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(pathName, json);
        }

        public static void CreateHTML<T>(IEnumerable<T> objectList, string pathname, string skeletonPathName = @".\www\index-Skeleton.html")
        {
            string html = File.ReadAllText(skeletonPathName);
            html = html.Replace("{{head-title}}", "AUTOVALLAURI");
            html = html.Replace("{{body-title}}", "SALONE VALLAURI-VEICOLI NUOVI E USATI");
            html = html.Replace("{{body-subtitle}}", "le migliori occasioni al miglior prezzo");
            html = html.Replace("{{main-content}}", "...(qui ci sarà le liste dei veicoli in vendite)...");
            File.WriteAllText(pathname, html);
        }

        public static void SalvaVeicoloInFileTXT<T>(SerializableBindingList<VenditaVeicoliDLLProject.Veicolo> BindingListVeicoli,string path)
        {
            string titolo = "*******VEICOLI NUOVI E USATI*******";
            string s="";
            s += titolo+"\n\n";
            string kmzero="";
            string usato="";
            string head_colonna = "ID \t| TIPO \t| MARCA \t| MODELLO \t| COLORE \t| CILINDRATA \t| POTENZAKW \t| IMMATRICOLAZIONE \t| USATO \t| KMZERO \t| KM_PERCORSI \t| PREZZO";
            s += head_colonna + "\n"+"__________________________________________________________________________________________________________________________\n";
            /// tutti i dati della lista Veicoli
            for (int i = 0; i < BindingListVeicoli.Count; i++)
            {
                int found = BindingListVeicoli[i].ToString().IndexOf(":");
                string Header = BindingListVeicoli[i].ToString().Substring(0, found);
                s += (Header + ": \t");
                if (BindingListVeicoli[i].IsKmZero == true)
                    kmzero = "SI";
                else
                    kmzero = "NO";
                if (BindingListVeicoli[i].IsUsato == true)
                    usato = "SI";
                else
                    usato = "NO";
                s +=(BindingListVeicoli[i].Marca + "\t" +
                             BindingListVeicoli[i].Modello + "\t" +
                             BindingListVeicoli[i].Colore + "\t" +
                             BindingListVeicoli[i].Cilindarata + "\t" +
                             BindingListVeicoli[i].PotenzaKw + "\t" +
                             BindingListVeicoli[i].Immatricolazione + "\t" +
                             usato+ "\t" +
                             kmzero+ "\t" +
                             BindingListVeicoli[i].KmPercorsi1 + "\t" +
                             BindingListVeicoli[i].Prezzo + "\t"
                             );
                s += "\n";
            }
            File.WriteAllText(path,s);
        }
        public static string[] ConvertVeicoliToString(SerializableBindingList<Veicolo> BindingListVeicoli, int i)
        {
            string[] car = new string[12];
            car[0] = BindingListVeicoli[i].Marca;
            car[1] = BindingListVeicoli[i].Modello;
            car[2] = BindingListVeicoli[i].Colore;
            car[3] = BindingListVeicoli[i].Cilindarata.ToString();
            car[4] = BindingListVeicoli[i].PotenzaKw.ToString();
            car[5] = BindingListVeicoli[i].Immatricolazione.ToShortDateString();
            car[6] = BindingListVeicoli[i].IsUsato.ToString();
            car[7] = BindingListVeicoli[i].IsKmZero.ToString();
            car[8] = BindingListVeicoli[i].KmPercorsi1.ToString();
            if (BindingListVeicoli[i] is Auto)
            {
                car[9] = (BindingListVeicoli[i] as Auto).NumAirBag.ToString();
            }
            else if (BindingListVeicoli[i] is Moto)
            {
                car[9] = (BindingListVeicoli[i] as Moto).MarcaSella.ToString();
            }
            car[11] = BindingListVeicoli[i].Prezzo.ToString();
            return car;
        }
    }
}
