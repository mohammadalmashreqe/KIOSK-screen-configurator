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
    }
}
