namespace Application.Services.BusinessService.Commands;

public struct ChangeStatusBusinessCommand : IRequest<Business>
{
    public Ulid BusinessId { get; set; }
    public Status BusinessStatus { get; set; }
}