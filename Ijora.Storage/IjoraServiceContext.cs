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
            PropertyEntity.OnModelConfig(modelBuilder.Entity<PropertyEntity>());
        }

        public DbSet<PropertyEntity> Properties { get; set; }
    }
}
