using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GladiatorBackend.Models
{
    public class reportStudent
    {
        public int user_id { get; set; }
        public string subject { get; set; }
        public int level1_score { get; set; }
        public int level2_score { get; set; }
        public int level3_score { get; set; }
        public int report_id { get; set; }
    }
}