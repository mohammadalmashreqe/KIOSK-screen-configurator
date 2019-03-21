namespace BusinessLayer
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="DataAccessLayer" />
    /// </summary>
    public class DataAccessLayer
    {
        /// <summary>
        /// Defines the Instance
        /// </summary>
        static DataAccessLayer _instance;

        /// <summary>
        /// Defines the sqlConnection
        /// </summary>
        private static SqlConnection _sqlConnection;

        /// <summary>
        /// Prevents a default instance of the <see cref="DataAccessLayer"/> class from being created.
        /// </summary>
        /// <param name="conString">The conString<see cref="String"/></param>
        private DataAccessLayer(string conString)
        {
            try
            {
                _sqlConnection = new SqlConnection(conString);
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);

               // MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for mor info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt");
               throw ex; 


            }
        }

        /// <summary>
        /// The getConInstance
        /// </summary>
        /// <returns>The <see cref="DataAccessLayer"/></returns>
        public static DataAccessLayer GetConInstance()
        {
            try
            {
                return _instance ?? (_instance = new DataAccessLayer(
                           // ReSharper disable once StringLiteralTypo
                           // ReSharper disable once StringLiteralTypo
                           // ReSharper disable once StringLiteralTypo
                           @"Data Source = M-ALMESHERQE\SQLEXPRESS;Initial Catalog=KIOSK screen configurator object oriented;;Integrated Security=True")
                       );
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);
                return null;
            }
        }

        /// <summary>
        /// method to open the connection
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        public bool Open()
        {
            try
            {
                if (_sqlConnection.State != ConnectionState.Open)
                {
                    _sqlConnection.Open();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);
                return false;
            }
        }

        /// <summary>
        /// method to close the connection
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        public bool Close()
        {
            try
            {
                if (_sqlConnection.State != ConnectionState.Closed)
                {
                    _sqlConnection.Close();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);
                return false; 
            }
        }

        /// <summary>
        /// The SelectData
        /// </summary>
        /// <param name="storedProc">The stored_proc<see cref="string"/></param>
        /// <param name="param">The param<see cref="SqlParameter"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable SelectData(string storedProc, SqlParameter[] param)
        {
            try
            {
                Open();
                SqlCommand sqlCommand = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure, CommandText = storedProc, Connection = _sqlConnection
                };



                if (param != null)
                {
                    foreach (SqlParameter t in param)
                        sqlCommand.Parameters.Add(t);
                }
                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);

               // MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);

               throw; 

            }
            finally
            {
                Close();
            }
          
        }

        /// <summary>
        /// method to delete insert update to database
        /// </summary>
        /// <param name="storedProc">The stored_proc<see cref="string"/></param>
        /// <param name="param">The param<see cref="SqlParameter"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public bool MyExcute(string storedProc, SqlParameter[] param)
        {
            try
            {
                Open();
                SqlCommand sqlCommand = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure, CommandText = storedProc, Connection = _sqlConnection
                };
                if (param != null)
                {
                    foreach (SqlParameter t in param)
                        sqlCommand.Parameters.Add(t);
                }
                int x = sqlCommand.ExecuteNonQuery();

                if (x > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);

               // MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
               throw; 
            }
            finally
            {
                Close();
            }
        }

        /// <summary>
        /// method to test connection
        /// </summary>
        
        /// <param name="constring">The con string<see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public static bool TestCon(string constring)
        {
            try
            {
                SqlConnection con = new SqlConnection(constring);
                con.Open();



                return con.State == ConnectionState.Open || con.State == ConnectionState.Open;
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);
                return false; 



            }
        }

        /// <summary>
        /// method to change  connection string
        /// </summary>
        /// <param name="value">The value<see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public static bool ChangeConnectioString(string value)
        {
            try
            {
                if (TestCon(value))


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
                ErrorLogger.ErrorLog(ex);
                return false;
            }
        }
    }
}
