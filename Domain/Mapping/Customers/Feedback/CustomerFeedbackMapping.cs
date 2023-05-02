namespace Domain.Mapping.Customers.Feedback;

internal class CustomerFeedbackMapping : IEntityTypeConfiguration<CustomerFeedback>
{
    public void Configure(EntityTypeBuilder<CustomerFeedback> builder)
    {
        builder.ToTable("CustomerFeedbacks");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Description).HasMaxLength(255).IsRequired();

        builder.HasOne(x => x.Category)
        .WithMany(x => x.Feedbacks)
        .HasForeignKey(d => d.IdCategory)
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK_Category_CustomerFeedback");

        builder.HasOne(x => x.IdProductNavigation)
        .WithMany(x => x.CustomerFeedbacks)
        .HasForeignKey(d => d.IdProduct)
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK_Product_CustomerFeedback");
    }
}
