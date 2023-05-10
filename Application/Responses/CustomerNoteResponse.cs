namespace Application.Responses;

public struct CustomerNoteResponse
{
    public Ulid Id { get; set; }
    public string Description { get; set; }
    public StatusType CustomerNoteStatusType { get; set; }
    public Ulid? IdProduct { get; set; }
    public Ulid IdCustomer { get; set; }
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
}