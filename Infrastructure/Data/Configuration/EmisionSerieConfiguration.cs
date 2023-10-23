using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;


namespace Infrastructure.Data.Configurations;

public class EmisionSerieConfiguration : IEntityTypeConfiguration<EmisionSerie> 
{
    public void Configure(EntityTypeBuilder<EmisionSerie> builder)
    {
        builder.ToTable("EmisionSerie");
        builder.HasKey(e => e.Id);
        //builder.Property(p => p.Nombre).HasMaxLength(100).IsRequired();
    }
}