namespace Domain.Mapping.Customers.Note;

public class NoteHashTagMapping : IEntityTypeConfiguration<NoteHashTag>
{
    public void Configure(EntityTypeBuilder<NoteHashTag> builder)
    {
        builder.ToTable("NoteHashTags");
        builder.HasKey(x => x.Id);
        // builder.Property(x => x.Title).HasMaxLength(255).IsRequired();

        // builder.HasOne(x => x.User).WithMany(x => x.NoteHashTags).HasForeignKey(x => x.CreatedBy);
        // builder.HasOne(x => x.User).WithMany(x => x.NoteHashTags).HasForeignKey(x => x.UpdatedBy);
    }
}