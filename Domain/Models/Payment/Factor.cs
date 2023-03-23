namespace Domain.Models;

public class Factor
{
    public Factor()
    {
        Orders = new HashSet<Order>();
    }

    public int Id { get; set; }
    public string IdUser { get; set; }
    public int? IdPaymenthMethod { get; set; }
    public byte Status { get; set; }
    public DateTime? DatePay { get; set; }
    public decimal? Amount { get; set; }
    public string Note { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? SendDate { get; set; }
    public int? SendTypeid { get; set; }
    public string RefNum { get; set; }
    public string BankMessage { get; set; }
    public DateTime DateCreated { get; set; }
    public byte[] Rowversion { get; set; }
    public int? AddressId { get; set; }
    public decimal? AmountPost { get; set; }
    public decimal? AmountTotal { get; set; }
    public string Description { get; set; }
    public string PostalCode { get; set; }
    public byte? Step { get; set; }
    public DateTime? DatePost { get; set; }



    public decimal? AmountReturned { get; set; }
    public string DarandeHesab { get; set; }
    public string ShomarePeygiri { get; set; }
    public DateTime? DateReturned { get; set; }


    public virtual PaymentMethod IdPaymenthMethodNavigation { get; set; }
    public virtual SendType SendType { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
}