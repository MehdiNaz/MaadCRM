namespace Application.Responses;

public struct CustomerDashboardResponse
{
    public int BelghovehCount { get; set; }
    public int BelFelCount { get; set; }
    public int RazyCount { get; set; }
    public int NaRazyCount { get; set; }
    public int DarHalePeyGiryCount { get; set; }
    public int VafadarCount { get; set; }
    public int AllCount { get; set; }
    public ICollection<CustomerResponse> AllCustomersInfo { get; set; }
}
