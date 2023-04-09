namespace Domain.Mapping.Customers;

public class CustomerCategoryMapping : IEntityTypeConfiguration<CustomerCategory>
{
    public void Configure(EntityTypeBuilder<CustomerCategory> builder)
    {
        builder.ToTable("CustomerCategories");
        builder.HasKey(x => x.CustomerCategoryId);
        builder.Property(x => x.CustomerCategoryName).HasMaxLength(255).IsRequired();

        // builder.HasOne(x => x.CreatorUser).WithMany(x => x.CustomerCategories).HasForeignKey(x => x.CreatedBy);
        // builder.HasOne(x => x.CreatorUser).WithMany(x => x.CustomerCategories).HasForeignKey(x => x.UpdatedBy);
    }
}