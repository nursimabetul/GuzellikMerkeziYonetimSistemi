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

        public DbSet<Personel>Personels { get; set; }
		public DbSet<IslemKategori> IslemKategoris { get; set; }
		public DbSet<Islem> Islems { get; set; }

	}
}
