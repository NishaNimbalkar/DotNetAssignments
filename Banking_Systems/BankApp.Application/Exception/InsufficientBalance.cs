﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Application.Exception
{
  public  class InsufficientBalance:ApplicationException
    {
        public InsufficientBalance(string msg):base(msg)
        {
            
        }
    }
}
