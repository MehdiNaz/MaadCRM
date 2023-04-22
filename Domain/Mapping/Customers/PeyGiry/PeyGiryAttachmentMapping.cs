namespace Domain.Mapping.Customers.PeyGiry;

public class PeyGiryAttachmentMapping : IEntityTypeConfiguration<PeyGiryAttachment>
{
    public void Configure(EntityTypeBuilder<PeyGiryAttachment> builder)
    {
        builder.ToTable("PeyGiryAttachments");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Extenstion).HasMaxLength(255).IsRequired();
        
        builder.Property(e => e.Version)
            .IsRowVersion();
        
        builder.HasOne(x => x.IdCustomerPeyGiryNavigation)
            .WithMany(x => x.PeyGiryAttachments)
            .HasForeignKey(x => x.IdPeyGiry)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_PeyGiryAttachment_PeyGiry");

    }
}