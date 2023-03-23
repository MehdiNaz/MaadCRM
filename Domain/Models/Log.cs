using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enum;
using Domain.Identity;

namespace Domain.Models;

/// <summary>
/// History of a user's actions
/// </summary>
public class Log
{
    [Key]
    public Guid Id { get; set; }
    public required string IdUser { get; set; }
    public LogKinds Kind { get; set; }
    public DateTime DateCreated {get;set;}

    [ForeignKey("IdUser")]
    public ApplicationUser? User { get; init; }
}