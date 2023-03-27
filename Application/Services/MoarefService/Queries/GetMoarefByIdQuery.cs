namespace Application.Services.MoarefService.Queries;

public class GetMoarefByIdQuery : IRequest<Moaref>
{
    public Ulid MoarefId { get; set; }
}