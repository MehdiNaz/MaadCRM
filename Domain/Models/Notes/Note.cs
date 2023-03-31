namespace Domain.Models.Notes;

public class Note : BaseEntity
{
    public Ulid NoteId { get; set; }
    public string TitleNote { get; set; }
    public string Description { get; set; }
    //public Ulid CustomerId { get; set; }
    


    //public Customer Customer { get; set; }
    public ICollection<Note_Tag_Mapping> Note_Tag_Mapping { get; set; }
    public ICollection<Note_Product_Mapping> Note_Product_Mapping { get; set; }
}