namespace Domain.Models.Notes;

public class Note_Tag_Mapping : BaseEntity
{
    public int TagId { get; set; }
    public int NoteId { get; set; }

    //public Tags Tag { get; set; }
    //public Note Note { get; set; }

    //public class Note_Tag_MappingConfiguration : IEntityTypeConfiguration<Note_Tag_Mapping>
    //{
    //    public void Configure(EntityTypeBuilder<Note_Tag_Mapping> builder)
    //    {
    //        builder.HasOne(p => p.Note).WithMany(c => c.Note_Tag_Mapping).HasForeignKey(p => p.NoteId);
    //        builder.HasOne(p => p.Tag).WithMany(c => c.Note_Tag_Mapping).HasForeignKey(p => p.TagId);
    //    }
    //}
}