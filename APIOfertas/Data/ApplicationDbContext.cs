using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace APIOfertas.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public DbSet<TipoOferta> TipoOferta { get; set; }
        public DbSet<Oferta> Oferta { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Oferta>()
                .HasOne(o => o.TipoOferta)
                .WithMany(to => to.Oferta)
                .HasForeignKey(o => o.TipoOfertaId);

    } */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TipoOferta>()//Establecer la relación uno a muchos entre Tipo oferta y Oferta
                .HasMany(tp => tp.Oferta)
                .WithOne(p => p.TipoOferta);
        }

    }
}