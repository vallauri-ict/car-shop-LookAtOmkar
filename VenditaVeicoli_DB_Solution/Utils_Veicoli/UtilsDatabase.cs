using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using VenditaVeicoliDLLProject;

namespace UtilsVeicoliDLLProject
{
    public class UtilsDatabase
    {

        public static string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Veicoli.accdb";

        public static void VisualizzaConsoleListaVeicoli()
        {
            ///Lista visualizzata in Console 
            if (connstr != null)
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
                        cmd.CommandText = "SELECT * FROM Veicoli";
                        OleDbDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows) //Significa che nella tabella ci sono dei dati
                        {

                            Console.WriteLine("LISTA VEICOLI");
                            Console.WriteLine("ID | MARCA | MODELLO | COLORE | CILINDRATA | POTENZAKW | IMMATRICOLAZIONE | USATO | KMZERO | KM_PERCORSI | NUMAIRBAG | MARCASELLA | PREZZO");
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9} | {10} | {11} | {12}",
                                                 reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetDouble(5),
                                                 reader.GetData(6), reader.GetBoolean(7), reader.GetBoolean(8), reader.GetInt32(9), reader.GetInt32(10), reader.GetString(11), reader.GetInt32(12));
                            }
                        }
                        else
                        {
                            Console.WriteLine("Veicoli Inesistenti");
                        }
                        reader.Close();
                    }

                }
                catch (OleDbException exc)
                {
                    throw new Exception("Connessione interrott " + exc);
                }
            }

        }

        public static void EliminaVeicolo(int id)
        {
            //Eliminazione di un solo record, passando per parametro, la sua chiave primaria
            try
            {
                OleDbConnection connection = new OleDbConnection(connstr);
                using (connection)
                {
                    connection.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = connection;
                    ///Comandi di eseguzione SQL
                    cmd.CommandText = "DELETE * FROM Veicoli WHERE ID = " + id;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (OleDbException exc)
            {
                throw new Exception("Connessione interrotta " + exc);
            }
        }

        public static void AggiungiVeicolo(Veicolo v)
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
                    ///Inserisco tutti i dettagli dell'auto
                    //////inserisco tutti i dettagli del moto
                    cmd.CommandText = @"INSERT INTO Veicoli(MARCA,MODELLO,COLORE,CILINDRATA,POTENZAKW,IMMATRICOLAZIONE,USATO,KMZERO,KM_PERCORSI,NUMAIRBAG,MARCASELLA,PREZZO)
                                        VALUES(@MARCA,@MODELLO,@COLORE,@CILINDRATA,@POTENZAKW,@IMMATRICOLAZIONE,@ISUSATO,@ISKMZERO,@KM_PERCORSI,@NUMAIRBAG,@MARCASELLA,@PREZZO)";
                    cmd.Parameters.Add("@MARCA", OleDbType.VarChar, 255).Value = v.Marca;
                    cmd.Parameters.Add("@MODELLO", OleDbType.VarChar, 255).Value = v.Modello;
                    cmd.Parameters.Add("@COLORE", OleDbType.VarChar, 255).Value = v.Colore;
                    cmd.Parameters.Add("@POTENZAKW", OleDbType.Integer).Value = v.PotenzaKw;
                    cmd.Parameters.Add("@IMMATRICOLAZIONE", OleDbType.Date).Value = v.Immatricolazione;
                    cmd.Parameters.Add("@ISUSATO", OleDbType.Boolean).Value = v.IsUsato;
                    cmd.Parameters.Add("@ISKMZERO", OleDbType.Boolean).Value = v.IsKmZero;
                    cmd.Parameters.Add("@KM_PERCORSI", OleDbType.Integer).Value = v.KmPercorsi1;
                    if (v is Auto) /// Devo anche mettere i parametri che hanno diversamente sia l'auto che la moto.
                    {
                        cmd.Parameters.Add("@NUMAIRBAG", OleDbType.Integer).Value = (v as Auto).NumAirBag;
                        cmd.Parameters.Add("@MARCASELLA", OleDbType.VarChar, 255).Value = " ";
                    }
                    else if (v is Moto) //anche se è ovvio(se non è auto, di sicuro sarà una moto), lo scrivo comunque, per sicurezza
                    {
                        cmd.Parameters.Add("@NUMAIRBAG", OleDbType.Integer).Value = null;
                        cmd.Parameters.Add("@MARCASELLA", OleDbType.VarChar, 255).Value = (v as Moto).MarcaSella;
                    }


                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (OleDbException exc)
            {
                Console.WriteLine("Errore --->" + exc.Message);
            }
        }



        public static void CreaTabella()
        {
            if (connstr != null)
            {
                OleDbConnection connection = new OleDbConnection(connstr);
                using (connection)
                {
                    connection.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = connection;
                    ///Comandi di eseguzione SQL
                    try
                    {
                        cmd.CommandText = @"CREATE TABLE Veicoli(
                                     ID INT NOT NULL PRIMARY KEY,
                                     MARCA  VARCHAR(255) NOT NULL,
                                     MODELLO VARCHAR(255) NOT NULL,
                                     COLORE VARCHAR(255) NOT NULL,
                                     CILINDRATA INT NOT NULL,
                                     POTENZAKW DOUBLE NOT NULL,
                                     IMMATRICOLAZIONE DATATIME NOT NULL,
                                     USATO CHECK (ISUSATO ==true)NOT NULL,
                                     KMZERO CHECK (ISKMZERO == true )NOT NULL,
                                     KM_PERCORSI INT ,
                                     NUMAIRBAG INT,
                                     MARCASELLA VARCHAR(255) NOT NULL,
                                     PREZZO INT NOT NULL,
                                     )";
                        cmd.ExecuteNonQuery();
                    }
                    catch (OleDbException exc)
                    {
                        Console.WriteLine("ERRORE --> " + exc.Message);
                    }
                }
            }
            else
            {
                Console.WriteLine("Problemi di connessione");
            }

        }
    }
}
