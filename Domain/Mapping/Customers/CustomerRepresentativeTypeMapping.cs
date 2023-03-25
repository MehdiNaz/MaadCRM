namespace Domain.Mapping.Customers;

public class CustomerRepresentativeTypeMapping : IEntityTypeConfiguration<CustomerRepresentativeType>
{
    public void Configure(EntityTypeBuilder<CustomerRepresentativeType> builder)
    {
        builder.ToTable("CustomerRepresentativeTypes");
        builder.HasKey(x => x.CustomerRepresentativeTypeId);

    }
}