namespace Domain.Models.General;

public class Country:BaseEntity
{
    public string Name { get; set; }
    public bool IsDefault { get; set; }
    public int DisplayOrder { get; set; }
    public ICollection<Province> Provinces { get; set; } 
}