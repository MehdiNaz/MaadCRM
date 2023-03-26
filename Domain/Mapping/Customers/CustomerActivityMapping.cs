namespace Domain.Mapping.Customers;

public class CustomerActivityMapping : IEntityTypeConfiguration<CustomerActivity>
{
    public void Configure(EntityTypeBuilder<CustomerActivity> builder)
    {
        builder.ToTable("CustomerActivities");
        builder.HasKey(x => x.CustomerActivityId);
        builder.Property(x => x.CustomerActivityName).HasMaxLength(250).IsRequired();
        builder.Property(x => x.CustomerActivityDescription).HasMaxLength(500).IsRequired();

        builder.HasOne(x => x.Customer).WithMany(x => x.CustomerActivities).HasForeignKey(x => x.CustomerId);
    }
}