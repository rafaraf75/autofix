using System.ComponentModel.DataAnnotations;

namespace AutoFix.Data.Data.Garaz
{
    public class Mechanik
    {
        [Key]
        public int IdMechanika { get; set; }

        [Required(ErrorMessage = "Imię mechanika jest wymagane")]
        [MaxLength(50, ErrorMessage = "Imię może zawierać max 50 znaków")]
        [Display(Name = "Imię")]
        public required string Imie { get; set; }

        [Required(ErrorMessage = "Nazwisko mechanika jest wymagane")]
        [MaxLength(50, ErrorMessage = "Nazwisko może zawierać max 50 znaków")]
        [Display(Name = "Nazwisko")]
        public required string Nazwisko { get; set; }

        [MaxLength(100)]
        [Display(Name = "Specjalizacja")]
        public string Specjalizacja { get; set; } = string.Empty;

        // Relacja: Mechanik może być przypisany do wielu napraw
        public ICollection<Naprawa> Naprawy { get; set; } = new List<Naprawa>();
    }
}
