using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kmp
{
    public class Procedure
    {
        public string nameId { get; set; }
        public string value { get; set; }
        public string type { get; set; }
        public string code { get; set; }
        public int codeN;



        public Procedure(string nameId,string type, string value)
        {
            this.nameId = nameId;
            this.type = type;
            this.value = value;
        }

        public Procedure()
        {

        }
    }
}
