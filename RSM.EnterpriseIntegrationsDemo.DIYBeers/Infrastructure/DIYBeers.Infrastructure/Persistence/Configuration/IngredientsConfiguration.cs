using DIYBeers.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DIYBeers.Infrastructure.Persistence.Configuration;

public class IngredientsConfiguration : IEntityTypeConfiguration<Ingredients>
{
    public void Configure(EntityTypeBuilder<Ingredients> builder)
    {
        // Ingredients -> Malt (1:N)
        builder.HasMany(i => i.Malt)
            .WithOne()
            .HasForeignKey(m => m.IngredientsId);
        
        // Ingredients → Hops (1:N)
        builder.HasMany(i => i.Hops)
            .WithOne()
            .HasForeignKey(h => h.IngredientsId);
        
        builder.Property(i => i.Yeast)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();
    }
}

public class MaltConfiguration : IEntityTypeConfiguration<Malt>
{
    public void Configure(EntityTypeBuilder<Malt> builder)
    {
        builder.ToTable(nameof(Malt));
        builder.Property(m => m.Name)
            .HasColumnType("varchar(50)")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(m => m.Unit)
            .HasColumnType("varchar(50)")
            .HasMaxLength(50)
            .IsRequired();
    }
}

public class HopsConfiguration : IEntityTypeConfiguration<Hops>
{
    public void Configure(EntityTypeBuilder<Hops> builder)
    {
        builder.Property(h => h.Name)
            .HasColumnType("varchar(50)")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(h => h.Unit)
            .HasColumnType("varchar(50)")
            .HasMaxLength(50)
            .IsRequired();
    }
}