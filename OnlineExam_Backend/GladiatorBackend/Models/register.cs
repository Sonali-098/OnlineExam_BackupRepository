using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GladiatorBackend.Models
{
    public class register
    {
        public string full_name { get; set; }
        public string mobile { get; set; }
        public string email_id { get; set; }
        public string password { get; set; }
        public string city { get; set; }
        public System.DateTime dob { get; set; }
        public string state { get; set; }
        public string qualification { get; set; }
        public string yoc { get; set; }
    }
}