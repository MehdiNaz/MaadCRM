namespace Domain.Models;

public class SanAt : BaseEntity
{
    public Ulid Id { get; set; }
    public string SanAtName { get; set; }
    public string IdUser { get; set; }

    public ApplicationUser User { get; set; }
}