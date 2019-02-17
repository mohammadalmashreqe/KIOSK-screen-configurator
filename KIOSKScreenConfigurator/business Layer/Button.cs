using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIOSKScreenConfigurator
{
   public  class Button
    {

        string buttonName;
        int ID;
        int order;
        string text; 
        List<Activity> myactivity = new List<Activity>();

        public string ButtonName { get => buttonName; set => buttonName = value; }
        public int Order { get => order; set => order = value; }
        public string Text { get => text; set => text = value; }
        public int ID1 { get => ID; set => ID = value; }

        public bool addActivity (Activity ac)
        {
            if (myactivity.Count >= 5)
                return false;
            else
            {
                myactivity.Add(ac);
                return true; 
            }

        }
        public int getactivityCount()
        {
            return myactivity.Count;

        }
        public List<Activity> getList ()
        {
            return myactivity;
        }
    }
}
