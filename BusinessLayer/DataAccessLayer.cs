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
        static DataAccessLayer Instance;

        /// <summary>
        /// Defines the sqlConnection
        /// </summary>
        static SqlConnection sqlConnection;

        /// <summary>
        /// Prevents a default instance of the <see cref="DataAccessLayer"/> class from being created.
        /// </summary>
        /// <param name="conString">The conString<see cref="String"/></param>
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

        /// <summary>
        /// The getConInstance
        /// </summary>
        /// <returns>The <see cref="DataAccessLayer"/></returns>
        public static DataAccessLayer getConInstance()
        {
            if (Instance == null)

            {



                //this value of con string for testing i save it and read it from file ,
                Instance = new DataAccessLayer(@"Data Source = M-ALMESHERQE\SQLEXPRESS;Initial Catalog=KIOSK screen configurator object oriented;;Integrated Security=True");

            }


            return Instance;
        }

        /// <summary>
        /// method to open the connection
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
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

        /// <summary>
        /// method to close the connection
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
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

        /// <summary>
        /// The SelectData
        /// </summary>
        /// <param name="stored_proc">The stored_proc<see cref="string"/></param>
        /// <param name="param">The param<see cref="SqlParameter[]"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable SelectData(string stored_proc, SqlParameter[] param)
        {
            try
            {
                Open();
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
            finally
            {
                Close();
            }
          
        }

        /// <summary>
        /// method to delete insert update to database
        /// </summary>
        /// <param name="stored_proc">The stored_proc<see cref="string"/></param>
        /// <param name="param">The param<see cref="SqlParameter[]"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public bool myExcute(string stored_proc, SqlParameter[] param)
        {
            int x = -1;
            try
            {
                Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = stored_proc;
                sqlCommand.Connection = sqlConnection;
                if (param != null)
                {
                    for (int i = 0; i < param.Length; i++)
                        sqlCommand.Parameters.Add(param[i]);
                }
                x = sqlCommand.ExecuteNonQuery();

                if (x > 0)
                    return true;
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
            finally
            {
                Close();
            }



        }

        /// <summary>
        /// method to test connection
        /// </summary>
        /// <param name="constring">The constring<see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public static bool TestCon(string constring)
        {
            try
            {
                SqlConnection con = new SqlConnection(constring);
                con.Open();



                if (con.State == ConnectionState.Open || con.State == ConnectionState.Open)
                    return true;
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

                sw.Close();

                throw ex;


            }
        }

        /// <summary>
        /// method to change  connection string
        /// </summary>
        /// <param name="value">The value<see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public static bool changeConnectioString(string value)
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

                sw.Close();

                throw ex;

            }
        }
    }
}
