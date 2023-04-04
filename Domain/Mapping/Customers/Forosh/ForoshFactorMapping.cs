using Domain.Models.Customers.Forosh;

namespace Domain.Mapping.Customers.Forosh;

public class ForoshFactorMapping : IEntityTypeConfiguration<ForoshFactor>
{
    public void Configure(EntityTypeBuilder<ForoshFactor> builder)
    {
        builder.ToTable("ForoshFactors");
        builder.HasKey(x => x.ForoshFactorId);
    }
}