namespace Domain.Mapping.SpecialFields;

public class AttributeOptionsMapping : IEntityTypeConfiguration<AttributeOption>
{
    public void Configure(EntityTypeBuilder<AttributeOption> builder)
    {
        builder.ToTable("AttributeOptions");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title).HasMaxLength(255).IsRequired();
        builder.Property(x => x.ColorSquaresRgb).HasMaxLength(255).IsRequired();

        builder.HasOne(x => x.IdAttributeNavigation)
            .WithMany(x => x.AttributeOptions)
            .HasForeignKey(x => x.IdAttribute)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_AttributeOption_Attribute");
    }
}