namespace Application.Services.SanAtService.Commands;

public class UpdateSanAtCommand : IRequest<SanAt>
{
    public Ulid SanAtId { get; set; }
    public string SanAtName { get; set; }
    public string IdUser { get; set; }
}