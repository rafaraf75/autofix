using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoFix.Data.Data.Garaz
{
    public class HistoriaNaprawy
    {
        [Key]
        public int IdHistorii { get; set; }

        [Required(ErrorMessage = "Data zmiany jest wymagana")]
        [Display(Name = "Data zmiany")]
        public DateTime DataZmiany { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Opis zmiany jest wymagany")]
        [Column(TypeName = "nvarchar(MAX)")]
        [Display(Name = "Opis zmiany")]
        public required string OpisZmiany { get; set; }

        // Relacja: Historia dotyczy konkretnej naprawy
        [ForeignKey("Naprawa")]
        [Display(Name = "Powiązana naprawa")]
        public int? IdNaprawy { get; set; }
        public Naprawa? Naprawa { get; set; }
    }
}
