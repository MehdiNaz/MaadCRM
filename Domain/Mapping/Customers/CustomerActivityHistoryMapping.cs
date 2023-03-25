namespace Domain.Mapping.Customers;

public class CustomerActivityHistoryMapping : IEntityTypeConfiguration<CustomerActivityHistory>
{
    public void Configure(EntityTypeBuilder<CustomerActivityHistory> builder)
    {
        builder.ToTable("CustomerActivityHistories");
        builder.HasKey(x => x.CustomerActivityHistoryId);
        builder.Property(x => x.Description).HasMaxLength(500).IsRequired();


        builder.HasOne(x => x.Customers).WithMany(x => x.CustomerActivityHistorys).HasForeignKey(x => x.CustomerActivityHistoryId);
        builder.HasOne(x => x.CustomerActivity).WithMany(x => x.CustomerActivityHistories).HasForeignKey(x => x.CustomerActivityHistoryId);
    }
}