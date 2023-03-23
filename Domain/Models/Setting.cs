namespace Domain.Models.General;

public class Setting: BaseEntity
{
    public string Name { get; set; }
    public string Value { get; set; }
    public int BusinessId { get; set; }
    public int DisplayOrder { get; set; } = 0;
    public Business Business{ get; set; }
}