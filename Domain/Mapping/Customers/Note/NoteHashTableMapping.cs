namespace Domain.Mapping.Customers.Note;

public class NoteHashTableMapping : IEntityTypeConfiguration<CustomerNoteHashTable>
{
    public void Configure(EntityTypeBuilder<CustomerNoteHashTable> builder)
    {
        builder.ToTable("NoteHashTables");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title).HasMaxLength(255).IsRequired();
        
        builder.Property(e => e.RowVersion)
            .IsRequired()
            .HasColumnName("rowversion")
            .IsRowVersion()
            .IsConcurrencyToken();
        
        builder.HasOne(x => x.IdBusinessNavigation)
            .WithMany(x => x.CustomerNoteHashTables)
            .HasForeignKey(x => x.IdBusiness)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_CustomersEmailAddress_Business");
    }
}