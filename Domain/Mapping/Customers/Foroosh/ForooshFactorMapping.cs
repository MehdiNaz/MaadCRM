namespace Domain.Mapping.Customers.Foroosh;

public class ForooshFactorMapping : IEntityTypeConfiguration<ForooshFactor>
{
    public void Configure(EntityTypeBuilder<ForooshFactor> builder)
    {
        builder.ToTable("ForooshFactors");
        builder.HasKey(x => x.Id);

        builder.Property(e => e.Version)
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

        builder.HasOne(x => x.IdUserAddNavigation)
            .WithMany(x => x.ForooshFactorsAdded)
            .HasForeignKey(d => d.IdUserAdded)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Add_ForooshFactor_User");

        builder.HasOne(x => x.IdUserUpdateNavigation)
            .WithMany(x => x.ForooshFactorsUpdated)
            .HasForeignKey(d => d.IdUserUpdated)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Update_ForooshFactor_User");
    }
}