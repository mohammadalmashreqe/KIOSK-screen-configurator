﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace KIOSKScreenConfigurator.DAL
{
    class DataAccessLayer
    {
        SqlConnection sqlConnection;

        // constructer to establish the connection 
        public DataAccessLayer(String conString)
        {
            sqlConnection = new SqlConnection(conString);
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
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = stored_proc;
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


        //method to delete insert update to database 

        public void myExcute(string stored_proc, SqlParameter[] param)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = stored_proc;
            if (param != null)
            {
                for (int i = 0; i < param.Length; i++)
                    sqlCommand.Parameters.Add(param[i]);
            }
            sqlCommand.ExecuteNonQuery();
        }

}
}