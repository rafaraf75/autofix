using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoFix.Data.Data.Garaz
{
    public class Rezerwacja
    {
        [Key]
        public int IdRezerwacji { get; set; }

        [Required(ErrorMessage = "Data rezerwacji jest wymagana")]
        [Display(Name = "Data rezerwacji")]
        public DateTime DataRezerwacji { get; set; } = DateTime.Now;

        [Display(Name = "Usługa (opis)")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Usluga { get; set; } = string.Empty;

        [Display(Name = "Uwagi")]
        public string Uwagi { get; set; } = string.Empty;

        // Relacja: Rezerwacja przypisana do Klienta
        [ForeignKey("Klient")]
        [Display(Name = "Klient")]
        public int IdKlienta { get; set; }
        public Klient? Klient { get; set; }

        // Relacja: Rezerwacja przypisana do Pojazdu
        [ForeignKey("Pojazd")]
        [Display(Name = "Pojazd")]
        public int IdPojazdu { get; set; }
        public Pojazd? Pojazd { get; set; }

        // Relacja: Rezerwacja przypisana do Mechanika (opcjonalna)
        [ForeignKey("Mechanik")]
        [Display(Name = "Mechanik")]
        public int? IdMechanika { get; set; }
        public Mechanik? Mechanik { get; set; }
    }
}
