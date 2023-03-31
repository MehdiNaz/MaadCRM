namespace Domain.Models.Notes;

public class Tags : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Note_Tag_Mapping> Note_Tag_Mapping { get; set; }
}