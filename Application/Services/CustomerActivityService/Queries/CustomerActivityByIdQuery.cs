namespace Application.Services.CustomerActivityService.Queries;

public struct CustomerActivityByIdQuery : IRequest<CustomerActivity>
{
    public Ulid CustomerActivityId { get; set; }
}