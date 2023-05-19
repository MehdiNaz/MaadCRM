namespace Application.Responses;

public struct CustomerPeyGiryResponse
{
    public string Description { get; set; }
    public string CategoryName { get; set; }
    public DateTime DateCreated { get; set; }
    public Ulid IdCustomerPeyGiry { get; set; }
}