namespace Domain.Models.IdentityModels;

public class Role : IdentityRole<string>
{
    public List<RoleClaim>? RoleClaims { get; set; }
    public List<UserRole>? UserRoles { get; set; }
}
