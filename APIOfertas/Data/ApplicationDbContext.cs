using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace APIOfertas.Data
{
    /*  public class ApplicationDbContext : DbContext
      {
          public ApplicationDbContext()
          {
          }

          public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
          {
          }

          public DbSet<Oferta> Ofertas { get; set; }
      }
  }*/


    public partial class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Oferta> Oferta { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
    }
}