using System;
using VenditaVeicoliDLLProject;
using System.Data.OleDb;

namespace ConsoleAppProject
{
    public class Program
    {
       
        static void Main(string[] args)
        {
            char scelta;


            //Moto m = new Moto();
            ///Console.WriteLine(m.Marca+" "+m.Modello); senza ovveride
            //Console.WriteLine(m); ///con ovveride
            //Auto a = new Auto();
            //Console.WriteLine(a);


            SerializableBindingList<Veicolo> BindingListVeicoli = new SerializableBindingList<Veicolo>();
            
            do
            {
                menu();
                Console.WriteLine("Digita un comando da eseguire : ");
                scelta = Console.ReadKey().KeyChar;
                switch (scelta)
                {
                    case '1':
                        {
                            UtilsDatabase.CreaTabella();
                            Console.WriteLine("Tabella Creata");
                            Console.ReadKey();
                            break;
                        }
                    case '2':
                        {
                            //Aggiungere un veicolo
                            Veicolo v;
                            Console.WriteLine("AUTO(A) O MOTO(M) ?");
                            char Veicolo_scelto = Console.ReadKey().KeyChar;
                            if((Veicolo_scelto =='A')||(Veicolo_scelto== 'a'))
                                v = new Auto();
                            else
                                v = new Moto();
                            Console.WriteLine("MARCA [DUCATI|HONDA|JEEP|MERCEDES] :");
                            v.Marca  =  Console.ReadLine().ToUpper(); //Per evitare errori o confusioni, metto tutti gli input dati in maiuscolo
                            Console.WriteLine("MODELLO [MONSTER|DIAVEL|CIVIC|JAZZ|WRANGLER|COMPASS|CLASSE_A|G_WAGON] : ");
                            v.Modello = Console.ReadLine().ToUpper();
                            Console.WriteLine("COLORE :");
                            v.Colore = Console.ReadLine().ToUpper();
                            Console.WriteLine("CILINDRATA: ");
                            v.Cilindarata = Convert.ToInt32(Console.ReadLine().ToUpper());
                            Console.WriteLine("POTENZA KW: ");
                            v.PotenzaKw = Convert.ToDouble(Console.ReadLine().ToUpper());
                            ///La data di immatricolazione metto come data attuale.
                            v.Immatricolazione = DateTime.Now;
                            string isUsato;
                            Console.WriteLine("E' USATO [SI|NO]: ");
                            isUsato = Console.ReadLine().ToUpper();
                            if (isUsato == "SI")
                                v.IsUsato = true;
                            else
                                v.IsUsato = false;
                            string isKmZero;
                            Console.WriteLine("E' A KM ZERO [SI|NO]: ");
                            isKmZero = Console.ReadLine().ToUpper();
                            if (isUsato == "SI")
                            {
                                v.IsKmZero = true;
                                v.KmPercorsi1 = 0;
                            }
                            else
                            {
                                v.IsKmZero = false;
                                Console.WriteLine("KM PERCORSI :");
                                v.KmPercorsi1 = Convert.ToInt32(Console.ReadLine().ToUpper());
                            }
                            if(v is Auto)
                            {
                                Console.WriteLine("NUMERO DI AIRBAG: ");
                                (v as Auto).NumAirBag = Convert.ToInt32(Console.ReadLine().ToUpper());
                            }
                            else if(v is Moto)
                            {
                                Console.WriteLine("MARCA SELLA: ");
                                (v as Moto).MarcaSella = Console.ReadLine().ToUpper();
                            }
                            Console.WriteLine("PREZZO:");
                            v.Prezzo = Convert.ToInt32(Console.ReadLine().ToUpper());


                            ///Aggiunta in Database
                            UtilsDatabase.AggiungiVeicolo(v);
                            BindingListVeicoli.Add(v);
                            Console.WriteLine("Veicolo Aggiunto Correttamente");
                            Console.ReadKey();
                            break;
                        }
                    case '3':
                        {
                            ///Veicolo Eliminato in Database
                            UtilsDatabase.EliminaVeicolo();
                            Console.WriteLine("Veicolo Eliminato");
                            Console.ReadKey();
                            break;
                        }
                    case '4':
                        {
                            //Esclusivamente usato per console
                            UtilsDatabase.VisualizzaListaVeicoli();
                            Console.ReadKey();
                            break;
                        }
                }
            } while ((scelta !='X')||(scelta != 'x'));
           
        }

        private static void menu()
        {
            Console.WriteLine("**** SALONE VENDITA VEICOLI NUOVI E USATI ****");
            Console.WriteLine("1 - CREA TABELLA");
            Console.WriteLine("2 - AGGIUNGI VEICOLO");
            Console.WriteLine("3 - ELIMINA VEICOLO");
            Console.WriteLine("4 - LISTA DI VEICOLI");
            Console.WriteLine("X - CHIUDI \n ");
        }


    }
}
