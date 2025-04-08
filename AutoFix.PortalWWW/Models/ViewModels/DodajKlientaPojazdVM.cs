using System.ComponentModel.DataAnnotations;

namespace AutoFix.Models.ViewModels
{
    public class DodajKlientaPojazdVM
    {
        // Dane klienta
        [Required(ErrorMessage = "Imię jest wymagane")]
        [Display(Name = "Imię")]
        public string Imie { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [Display(Name = "Nazwisko")]
        public string Nazwisko { get; set; } = string.Empty;

        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Telefon")]
        public string Telefon { get; set; } = string.Empty;

        // Dane pojazdu
        [Required(ErrorMessage = "Marka pojazdu jest wymagana")]
        [Display(Name = "Marka")]
        public string Marka { get; set; } = string.Empty;

        [Required(ErrorMessage = "Model pojazdu jest wymagany")]
        [Display(Name = "Model")]
        public string Model { get; set; } = string.Empty;

        [Display(Name = "Rok produkcji")]
        [Range(1900, 2100, ErrorMessage = "Podaj poprawny rok")]
        public int Rok { get; set; }

        [Display(Name = "Silnik")]
        public string Silnik { get; set; } = string.Empty;

        [Required(ErrorMessage = "Numer rejestracyjny jest wymagany")]
        [Display(Name = "Nr rejestracyjny")]
        public string NrRejestracyjny { get; set; } = string.Empty;
    }
}
