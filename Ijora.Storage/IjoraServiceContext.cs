using Ijora.Storage.Entity;
using Microsoft.EntityFrameworkCore;

namespace Ijora.Storage
{
    public class IjoraServiceContext : DbContext
    {
        //public const string SCHEMA = "IjoraService";
        public const string SCHEMA = null;

        public IjoraServiceContext(DbContextOptions<IjoraServiceContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AuthEntity.OnModelConfig(modelBuilder.Entity<AuthEntity>());
            RealEstateEntity.OnModelConfig(modelBuilder.Entity<RealEstateEntity>());
            ComplexEntity.OnModelConfig(modelBuilder.Entity<ComplexEntity>());
            UserEntity.OnModelConfig(modelBuilder.Entity<UserEntity>());
        }

        /// <summary>
        /// Недвижимости.
        /// </summary>
        public DbSet<RealEstateEntity> RealEstates { get; set; }

        /// <summary>
        /// Жилые комплексы.
        /// </summary>
        public DbSet<ComplexEntity> Complexes { get; set; }

        /// <summary>
        /// Авторизация.
        /// </summary>
        public DbSet<AuthEntity> Auth { get; set; }

        /// <summary>
        /// Список пользоватлей.
        /// </summary>
        public DbSet<UserEntity> Users { get; set; }
    }
}
