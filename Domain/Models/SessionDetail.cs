using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enum;

namespace Domain.Models;

/// <summary>
/// Sessions Details List
/// </summary>
public class SessionDetail
{
    [Key]
    public Guid Id { get; set; }
    public required Guid IdSession { get; set; }
    public required Gender Sex { get; set; }
    public required string Age { get; set; }
    public required string Education { get; set; }
    public required string Address { get; set; }
    public required string AddressDuration { get; set; }
    public required string Salary { get; set; }
    public required string Vehicle { get; set; }
    public required string Reason { get; set; }
    public required string Companions { get; set; }
    public required string WidthLenght { get; set; }
    public required string WidthLenghtRate { get; set; }
    public required string WidthNature { get; set; }
    public required string WidthNatureRate { get; set; }
    public required string WidthCommercial { get; set; }
    public required string WidthCommercialRate { get; set; }
    public required string LenghtNature { get; set; }
    public required string LenghtNatureRate { get; set; }
    public required string LenghtCommercial { get; set; }
    public required string LenghtCommercialRate { get; set; }
    public required string NatureCommercial { get; set; }
    public required string NatureCommercialRate { get; set; }

    public required DateTime DateUpdated { get; set; }

    public DateTime DateCreated {get;set;}

    [ForeignKey("IdSession")]
    public Session? Session { get; init; }
}

