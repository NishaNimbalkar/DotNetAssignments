using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BankApp.Infrastrucure.Context
{
    public class BankDbContext:DbContext
    {
        public BankDbContext(DbContextOptions<BankDbContext> options) : base(options) { }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new AccountConfiguration)
        //    base.OnModelCreating(modelBuilder);
        //}
        //public DbSet<User> Users { get; set; } // Manually managing users

        public DbSet<Account>Accounts { get; set; }
      public  DbSet<Transaction>Transactions { get; set; }
    }
}
