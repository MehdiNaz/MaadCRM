namespace Domain.Mapping.Customers;

public class NoteAttachmentMapping : IEntityTypeConfiguration<NoteAttachment>
{
    public void Configure(EntityTypeBuilder<NoteAttachment> builder)
    {
        builder.ToTable("NoteAttachments");
        builder.HasKey(x => x.NoteAttachmentId);
        builder.Property(x => x.Extenstion).HasMaxLength(255).IsRequired();
    }
}