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

        //di solito i file stanno all'interno del debug, ma visto che io l'ho messo fuori dal debug, bisogna fare in questo modo
        public static string DataBaseFullPath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\Veicoli.accdb";
        public static string connstr = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={DataBaseFullPath}";
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
                            Console.WriteLine("ID | TIPO | MARCA | MODELLO | COLORE | CILINDRATA | POTENZAKW | IMMATRICOLAZIONE | USATO | KMZERO | KM_PERCORSI | NUMAIRBAG | MARCASELLA | PREZZO");
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
                    throw new Exception("Connessione interrotta " + exc);
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
                    cmd.CommandText = $"DELETE * FROM Veicoli WHERE ID ={id}";
                    cmd.ExecuteNonQuery();
                }

            }
            catch (OleDbException exc)
            {
                throw new Exception("Connessione interrotta " + exc);
            }
        }

        private static void AddParametres(Veicolo v,OleDbCommand cmd)
        {

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
                cmd.Parameters.Add("@TIPO", OleDbType.VarChar, 255).Value = "AUTO";
                cmd.Parameters.Add("@NUMAIRBAG", OleDbType.Integer).Value = (v as Auto).NumAirBag;
                cmd.Parameters.Add("@MARCASELLA", OleDbType.VarChar, 255).Value = " ";
            }
            else if (v is Moto) //anche se è ovvio(se non è auto, di sicuro sarà una moto), lo scrivo comunque, per sicurezza
            {
                cmd.Parameters.Add("@TIPO", OleDbType.VarChar, 255).Value = "MOTO";
                cmd.Parameters.Add("@NUMAIRBAG", OleDbType.Integer).Value = null;
                cmd.Parameters.Add("@MARCASELLA", OleDbType.VarChar, 255).Value = (v as Moto).MarcaSella;
            }
        }

        public static void AggiornaDataBase(string tablename,string id,string option,string data)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection(connstr);
                using(connection)
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = $@"UPDATE {tablename} SET MARCA = @MARCA, MODELLO = @MODELLO, COLORE = @COLORE, CILINDRATA = @CILINDRATA, POTENZAKW = @POTENZAKW,
                                        IMMATRICOLAZIONE = @IMMATRICOLAZIONE, USATO= @USATO, KMZERO=@KMZERO, KM_PERCORSI=@KM_PERCORSI ,NUMAIRBAG = @NUMAIRBAG, MARCASELLA = @MARCASELLA, PREZZO = @PREZZO WHERE ID={id}";
                    if((option == "MARCA")|| (option == "MODELLO")|| (option == "COLORE")|| (option == "MARCASELLA"))
                    {
                        cmd.Parameters.Add($"{option}",OleDbType.VarChar,255).Value=data;
                    }
                    else if((option == "CILINDRATA" )|| (option == "KM_PERCORSI") || (option == "NUMAIRBAG") || (option == "PREZZO"))
                    {
                        cmd.Parameters.Add($"{option}",OleDbType.Integer).Value=data;
                    }
                    else if(option == "POTENZAKW")
                    {
                        cmd.Parameters.Add($"{option}", OleDbType.Double).Value = data;
                    }
                    else if((option == "USATO") ||(option == "KMZERO"))
                    {
                        cmd.Parameters.Add($"{option}", OleDbType.Boolean).Value = data;
                    }
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
            catch(OleDbException exc) { };
        }


        public static void EliminaDataBase(string tablename)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection(connstr);
                using(connection)
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = $"DROP TABLE {tablename}";
                    cmd.ExecuteNonQuery();
                }
            }
            catch(OleDbException exc) { }
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
                    cmd.CommandText = @"INSERT INTO Veicoli(TIPO,MARCA,MODELLO,COLORE,CILINDRATA,POTENZAKW,IMMATRICOLAZIONE,USATO,KMZERO,KM_PERCORSI,NUMAIRBAG,MARCASELLA,PREZZO)
                                        VALUES(@TIPO,@MARCA,@MODELLO,@COLORE,@CILINDRATA,@POTENZAKW,@IMMATRICOLAZIONE,@ISUSATO,@ISKMZERO,@KM_PERCORSI,@NUMAIRBAG,@MARCASELLA,@PREZZO)";
                    AddParametres(v,cmd);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (OleDbException exc)
            {
                throw new Exception("Errore --->" + exc.Message);
            }
        }

        //Serve per prendere i dati dal database, e caricarli su SerializeBindingList. Lo uso all'inizio di form_load, quando su dgv bisogna caricare i
        // dati presi dal database.
        public static SerializableBindingList<Veicolo> OpenDataBaseToList(SerializableBindingList<Veicolo> listaVeicoli)
        {
            if (connstr != null)
            {
                OleDbConnection connection = new OleDbConnection(connstr);
                using (connection)
                {
                    connection.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    try
                    {
                        OleDbDataReader rd = cmd.ExecuteReader();
                        while (rd.Read()) //finchè ci sono le righe
                        {
                            if (rd.GetString(1) == "AUTO")
                            {
                                listaVeicoli.Add(new Auto(rd.GetString(1), rd.GetString(2), rd.GetString(3), rd.GetInt32(4), rd.GetDouble(5),
                                                     rd.GetDateTime(6), rd.GetBoolean(7), rd.GetBoolean(8), rd.GetInt32(9), rd.GetInt32(10), rd.GetInt32(11)));
                            }
                            else if (rd.GetString(1) == "MOTO")
                            {
                                listaVeicoli.Add(new Moto(rd.GetString(1), rd.GetString(2), rd.GetString(3), rd.GetInt32(4), rd.GetDouble(5),
                                                     rd.GetDateTime(6), rd.GetBoolean(7), rd.GetBoolean(8), rd.GetInt32(9), rd.GetString(10), rd.GetInt32(11)));
                            }
                        }
                        rd.Close();
                    }
                    catch (OleDbException exc) { };
                }
            }
            return listaVeicoli;
        }



        public static void CreaTabella(string tablename)
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
                        cmd.CommandText = $@"CREATE TABLE {tablename}(
                                     ID INT NOT NULL AUTO_INCREMENT,
                                     TIPO VARCHAR(255) NOT NULL,
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
                                     PRIMARY KEY (ID)
                                     )";
                        cmd.ExecuteNonQuery();
                    }
                    catch (OleDbException exc)
                    {
                        throw new Exception(exc.Message);
                        System.Threading.Thread.Sleep(2000);
                    }
                }
            }
        }
    }
}
