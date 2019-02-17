using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIOSKScreenConfigurator
{
    class Confirmation_activity:Activity
    {


        int _Timeout;

        public Confirmation_activity (string m , int s ):base (m )
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
    }
}
