﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace KIOSKScreenConfigurator.DAL
{    // I AM USING SINGILTON DESIGN PATTERN TO HAVE 1 INSTANCE OF DATACCESSLAYER DURING RUNTIME 
    class DataAccessLayer
    {
        static DataAccessLayer Instance;
        static SqlConnection sqlConnection;

        // constructer to establish the connection 
        private DataAccessLayer(String conString)
        {
            try
            {
                sqlConnection = new SqlConnection(conString);
            }
            catch (Exception ex)
            {
                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\LogFile.txt", true);
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("message : \n\n" + ex.Message);
                sw.WriteLine("------------------------------------\n\n");
                sw.WriteLine("stack trace : \n\n" + ex.StackTrace + "\n\n");

                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for mor info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt");
                sw.Close();


            }
        }

        
        public static DataAccessLayer getConInstance ()
        {
            if (sqlConnection == null)
                if(File.Exists(Directory.GetCurrentDirectory() + @"\constring.txt"))
            {
                    StreamReader sw2 = new StreamReader(Directory.GetCurrentDirectory() + @"\constring.txt");
                 

                    Instance = new DataAccessLayer(sw2.ReadLine());
                    sw2.Close();
            }
            
            
                return Instance;
            
        }

        // method to open the connection 

        public bool Open()
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
                return true;
            }
            else
                return false;
        }

        // method to close the connection 
        public bool Close()
        {
            if (sqlConnection.State != ConnectionState.Closed)
            {
                sqlConnection.Close();
                return true;
            }
            else
                return false;
        }

        //method to read data from database 

        public DataTable SelectData(string stored_proc, SqlParameter[] param)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = stored_proc;
                sqlCommand.Connection = sqlConnection;


                if (param != null)
                {
                    for (int i = 0; i < param.Length; i++)
                        sqlCommand.Parameters.Add(param[i]);
                }
                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\LogFile.txt", true);
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("message : \n\n" + ex.Message);
                sw.WriteLine("------------------------------------\n\n");
                sw.WriteLine("stack trace : \n\n" + ex.StackTrace +"\n\n");

                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for mor info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt");
                sw.Close();


            }
            return null; 

        }


        //method to delete insert update to database 

        public bool  myExcute(string stored_proc, SqlParameter[] param)
        {
            int x=-1;
            try
            {

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = stored_proc;
                sqlCommand.Connection = sqlConnection;
                if (param != null)
                {
                    for (int i = 0; i < param.Length; i++)
                        sqlCommand.Parameters.Add(param[i]);
                }
              x  = sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\LogFile.txt", true);
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("message : \n\n" + ex.Message);
                sw.WriteLine("------------------------------------\n\n");
                sw.WriteLine("stack trace : \n\n" + ex.StackTrace + "\n\n");

                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for mor info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt");
                sw.Close();


            }



            if (x > 0)
                return true;
            else
                return false; 

        }

        public static  bool TestCon ( string constring)
        {
            try
            {
                SqlConnection con = new SqlConnection(constring);
                con.Open();
                

                
                if (con.State == ConnectionState. Open || con.State == ConnectionState.Open)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\LogFile.txt", true);
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("message : \n\n" + ex.Message);
                sw.WriteLine("------------------------------------\n\n");
                sw.WriteLine("stack trace : \n\n" + ex.StackTrace + "\n\n");

                sw.Close();
                MessageBox.Show(ex.Message);
                throw ex;


            }


        }

        public static bool  changeConnectioString (string value)
        {
            try
            {
                if (TestCon(value))
                //{
                //    Properties.Settings.Default["mycon"] = value;
                //    Properties.Settings.Default.Save();
                //    Properties.Settings.Default.Upgrade();
                //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //config.ConnectionStrings.ConnectionStrings["mycon"].ConnectionString = value;
                //config.ConnectionStrings.ConnectionStrings["mycon"].ProviderName = "System.Data.SqlClient";
                //config.Save(ConfigurationSaveMode.Modified);

                {
                    StreamWriter sw2 = new StreamWriter(Directory.GetCurrentDirectory() + @"\constring.txt");
                   sw2.Write(value);
                    sw2.Close();
                return true;
                }
                else
                    return false; 
            }

            catch (Exception ex)
            {
                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\LogFile.txt", true);
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("message : \n\n" + ex.Message);
                sw.WriteLine("------------------------------------\n\n");
                sw.WriteLine("stack trace : \n\n" + ex.StackTrace + "\n\n");

                sw.Close();

                throw ex; 

            }

        }

    }
}
