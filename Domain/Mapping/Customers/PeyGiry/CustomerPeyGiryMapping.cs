namespace Domain.Mapping.Customers.PeyGiry;

public class CustomerPeyGiryMapping : IEntityTypeConfiguration<CustomerPeyGiry>
{
    public void Configure(EntityTypeBuilder<CustomerPeyGiry> builder)
    {
        builder.ToTable("CustomerPeyGiries");
        builder.HasKey(x => x.CustomerPeyGiryId);
        builder.Property(x => x.Description).HasMaxLength(255).IsRequired();

        builder.HasMany(x => x.PeyGiryAttachments).WithOne(x => x.CustomerPeyGiry).HasForeignKey(x => x.PeyGiryAttachmentId);
    }
}