namespace Domain.Models.Base;

public class BaseEntityWithUserId : BaseEntityWithUserUpdate
{
    public string IdUser { get; set; }
    public User IdUserNavigation { get; set; }
}