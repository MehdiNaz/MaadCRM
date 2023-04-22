namespace Domain.Mapping.Customers.PeyGiry;

public class CustomerPeyGiryMapping : IEntityTypeConfiguration<CustomerPeyGiry>
{
    public void Configure(EntityTypeBuilder<CustomerPeyGiry> builder)
    {
        builder.ToTable("CustomerPeyGiries");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Description).HasMaxLength(255).IsRequired();

        builder.Property(e => e.RowVersion)
            .IsRequired()
            .HasColumnName("rowversion")
            .IsRowVersion();
        
        builder.HasOne(x => x.IdCustomerNavigation)
            .WithMany(x => x.CustomerPeyGiries)
            .HasForeignKey(x => x.IdCustomer)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_CustomerPeyGiry_Customers");
    }
}
