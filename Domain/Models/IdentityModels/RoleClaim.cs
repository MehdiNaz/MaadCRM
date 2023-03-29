namespace Domain.Models.IdentityModels;

public class RoleClaim : IdentityRoleClaim<int>
{
    public string? RoleId { get; set; }
    public Role? Role { get; set; }
}