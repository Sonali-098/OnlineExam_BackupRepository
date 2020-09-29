using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GladiatorBackend.Models
{
    public class searchReport
    {
        public string tech { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int marks { get; set; }
        public string[] level { get; set; }
    }
}