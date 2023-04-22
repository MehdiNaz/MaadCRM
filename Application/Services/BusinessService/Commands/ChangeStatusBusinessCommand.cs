namespace Application.Services.BusinessService.Commands;

public struct ChangeStatusBusinessCommand : IRequest<Result<Business>>
{
    public Ulid BusinessId { get; set; }
    public Status BusinessStatus { get; set; }
}