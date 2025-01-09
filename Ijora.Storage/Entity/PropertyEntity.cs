using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ijora.Storage.Entity
{
    public class PropertyEntity
    {
        
        public long Id { get; set; }
        public Guid UserId { get; set; }
        public long dd { get; set; }
        public long ddsd { get; set; }

        public static void OnModelConfig(EntityTypeBuilder<PropertyEntity> config)
        {
            config.ToTable("AKBTasks")
                .HasKey(a => a.Id);
        }
    }
}
