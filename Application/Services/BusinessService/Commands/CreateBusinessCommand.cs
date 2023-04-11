namespace Application.Services.BusinessService.Commands;

public struct CreateBusinessCommand : IRequest<Business>
{

    public string BusinessName { get; set; }
    public string Url { get; set; }
    public string Hosts { get; set; }
    public string CompanyName { get; set; }
    public string CompanyAddress { get; set; }
    //public bool SslEnabled { get; set; }
    public int DisplayOrder { get; set; }
    //public string? UserId { get; set; }
}