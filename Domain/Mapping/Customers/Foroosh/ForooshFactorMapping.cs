namespace Domain.Mapping.Customers.Foroosh;

public class ForooshFactorMapping : IEntityTypeConfiguration<ForooshFactor>
{
    public void Configure(EntityTypeBuilder<ForooshFactor> builder)
    {
        builder.ToTable("ForooshFactors");
        builder.HasKey(x => x.Id);
        
        builder.Property(e => e.RowVersion)
            .IsRequired()
            .HasColumnName("rowversion")
            .IsRowVersion();
        
        builder.HasOne(x => x.IdCustomerNavigation)
            .WithMany(x => x.ForooshFactors)
            .HasForeignKey(x => x.IdCustomer)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ForooshFactor_Customers");
        
        builder.HasOne(x => x.IdCustomerAddressNavigation)
            .WithMany(x => x.ForooshFactors)
            .HasForeignKey(x => x.IdCustomerAddress)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ForooshFactor_CustomerAddress");
    }
}