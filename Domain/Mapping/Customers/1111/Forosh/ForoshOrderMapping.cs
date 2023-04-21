namespace Domain.Mapping.Customers.Forosh;

public class ForoshOrderMapping : IEntityTypeConfiguration<ForooshOrder>
{
    public void Configure(EntityTypeBuilder<ForooshOrder> builder)
    {
        builder.ToTable("ForoshOrders");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Description).HasMaxLength(500).IsRequired();
    }
}