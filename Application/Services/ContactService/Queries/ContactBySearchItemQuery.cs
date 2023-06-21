namespace Application.Services.ContactService.Queries;

public struct ContactBySearchItemQuery : IRequest<Result<ICollection<ContactsResponse>>>
{
    public string Q { get; set; }
    public string UserId { get; set; }
}
