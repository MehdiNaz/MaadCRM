namespace Domain.Mapping.Customers.Note;

public class NoteAttachmentMapping : IEntityTypeConfiguration<NoteAttachment>
{
    public void Configure(EntityTypeBuilder<NoteAttachment> builder)
    {
        builder.ToTable("NoteAttachments");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Extenstion).HasMaxLength(255).IsRequired();
    }
}