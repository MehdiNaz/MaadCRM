namespace Application.Responses;

public struct CustomerAttributeResponse
{
    public Ulid Id { get; set; }
    public StatusType Status { get; set; }
    public string AttributeOptionTitle { get; set; }
    public Ulid IdCustomer { get; set; }
    public string CustomerFirstName { get; set; }
    public string CustomerLastName { get; set; }
}