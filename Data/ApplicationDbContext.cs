using Microsoft.EntityFrameworkCore;
using Ege.Models;
using Ege.Data;
namespace Ege.Data;


public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }
    public DbSet<Araclar> Araclar { get; set;}
    public DbSet<Kullanicilar> Kullanicilar { get; set;}
    public DbSet<AracDetay> AracDetay { get; set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    // Bir-bir ilişkisini doğru şekilde tanımlama
    modelBuilder.Entity<AracDetay>()
        .HasOne(ad => ad.Arac)  // AracDetay'ın bir Arac'ı vardır
        .WithOne(a => a.AracDetay)  // Arac'ın bir AracDetay'ı vardır
        .HasForeignKey<AracDetay>(ad => ad.arac_ıd)  // AracDetay'da AracId, foreign key
        .IsRequired();  // İlişkinin zorunlu olduğunu belirtiyoruz (optional değil)
}

    
}
