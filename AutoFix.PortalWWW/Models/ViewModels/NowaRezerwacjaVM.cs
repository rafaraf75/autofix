using System;
using System.ComponentModel.DataAnnotations;

namespace AutoFix.Models.ViewModels
{
    public class NowaRezerwacjaVM
    {
        [Required(ErrorMessage = "Numer rejestracyjny jest wymagany")]
        [Display(Name = "Numer rejestracyjny")]
        public string NrRejestracyjny { get; set; } = string.Empty;

        [Required(ErrorMessage = "Data rezerwacji jest wymagana")]
        [Display(Name = "Data rezerwacji")]
        public DateTime DataRezerwacji { get; set; } = DateTime.Now;

        [Display(Name = "Opis usługi")]
        public string Usluga { get; set; } = string.Empty;

        [Display(Name = "Dodatkowe uwagi")]
        public string? Uwagi { get; set; }

        [Display(Name = "Silnik")]
        public string Silnik { get; set; } = string.Empty;
    }
}
