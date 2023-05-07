namespace Domain.Mapping.Customers.Foroosh;

public class ForooshOrderMapping : IEntityTypeConfiguration<ForooshOrder>
{
    public void Configure(EntityTypeBuilder<ForooshOrder> builder)
    {
        builder.ToTable("ForooshOrders");
        builder.HasKey(x => x.Id);

        builder.Property(e => e.Version)
            .IsRowVersion();

        builder.HasOne(x => x.IdProductNavigation)
            .WithMany(x => x.ForooshOrders)
            .HasForeignKey(x => x.IdProduct)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ForooshOrder_Product");

        builder.HasOne(x => x.IdForooshFactorNavigation)
            .WithMany(x => x.ForooshOrders)
            .HasForeignKey(x => x.IdForooshFactor)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ForooshFactor_ForooshOrder");

        builder.HasOne(x => x.IdUserAddNavigation)
            .WithMany(x => x.ForooshOrdersAdded)
            .HasForeignKey(d => d.IdUserAdded)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Add_ForooshOrder_User");

        builder.HasOne(x => x.IdUserUpdateNavigation)
            .WithMany(x => x.ForooshOrdersUpdated)
            .HasForeignKey(d => d.IdUserUpdated)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Update_ForooshOrder_User");
    }
}