using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Chrome___Firefox_Db_Project.Model
{
    public partial class permissionsContext : DbContext
    {
        public permissionsContext()
        {
        }

        public permissionsContext(DbContextOptions<permissionsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MozHost> MozHosts { get; set; } = null!;
        public virtual DbSet<MozPerm> MozPerms { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=C:\\sqlite\\db\\permissions.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MozHost>(entity =>
            {
                entity.ToTable("moz_hosts");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ExpireTime).HasColumnName("expireTime");

                entity.Property(e => e.ExpireType).HasColumnName("expireType");

                entity.Property(e => e.Host).HasColumnName("host");

                entity.Property(e => e.IsInBrowserElement).HasColumnName("isInBrowserElement");

                entity.Property(e => e.ModificationTime).HasColumnName("modificationTime");

                entity.Property(e => e.Permission).HasColumnName("permission");

                entity.Property(e => e.Type).HasColumnName("type");
            });

            modelBuilder.Entity<MozPerm>(entity =>
            {
                entity.ToTable("moz_perms");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ExpireTime).HasColumnName("expireTime");

                entity.Property(e => e.ExpireType).HasColumnName("expireType");

                entity.Property(e => e.ModificationTime).HasColumnName("modificationTime");

                entity.Property(e => e.Origin).HasColumnName("origin");

                entity.Property(e => e.Permission).HasColumnName("permission");

                entity.Property(e => e.Type).HasColumnName("type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
