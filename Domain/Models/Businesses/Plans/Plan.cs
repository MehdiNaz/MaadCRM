﻿namespace Domain.Models.Businesses.Plans;

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
        Id = Ulid.NewUlid();
        StatusPlan = Status.Show;
    }

    public Ulid Id { get; set; }
    public string PlanName { get; set; }
    public uint CountOfUsers { get; set; }
    public decimal PriceOfUsers { get; set; }
    public uint CountOfDay { get; set; }
    public decimal PriceOfDay { get; set; }
    public decimal? Discount { get; set; } 
    public decimal PriceFinal { get; set; }
    public Status StatusPlan { get; set; }
    
    public string UserId { get; set; }
    
    public ICollection<BusinessPlan>? UsersPlans { get; set; }  //Relation OK
}