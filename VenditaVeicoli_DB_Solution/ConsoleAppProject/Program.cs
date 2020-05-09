using System;
using VenditaVeicoliDLLProject;
using System.Data.OleDb;

namespace ConsoleAppProject
{
    class Program
    {
        private static void Main(string[] args)
        {
            char scelta;
            Moto m = new Moto();
            ///Console.WriteLine(m.Marca+" "+m.Modello); senza ovveride
            Console.WriteLine(m); ///con ovveride
            Auto a = new Auto();
            Console.WriteLine(a);
            do
            {
                Console.WriteLine("**** SALONE VENDITA VEICOLI NUOVI E USATI ****");
                menu();
                Console.WriteLine("Digita un comando da eseguire : ");
                scelta = Console.ReadKey().KeyChar;
                switch (scelta)
                {
                    case '1':
                        {
                            UtilsDatabase.CreaTabella();
                            Console.WriteLine("Tabella Creata");
                            break;
                        }
                    case '2':
                        {
                            Console.WriteLine("AUTO O MOTO ?");
                            string Veicolo_scelto = Console.ReadLine();
                            UtilsDatabase.AggiungiVeicolo(Veicolo_scelto);
                            Console.WriteLine("Veicolo Aggiunto");
                            break;
                        }
                    case '3':
                        {
                            UtilsDatabase.EliminaVeicolo();
                            Console.WriteLine("Veicolo Eliminato");
                            break;
                        }
                    case '4':
                        {
                           UtilsDatabase.VisualizzaListaVeicoli();
                            break;
                        }
                }
            } while ((scelta !='X')||(scelta != 'x'));
           
        }

        private static void menu()
        {
            Console.WriteLine("1 - CREA TABELLA");
            Console.WriteLine("2 - AGGIUNGI VEICOLO");
            Console.WriteLine("3 - ELIMINA VEICOLO");
            Console.WriteLine("4 - LISTA DI VEICOLI");
            Console.WriteLine("X - CHIUDI  ");
        }


    }
}
