namespace Domain.Mapping;

public class BusinessAttributeMapping : IEntityTypeConfiguration<BusinessAttribute>
{
    public void Configure(EntityTypeBuilder<BusinessAttribute> builder)
    {
        builder.ToTable("BusinessAttributes");
        builder.HasKey(x => x.BusinessAttributeId);
        builder.Property(x => x.TextPrompt).HasMaxLength(255).IsRequired();
        builder.Property(x => x.ValidationFileAllowExtention).HasMaxLength(255).IsRequired();
        builder.Property(x => x.DefaultValue).HasMaxLength(255).IsRequired();
        builder.Property(x => x.ConditionValue).HasMaxLength(255).IsRequired();


        // builder.HasOne(x => x.CategoryAttribute).WithMany(x => x.BusinessAttributes).HasForeignKey(x => x.CategoryAttributeId);
    }
}