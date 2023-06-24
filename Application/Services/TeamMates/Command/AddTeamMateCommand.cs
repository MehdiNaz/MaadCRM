namespace Application.Services.TeamMates.Command;

public struct AddTeamMateCommand : IRequest<Result<bool>>
{
    public string IdUser { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public string PhoneNo { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Email { get; set; }
    public string Address { get; set; }
    public string CodeMelli { get; set; }
    public GenderTypes Gender { get; set; }
    public Ulid IdCity { get; set; }
    public Ulid IdGroup { get; set; }
}