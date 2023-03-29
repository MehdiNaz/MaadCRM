namespace Application.Services.SanAtService.Queries;

public struct GetByIdSanAtQuery : IRequest<SanAt>
{
    public Ulid SanAtId { get; set; }
}