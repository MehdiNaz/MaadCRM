namespace Application.Responses;

public struct ContactsResponse
{
    public Ulid ContactId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Job { get; set; }
    public string MobileNumber { get; set; }
    public string EmailAddress { get; set; }
}
