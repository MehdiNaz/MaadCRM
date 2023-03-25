namespace Domain.Mapping;

public class NoteMapping : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder.ToTable("Notes");
        builder.HasKey(x => x.NoteId);
        builder.Property(x => x.TitleNote).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(500).IsRequired();


        builder.HasOne(x => x.Customer).WithMany(x => x.Notes).HasForeignKey(x => x.NoteId);
    }
}