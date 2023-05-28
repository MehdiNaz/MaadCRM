namespace Domain.Models.Base;

public class BaseEntityWithOptionalUserId : BaseEntityWithUserUpdate
{
    public string? IdUser { get; set; }
    public User? IdUserNavigation { get; set; }
}