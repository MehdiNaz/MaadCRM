namespace Application.Services.MoarefService.Queries;

public struct GetMoarefByIdQuery : IRequest<Moaref>
{
    public Ulid MoarefId { get; set; }
}