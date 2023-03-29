namespace Domain.Models.IdentityModels;

public class UserRole : IdentityUserRole<string>
{
    public Role? Role { get; set; }
    public User? User { get; set; }
}