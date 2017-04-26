using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SBKAvtalskatalog.Models
{
    public class Avtalsmodel
    {
        public int id { get; set; }
        public long diarienummer { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public string orgnummer { get; set; }

    }
}