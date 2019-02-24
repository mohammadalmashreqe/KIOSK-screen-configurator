using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessLayer
{
   public class Print_ticket_type : Activity
    {
        //from 1 to 5
        int _Num_of_printed_tickets;
        public Print_ticket_type(string i, int n) : base(i)
        {
            Num_of_printed_tickets1 = n;
        }
        public int Num_of_printed_tickets
        {
            set
            {
                if (value > 0 && value < 6)
                    Num_of_printed_tickets1 = value;
                else

                    MessageBox.Show("please enter a valid number between 1 and 5 ");
            }


        }

        public int Num_of_printed_tickets1 { get => _Num_of_printed_tickets; set => _Num_of_printed_tickets = value; }

    


        public  int getnumberOfprintedTick()
        {
            return Num_of_printed_tickets1;
        }

      

        public  activityType getType()
        {
            return activityType.print_ticket_type;
        }
        public static DataTable getPrintActivity(int val)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@_butId", val);
            DataAccessLayer dal = DataAccessLayer.getConInstance();
            dal.Open();

            return dal.SelectData("getPrintTickActivity", p);
        }

        public bool AddPrintActivity(int bt_id)
        {
            SqlParameter[] p2 = new SqlParameter[4];
            DataAccessLayer dal = DataAccessLayer.getConInstance();
            dal.Open();
            p2[0] = new SqlParameter("@_but_id", bt_id);
            p2[1] = new SqlParameter("@_type", "print_ticket_type");
            p2[2] = new SqlParameter("@_info_msg", Information_message);
            p2[3] = new SqlParameter("@_num_Of_tick", getnumberOfprintedTick());

            if (dal.myExcute("Add_activity_print", p2))
                return true;
            else
                return false;

        }

        public static bool deleteActivity(string id)
        {

            DAL.DataAccessLayer dal = DataAccessLayer.getConInstance();
            dal.Open();


            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@_activity_id", id);

            return dal.myExcute("deletePrintActivity", p);



        }

    }
}
