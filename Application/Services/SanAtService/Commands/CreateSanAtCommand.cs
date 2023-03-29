namespace Application.Services.SanAtService.Commands;

public struct CreateSanAtCommand : IRequest<SanAt>
{
    public string SanAtName { get; set; }
    public Ulid UserId { get; set; }
}