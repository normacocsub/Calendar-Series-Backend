using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using Infrastructure.Data.Configurations;

namespace Infrastructure.Data.Context
{
    public class CalendarSerieContext : DbContext
    {
        public CalendarSerieContext(DbContextOptions<CalendarSerieContext> options)
            : base(options)
        {
        }
        public DbSet<Serie> Series { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SerieConfiguration());
            modelBuilder.ApplyConfiguration(new EmisionSerieConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}