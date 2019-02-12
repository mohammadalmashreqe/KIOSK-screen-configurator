using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIOSKScreenConfigurator
{ 
    enum Identification_type { card, mobile };
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

    }
}
