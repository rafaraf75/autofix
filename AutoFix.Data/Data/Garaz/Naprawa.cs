using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoFix.Data.Data.Garaz
{
    public class Naprawa
    {
        [Key]
        public int IdNaprawy { get; set; }

        [Required(ErrorMessage = "Data przyjęcia jest wymagana")]
        [Display(Name = "Data przyjęcia")]
        public DateTime DataPrzyjecia { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Opis naprawy jest wymagany")]
        [Column(TypeName = "nvarchar(MAX)")]
        [Display(Name = "Opis naprawy")]
        public required string Opis { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; } = "Przyjęta";

        [Display(Name = "Czy auto zastępcze?")]
        public bool AutoZastepcze { get; set; } = false;

        // Relacja: Naprawa dotyczy danego pojazdu
        [ForeignKey("Pojazd")]
        [Display(Name = "Pojazd")]
        public int IdPojazdu { get; set; }
        public Pojazd? Pojazd { get; set; }

        // Relacja: Naprawa może być przypisana do mechanika
        [ForeignKey("Mechanik")]
        [Display(Name = "Mechanik")]
        public int? IdMechanika { get; set; }
        public Mechanik? Mechanik { get; set; }

        // Relacja: Naprawa może mieć wiele wpisów w historii
        public ICollection<HistoriaNaprawy> Historie { get; set; } = new List<HistoriaNaprawy>();
    }
}
