namespace Domain.Models;

public class BaseEntityWithUpdateInfo : BaseEntity
{
    public string CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }

    public User CreatorUser { get; set; }
    public User? UpdaterUser { get; set; }
}