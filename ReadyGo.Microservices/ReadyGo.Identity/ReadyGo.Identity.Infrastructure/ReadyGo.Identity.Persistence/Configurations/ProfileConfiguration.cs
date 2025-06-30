using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadyGo.Identity.Domain.Entities;

namespace ReadyGo.Identity.Persistence.Configurations
{
    internal class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.HasKey(p => p.Id);

            builder.OwnsOne(p => p.EmailAddress, pea =>
            {
                pea.Property(ea => ea.Value)
                   .HasColumnName(nameof(Profile.EmailAddress));
            });

            builder.OwnsOne(p => p.PersonName, pun =>
            {
                pun.Property(un => un.Name)
                   .HasColumnName(nameof(Profile.PersonName));
            });
        }
    }
}
