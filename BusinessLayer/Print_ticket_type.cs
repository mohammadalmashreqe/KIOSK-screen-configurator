namespace BusinessLayer
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="Print_ticket_type" />
    /// </summary>
    public class Print_ticket_type : Activity
    {
        /// <summary>
        /// Defines the _Num_of_printed_tickets
        /// </summary>
        int _Num_of_printed_tickets;

        /// <summary>
        /// Initializes a new instance of the <see cref="Print_ticket_type"/> class.
        /// </summary>
        /// <param name="i">The i<see cref="string"/></param>
        /// <param name="n">The n<see cref="int"/></param>
        public Print_ticket_type(string i, int n) : base(i)
        {
            Num_of_printed_tickets = n;
        }

        /// <summary>
        /// Gets or sets the Num_of_printed_tickets
        /// </summary>
        public int Num_of_printed_tickets { get => _Num_of_printed_tickets; set => _Num_of_printed_tickets = value; }

        /// <summary>
        /// get Print Activity
        /// </summary>
        /// <param name="id">id of button want get its activities<see cref="int"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public static DataTable getPrintActivity(int id)
        {
            try
            {
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@_butId", id);
                DataAccessLayer dal = DataAccessLayer.getConInstance();
                dal.Open();

                return dal.SelectData("getPrintTickActivity", p);
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
        /// Add Print tickit Activity
        /// </summary>
        /// <param name="bt_id">id of button want to add avtivity to it <see cref="int"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public bool AddPrintActivity(int bt_id)
        {
            try
            {
                SqlParameter[] p2 = new SqlParameter[4];
                DataAccessLayer dal = DataAccessLayer.getConInstance();
                dal.Open();
                p2[0] = new SqlParameter("@_but_id", bt_id);
                p2[1] = new SqlParameter("@_type", "print_ticket_type");
                p2[2] = new SqlParameter("@_info_msg", Information_message);
                p2[3] = new SqlParameter("@_num_Of_tick", Num_of_printed_tickets);

                if (dal.myExcute("Add_activity_print", p2))
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
        /// The delete  Activity
        /// </summary>
        /// <param name="id">The id of button wnat to delete activity from it <see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public static bool deleteActivity(string id)
        {

            DataAccessLayer dal = DataAccessLayer.getConInstance();
            dal.Open();


            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@_activity_id", id);

            return dal.myExcute("deletePrintActivity", p);
        }
    }
}
