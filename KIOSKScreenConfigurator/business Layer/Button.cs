using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIOSKScreenConfigurator
{
    class Button
    {

        string buttonName;

        int order;
        List<Activity> myactivity = new List<Activity>();

        public string ButtonName { get => buttonName; set => buttonName = value; }
        public int Order { get => order; set => order = value; }

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
    }
}
