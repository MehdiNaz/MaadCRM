namespace Application.Services.SanAtService.Queries;

public class GetByIdSanAtQuery : IRequest<SanAt>
{
    public Ulid SanAtId { get; set; }
}