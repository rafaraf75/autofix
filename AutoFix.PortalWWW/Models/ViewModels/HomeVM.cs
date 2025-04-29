using System.Collections.Generic;
using AutoFix.Data.Data.CMS;

namespace AutoFix.PortalWWW.Models.ViewModels
{
    public class HomeVM
    {
        public List<Promocja> Promocje { get; set; } = new();
        public List<Usluga> Uslugi { get; set; } = new();
    }
}
