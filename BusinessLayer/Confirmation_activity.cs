namespace BusinessLayer
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="Confirmation_activity" />
    /// </summary>
    public class Confirmation_activity : Activity
    {
        /// <summary>
        /// Defines the _Timeout
        /// </summary>
        int _Timeout;

        /// <summary>
        /// Initializes a new instance of the <see cref="Confirmation_activity"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/></param>
        /// <param name="timout">The timout<see cref="int"/></param>
        public Confirmation_activity(string message, int timout) : base(message)
        {
            _Timeout = timout;
        }

        /// <summary>
        /// Gets or sets the Timeout
        /// </summary>
        public int Timeout
        {
            set
            {
                _Timeout = value;

            }
            get
            {
                return _Timeout; ;
            }
        }

        /// <summary>
        /// The getConActivity
        /// </summary>
        /// <param name="val">The val<see cref="int"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public static DataTable getConActivity(int val)
        {
            try
            {
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@_butId", val);
                DataAccessLayer dal = DataAccessLayer.getConInstance();
                dal.Open();

                return dal.SelectData("getConActivity", p);
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
        /// The AddconActivity
        /// </summary>
        /// <param name="bt_id">The bt_id<see cref="int"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public bool AddconActivity(int bt_id)
        {
            try
            {
                SqlParameter[] p4 = new SqlParameter[4];
                DataAccessLayer dal = DataAccessLayer.getConInstance();
                dal.Open();
                p4[0] = new SqlParameter("@_but_id", bt_id);
                p4[1] = new SqlParameter("@_type", "Confirmation_activity");
                p4[2] = new SqlParameter("@_info_msg", Information_message);
                p4[3] = new SqlParameter("@_timeOut", Timeout);
                if (dal.myExcute("Add_activity_Confirm", p4))
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
        }

        /// <summary>
        /// The deleteActivity
        /// </summary>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public static bool deleteActivity(string id)
        {
            try
            {
                DataAccessLayer dal = DataAccessLayer.getConInstance();
                dal.Open();


                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@_activity_id", id);

                return dal.myExcute("deleteConfirmationActivity", p);
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
