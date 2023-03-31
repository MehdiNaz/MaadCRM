namespace Domain.Mapping.Customers;

public class CustomerHashTagMapping : IEntityTypeConfiguration<CustomerHashTag>
{
    public void Configure(EntityTypeBuilder<CustomerHashTag> builder)
    {
        builder.ToTable("CustomerHashTags");
        builder.HasKey(x => x.CustomerHashTagId);
        builder.Property(x => x.Title).HasMaxLength(255).IsRequired();
    }
}