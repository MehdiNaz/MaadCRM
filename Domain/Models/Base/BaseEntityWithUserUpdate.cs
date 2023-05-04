namespace Domain.Models.Base;

public class BaseEntityWithUserUpdate : BaseEntity
{
    public string IdUserUpdated { get; set; }
    public User? IdUserUpdateNavigation { get; set; }

    public string IdUserAdded { get; set; }
    public User? IdUserAddNavigation { get; set; }
}