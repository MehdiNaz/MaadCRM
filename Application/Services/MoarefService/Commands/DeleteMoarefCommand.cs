namespace Application.Services.MoarefService.Commands;

public struct DeleteMoarefCommand : IRequest<Moaref>
{
    public Ulid MoarefId { get; set; }
}