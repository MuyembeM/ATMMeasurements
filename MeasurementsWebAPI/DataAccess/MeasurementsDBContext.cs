using System;
using System.Collections.Generic;
using MeasurementsWebAPI.BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MeasurementsWebAPI.DataAccess
{
    public partial class MeasurementsDBContext : DbContext
    {
        public MeasurementsDBContext()
        {
        }

        public MeasurementsDBContext(DbContextOptions<MeasurementsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Atm> Atms { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Atm>(entity =>
            {
                entity.ToTable("ATM");

                entity.Property(e => e.Description).IsUnicode(false);
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
