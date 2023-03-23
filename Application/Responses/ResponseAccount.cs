namespace Application.Responses;

public struct ResponseAccount
{
    public required bool Valid { get; set; }
    public required string Token { get; set; }
    public required string Message { get; set; }
    public required int StatusCode { get; set; }
    public List<string>? Errors { get; set; }
    public string? UserRole { get; set; }
}