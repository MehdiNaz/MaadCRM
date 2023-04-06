namespace Domain.Models.Plans;

/// <summary>
/// .این کلاس برای قسمت پلن ها ایجاده شده است
/// .در صورت دمو بودن تعداد کاربران مهم نیست
/// .تعداد روز ها هم به صورت پانزده است
/// .قیمت هم به صورت صفر در نظر گرفته می شود
/// </summary>

public class Plan
{
    public Plan()
    {
        PlanId = Ulid.NewUlid();
        PlanStatus = Status.Show;
    }

    public Ulid PlanId { get; set; }
    public string PlanName { get; set; }
    public uint DayDurations { get; set; }
    public uint CountOfUsers { get; set; }
    public decimal Price { get; set; }
    public string Discount { get; set; }
    public decimal FinalPrice { get; set; }
    public Status PlanStatus { get; set; }
    public ICollection<UsersPlans> UsersPlans { get; set; }  //Relation OK
}
