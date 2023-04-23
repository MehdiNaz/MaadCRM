namespace Domain.Mapping.Customers.Note;

public class CustomerNoteMapping : IEntityTypeConfiguration<CustomerNote>
{
    public void Configure(EntityTypeBuilder<CustomerNote> builder)
    {
        builder.ToTable("CustomerNotes");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Description);

        builder.Property(e => e.Version)
            .IsRowVersion();

        builder.HasOne(x => x.IdCustomerNavigation)
            .WithMany(x => x.CustomerNotes)
            .HasForeignKey(x => x.IdCustomer)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_CustomerNote_Customers");

        builder.HasOne(x => x.IdProductNavigation)
            .WithMany(x => x.CustomerNotes)
            .HasForeignKey(x => x.IdProduct)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_CustomerNote_Product");

        builder.HasOne(x => x.IdUserUpdateNavigation)
            .WithMany(x => x.CustomerNotesAdded)
            .HasForeignKey(d => d.IdUserAdded)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Add_CustomerNote_User");

        builder.HasOne(x => x.IdUserAddNavigation)
            .WithMany(x => x.CustomerNotesUpdated)
            .HasForeignKey(d => d.IdUserAdded)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Add_CustomerNote_User");
    }
}