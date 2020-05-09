using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace VenditaVeicoliDLLProject
{
    public class UtilsDatabase
    {

       public static string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Veicoli.accdb";
   
        public static void VisualizzaListaVeicoli()
        {
            ///Lista visualizzata in Console 
            try
            {
                OleDbConnection connection = new OleDbConnection(connstr);
                using (connection)
                {
                    connection.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = connection;
                    ///Comandi di eseguzione SQL
                    cmd.CommandText = "SELECT * FROM Veicoli";
                    cmd.ExecuteNonQuery();

                }

            }
            catch (Exception)
            {
                throw new Exception("Connessione interrotta");
            }
        }

        public static void EliminaVeicolo()
        {
            try
            {
                OleDbConnection connection = new OleDbConnection(connstr);
                using (connection)
                {
                    connection.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = connection;
                    ///Comandi di eseguzione SQL
                    //cmd.CommandText =;
                }

            }
            catch (Exception)
            {
                throw new Exception("Connessione interrotta");
            }
        }

        public static void AggiungiVeicolo(string Veicolo)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection(connstr);
                using (connection)
                {
                    connection.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = connection;
                    ///Comandi di eseguzione SQL
                    if(Veicolo.ToUpper() =="AUTO")
                    {
                        ///Inserisco tutti i dettagli dell'auto, tenendo conto la classe Auto.cs
                        //cmd.CommandText = @"INSERT INTO Veicoli(ID,MARCA,MODELLO,COLORE,CILINDRATA,POTENZAKW,IMMATRICOLAZIONE) VALUES()";
                    }
                    else if(Veicolo.ToUpper() =="MOTO")
                    {
                        ///inserisco tutti i dettagli del moto, tenendo conto la classe Moto.cs
                    }

                    
                }

            }
            catch (Exception)
            {
                throw new Exception("Connessione interrotta");
            }
        }

        public static void CreaTabella()
        {
            if(connstr != null)
            {
                OleDbConnection connection = new OleDbConnection(connstr);
                using (connection)
                {
                    connection.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = connection;
                    ///Comandi di eseguzione SQL
                    cmd.CommandText =@"CREATE TABLE Veicoli(
                                     ID INT NOT NULL PRIMARY KEY,
                                     MARCA  VARCHAR(255) NOT NULL,
                                     MODELLO VARCHAR(255) NOT NULL,
                                     COLORE VARCHAR(255) NOT NULL,
                                     CILINDRATA INT NOT NULL,
                                     POTENZAKW DOUBLE NOT NULL,
                                     IMMATRICOLAZIONE DATATIME NOT NULL,
                                     )";
                    cmd.ExecuteNonQuery();
                }
            }
            else
            {
                Console.WriteLine("Problemi di connessione");
            }

        }
    }
}
