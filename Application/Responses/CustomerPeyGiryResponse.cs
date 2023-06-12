namespace Application.Responses;

public struct CustomerPeyGiryResponse
{
    public string? Description { get; set; }
    public DateTime DateCreated { get; set; }
    public Ulid IdCustomerPeyGiry { get; set; }
    
    public DateTime? DatePeyGiry { get; set; }

    public Ulid IdCustomer { get; set; }
    public string NameCustomer { get; set; }

    public Ulid IdPeyGiryCategory { get; set; }
    public string NamePeyGiryCategory { get; set; }

}