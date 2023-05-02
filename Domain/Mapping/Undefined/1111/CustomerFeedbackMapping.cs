
namespace Domain.Mapping.Customers;

public class CustomerFeedbackMapping : IEntityTypeConfiguration<CustomerFeedback>
{
    public void Configure(EntityTypeBuilder<CustomerFeedback> builder)
    {
        builder.ToTable("CustomerFeedbacks");
        builder.HasKey(x => x.Id);
    }
}