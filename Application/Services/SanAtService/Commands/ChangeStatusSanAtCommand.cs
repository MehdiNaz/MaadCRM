namespace Application.Services.SanAtService.Commands;

public struct ChangeStatusSanAtCommand : IRequest<SanAt?>
{
    public Ulid SanAtId { get; set; }
    public Status SanAtStatus { get; set; }
}