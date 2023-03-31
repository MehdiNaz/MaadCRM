namespace Application.Responses;

public struct ResponseAccount
{
    public required bool Valid { get; set; }
    public string Token { get; set; }
    public required string Message { get; set; }
    public required int StatusCode { get; set; }
    public IList<string>? Errors { get; set; }
    public string? UserRole { get; set; }
}