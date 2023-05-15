namespace Application.Services.BusinessService.Commands;

public struct UpdateBusinessCommand : IRequest<Result<Business>>
{
    public Ulid BusinessId { get; set; }
    public string BusinessName { get; set; }
    public string Url { get; set; }
    public string Hosts { get; set; }
    public string CompanyName { get; set; }
    public string CompanyAddress { get; set; }
    //public bool SslEnabled { get; set; }
    public int DisplayOrder { get; set; }
    //public string? IdUser { get; set; }
}