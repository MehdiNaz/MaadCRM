namespace Domain.Models.IdentityModels;

public class UserToken : IdentityUserToken<string>
{
    public User? User{ get; set; }
}