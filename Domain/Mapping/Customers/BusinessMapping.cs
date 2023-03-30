namespace Domain.Mapping.Customers;

public class BusinessMapping : IEntityTypeConfiguration<Business>
{
    public void Configure(EntityTypeBuilder<Business> builder)
    {
        builder.ToTable("Businesses");
        builder.HasKey(x => x.BusinessId);
        builder.Property(x => x.BusinessName).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Url).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Hosts).HasMaxLength(255).IsRequired();
        builder.Property(x => x.CompanyName).HasMaxLength(255).IsRequired();
        builder.Property(x => x.CompanyAddress).HasMaxLength(255).IsRequired();


        builder.HasOne(x => x.User).WithMany(x => x.Businesses).HasForeignKey(x => x.UserId);
        builder.HasOne(x => x.Customer).WithMany(x => x.Businesses).HasForeignKey(x => x.CustomerId);
        builder.HasOne(x => x.Contact).WithMany(x => x.Businesses).HasForeignKey(x => x.ContactId);
        builder.HasOne(x => x.ContactGroup).WithMany(x => x.Businesses).HasForeignKey(x => x.ContactGroupId);
        builder.HasOne(x => x.AttributeOptions).WithMany(x => x.Businesses).HasForeignKey(x => x.AttributeOptionsId);
        builder.HasOne(x => x.AttributeOptionsValue).WithMany(x => x.Businesses).HasForeignKey(x => x.AttributeOptionsValueId);
        builder.HasOne(x => x.BusinessAttribute).WithMany(x => x.Businesses).HasForeignKey(x => x.BusinessAttributeId);
        builder.HasOne(x => x.CategoryAttribute).WithMany(x => x.Businesses).HasForeignKey(x => x.CategoryAttributeId);
    }
}