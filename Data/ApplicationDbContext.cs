using GuzellikMerkeziYonetimSistemi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GuzellikMerkeziYonetimSistemi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
		public DbSet<Personel> Personels { get; set; }
		public DbSet<IslemKategori> IslemKategoris { get; set; }
		public DbSet<Islem> Islems { get; set; }
		public DbSet<KullaniciTuru> KullaniciTurus { get; set; }
		public DbSet<Salon> Salons { get; set; }
		public DbSet<Uzmanlik> Uzmanliks { get; set; }
		public DbSet<Sil> Sils { get; set; }

	}
}
