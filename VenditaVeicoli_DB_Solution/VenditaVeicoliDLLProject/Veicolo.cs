using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace VenditaVeicoliDLLProject
{
    [Serializable()]
    [XmlInclude(typeof(Moto))]
    [XmlInclude(typeof(Auto))]
    public class Veicolo
    {
        //Concetto astratto 
        #region fields
        ///Campi
        private string marca;
        private string modello;
        private string colore;
        private int cilindarata;
        private double potenzaKw;
        private DateTime immatricolazione;
        private bool isUsato;
        private bool isKmZero;
        private int KmPercorsi;
        private int prezzo;

        #endregion

        public Veicolo(string marca, string modello, string colore, int cilindarata, double potenzaKw, DateTime immatricolazione, bool isUsato, bool isKmZero, int kmPercorsi, int prezzo)
        {
            this.Marca = marca;
            this.Modello = modello;
            this.Colore = colore;
            this.Cilindarata = cilindarata;
            this.PotenzaKw = potenzaKw;
            this.Immatricolazione = immatricolazione;
            this.IsUsato = isUsato;
            this.IsKmZero = isKmZero;
            this.KmPercorsi1 = kmPercorsi;
            this.Prezzo = prezzo;

        }
        public string Marca { get => marca.ToUpper(); set => marca = value; }
        public string Modello { get => modello; set => modello = value; }
        public string Colore { get => colore; set => colore = value; }
        public int Cilindarata { get => cilindarata; set => cilindarata = value; }
        public double PotenzaKw { get => potenzaKw; set => potenzaKw = value; }
        public DateTime Immatricolazione { get => immatricolazione; set => immatricolazione = value; }
        public bool IsUsato { get => isUsato; set => isUsato = value; }
        public bool IsKmZero { get => isKmZero; set => isKmZero = value; }
        public int KmPercorsi1 { get => KmPercorsi; set => KmPercorsi = value; }
        public int Prezzo { get => prezzo; set => prezzo = value; }

        public override string ToString()
        {
            return $": {this.Marca} {this.Modello}  ({this.Colore})";
        }
    }
}
