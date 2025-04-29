using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFix.Data.Data.CMS
{
    public class Usluga
    {
        public int Id { get; set; }
        public string Tytul { get; set; } = string.Empty;
        public string Opis { get; set; } = string.Empty;
        public string Ikona { get; set; } = string.Empty;
    }
}
