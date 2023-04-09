namespace Application.Services.BusinessService.Queries;

public class BusinessByIdQuery : IRequest<Business>
{
    public Ulid BusinessId { get; set; }
}