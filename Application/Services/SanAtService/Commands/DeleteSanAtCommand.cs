namespace Application.Services.SanAtService.Commands;

public struct DeleteSanAtCommand : IRequest<SanAt>
{
    public Ulid SanAtId { get; set; }
}