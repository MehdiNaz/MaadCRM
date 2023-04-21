namespace Domain.Mapping.Customers.Note;

public class CustomerNoteMapping : IEntityTypeConfiguration<CustomerNote>
{
    public void Configure(EntityTypeBuilder<CustomerNote> builder)
    {
        builder.ToTable("CustomerNotes");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Description);

        builder.Property(e => e.RowVersion)
            .IsRequired()
            .HasColumnName("rowversion")
            .IsRowVersion()
            .IsConcurrencyToken();

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
    }
}