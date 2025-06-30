using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadyGo.Identity.Domain.Aggregates;
using ReadyGo.Identity.Domain.Entities;

namespace ReadyGo.Identity.Persistence.Configurations
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Ignore(x => x.Entitlements);

            builder.HasMany<Entitlement>("_entitlements")
                   .WithOne()
                   .HasForeignKey(e => e.RoleId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
