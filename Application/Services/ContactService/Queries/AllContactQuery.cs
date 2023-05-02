namespace Application.Services.ContactService.Queries;

public struct AllContactQuery : IRequest<Result<ICollection<ContactsResponse>>>
{
    public string UserId { get; set; }
}