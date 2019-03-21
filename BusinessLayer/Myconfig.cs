namespace BusinessLayer
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
        static string _serverName;

        /// <summary>
        /// Defines the database_name
        /// </summary>
        static string _databaseName;

        /// <summary>
        /// Gets or sets the Server_name
        /// </summary>
        public static string ServerName { get => _serverName; set => _serverName = value; }

        /// <summary>
        /// Gets or sets the Database_name
        /// </summary>
        public static string DatabaseName { get => _databaseName; set => _databaseName = value; }

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
                ErrorLogger.ErrorLog(ex);

                MessageBoxEx.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
                


            }
        }

        /// <summary>
        /// change the connection string 
        /// </summary>
        /// <param name="con">The connection string <see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public static bool ChangeCon(string con)
        {
            try
            {
                if (DataAccessLayer.ChangeConnectioString(con))
                {

                    StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\FIrstTimeCheck.txt");
                    sw.Write("F");
                    sw.Close();



                    DataAccessLayer.GetConInstance();
                    return true;

                }
                else
                    return false;


            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);

                MessageBoxEx.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; 

            }
        }
    }
}
