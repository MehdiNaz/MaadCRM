namespace Domain.Models.Payment;

public class Order:BaseEntity
{
    public int Id { get; set; }
    public int IdFactor { get; set; }
    public int IdPlan { get; set; }
    
    public decimal? Price { get; set; }
    public decimal? PriceFinal { get; set; }

    public string IpAddress { get; set; }

    public virtual Factor IdFactorNavigation { get; set; }
    public virtual Plan IdPlanNavigation { get; set; }
}