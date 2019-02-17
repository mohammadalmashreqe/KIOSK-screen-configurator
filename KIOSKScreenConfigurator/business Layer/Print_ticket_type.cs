using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KIOSKScreenConfigurator
{
    class Print_ticket_type :Activity
    {
        //from 1 to 5
        int _Num_of_printed_tickets;
       public  Print_ticket_type (string i , int n ):base(i)
        {
            _Num_of_printed_tickets = n; 
        }
        public int  Num_of_printed_tickets 
            {
            set
            {
                if (value > 0 && value < 6)
                    _Num_of_printed_tickets = value;
                else

                    MessageBox.Show("please enter a valid number between 1 and 5 ");
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
            return _Num_of_printed_tickets;
        }

        public override int getTimeOutInSecond()
        {
            return 0;
        }

        public override activityType getType()
        {
            return activityType.print_ticket_type;
        }
    }
}
