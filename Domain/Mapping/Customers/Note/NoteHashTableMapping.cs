namespace Domain.Mapping.Customers.Note;

public class NoteHashTableMapping : IEntityTypeConfiguration<NoteHashTable>
{
    public void Configure(EntityTypeBuilder<NoteHashTable> builder)
    {
        builder.ToTable("NoteHashTables");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title).HasMaxLength(255).IsRequired();
    }
}