namespace Application.Responses;

public struct CustomerFilterResponse
{
    public int FilterCount { get; set; }
    public ICollection<CustomerResponse> AllCustomersInfo { get; set; }
}
