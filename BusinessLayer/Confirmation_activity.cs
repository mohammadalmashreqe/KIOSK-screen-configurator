using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BusinessLayer
{
  public   class Confirmation_activity : Activity
    {


        int _Timeout;

        public Confirmation_activity(string m, int s) : base(m)
        {
            _Timeout = s;
        }

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



        public override string getIdentificationType()
        {
            return null;
        }

        public override bool getIsmandatory()
        {
            return false;
        }

        public override int getnumberOfprintedTick()
        {
            return 0;
        }

        public override int getTimeOutInSecond()
        {
            return Timeout;
        }

        public override activityType getType()
        {
            return activityType.Confirmation_activity;
        }

        public static DataTable getConActivity(int val)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@_butId", val);
            DataAccessLayer dal = DataAccessLayer.getConInstance();
            dal.Open();

            return dal.SelectData("getConActivity", p);
        }

        public bool AddconActivity(int bt_id)
        {
            SqlParameter[] p4 = new SqlParameter[4];
            DataAccessLayer dal = DataAccessLayer.getConInstance();
            dal.Open();
            p4[0] = new SqlParameter("@_but_id", bt_id);
            p4[1] = new SqlParameter("@_type", "Confirmation_activity");
            p4[2] = new SqlParameter("@_info_msg", Information_message);
            p4[3] = new SqlParameter("@_timeOut", getTimeOutInSecond());
            if (dal.myExcute("Add_activity_Confirm", p4))
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

            return dal.myExcute("deleteConfirmationActivity", p);



        }

    }
}
