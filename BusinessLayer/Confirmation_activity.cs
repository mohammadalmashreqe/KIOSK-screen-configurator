namespace BusinessLayer
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="ConfirmationActivity" />
    /// </summary>
    public class ConfirmationActivity : Activity
    {
        /// <summary>
        /// Defines the _Timeout
        /// </summary>
        int _timeout;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmationActivity"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/></param>
        /// <param name="timeout">The timeout<see cref="int"/></param>
        public ConfirmationActivity(string message, int timeout) : base(message)
        {
            _timeout = timeout;
        }

        /// <summary>
        /// Gets or sets the Timeout
        /// </summary>
        public int Timeout
        {
            set=>_timeout = value;

            
            get=> _timeout; 
            
        }

        /// <summary>
        /// The getConActivity
        /// </summary>
        /// <param name="val">The val<see cref="int"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public static DataTable GetConfirmationActivity(int val)
        {
            try
            {
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@_butId", val);
                DataAccessLayer dal = DataAccessLayer.GetConInstance();
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

                throw;

            }
        }

        /// <summary>
        /// The Add-confirm Activity
        /// </summary>
        /// <param name="btId">The bt_id<see cref="int"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public bool AddConfirmationActivity(int btId)
        {
            try
            {
                SqlParameter[] p4 = new SqlParameter[4];
                DataAccessLayer dal = DataAccessLayer.GetConInstance();
                dal.Open();
                p4[0] = new SqlParameter("@_but_id", btId);
                p4[1] = new SqlParameter("@_type", "Confirmation_activity");
                p4[2] = new SqlParameter("@_info_msg", InformationMessage);
                p4[3] = new SqlParameter("@_timeOut", Timeout);
                if (dal.MyExcute("Add_activity_Confirm", p4))
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

                throw;

            }
        }

        /// <summary>
        /// The deleteActivity
        /// </summary>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public static bool DeleteActivity(string id)
        {
            try
            {
                DataAccessLayer dal = DataAccessLayer.GetConInstance();
                dal.Open();


                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@_activity_id", id);

                return dal.MyExcute("deleteConfirmationActivity", p);
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
                throw;
            }
        }
    }
}
