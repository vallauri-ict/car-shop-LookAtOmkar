using System;

namespace VenditaVeicoliDLLProject
{
    [Serializable()]
    public class Moto:Veicolo //eredita dalla classe veicolo
    {

        private string marcaSella;

        public Moto():base(  ///base=classe veicolo 
            "DUCATI",
            "Squalo",
            "Nero",
            1000,
            75.20,
            new DateTime(),
            false,
            false,
            0)
        {
            this.MarcaSella = "Cavallino";
        }

        public Moto(string marca, string modello, string colore, int cilindarata, double potenzaKw, DateTime immatricolazione, bool isUsato, bool isKmZero, int kmPercorsi,string marcaSella) : base(
           marca,
           modello,
           colore,
           cilindarata,
           potenzaKw,
           immatricolazione,
           isUsato,
           isKmZero,
           kmPercorsi)
        {
            this.MarcaSella = marcaSella;
        }

        public string MarcaSella { get => marcaSella; set => marcaSella = value; }

        public override string ToString()
        {
            return $"Moto:{ base.ToString()} - Sella {this.MarcaSella}";
        }
    }
}
