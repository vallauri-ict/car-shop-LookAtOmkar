using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.ComponentModel;
using System.Reflection;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace VenditaVeicoliDLLProject
{

    [Serializable]
    public class SerializableBindingList<T> : BindingList<T> { }

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
            string json = JsonConvert.SerializeObject(objectlist, Formatting.Indented);
            File.WriteAllText(pathName, json);
        }

        public static void CreateHTML<T>(IEnumerable<T> objectList,string pathname,string skeletonPathName = @".\www\index-Skeleton.html")
        {
            string html = File.ReadAllText(skeletonPathName);
            html = html.Replace("{{head-title}}","AUTOVALLAURI");
            html = html.Replace("{{body-title}}", "SALONE VALLAURI-VEICOLI NUOVI E USATI");
            html = html.Replace("{{body-subtitle}}", "le migliori occasioni al miglior prezzo");
            html = html.Replace("{{main-content}}", "...(qui ci sarà le liste dei veicoli in vendite)...");
            File.WriteAllText(pathname, html);
        }
    }
}
