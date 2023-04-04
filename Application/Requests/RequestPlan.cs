namespace Application.Requests;

public struct RequestPlan
{
    public required Ulid Id { get; set; }
    public required byte Days { get; set; } // 0 = unlimited
    public required byte KarbarCount { get; set; } // 0 = unlimited
}