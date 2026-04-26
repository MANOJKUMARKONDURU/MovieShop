using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MovieShopDbContext : DbContext
    {
        // Parameterless ctor for design-time (EF CLI)
        public MovieShopDbContext()
        {
        }

        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options)
            : base(options)
        {
        }

        // Design-time configuration for EF tools
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            
                optionsBuilder.UseSqlServer(
                    "Server=localhost,1433;Database=MovieShopDb;User ID=sa;Password=Manoj@2127;TrustServerCertificate=True;");
            }
        } 


        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<MovieCrew> MovieCrews { get; set; }
        public DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite Keys
            modelBuilder.Entity<MovieGenre>()
                .HasKey(mg => new { mg.MovieId, mg.GenreId });

            modelBuilder.Entity<MovieCast>()
                .HasKey(mc => new { mc.MovieId, mc.CastId, mc.Character });

            modelBuilder.Entity<MovieCrew>()
                .HasKey(mc => new { mc.MovieId, mc.CrewId, mc.Department, mc.Job });

            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            // Decimal precision
            modelBuilder.Entity<Movie>()
                .Property(m => m.Revenue)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Purchase>()
                .Property(p => p.TotalPrice)
                .HasColumnType("decimal(18,2)");

            // -------------------------
            // SEEDING DATA (optional)
            // -------------------------
        }
    }
}
