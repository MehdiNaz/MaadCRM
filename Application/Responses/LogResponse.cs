namespace Application.Responses;

public struct LogResponse
{
    public Ulid Id { get; set; }
    public Ulid? IdPeyGiry { get; set; }
    public string PeyGiryDescription { get; set; }
    public Ulid? IdNote { get; set; }
    public string NoteDescription { get; set; }
    public Ulid? IdFeedBack { get; set; }
    public string? FeedBackDescription { get; set; }
    public Ulid? IdCustomer { get; set; }
    public string CustomerFullName { get; set; }
    public Ulid? IdProduct { get; set; }
    public string ProductName { get; set; }
    public Ulid? IdProductCategory { get; set; }
    public string ProductCategoryName { get; set; }
    public Ulid? IdForoosh { get; set; }
    public LogTypes Type { get; set; }
    public string IdUser { get; set; }
    public string UserFullName { get; set; }
    public string IpAddress { get; set; }
    public string UserAgent { get; set; }
    public string? Description { get; set; }
}