using KANOKO.Contract;
using KANOKO.Entity;
using KANOKO.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace KANOKO.Context
{
    public class ApplicationContext : DbContext
    {
        
        
            public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
            {

            }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<AppUser>()
                    .HasOne(e => e.User)
                    .WithOne(e => e.AppUser)
                    .HasForeignKey<AppUser>(e => e.UserId);
            }


        public override int SaveChanges()
            {
                var now = DateTime.UtcNow;

                foreach (var changedEntity in ChangeTracker.Entries())
                {
                    if (changedEntity.Entity is AuditableEntity entity)
                    {
                        switch (changedEntity.State)
                        {
                            case EntityState.Added:
                                entity.CreatedOn = now;
                                entity.UpdatedDate = now;
                                break;

                            case EntityState.Modified:
                                Entry(entity).Property(x => x.CreatedOn).IsModified = false;
                                entity.UpdatedDate = now;
                                break;
                        }
                    }
                }

                return base.SaveChanges();
            }
            public DbSet<User> Users { get; set; }
            public DbSet<Admin> Admins { get; set; }
            public DbSet<AppUser> AppUser { get; set; }
           // public DbSet<Wallet> Wallets { get; set; }
           public DbSet<PaymentMethod> PaymentMethods { get; set; }
            public DbSet<Admin> Drivers { get; set; }
            public DbSet<Payment> Payments { get; set; }
            public DbSet<Transaction> Transactions { get; set; }
            public DbSet<Dispute> Disputes { get; set; }
            public DbSet<AppUserTransaction> AppUserTransactions { get; set; }
            public DbSet<Location> Locations { get; set; }

            
            

    }
}
