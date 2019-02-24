using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIOSKScreenConfigurator
{ 
    public enum activityType { print_ticket_type, Request_identification, Confirmation_activity }

    public abstract class Activity
    {

        string _Information_message;

        public Activity (string i )
        {
            _Information_message = i; 
        }
        public string Information_message
        {
            set
            {
                _Information_message = value; 
            }
            get
            {
                return _Information_message;
            }

        }
        abstract   public activityType getType();
        abstract public int  getnumberOfprintedTick();
        abstract public string getIdentificationType();
        abstract public bool getIsmandatory();
        abstract public int getTimeOutInSecond();

        



    }
}
