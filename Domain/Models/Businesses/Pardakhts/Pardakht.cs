namespace Domain.Models.Businesses.Pardakhts;

public class Pardakht : BaseEntityWithUserId
{
    public Pardakht()
    {
        Id = Ulid.NewUlid();
        Status = StatusType.Show;
        PardakhtTakhfifs = new HashSet<PardakhtTakhfif>();
        BusinessPlans = new HashSet<BusinessPlan>();
    }

    public Ulid Id { get; set; }
    
    
    public decimal Price { get; set; }
    public decimal PriceDiscount { get; set; }
    public decimal PriceTotal { get; set; }
    public DateTime DatePay { get; set; }
    public PaymentMethodTypes PaymentMethod { get; set; }
    public string RefNum { get; set; }
    public string BankMessage { get; set; }
    public string Description { get; set; }
    
    
    public decimal? AmountReturned { get; set; }
    public string DarandeHesab { get; set; }
    public string ShomarePeygiri { get; set; }
    public DateTime? DateReturned { get; set; }
    public string DescriptionReturned { get; set; }
    public StatusType Status { get; set; }

    public Ulid IdBusiness { get; set; }
    public Business IdBusinessNavigation { get; set; }
    
    public ICollection<PardakhtTakhfif>? PardakhtTakhfifs { get; set; } 
    public ICollection<BusinessPlan>? BusinessPlans { get; set; } 

}