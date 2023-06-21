namespace Domain.Models.IdentityModels;

public class UserGroup : BaseEntityWithUserUpdate
{
    public UserGroup()
    {
        Id = Ulid.NewUlid();
        Status = StatusType.Show;
        DisplayOrder = 0;
    }

    public Ulid Id { get; set; }
    public required string Title { get; set; }
    public int DisplayOrder { get; set; }
    public StatusType Status { get; set; }
    public required Ulid IdBusiness { get; set; }
    public virtual Business? IdBusinessNavigation { get; set; }
    public virtual ICollection<User>? Users { get; set; }
}