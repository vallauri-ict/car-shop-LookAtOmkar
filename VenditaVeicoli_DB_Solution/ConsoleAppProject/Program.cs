﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using VenditaVeicoliDLLProject;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using UtilsVeicoliDLLProject;

namespace ConsoleAppProject
{
    public class Program
    {
        public static string DbPath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\Veicoli.accdb";

        public static string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + DbPath;
        public static void Main(string[] args)
        {

            char scelta;
            //Moto m = new Moto();
            ///Console.WriteLine(m.Marca+" "+m.Modello); senza ovveride
            //Console.WriteLine(m); ///con ovveride
            //Auto a = new Auto();
            //Console.WriteLine(a);
            do
            {
                menu();
                Console.WriteLine("Digita un comando da eseguire : ");
                scelta = Console.ReadKey().KeyChar;
                switch (scelta)
                {
                    case '1':
                        {
                            ///Create Table
                            UtilsDatabase.CreaTabella("Veicoli");
                            Console.WriteLine("Tabella Creata Correttamente");
                            Console.ReadKey();
                            break;
                        }
                    case '2':
                        {
                            Veicolo v;
                            v=AddParamtresConsole();
                            ///Aggiunta in Database
                            UtilsDatabase.AggiungiVeicolo(v);
                            Console.WriteLine("Veicolo Aggiunto Correttamente");
                            Console.ReadKey();
                            break;
                        }
                    case '3':
                        {
                            ///Veicolo Eliminato in Database
                            Console.WriteLine("Inserisci ID del Veicolo da eliminare: ");
                            int Key = Convert.ToInt32(Console.ReadLine());
                            UtilsDatabase.EliminaVeicolo(Key);
                            Console.WriteLine("Veicolo Eliminato Correttamente");
                            Console.ReadKey();
                            break;
                        }
                    case '4':
                        {
                            ///Update Table with new Datas
                            string _option;
                            string Data_Mod;
                            String Id;
                            Console.WriteLine("SCRIVI ID DEL VEICOLO:");
                            Id = Console.ReadLine().ToUpper();
                            Console.WriteLine("MARCA|MODELLO|COLORE|CILINDRATA|POTENZAKW|USATO|KMZERO|KM_PERCORSI|NUMAIRBAG|MARCASELLA|PREZZO");
                            Console.WriteLine("SCEGLI OPZIONE: ");
                            _option = Console.ReadLine().ToUpper();
                            if ((_option == "USATO") || (_option == "KMZERO"))
                            {
                                Console.WriteLine($"SCRIVI IL DATO DI {_option} [SI][NO] : ");
                            }
                            else
                            {
                                Console.WriteLine($"SCRIVI IL DATO DI {_option} : ");
                            }
                            Data_Mod = Console.ReadLine().ToUpper();
                            UtilsDatabase.AggiornaDataBase("Veicoli",Id,_option,Data_Mod);
                            Console.WriteLine("Database aggiornato correttamente");
                            Console.ReadKey();
                            break;
                        }
                    case '5':
                        {
                            ///Destroy Table
                            string confirm;
                            Console.WriteLine("Sei sicuro di eliminare database[SI][NO] ?");
                            confirm = Console.ReadLine().ToUpper();
                            if(confirm=="SI")
                            {
                                UtilsDatabase.EliminaDataBase("Veicolo");
                                Console.WriteLine("Il database è stato eliminato con successo");
                            }
                            Console.ReadKey();
                            break;
                        }
                    case '6':
                        {
                            //Esclusivamente usato per console
                            UtilsDatabase.VisualizzaConsoleListaVeicoli();
                            Console.WriteLine("Ecco la lista dei veicoli");
                            Console.ReadKey();
                            break;
                        }
                    case '7':
                        {
                            Console.Clear();
                            break;
                        }
                }
            } while ((scelta != 'X') || (scelta != 'x'));

        }

        private static Veicolo AddParamtresConsole()
        {
            Veicolo v;
            Console.WriteLine("AUTO(A) O MOTO(M) ?");
            char Veicolo_scelto = Console.ReadKey().KeyChar;
            if ((Veicolo_scelto == 'A') || (Veicolo_scelto == 'a'))
                v = new Auto(); 
            else
                v = new Moto();
            Console.WriteLine("MARCA [DUCATI|HONDA|JEEP|MERCEDES] :");
            v.Marca = Console.ReadLine().ToUpper(); //Per evitare errori o confusioni, metto tutti gli input dati in maiuscolo
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
            if (v is Auto)
            {
                Console.WriteLine("NUMERO DI AIRBAG: ");
                (v as Auto).NumAirBag = Convert.ToInt32(Console.ReadLine().ToUpper());
            }
            else if (v is Moto)
            {
                Console.WriteLine("MARCA SELLA: ");
                (v as Moto).MarcaSella = Console.ReadLine().ToUpper();
            }
            Console.WriteLine("PREZZO:");
            v.Prezzo = Convert.ToInt32(Console.ReadLine().ToUpper());
            return v;
        }
        private static void menu()
        {
            Console.WriteLine("******** \t SALONE VENDITA VEICOLI NUOVI E USATI\t ********");
            Console.WriteLine("1 - CREA TABELLA");
            Console.WriteLine("2 - AGGIUNGI VEICOLO");
            Console.WriteLine("3 - ELIMINA VEICOLO");
            Console.WriteLine("4 - MODIFICA DATABASE");
            Console.WriteLine("5 - ELIMINA DATABASE ");
            Console.WriteLine("6 - LISTA DI VEICOLI");
            Console.WriteLine("7 - PULISCI");
            Console.WriteLine("X - CHIUDI \n ");
        }


    }
}
