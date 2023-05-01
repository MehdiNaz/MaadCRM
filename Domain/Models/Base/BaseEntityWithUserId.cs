namespace Domain.Models.Base;

public class BaseEntityWithUserUpdate : BaseEntity
{
    public string IdUserUpdated { get; set; }
    public virtual User IdUserUpdateNavigation { get; set; }

    public string IdUserAdded { get; set; }
    public virtual User IdUserAddNavigation { get; set; }
}