namespace Domain.Mapping.Customers.Feedback;

public class CustomerFeedbackMapping : IEntityTypeConfiguration<CustomerFeedback>
{
    public void Configure(EntityTypeBuilder<CustomerFeedback> builder)
    {
        builder.ToTable("CustomerFeedbacks");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Description).HasMaxLength(255);

        builder.HasOne(x => x.IdCategoryNavigation)
        .WithMany(x => x.Feedbacks)
        .HasForeignKey(d => d.IdCategory)
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK_CustomerFeedbacks_Category");

        builder.HasOne(x => x.IdProductNavigation)
        .WithMany(x => x.CustomerFeedbacks)
        .HasForeignKey(d => d.IdProduct)
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK_CustomerFeedbacks_Product");

        builder.HasOne(d => d.IdCustomerNavigation)
        .WithMany(p => p.CustomerFeedbacks)
        .HasForeignKey(d => d.IdCustomer)
        .HasConstraintName("FK_CustomerFeedbacks_Customer");

        builder.HasOne(d => d.IdUserNavigation)
        .WithMany(p => p.CustomerFeedbacks)
        .HasForeignKey(d => d.IdUser)
        .HasConstraintName("FK_CustomerFeedbacks_User");


        builder.HasOne(d => d.IdUserAddNavigation)
        .WithMany(p => p.CustomerFeedbacksAdded)
        .HasForeignKey(d => d.IdUserAdded)
        .HasConstraintName("FK_CustomerFeedbacks_User_Added");

        builder.HasOne(d => d.IdUserUpdateNavigation)
        .WithMany(p => p.CustomerFeedbacksUpdated)
        .HasForeignKey(d => d.IdUserUpdated)
        .HasConstraintName("FK_CustomerFeedbacks_User_Updated");
    }
}
