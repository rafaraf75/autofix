using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFix.Data.Data.CMS
{
    public class Promocja
    {
        public int Id { get; set; }
        public string Tytul { get; set; } = string.Empty;
        public string Tresc { get; set; } = string.Empty;
        public string Ikona { get; set; } = string.Empty;
    }
}
