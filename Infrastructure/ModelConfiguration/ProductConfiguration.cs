using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ModelConfiguration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Description).IsRequired();
        builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
        builder.Property(x => x.PictureUrl).IsRequired();
        builder.Property(x => x.Type).IsRequired();
        builder.Property(x => x.Brand).IsRequired();
        
    }
}
