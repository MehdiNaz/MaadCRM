using Domain.Models.IdentityModels;

namespace Application.Services.Profile.Command;

public class SetProfileCommand : IRequest<User?>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public DateTime BirthDatre { get; set; }
    public string? Email { get; set; }
    public string Address { get; set; }
    public string CodeMelli { get; set; }
    public GenderTypes Gender { get; set; }
    
    // public string ZamineFaaliat { get; set; }
    public Ulid CityId { get; set; }
}