namespace Application.Responses;

public struct ErrorResponse
{
    public required bool Valid { get; set; }
    public Exception Exceptions { get; set; }
    // public string Message { get; set; }
    // public string StackTrace { get; set; }
}