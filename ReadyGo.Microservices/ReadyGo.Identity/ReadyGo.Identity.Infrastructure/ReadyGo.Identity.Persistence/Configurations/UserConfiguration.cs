using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadyGo.Identity.Domain.Aggregates;
using ReadyGo.Identity.Domain.Entities;

namespace ReadyGo.Identity.Persistence.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.Id);

            builder.Property(u => u.IsActive)
                   .IsRequired();

            builder.HasOne(a => a.Authentication)
                   .WithOne()
                   .HasForeignKey<Authentication>(a => a.Id)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Authorization)
                   .WithOne()
                   .HasForeignKey<Authorization>(a => a.Id)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(u => u.Profile)
                   .WithOne()
                   .HasForeignKey<Profile>(p => p.Id)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany<Session>()
                   .WithOne()
                   .HasForeignKey(s => s.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
