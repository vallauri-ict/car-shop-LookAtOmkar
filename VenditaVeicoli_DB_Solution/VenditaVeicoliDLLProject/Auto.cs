using System;
using System.Collections.Generic;
using System.Text;

namespace VenditaVeicoliDLLProject
{
    [Serializable()]
    public class Auto : Veicolo ///eredita dal veicolo
    {

        private int numAirBag;


        public Auto() : base(  ///c'è l'abbiamo nella classe base, this,ovvero nella classe veicolo 
            "MERCEDES",
            "Glx",
            "Nero",
            2100,
            175.30,
            new DateTime(),
            false,
            false,
            0)
        {
            numAirBag = 6;
        }

        public Auto(string marca, string modello, string colore, int cilindarata, double potenzaKw, DateTime immatricolazione, bool isUsato, bool isKmZero, int kmPercorsi,int numAirBag) : base(
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
            this.NumAirBag = numAirBag;
        }

        public int NumAirBag { get => numAirBag; set => numAirBag = value; }

        public override string ToString()
        {
            return $"Auto { base.ToString()} - {this.NumAirBag}  Airbag";
        }
    }
}
