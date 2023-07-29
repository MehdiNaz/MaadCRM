namespace Domain.Models.Businesses.Plans;

/// <summary>
/// .در صورت دمو بودن تعداد کاربران مهم نیست
/// .تعداد روز ها هم به صورت پانزده است
/// .قیمت هم به صورت صفر در نظر گرفته می شود
/// </summary>

public class Plan : BaseEntityWithUserUpdate
{
    public Plan()
    {
        Id = Ulid.NewUlid();
        Status = StatusType.Show;
        BusinessPlans = new HashSet<BusinessPlan>();
    }

    public Ulid Id { get; set; }
    public string Title { get; set; }
    public uint CountOfUsers { get; set; }
    public decimal PriceOfEachUsers { get; set; }
    public uint CountOfDay { get; set; }
    public decimal PriceOfEachDay { get; set; }

    public uint MaxUser { get; set; }
    public uint MinUser { get; set; }
    public StatusType Status { get; set; }
    
    public ICollection<BusinessPlan>? BusinessPlans { get; set; }
}
