namespace Domain.Models.Users;

public class RolePattern: BaseEntity
{

    public string RolePatternName { get; set; }
    public string RolePatternDescription { get; set; }
    public ICollection<RolePatternDetails> rolePatternDetails { get; set; }
}