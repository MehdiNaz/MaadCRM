namespace Application.Services.BusinessService.Commands;

public class DeleteBusinessCommand : IRequest<Business>
{
    public Ulid BusinessId { get; set; }
}