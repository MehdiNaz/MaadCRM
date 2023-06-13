namespace Application.Responses;

public struct CustomerFeedbackResponse
{
    public Ulid Id { get; set; }
    public string? Description { get; set; }
    public StatusType CustomerFeedbackStatusType { get; set; }
    public Ulid IdCategory { get; set; }
    public Ulid? IdProduct { get; set; }
    public Ulid? IdCustomer { get; set; }
    public string IdUserAdded { get; set; }
    public string IdUserUpdated { get; set; }
    public string UserFullName { get; set; }
    public string? IdUser { get; set; }
}