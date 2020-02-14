using CsvHelper.Configuration.Attributes;

namespace ApiSVG.Models
{
    public class BIN
    {
        public string PS { get; set; }
        public long START_BIN { get; set; }
        public long END_BIN { get; set; }
        public string CODE_A2 { get; set; }
        public string CODE_A3 { get; set; }
        public int CODE_N3 { get; set; }
        public int BIN_LEN { get; set; }
        // [DataMember(Name = "PRODUCT ID")]
        [Name("PRODUCT ID")]
        public string Product_ID { get; set; }
        public static string Delimiter { get; private set; } = ";";





    }
}
