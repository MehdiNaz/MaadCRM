namespace Application.Services.BusinessPlansService.Queries;

public struct ChangeStatusBusinessPlansQuery : IRequest<bool>
{
    public required Status Status { get; set; }
    public required Ulid BusinessPlansId { get; set; }
}
