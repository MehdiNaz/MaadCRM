namespace Domain.Mapping.Customers.Foroosh;

public class PaymentMapping : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payments");
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.IdForooshFactorNavigation)
            .WithMany(x => x.Payments)
            .HasForeignKey(x => x.IdForooshFactor)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Payment_ForooshFactor");
    }
}