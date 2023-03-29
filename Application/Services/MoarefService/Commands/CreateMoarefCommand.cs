namespace Application.Services.MoarefService.Commands;

public struct CreateMoarefCommand : IRequest<Moaref>
{
    public string MoarefName { get; set; }
    public string MoarefFamily { get; set; }
    public string MoarefPhone { get; set; }
}