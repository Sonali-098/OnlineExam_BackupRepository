using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GladiatorBackend.Models
{
    public class questionR
    {
        public int sno { get; set; }
        public string question { get; set; }
        public string option1 { get; set; }
        public string option2 { get; set; }
        public string option3 { get; set; }
        public string option4 { get; set; }
        public string correct_option { get; set; }
        public string difficulty { get; set; }
    }
}