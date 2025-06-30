﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadyGo.Identity.Domain.Aggregates;
using ReadyGo.Identity.Domain.Entities;

namespace ReadyGo.Identity.Persistence.Configurations
{
    internal class ScopePermissionConfiguration : IEntityTypeConfiguration<ScopePermission>
    {
        public void Configure(EntityTypeBuilder<ScopePermission> builder)
        {
            builder.HasKey(sp => sp.Id);

            builder.HasIndex(sp => sp.AuthorizationId);

            builder.HasOne<Authorization>()
                   .WithMany()
                   .HasForeignKey(sp => sp.AuthorizationId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Scope>()
                   .WithMany()
                   .HasForeignKey(sp => sp.ScopeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
