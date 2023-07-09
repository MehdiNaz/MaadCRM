namespace Domain.Mapping.SpecialFields;

public class AttributeCustomerMapping : IEntityTypeConfiguration<AttributeCustomer>
{
    public void Configure(EntityTypeBuilder<AttributeCustomer> builder)
    {
        builder.ToTable("AttributesCustomer");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ValueString).HasMaxLength(255).IsRequired();

        builder.HasOne(x => x.IdAttributeOptionNavigation)
            .WithMany(x => x.CustomerAttributes)
            .HasForeignKey(x => x.IdAttributeOption)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_AttributeOption_AttributesCustomer");

        builder.HasOne(x => x.IdCustomerNavigation)
            .WithMany(x => x.CustomerAttributes)
            .HasForeignKey(x => x.IdCustomer)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Customer_AttributesCustomer");
    }
}