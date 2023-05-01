namespace Application.Services.ContactService.Queries;

public struct AllContactQuery : IRequest<Result<ICollection<Contact>>>
{
    public string UserId { get; set; }
}