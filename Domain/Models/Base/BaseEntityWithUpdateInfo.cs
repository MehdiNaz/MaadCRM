namespace Domain.Models;

public class BaseEntityWithUserId : BaseEntityWithUserUpdate
{
    public string IdUser { get; set; }
    public virtual User IdUserNavigation { get; set; }
}