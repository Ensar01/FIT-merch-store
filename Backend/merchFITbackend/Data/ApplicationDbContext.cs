using merchFITbackend.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace merchFITbackend.Data
{
    public class ApplicationDbContext : IdentityDbContext<Korisnik,IdentityRole<int>,int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
        
        }

        public DbSet<Korisnik>Korisnik { get; set; }
        public DbSet<Kategorija> Kategorija { get; set;}
        public DbSet<Podkategorija> Podkategorija { get; set; }
        public DbSet<Proizvod> Proizvod { get; set; }
        public DbSet<Uzrast> Uzrast { get; set; }
        public DbSet<Narudzba> Narudzba { get; set; }
        public DbSet<StavkeNarudzbe> StavkeNarudzbe { get; set; }
        public DbSet<Velicina> Velicina { get; set; }
        public DbSet<ProizvodVelicina> ProizvodVelicina { get; set; }
        public DbSet<Dostavljac> Dostavljac { get; set; }
        public DbSet<Korpa> Korpa { get; set; }
        public DbSet<KorpaStavka> KorpaStavka { get; set; }
        public DbSet<Wishlist> Wishlist { get; set; }
        public DbSet<WishlistStavka> WishlistStavka { get; set; }
        public DbSet<Recenzija> Recenzija { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProizvodVelicina>()
                .HasKey(pk => new { pk.ProizvodID, pk.VelicinaID });

            modelBuilder.Entity<ProizvodVelicina>()
                .HasOne(pv => pv.Proizvod)
                .WithMany(p => p.Velicine)
                .HasForeignKey(pv => pv.ProizvodID);

            modelBuilder.Entity<ProizvodVelicina>()
                .HasOne(pv => pv.Velicina)
                .WithMany(p => p.Proizvod)
                .HasForeignKey(pv => pv.VelicinaID);
          

        }
    }

}
