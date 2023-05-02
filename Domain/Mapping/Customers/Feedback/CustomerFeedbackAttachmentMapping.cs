namespace Domain.Mapping.Customers.Feedback;

public class CustomerFeedbackAttachmentMapping : IEntityTypeConfiguration<CustomerFeedbackAttachment>
{
    public void Configure(EntityTypeBuilder<CustomerFeedbackAttachment> builder)
    {
        builder.ToTable("CustomerFeedbackAttachments");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Extenstion).HasMaxLength(255).IsRequired();

        builder.HasOne(x => x.IdCustomerFeedbackNavigation)
        .WithMany(x => x.Attachments)
        .HasForeignKey(d => d.IdCustomerFeedback)
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK_CustomerFeedback_CustomerFeedbackAttachment");
    }
}
