using Ijora.Storage.Entity;
using Microsoft.EntityFrameworkCore;

namespace Ijora.Storage
{
    public class IjoraServiceContext : DbContext
    {
        public const string SCHEMA = "IjoraService";

        public IjoraServiceContext(DbContextOptions<IjoraServiceContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            RealEstateEntity.OnModelConfig(modelBuilder.Entity<RealEstateEntity>());
        }

        /// <summary>
        /// Недвижимости.
        /// </summary>
        public DbSet<RealEstateEntity> RealEstates { get; set; }
    }
}
