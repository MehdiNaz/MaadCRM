namespace Domain.Mapping.Customers;

public class CustomerRepresentativeHistoryMapping : IEntityTypeConfiguration<CustomerRepresentativeHistory>
{
    public void Configure(EntityTypeBuilder<CustomerRepresentativeHistory> builder)
    {
        builder.ToTable("CustomerRepresentativeHistories");
        builder.HasKey(x => x.CustomerRepresentativeHistoryId);

        builder.HasOne(x => x.CustomerRepresentativeType).WithMany(x => x.CustomerRepresentativeHistory).HasForeignKey(x => x.CustomerRepresentativeTypeId);
    }
}