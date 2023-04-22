namespace Domain.Mapping.Customers.Note;

public class NoteAttachmentMapping : IEntityTypeConfiguration<CustomerNoteAttachment>
{
    public void Configure(EntityTypeBuilder<CustomerNoteAttachment> builder)
    {
        builder.ToTable("NoteAttachments");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Extenstion).HasMaxLength(255).IsRequired();
        
        builder.Property(e => e.Version)
            .IsRowVersion();
        
        builder.HasOne(x => x.IdCustomerNoteNavigation)
            .WithMany(x => x.NoteAttachments)
            .HasForeignKey(x => x.IdCustomerNote)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_CustomerNoteAttachment_CustomerNote");
    }
}