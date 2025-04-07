using System.ComponentModel.DataAnnotations;

namespace AutoFix.Data.Data.Garaz
{
    public class Klient
    {
        [Key]
        public int IdKlienta { get; set; }

        [Required(ErrorMessage = "Imię jest wymagane")]
        [MaxLength(50, ErrorMessage = "Imię może zawierać max 50 znaków")]
        [Display(Name = "Imię")]
        public required string Imie { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [MaxLength(50, ErrorMessage = "Nazwisko może zawierać max 50 znaków")]
        [Display(Name = "Nazwisko")]
        public required string Nazwisko { get; set; }

        [MaxLength(20)]
        [Display(Name = "Telefon")]
        public string Telefon { get; set; } = string.Empty;

        [MaxLength(100)]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        // Relacja: Klient może mieć wiele pojazdów
        public ICollection<Pojazd> Pojazdy { get; set; } = new List<Pojazd>();
    }
}
