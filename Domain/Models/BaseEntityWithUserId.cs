namespace Domain.Models;

public class BaseEntityWithUserId : BaseEntityWithUpdateInfo
{
    public string UserId { get; set; }
    // public User User { get; set; }
}