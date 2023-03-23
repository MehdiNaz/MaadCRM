using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enum;

namespace Domain.Models;

/// <summary>
/// Sessions
/// </summary>
public class Session
{
    [Key]
    public Guid Id { get; set; }
    public required string IdUser { get; set; }
    public required string Lat1 { get; set; }
    public required string Long1 { get; set; }
    public required string Lat2 { get; set; }
    public required string Long2 { get; set; }
    public required string Title { get; set; }
    public required Status Status { get; set; }

    public required DateTime DateUpdated { get; set; }

    public DateTime DateCreated {get;set;}

    // [ForeignKey("IdUser")]
    // public ApplicationUser? User { get; init; }
}