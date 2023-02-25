using KANOKO.Entity;
using KANOKO.Entity.Identity;
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
            }
            public DbSet<User> Users { get; set; }

            public DbSet<Role> Roles { get; set; }

            public DbSet<UserRole> UserRole { get; set; }
            public DbSet<Admin> Admins { get; set; }

            public DbSet<Customer> Customers { get; set; }

            public DbSet<Order> Order { get; set; }
            public DbSet<Transaction> Transactions { get; set; }
            public DbSet<Wallet> Wallets { get; set; }
            public DbSet<Driver> Drivers { get; set; }
            public DbSet<Location> Locations { get; set; }
            public DbSet<Payment> Payments { get; set; }


    }
}
