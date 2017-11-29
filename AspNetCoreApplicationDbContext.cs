using System;
using System.Linq;
using AspNetCoreApplication.Model;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreApplication {
    public class AspNetCoreApplicationDbContext : DbContext {
        public AspNetCoreApplicationDbContext (DbContextOptions<AspNetCoreApplicationDbContext> options) : base (options) { }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Modality> Modalities { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<BusinessUnit> BusinessUnit { get; set; }
        public DbSet<Campaign> Campaign { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            base.OnModelCreating (modelBuilder);
            modelBuilder.Entity<Training> ().Property (e => e.RowVersion).ValueGeneratedOnAddOrUpdate ().IsConcurrencyToken ();
            modelBuilder.Entity<Modality> ().Property (d => d.RowVersion).ValueGeneratedOnAddOrUpdate ().IsConcurrencyToken ();
            modelBuilder.Entity<Organization> ().Property (c => c.RowVersion).ValueGeneratedOnAddOrUpdate ().IsConcurrencyToken ();
            modelBuilder.Entity<BusinessUnit> ().Property (l => l.RowVersion).ValueGeneratedOnAddOrUpdate ().IsConcurrencyToken ();
            modelBuilder.Entity<Campaign> ().Property (c => c.RowVersion).ValueGeneratedOnAddOrUpdate ().IsConcurrencyToken ();
        }
        public override int SaveChanges () {
            foreach (var entry in ChangeTracker.Entries ()
                    .Where (e => e.State == EntityState.Added)) {
                entry.Property ("CreatedDate").CurrentValue = DateTime.Now;
            }
            return base.SaveChanges ();
        }
    }
}