namespace Domain.Mapping.Customers.PeyGiry;

public class PeyGiryAttachmentMapping : IEntityTypeConfiguration<PeyGiryAttachment>
{
    public void Configure(EntityTypeBuilder<PeyGiryAttachment> builder)
    {
        builder.ToTable("PeyGiryAttachments");
        builder.HasKey(x => x.PeyGiryAttachmentId);
        builder.Property(x => x.Extenstion).HasMaxLength(255).IsRequired();
    }
}