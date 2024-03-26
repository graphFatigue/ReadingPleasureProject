using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReadingPleasure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingPleasure.Infrastructure
{
    public class AppDbContext : IdentityDbContext<User, Role, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Reader> Readers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Edition> Editions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<PublishingHouse> PublishingHouses { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            HandleSoftDelete();
            AuditEntities();

            return base.SaveChangesAsync(cancellationToken);
        }

        private void AuditEntities()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.State is EntityState.Added or EntityState.Modified);

            foreach (var entityEntry in entries)
            {
                var auditEntity = (IBaseEntity)entityEntry.Entity;
                auditEntity.ModifiedAt = DateTime.UtcNow;

                if (entityEntry.State == EntityState.Added)
                {
                    auditEntity.CreatedAt = DateTime.UtcNow;
                }
            }
        }

        private void HandleSoftDelete()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.State == EntityState.Deleted);

            foreach (var entityEntry in entries)
            {
                var auditEntity = (IBaseEntity)entityEntry.Entity;
                auditEntity.IsDeleted = true;
                entityEntry.State = EntityState.Modified;
            }
        }
    }
}
