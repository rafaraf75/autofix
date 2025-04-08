using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoFix.Data.Data.Garaz
{
    public class Pojazd
    {
        [Key]
        public int IdPojazdu { get; set; }

        [Required(ErrorMessage = "Marka pojazdu jest wymagana")]
        [MaxLength(50, ErrorMessage = "Marka może zawierać max 50 znaków")]
        [Display(Name = "Marka")]
        public required string Marka { get; set; }

        [Required(ErrorMessage = "Model pojazdu jest wymagany")]
        [MaxLength(50, ErrorMessage = "Model może zawierać max 50 znaków")]
        [Display(Name = "Model")]
        public required string Model { get; set; }

        [Display(Name = "Rok produkcji")]
        public int Rok { get; set; }

        [MaxLength(20)]
        [Display(Name = "Nr rejestracyjny")]
        public string NrRejestracyjny { get; set; } = string.Empty;
        [MaxLength(50)]
        [Display(Name = "Silnik")]
        public string Silnik { get; set; } = string.Empty;

        // Relacja: Pojazd należy do Klienta
        [ForeignKey("Klient")]
        [Display(Name = "Właściciel (Klient)")]
        public int IdKlienta { get; set; }
        public Klient? Klient { get; set; }

        // Relacja: Pojazd może mieć wiele napraw
        public ICollection<Naprawa> Naprawy { get; set; } = new List<Naprawa>();
    }
}
