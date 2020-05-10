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
                    cmd.CommandText = @"INSERT INTO Veicoli(MARCA,MODELLO,COLORE,CILINDRATA,POTENZAKW,IMMATRICOLAZIONE,ISUSATO,ISKMZERO,KM_PERCORSI,NUMAIRBAG,MARCASELLA,PREZZO)
                                        VALUES(@MARCA,@MODELLO,@COLORE,@CILINDRATA,@POTENZAKW,@IMMATRICOLAZIONE,@ISUSATO,@ISKMZERO,@KM_PERCORSI,@NUMAIRBAG,@MARCASELLA,@PREZZO)";
                    cmd.Parameters.Add("@MARCA",OleDbType.VarChar,255).Value=v.Marca;
                    cmd.Parameters.Add("@MODELLO",OleDbType.VarChar,255).Value=v.Modello;
                    cmd.Parameters.Add("@COLORE", OleDbType.VarChar, 255).Value = v.Colore;
                    cmd.Parameters.Add("@POTENZAKW",OleDbType.Integer).Value=v.PotenzaKw;
                    cmd.Parameters.Add("@IMMATRICOLAZIONE", OleDbType.Date).Value = v.Immatricolazione;
                    cmd.Parameters.Add("@ISUSATO",OleDbType.Boolean).Value=v.IsUsato;
                    cmd.Parameters.Add("@ISKMZERO", OleDbType.Boolean).Value = v.IsKmZero;
                    cmd.Parameters.Add("@KM_PERCORSI", OleDbType.Integer).Value = v.KmPercorsi1;
                    if(v is Auto) /// Devo anche mettere i parametri che hanno diversamente sia l'auto che la moto.
                    {
                        cmd.Parameters.Add("@NUMAIRBAG",OleDbType.Integer).Value=(v as Auto).NumAirBag;
                        cmd.Parameters.Add("@MARCASELLA",OleDbType.VarChar,255).Value= " ";
                    }
                    else if(v is Moto) //anche se è ovvio(se non è auto, di sicuro sarà una moto), lo scrivo comunque, per sicurezza
                    {
                        cmd.Parameters.Add("@NUMAIRBAG", OleDbType.Integer).Value = null;
                        cmd.Parameters.Add("@MARCASELLA", OleDbType.VarChar, 255).Value = (v as Moto).MarcaSella;
                    }


                    cmd.Prepare();
                    cmd.ExecuteNonQuery();   
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
                                     ISUSATO CHECK (ISUSATO ==true)NOT NULL,
                                     ISKMZERO CHECK (ISKMZERO == true )BIT NOT NULL,
                                     KM_PERCORSI INT ,
                                     NUMAIRBAG INT,
                                     MARCASELLA VARCHAR(255) NOT NULL,
                                     PREZZO INT NOT NULL,
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
