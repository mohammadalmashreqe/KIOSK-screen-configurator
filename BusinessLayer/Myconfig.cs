﻿namespace BusinessLayer
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="Myconfig" />
    /// </summary>
    public class Myconfig
    {
        /// <summary>
        /// Defines the server_name
        /// </summary>
        static string server_name;

        /// <summary>
        /// Defines the database_name
        /// </summary>
        static string database_name;

        /// <summary>
        /// Gets or sets the Server_name
        /// </summary>
        public static string Server_name { get => server_name; set => server_name = value; }

        /// <summary>
        /// Gets or sets the Database_name
        /// </summary>
        public static string Database_name { get => database_name; set => database_name = value; }

        /// <summary>
        /// The Test connection string 
        /// </summary>
        /// <param name="con">The connection string <see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public static bool TestCon(string con)
        {


            try
            {
                return (DataAccessLayer.TestCon(con));

            }
            catch (Exception ex)
            {
                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\LogFile.txt", true);
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("message : ");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine(ex.Message);
                sw.WriteLine("------------------------------------------------------------------------------------");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("stack trace :");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine(ex.StackTrace);
                sw.WriteLine("------------------------------------------------------------------------------------");
                sw.WriteLine("");
                sw.WriteLine("");

                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sw.Close();
                throw ex; 


            }
        }

        /// <summary>
        /// change the connection string 
        /// </summary>
        /// <param name="con">The connection string <see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public static bool changeCon(string con)
        {
            try
            {
                if (DataAccessLayer.changeConnectioString(con))
                {

                    StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\FIrstTimeCheck.txt");
                    sw.Write("F");
                    sw.Close();



                    DataAccessLayer.getConInstance();
                    return true;

                }
                else
                    return false;


            }
            catch (Exception ex)
            {
                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\LogFile.txt", true);
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("message : ");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine(ex.Message);
                sw.WriteLine("------------------------------------------------------------------------------------");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("stack trace :");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine(ex.StackTrace);
                sw.WriteLine("------------------------------------------------------------------------------------");
                sw.WriteLine("");
                sw.WriteLine("");

                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sw.Close();
                throw ex; 

            }
        }
    }
}
