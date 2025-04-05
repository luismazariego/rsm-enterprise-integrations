using DIYBeers.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DIYBeers.Infrastructure.Persistence.Configuration;

public class BeerConfiguration : IEntityTypeConfiguration<Beer>
{
    public void Configure(EntityTypeBuilder<Beer> builder)
    {
        builder.ToTable(nameof(Beer));
        
        builder.HasOne(b => b.Ingredients)
            .WithOne(i => i.Beer)
            .HasForeignKey<Ingredients>(i => i.BeerId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.Property(b => b.Name)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(b => b.Tagline)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(b => b.FirstBrewed)
            .HasColumnType("varchar(10)")
            .HasMaxLength(10)
            .IsRequired();
        builder.Property(b => b.Description)
            .HasColumnType("varchar(max)")
            .IsRequired();
        builder.Property(b => b.FoodPairing)
            .HasColumnType("varchar(max)")
            .IsRequired();
        builder.Property(b => b.BrewersTips)
            .HasColumnType("varchar(1000)")
            .HasMaxLength(1000);
    }
}
