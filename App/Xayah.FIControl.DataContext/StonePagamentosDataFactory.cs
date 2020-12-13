using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Xayah.FIControl.DataContext;

namespace  XayahFIControl.DataContext
{
    class  XayahFIControlDataFactory : IDesignTimeDbContextFactory< XayahFIControlDataContext>
    {
        


        public  XayahFIControlDataFactory()
        {
        }

        public  XayahFIControlDataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder< XayahFIControlDataContext>();

            var builder = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot config = builder.Build();

            optionsBuilder.UseSqlite(config.GetConnectionString(" XayahFIControlConnection"));

            return new  XayahFIControlDataContext(optionsBuilder.Options);
        }


        //public  XayahFIControlDataContext Create(DbContextFactoryOptions options)
        //{
        //    var builder = new ConfigurationBuilder()
        //  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //    IConfigurationRoot config = builder.Build();

        //    var construtor = new DbContextOptionsBuilder< XayahFIControlDataContext>();
        //    construtor.UseSqlite(config.GetConnectionString(" XayahFIControlConnection"));
        //    return new  XayahFIControlDataContext(construtor.Options);
        //}
    }
}
