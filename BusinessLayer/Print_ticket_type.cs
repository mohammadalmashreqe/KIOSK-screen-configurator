namespace BusinessLayer
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="PrintTicketType" />
    /// </summary>
    public class PrintTicketType : Activity
    {
        /// <summary>
        /// Defines the _Num_of_printed_tickets
        /// </summary>
        int _numOfPrintedTickets;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrintTicketType"/> class.
        /// </summary>
        /// <param name="i">The i<see cref="string"/></param>
        /// <param name="n">The n<see cref="int"/></param>
        public PrintTicketType(string i, int n) : base(i)
        {
            NumOfPrintedTickets = n;
        }

        /// <summary>
        /// Gets or sets the Num_of_printed_tickets
        /// </summary>
        public int NumOfPrintedTickets { get => _numOfPrintedTickets; set => _numOfPrintedTickets = value; }

        /// <summary>
        /// get Print Activity
        /// </summary>
        /// <param name="id">id of button want get its activities<see cref="int"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public static DataTable GetPrintActivity(int id)
        {
            try
            {
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@_butId", id);
                DataAccessLayer dal = DataAccessLayer.GetConInstance();
                dal.Open();

                return dal.SelectData("getPrintTickActivity", p);
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);

                MessageBoxEx.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null; 

            }
        }

        /// <summary>
        /// Add Print tickets Activity
        /// </summary>
        /// <param name="btId">id of button want to add activity to it <see cref="int"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public bool AddPrintActivity(int btId)
        {
            try
            {
                SqlParameter[] p2 = new SqlParameter[4];
                DataAccessLayer dal = DataAccessLayer.GetConInstance();
                dal.Open();
                p2[0] = new SqlParameter("@_but_id", btId);
                p2[1] = new SqlParameter("@_type", "print_ticket_type");
                p2[2] = new SqlParameter("@_info_msg", InformationMessage);
                p2[3] = new SqlParameter("@_num_Of_tick", NumOfPrintedTickets);

                return dal.MyExcute("Add_activity_print", p2);
            }
            catch (Exception ex)
            {

                ErrorLogger.ErrorLog(ex);

                // MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
              

            }
        }

        /// <summary>
        ///  delete  Activity
        /// </summary>
        /// <param name="id">The id of button want to delete activity from it <see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public static bool DeleteActivity(string id)
        {

            try

            {

                DataAccessLayer dal = DataAccessLayer.GetConInstance();
                dal.Open();


                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@_activity_id", id);

                return dal.MyExcute("deletePrintActivity", p);
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);
                return false; 

            }
    }

        public static PrintTicketType GetInfoById(int id)
        {
            DataAccessLayer dal = DataAccessLayer.GetConInstance();
            dal.Open();
            DataTable dt = dal.SelectData("getPrintActByid", new[] { new SqlParameter("@_id", id) });
            DataRow row = dt.Rows[0];


            PrintTicketType t =
                new PrintTicketType(row["info_msg"].ToString(), int.Parse(row["num_of_tick"].ToString()))
                {
                    Id = int.Parse(row["activity_id"].ToString()), Type = ActivityType.PrintTicketType
                };
            return t; 
        }

        public bool UpdateActivity()
        {

            try
            {
                DataAccessLayer dal = DataAccessLayer.GetConInstance();
                dal.Open();
                SqlParameter[] p = new SqlParameter[3];
                p[0] = new SqlParameter("@_id", Id);
                p[1] = new SqlParameter("@_num_of_tick", NumOfPrintedTickets);
                p[2] = new SqlParameter("@_info_msg ", InformationMessage);
                return dal.MyExcute("UpdateprintActivity", p);
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);
                return false;
            }


        }

    }
}
