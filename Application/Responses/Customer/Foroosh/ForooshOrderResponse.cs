namespace Application.Responses;

public sealed class ForooshOrderResponse 
{
    public Ulid Id { get; set; }
    public decimal Price { get; set; }
    public decimal PriceTotal { get; set; }
    public uint Tedad { get; set; }
    public decimal PriceDiscount { get; set; } // تخفیف بخش فروش
    public decimal PriceShipping { get; set; }
    public StatusType StatusTypeForooshOrder { get; set; }
    public Ulid IdProduct { get; set; }
    public string ProductName { get; set; }
}