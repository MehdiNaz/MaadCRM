namespace Domain.Mapping.Customers.Foroosh;

public class ForooshOrderMapping : IEntityTypeConfiguration<ForooshOrder>
{
    public void Configure(EntityTypeBuilder<ForooshOrder> builder)
    {
        builder.ToTable("ForooshOrders");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Description).HasMaxLength(500);
        
        builder.Property(e => e.Version)
            .IsRowVersion();
        
        builder.HasOne(x => x.IdForooshFactorNavigation)
            .WithMany(x => x.ForooshOrders)
            .HasForeignKey(x => x.IdForooshFactor)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ForooshOrder_Customers");
        
        builder.HasOne(x => x.IdProductNavigation)
            .WithMany(x => x.ForooshOrders)
            .HasForeignKey(x => x.IdProduct)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ForooshOrder_Product");
    }
}