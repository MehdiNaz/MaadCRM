namespace Application.Responses;

public struct CustomerFeedbackCategoryResponse
{
    public required Ulid Id { get; set; }
    public required string Name { get; set; }
    public FeedbackType TypeFeedback { get; set; }
    public bool PositiveNegative { get; set; }
    public Status CustomerFeedbackCategoryStatus { get; set; }
}
