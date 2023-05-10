namespace Domain.Mapping.SpecialFields;

public class AttributeOptionsValueMapping : IEntityTypeConfiguration<AttributeOptionValue>
{
    public void Configure(EntityTypeBuilder<AttributeOptionValue> builder)
    {
        builder.ToTable("AttributeOptionsValues");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Value).HasMaxLength(500).IsRequired();
        builder.Property(x => x.FilePath).HasMaxLength(500);

        builder.HasOne(x => x.AttributeOptions)
            .WithMany(x => x.AttributeOptionValues)
            .HasForeignKey(x => x.IdAttributeOption)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_AttributeOption_AttributeOptionValue");
    }
}