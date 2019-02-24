using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KIOSKScreenConfigurator.DAL;

namespace KIOSKScreenConfigurator
{
   public  class Button
    {

        string buttonName;
        int ID;
        int order;
        string text; 
        List<Activity> myactivity = new List<Activity>();

        public string ButtonName { get => buttonName; set => buttonName = value; }
        public int Order { get => order; set => order = value; }
        public string Text { get => text; set => text = value; }
        public int ID1 { get => ID; set => ID = value; }

        public bool addActivity (Activity ac)
        {
            if (myactivity.Count >= 5)
                return false;
            else
            {
                myactivity.Add(ac);
                return true; 
            }

        }
        public int getactivityCount()
        {
            return myactivity.Count;

        }
        public List<Activity> getList ()
        {
            return myactivity;
        }
        public static DataTable getButtons ()
        {
            DataAccessLayer dal = DataAccessLayer.getConInstance();
            dal.Open();
            DataTable dt = dal.SelectData("getButtons", null);
            return dt;
        }
        public bool DeleteButton ()
        {
            DataAccessLayer dal = DataAccessLayer.getConInstance();
            dal.Open();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@_id", ID1);
            if (dal.myExcute("deleteButton", p))
                return true;
            else
                return false; 

           
        }
        public bool AddButton ()
        {
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@_name", ButtonName);
            p[1] = new SqlParameter("@_text", Text);
            p[2] = new SqlParameter("@_order", Order);
            DataAccessLayer dal = DataAccessLayer.getConInstance();
            dal.Open();
            if (dal.myExcute("AddButton", p))
                return true;
            else
                return false; 

        }

        public int GetId ()
        {
            DataAccessLayer dal = DataAccessLayer.getConInstance();
            dal.Open();
            SqlParameter[] p5 = new SqlParameter[3];
            p5[0] = new SqlParameter("@_name", ButtonName);
            p5[1] = new SqlParameter("@_text", Text);
            p5[2] = new SqlParameter("@_order", Order);
            DataTable dt = dal.SelectData("GetId", p5);
            int bt_id = dt.Rows[0].Field<int>(0);

            return bt_id;
        }

        public bool updatButton ()
        {
            try
            {
                DataAccessLayer dal = DataAccessLayer.getConInstance();
                dal.Open();
                SqlParameter[] p = new SqlParameter[4];
                p[0] = new SqlParameter("@_id", ID1);
                p[1] = new SqlParameter("@_name", ButtonName);

                p[2] = new SqlParameter("@_text", Text);

                p[3] = new SqlParameter("@_order", Order);

                return dal.myExcute("EditButton", p);
               
               

            }
            catch (Exception ex)
            {
                #region Format excepton and write details to the log file 
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
                #endregion

                return false; 

            }


     
        }


    }
}
