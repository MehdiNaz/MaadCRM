namespace Application.Services.CustomerService.Query;

public struct DarHalePeyGiryCustomersCountQuery : IRequest<Result<int>>
{
    public string UserId { get; set; }
}
