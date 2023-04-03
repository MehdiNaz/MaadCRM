namespace Application.Services.SanAtService.Commands;

public struct UpdateSanAtCommand : IRequest<SanAt>
{
    public Ulid SanAtId { get; set; }
    public string SanAtName { get; set; }
    public string UserId { get; set; }
}