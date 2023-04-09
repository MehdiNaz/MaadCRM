namespace Application.Services.BusinessPlansService.Queries;

public class ChangeStatusBusinessPlansQuery : IRequest<bool>
{
    public required Status Status { get; set; }
    public required Ulid BusinessId { get; set; }
}
