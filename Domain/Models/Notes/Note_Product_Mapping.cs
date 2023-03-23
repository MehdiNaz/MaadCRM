using Domain.Models.Products;

namespace Domain.Models.Notes;

public class Note_Product_Mapping : BaseEntity
{
    public int ProductId { get; set; }
    public int NoteId { get; set; }

    public Product Product { get; set; }
    public Note Note { get; set; }

    public class Note_Product_MappingConfiguration : IEntityTypeConfiguration<Note_Product_Mapping>
    {
        public void Configure(EntityTypeBuilder<Note_Product_Mapping> builder)
        {
            builder.HasOne(p => p.Product).WithMany(c => c.Note_Product_Mapping).HasForeignKey(p => p.ProductId);
            builder.HasOne(p => p.Note).WithMany(c => c.Note_Product_Mapping).HasForeignKey(p => p.NoteId);
        }
    }
}