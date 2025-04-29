using AutoFix.Data.Data.Garaz;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoFix.Intranet.ViewModels
{
    public class RezerwacjaDashboardViewModel
    {
        public int IdRezerwacji { get; set; }
        public DateTime DataRezerwacji { get; set; }
        public string Usluga { get; set; } = string.Empty;
        public string Uwagi { get; set; } = string.Empty;
        public string KlientEmail { get; set; } = string.Empty;
        public string PojazdOpis { get; set; } = string.Empty;
        public string? MechanikImieNazwisko { get; set; } = "Nieprzypisany";

        public int? IdMechanika { get; set; }

        // Lista mechaników do wyboru
        public List<SelectListItem> ListaMechanikow { get; set; } = new();
    }
}
