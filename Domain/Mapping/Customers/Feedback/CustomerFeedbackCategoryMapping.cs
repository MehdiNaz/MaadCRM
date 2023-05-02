namespace Domain.Mapping.Customers.Feedback;

public class CustomerFeedbackCategoryMapping : IEntityTypeConfiguration<CustomerFeedbackCategory>
{
    public void Configure(EntityTypeBuilder<CustomerFeedbackCategory> builder)
    {
        builder.ToTable("CustomerCategories");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(255).IsRequired();

        builder.Property(e => e.Version).IsRowVersion();
    }
}