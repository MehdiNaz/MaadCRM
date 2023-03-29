namespace Domain.Models.IdentityModels;

public class UserLogin : IdentityUserLogin<string>
{
    public User? User { get; set; }
}