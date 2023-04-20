namespace Domain.Mapping.Customers.Forosh;

public class ForoshOrderMapping : IEntityTypeConfiguration<ForoshOrder>
{
    public void Configure(EntityTypeBuilder<ForoshOrder> builder)
    {
        builder.ToTable("ForoshOrders");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Description).HasMaxLength(500).IsRequired();
    }
}