namespace Domain.Mapping.Customers.PeyGiry;

public class PeyGiryAttachmentMapping : IEntityTypeConfiguration<PeyGiryAttachment>
{
    public void Configure(EntityTypeBuilder<PeyGiryAttachment> builder)
    {
        builder.ToTable("PeyGiryAttachments");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Extenstion).HasMaxLength(255).IsRequired();

        // builder.HasOne(x => x.User).WithMany(x => x.PeyGiryAttachments).HasForeignKey(x => x.CreatedBy);
        // builder.HasOne(x => x.User).WithMany(x => x.PeyGiryAttachments).HasForeignKey(x => x.UpdatedBy);
    }
}