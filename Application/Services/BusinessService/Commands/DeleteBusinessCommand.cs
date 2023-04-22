namespace Application.Services.BusinessService.Commands;

public struct DeleteBusinessCommand : IRequest<Result<Business>>
{
    public Ulid BusinessId { get; set; }
}