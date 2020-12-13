
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Xayah.FIControl.Domain.Enitties;

namespace Xayah.FIControl.DataContext
{
    public class XayahFIControlDataContext : DbContext
    {

        public XayahFIControlDataContext()
        {

        }

  
        public XayahFIControlDataContext(DbContextOptions<XayahFIControlDataContext> options)
            : base(options)
        {
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                IConfigurationRoot config = builder.Build();

                optionsBuilder.UseSqlite(config.GetConnectionString("XayahFIControlConnection"));
            }

            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder construtorDeModelos)
        {

            construtorDeModelos.HasDefaultSchema("XayahFIControl");





       

        }
        public DbSet<BankStatement> BankStatement { get; set; }

        public DbSet<Accountlaunche> Accountlaunche { get; set; }

        public override int SaveChanges()
        {

            #region 

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity.GetType().GetProperty("CreatedDate") != null)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("CreatedDate").CurrentValue = DateTime.Now;
                    }
                    if (entry.State == EntityState.Modified)
                    {
                        entry.Property("CreatedDate").IsModified = false;
                    }
                }

                if (entry.Entity.GetType().GetProperty("Active") != null)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("Active").CurrentValue = true;
                    }
                    if (entry.State == EntityState.Modified)
                    {
                        entry.Property("Active").IsModified = false;
                    }
                }
            }
            #endregion
            return base.SaveChanges();

        }
    }
}
