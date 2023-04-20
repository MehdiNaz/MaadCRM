namespace Domain.Mapping.Customers.PeyGiry;

public class CustomerPeyGiryMapping : IEntityTypeConfiguration<CustomerPeyGiry>
{
    public void Configure(EntityTypeBuilder<CustomerPeyGiry> builder)
    {
        builder.ToTable("CustomerPeyGiries");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Description).HasMaxLength(255).IsRequired();

        // builder.HasMany(x => x.PeyGiryAttachments).WithOne(x => x.CustomerPeyGiry).HasForeignKey(x => x.Id);
        // builder.HasOne(x => x.User).WithMany(x => x.CustomerPeyGiries).HasForeignKey(x => x.CreatedBy);
        // builder.HasOne(x => x.User).WithMany(x => x.CustomerPeyGiries).HasForeignKey(x => x.UpdatedBy);
    }
}
