namespace Application.Requests;

// TODO: Add validation
public struct RequestVerifyPhone
{
    public string Phone { get; set; }
    public string Code { get; set; }
}