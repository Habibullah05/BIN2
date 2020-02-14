using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientBIN.Models
{
    public class MyOptions
    {
        public string Path { get; set; }
        public FileName FileName { set; get; } = new FileName();
        public string ServerUrl { get; set; }
        public string Delimiter { get; set; }
        public string DayOfWeek { get; set; }



    }
}
