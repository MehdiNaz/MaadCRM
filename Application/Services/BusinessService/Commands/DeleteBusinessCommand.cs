namespace Application.Services.BusinessService.Commands;

public struct DeleteBusinessCommand : IRequest<Business>
{
    public Ulid BusinessId { get; set; }
}