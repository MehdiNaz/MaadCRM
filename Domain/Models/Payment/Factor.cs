namespace Domain.Models.Payment;

public class Factor : BaseEntity
{
    public int Id { get; set; }
    public string IdUser { get; set; }
    public int? IdPaymenthMethod { get; set; }
    public byte Status { get; set; }
    public DateTime? DatePay { get; set; }
    public decimal? Amount { get; set; }
    public DateTime? OrderDate { get; set; }
    public string RefNum { get; set; }
    public string BankMessage { get; set; }
    public decimal? AmountPost { get; set; }
    public decimal? AmountTotal { get; set; }
    public string Description { get; set; }
    public byte? Step { get; set; }



    public decimal? AmountReturned { get; set; }
    public string DarandeHesab { get; set; }
    public string ShomarePeygiri { get; set; }
    public DateTime? DateReturned { get; set; }


    //public virtual PaymentMethod IdPaymenthMethodNavigation { get; set; }
    public virtual ICollection<Order>? Orders { get; set; }
}