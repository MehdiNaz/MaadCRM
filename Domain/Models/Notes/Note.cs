namespace Domain.Models.Notes;

public class Note : BaseEntity
{
    public Ulid NoteId { get; set; }
    public string TitleNote { get; set; }
    public string Description { get; set; }
    public int CustomerId { get; set; }
    //[ForeignKey(nameof(CustomerId))]
    public Customer Customer { get; set; }
    public ICollection<Note_Tag_Mapping> Note_Tag_Mapping { get; set; }
    public ICollection<Note_Product_Mapping> Note_Product_Mapping { get; set; }

}