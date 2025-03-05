using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Day5.Model
{
    internal class User
    {
        public int UserId {  get; set; }
        public string Username {  get; set; }
        public int UserAccountNo {  get; set; }

        public override string ToString()
        {
            return $"UserId::{UserId}\tUserName::{Username}\tUserAccountNo::{UserAccountNo}";
        }
    }
}
