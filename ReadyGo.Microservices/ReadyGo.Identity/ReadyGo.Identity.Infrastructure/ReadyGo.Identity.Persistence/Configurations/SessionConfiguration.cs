using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadyGo.Identity.Domain.Aggregates;

namespace ReadyGo.Identity.Persistence.Configurations
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.UserId);

            builder.OwnsOne(s => s.Device, sd =>
            {
                sd.Property(d => d.Value)
                   .HasColumnName(nameof(Session.Device));
            });

            builder.OwnsOne(s => s.IpAddress, si =>
            {
                si.Property(i => i.Value)
                  .HasColumnName(nameof(Session.IpAddress));
            });
        }
    }
}
