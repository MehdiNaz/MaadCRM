using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Users;

public class RolePatternDetails: BaseEntity
{
    public int RolePatternID { get; set; }
    public int RoleID { get; set; }

    [ForeignKey(nameof(RolePatternID))]
    public virtual RolePattern RP { get; set; }
    [ForeignKey(nameof(RoleID))]
    public virtual Role Roles { get; set; }
}