using Microsoft.EntityFrameworkCore;
using AutoFix.Data.Data.CMS;
using AutoFix.Data.Data.Garaz;
using System.Collections.Generic;

namespace AutoFix.Data
{
    public class AutoFixContext : DbContext
    {
        public AutoFixContext(DbContextOptions<AutoFixContext> options)
            : base(options)
        {
        }

        // CMS
        public DbSet<Aktualnosc> Aktualnosci { get; set; }
        public DbSet<Strona> Strony { get; set; }
        public DbSet<Promocja> Promocje { get; set; }
        public DbSet<Usluga> Uslugi { get; set; }

        // Garaz
        public DbSet<Klient> Klienci { get; set; }
        public DbSet<Pojazd> Pojazdy { get; set; }
        public DbSet<Mechanik> Mechanicy { get; set; }
        public DbSet<Naprawa> Naprawy { get; set; }
        public DbSet<Rezerwacja> Rezerwacje { get; set; }
        public DbSet<AutoZastepcze> AutaZastepcze { get; set; }
        public DbSet<HistoriaNaprawy> HistorieNapraw { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Rezerwacja>()
                .HasOne(r => r.Pojazd)
                .WithMany()
                .HasForeignKey(r => r.IdPojazdu)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Rezerwacja>()
                .HasOne(r => r.Klient)
                .WithMany()
                .HasForeignKey(r => r.IdKlienta)
                .OnDelete(DeleteBehavior.Restrict);

            // relacja do mechanika
            modelBuilder.Entity<Rezerwacja>()
                .HasOne(r => r.Mechanik)
                .WithMany()
                .HasForeignKey(r => r.IdMechanika)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
