using System;
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
            sqlConnection = new SqlConnection(conString);
        }

        
        public static DataAccessLayer getConInstance ()
        {
            if (sqlConnection == null)
                Instance = new DataAccessLayer(ConfigurationManager.ConnectionStrings["mycon"].ToString());
           
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

}
}
