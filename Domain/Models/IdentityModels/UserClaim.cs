namespace Domain.Models.IdentityModels;

public class UserClaim : IdentityUserClaim<int>
{
    public string? UserId { get; set; }

    public User? User { get; set; }
}
