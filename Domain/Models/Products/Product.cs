using Domain.Models.Notes;

namespace Domain.Models.Products;

public class Product:BaseEntity
{
    public string Name { get; set; }
    public bool Published { get; set; }

    public ICollection<Note_Product_Mapping> Note_Product_Mapping { get; set; }
}