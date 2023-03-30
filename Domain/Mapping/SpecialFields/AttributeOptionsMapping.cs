namespace Domain.Mapping.SpecialFields;

public class AttributeOptionsMapping : IEntityTypeConfiguration<AttributeOptions>
{
    public void Configure(EntityTypeBuilder<AttributeOptions> builder)
    {
        builder.ToTable("AttributeOptions");
        builder.HasKey(x => x.AttributeOptionsId);
        builder.Property(x => x.Title).HasMaxLength(255).IsRequired();
        builder.Property(x => x.ColorSquaresRgb).HasMaxLength(255).IsRequired();


        builder.HasOne(x => x.BusinessAttribute).WithMany(x => x.AttributeOptions).HasForeignKey(x => x.BusinessAttributeId);
    }
}