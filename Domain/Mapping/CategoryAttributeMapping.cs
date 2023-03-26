namespace Domain.Mapping;

public class CategoryAttributeMapping : IEntityTypeConfiguration<CategoryAttribute>
{
    public void Configure(EntityTypeBuilder<CategoryAttribute> builder)
    {
        builder.ToTable("CategoryAttributes");
        builder.HasKey(x => x.CategoryAttributeId);
        builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(255).IsRequired();


        builder.HasOne(x => x.Business).WithMany(x => x.CategoryAttributes).HasForeignKey(x => x.BusinessId);
    }
}