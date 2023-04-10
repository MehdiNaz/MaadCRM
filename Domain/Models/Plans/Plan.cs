namespace Domain.Models.Plans;

/// <summary>
/// .این کلاس برای قسمت پلن ها ایجاده شده است
/// .در صورت دمو بودن تعداد کاربران مهم نیست
/// .تعداد روز ها هم به صورت پانزده است
/// .قیمت هم به صورت صفر در نظر گرفته می شود
/// </summary>

public class Plan : BaseEntity
{
    public Plan()
    {
        PlanId = Ulid.NewUlid();
        PlanStatus = Status.Show;
    }

    public Ulid PlanId { get; set; }
    public string PlanName { get; set; }
    public uint CountOfUsers { get; set; }
    public decimal PriceOfUsers { get; set; }
    public uint CountOfDay { get; set; }
    public decimal PriceOfDay { get; set; }
    public decimal? Discount { get; set; } //TODO: Hanooz Kar Dare In
    public decimal FinalPrice { get; set; }
    public string UserId { get; set; }
    public Status PlanStatus { get; set; }
    public ICollection<BusinessPlans>? UsersPlans { get; set; }  //Relation OK
}
