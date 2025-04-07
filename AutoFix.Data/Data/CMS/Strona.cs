using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoFix.Data.Data.CMS
{
    public class Strona
    {
        [Key]
        public int IdStrony { get; set; }

        [Required(ErrorMessage = "Tytuł odnośnika jest wymagany")]
        [MaxLength(10, ErrorMessage = "Link może zawierać max 10 znaków")]
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
    }
}
