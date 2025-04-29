using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoFix.Data.Data.CMS
{
    public class Strona
    {
        [Key]
        public int IdStrony { get; set; }

        [Required(ErrorMessage = "Tytuł odnośnika jest wymagany")]
        [MaxLength(20, ErrorMessage = "Link może zawierać max 20 znaków")]
        [Display(Name = "Tytuł odnośnika")]
        public required string LinkTytul { get; set; }

        [Required(ErrorMessage = "Tytuł strony jest wymagany")]
        [MaxLength(50, ErrorMessage = "Tytuł może zawierać max 50 znaków")]
        [Display(Name = "Tytuł strony")]
        public required string Tytul { get; set; }

        [Display(Name = "Treść")]
        [Column(TypeName = "nvarchar(MAX)")]
        public required string Tresc { get; set; }

        [Display(Name = "Pozycja wyświetlania")]
        [Required(ErrorMessage = "Wpisz pozycję wyświetlania")]
        public int Pozycja { get; set; }

        [Display(Name = "Link bezpośredni (opcjonalnie)")]
        [MaxLength(100, ErrorMessage = "Link może zawierać max 100 znaków")]
        public string? LinkBezposredni { get; set; }

        [Display(Name = "Podtytuł")]
        [MaxLength(200, ErrorMessage = "Podtytuł może mieć max 200 znaków")]
        public string? Podtytul { get; set; }

        [Display(Name = "Ikona (np. bi-envelope-question-fill)")]
        [MaxLength(100)]
        public string? Ikona { get; set; }

        [Display(Name = "Tytuł CTA (sekcji na dole)")]
        [MaxLength(200)]
        public string? CtaTytul { get; set; }

        [Display(Name = "Opis CTA")]
        [MaxLength(500)]
        public string? CtaOpis { get; set; }

        [Display(Name = "Tekst przycisku CTA")]
        [MaxLength(100)]
        public string? CtaPrzycisk { get; set; }

        [Display(Name = "Link przycisku CTA")]
        [MaxLength(200)]
        public string? CtaLink { get; set; }

    }
}
