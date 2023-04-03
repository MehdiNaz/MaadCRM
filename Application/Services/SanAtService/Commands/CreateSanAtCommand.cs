namespace Application.Services.SanAtService.Commands;

public struct CreateSanAtCommand : IRequest<SanAt>
{
    public string SanAtName { get; set; }
    public string UserId { get; set; }
}