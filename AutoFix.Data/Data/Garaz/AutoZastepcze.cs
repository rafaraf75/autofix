using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoFix.Data.Data.Garaz
{
    public class AutoZastepcze
    {
        [Key]
        public int IdAutoZastepczego { get; set; }

        [Required(ErrorMessage = "Data wypożyczenia jest wymagana")]
        [Display(Name = "Data wypożyczenia")]
        public DateTime DataOd { get; set; } = DateTime.Now;

        [Display(Name = "Data zwrotu")]
        public DateTime? DataDo { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Koszt wypożyczenia")]
        public decimal Koszt { get; set; }

        // Relacja: Auto zastępcze powiązane z konkretną naprawą
        [ForeignKey("Naprawa")]
        [Display(Name = "Powiązana naprawa")]
        public int? IdNaprawy { get; set; }
        public Naprawa? Naprawa { get; set; }

        [Display(Name = "Opis naprawy")]
        public string? OpisNaprawy { get; set; }

    }
}
