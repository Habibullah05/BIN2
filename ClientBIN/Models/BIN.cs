using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClientBIN.Models
{
    public class BIN
    {
       
        [Ignore]
        public int Id { get; set; }
        public string PS { get; set; }
        public long START_BIN { get; set; }
        public long END_BIN { get; set; }
        public string CODE_A2 { get; set; }
        public string CODE_A3 { get; set; }
        public int CODE_N3 { get; set; }
        public int BIN_LEN { get; set; }
        [Name("PRODUCT ID")]
        public string Product_ID { get; set; }
        [NotMapped]
        public static string Delimiter { get;  set; } 


    }
}
