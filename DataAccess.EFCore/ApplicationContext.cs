using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EFCore
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public DbSet<PaymentState> PaymentStates { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentState>().HasData(new PaymentState[] {
                new PaymentState{ID=1,Status="Completed"},
                new PaymentState{ID=2,Status="Pending"},
                new PaymentState{ID=3,Status="Failed"},
            });
        }
    }

}
