namespace Domain.Models;

public class BaseEntityWithOptionalUserId : BaseEntityWithUserUpdate
{
    public string? IdUser { get; set; }
    public User? IdUserNavigation { get; set; }
}