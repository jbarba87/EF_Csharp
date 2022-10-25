using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    public class Boleta {
        public UInt32 id { get; set; }
        public string alumno { get; set; }
        public decimal n1 { get; set; }
        public decimal n2 { get; set; }
        public decimal n3 { get; set; }
        public decimal promedio { get; set; }
        public string estado { get; set; }
        public string nivel { get; set; }

        public Boleta() { }
    }
}
