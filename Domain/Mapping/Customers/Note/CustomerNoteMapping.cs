namespace Domain.Mapping.Customers.Note;

public class CustomerNoteMapping : IEntityTypeConfiguration<CustomerNote>
{
    public void Configure(EntityTypeBuilder<CustomerNote> builder)
    {
        builder.ToTable("CustomerNotes");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Description);

        //builder.HasMany(x => x.CustomerHashTags).WithOne(x => x.CustomerNote).HasForeignKey(x => x.Id);
        //builder.HasMany(x => x.NoteAttachments).WithOne(x => x.CustomerNote).HasForeignKey(x => x.Id);

        // builder.HasOne(x => x.User).WithMany(x => x.CustomerNotes).HasForeignKey(x => x.CreatedBy);
        // builder.HasOne(x => x.User).WithMany(x => x.CustomerNotes).HasForeignKey(x => x.UpdatedBy);
    }
}