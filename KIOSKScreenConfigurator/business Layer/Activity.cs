﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIOSKScreenConfigurator
{
    class Activity
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
    }
}