using System;
using System.Linq;
using AspNetCoreApplication.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreApplication {
    public class AspNetCoreApplicationDbContext : IdentityDbContext<IdentityUser> {
        public AspNetCoreApplicationDbContext (DbContextOptions<AspNetCoreApplicationDbContext> options) : base (options) { }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Modality> Modalities { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<BusinessUnit> BusinessUnit { get; set; }
        public DbSet<Campaign> Campaign { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<NewTraining> NewTrainings { get; set; }
        public DbSet<Technologies> Technologies { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            base.OnModelCreating (modelBuilder);
            modelBuilder.Entity<Training> ().Property (e => e.RowVersion).ValueGeneratedOnAddOrUpdate ().IsConcurrencyToken ();
            modelBuilder.Entity<Modality> ().Property (d => d.RowVersion).ValueGeneratedOnAddOrUpdate ().IsConcurrencyToken ();
            modelBuilder.Entity<Organization> ().Property (c => c.RowVersion).ValueGeneratedOnAddOrUpdate ().IsConcurrencyToken ();
            modelBuilder.Entity<BusinessUnit> ().Property (l => l.RowVersion).ValueGeneratedOnAddOrUpdate ().IsConcurrencyToken ();
            modelBuilder.Entity<Campaign> ().Property (c => c.RowVersion).ValueGeneratedOnAddOrUpdate ().IsConcurrencyToken ();
            modelBuilder.Entity<Category> ().Property (c => c.RowVersion).ValueGeneratedOnAddOrUpdate ().IsConcurrencyToken ();

        }
        public override int SaveChanges () {
            foreach (var entry in ChangeTracker.Entries ()
                    .Where (e => e.State == EntityState.Added)) {
                entry.Property ("CreatedDate").CurrentValue = DateTime.Today;
            }
            return base.SaveChanges ();
        }
    }
}