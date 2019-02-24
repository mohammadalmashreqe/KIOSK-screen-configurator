using KIOSKScreenConfigurator.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIOSKScreenConfigurator
{    //Author :mohammad almashreqe 
    // desc : enum for determine the type of identification for user . 
    enum Identification_type { card, mobile };

    //Author :mohammad almashreqe 
    // desc : class  Request_identification is a sub class from class Activity and i am override some behavior to achiave the polymorphism  . 

    #region class  Request_identification definition  
    class Request_identification : Activity
    {
        Identification_type _type;
        bool _is_mandatory;

        public Request_identification(string m, Identification_type t, bool im) : base(m)
        {
            _type = t;
            _is_mandatory = im;
        }

        public Identification_type  type
            {

            set 
            {
                _type = value; 
            }
            
            get
            {
                return _type;
            }

            
      
            }
        public bool is_mandatory
        {
            set
            {
                _is_mandatory = value; 
            }
            get
            {
                return _is_mandatory;
            }
        }

        public override string getIdentificationType()
        {
            if (_type == Identification_type.card)
                return "card";
            else
                return "mobile";
        }

        public override bool getIsmandatory()
        {
            return is_mandatory;
        }

        public override int getnumberOfprintedTick()
        {
            return 0; 
        }

        public override int getTimeOutInSecond()
        {
            return 0; 
        }

        public override activityType getType()
        {
            return activityType.Request_identification; 
        }

        public static DataTable getRequestActivity(int val)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@_butId", val);
            DataAccessLayer dal = DataAccessLayer.getConInstance();
            dal.Open();

            return dal.SelectData("getRequestTickActivity", p);
        }
        public bool AddRequestActivity (int bt_id)
        {
           
            DataAccessLayer dal = DataAccessLayer.getConInstance();
            dal.Open();
            SqlParameter[] p3 = new SqlParameter[5];

            p3[0] = new SqlParameter("@_but_id", bt_id);
            p3[1] = new SqlParameter("@_type", "Request_identification");
            p3[2] = new SqlParameter("@_info_msg",Information_message);
            p3[3] = new SqlParameter("@_Identification_type", getIdentificationType());

            p3[4] = new SqlParameter("@_Is_mandatory", getIsmandatory());
            

            if (dal.myExcute("Add_activity_request", p3))
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

            return dal.myExcute("deleteRequestActivity", p);



        }
    }
    #endregion
}
