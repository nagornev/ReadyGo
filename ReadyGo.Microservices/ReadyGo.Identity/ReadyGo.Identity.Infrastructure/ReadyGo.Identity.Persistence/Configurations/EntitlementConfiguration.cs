using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadyGo.Identity.Domain.Aggregates;
using ReadyGo.Identity.Domain.Entities;

namespace ReadyGo.Identity.Persistence.Configurations
{
    internal class EntitlementConfiguration : IEntityTypeConfiguration<Entitlement>
    {
        public void Configure(EntityTypeBuilder<Entitlement> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.RoleId);

            builder.HasOne<Role>()
                   .WithMany()
                   .HasForeignKey(e => e.RoleId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Scope>()
                   .WithMany()
                   .HasForeignKey(e => e.ScopeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
