namespace Domain.Mapping.SpecialFields;

public class CustomerAttributeMapping : IEntityTypeConfiguration<CustomerAttribute>
{
    public void Configure(EntityTypeBuilder<CustomerAttribute> builder)
    {
        builder.ToTable("CustomerAttributes");
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.IdAttributeOptionNavigation)
            .WithMany(x => x.CustomerAttributes)
            .HasForeignKey(x => x.IdAttributeOption)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_AttributeOptionNavigation_CustomerAttribute");

        builder.HasOne(x => x.IdCustomerNavigation)
            .WithMany(x => x.CustomerAttributes)
            .HasForeignKey(x => x.IdCustomer)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Customer_CustomerAttribute");
    }
}