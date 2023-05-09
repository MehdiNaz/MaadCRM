namespace Application.Services.SanAtService.Commands;

public struct ChangeStatusSanAtCommand : IRequest<SanAt?>
{
    public Ulid Id { get; set; }
    public StatusType SanAtStatusType { get; set; }
}