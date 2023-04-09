namespace Application.Services.BusinessService.Commands;

public class CreateBusinessCommand : IRequest<Business>
{
    public string BusinessName { get; set; }
    public string Url { get; set; }
    public string Hosts { get; set; }
    public string CompanyName { get; set; }
    public string CompanyAddress { get; set; }
    //public bool SslEnabled { get; set; }
    public int DisplayOrder { get; set; } = 0;
    //public string? UserId { get; set; }
}