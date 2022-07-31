using DB.Model;
using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class ChallengeContext: DbContext 

    {
        public ChallengeContext(DbContextOptions<ChallengeContext> options)
            : base(options)
        {
             
        }

        public DbSet<Personaje> Personajes { get; set; }
        public DbSet<Pelicula> Pelicula { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<PeliculaPersonaje> PeliculaPersonajes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personaje>().ToTable("Personaje");
            modelBuilder.Entity<Pelicula>().ToTable("Pelicula");
            modelBuilder.Entity<Genero>().ToTable("Genero");
            modelBuilder.Entity<PeliculaPersonaje>().ToTable("PeliculaPersonaje");

            modelBuilder.Entity<Pelicula>()
                .HasOne<Genero>(g => g.Genero)
                .WithMany(pe => pe.Peliculas)
                .HasForeignKey(g => g.GeneroID);

            modelBuilder.Entity<Personaje>()
            .HasMany(p => p.Peliculas)
            .WithMany(p => p.Personajes)
            .UsingEntity<PeliculaPersonaje>(
                j => j
                    .HasOne(pt => pt.Pelicula)
                    .WithMany(t => t.PeliculasPersonajes)
                    .HasForeignKey(pt => pt.PeliculaId),
                j => j
                    .HasOne(pt => pt.Personaje)
                    .WithMany(p => p.PeliculasPersonajes)
                    .HasForeignKey(pt => pt.PersonajeId),
                j =>
                {
                    j.HasKey(t => new { t.PersonajeId, t.PeliculaId });
                });
        }

    }
}