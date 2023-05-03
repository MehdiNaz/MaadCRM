namespace Domain.Mapping.Customers.Feedback;

public class CustomerFeedbackCategoryMapping : IEntityTypeConfiguration<CustomerFeedbackCategory>
{
    public void Configure(EntityTypeBuilder<CustomerFeedbackCategory> builder)
    {
        builder.ToTable("CustomerFeedbackCategories");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(255).IsRequired();

        builder.Property(e => e.Version).IsRowVersion();

        builder.HasOne(d => d.IdUserAddNavigation)
        .WithMany(p => p.CustomerFeedbackCategoryAdded)
        .HasForeignKey(d => d.IdUserAdded)
        .HasConstraintName("FK_CustomerFeedbacksCategory_User_Added");

        builder.HasOne(d => d.IdUserUpdateNavigation)
        .WithMany(p => p.CustomerFeedbackCategoryUpdated)
        .HasForeignKey(d => d.IdUserUpdated)
        .HasConstraintName("FK_CustomerFeedbackCategory_User_Updated");

        builder.HasOne(d => d.IdBusinessNavigation)
        .WithMany(p => p.CustomerFeedbackCategories)
        .HasForeignKey(d => d.IdBusiness)
        .HasConstraintName("FK_CustomerFeedbackCategory_Business");
    }
}