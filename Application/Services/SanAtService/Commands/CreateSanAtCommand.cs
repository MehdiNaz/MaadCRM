namespace Application.Services.SanAtService.Commands;

public class CreateSanAtCommand : IRequest<SanAt>
{
    public string SanAtName { get; set; }
    public string IdUser { get; set; }
}