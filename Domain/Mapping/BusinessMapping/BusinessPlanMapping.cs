namespace Domain.Mapping.BusinessMapping;

public class BusinessPlanMapping : IEntityTypeConfiguration<BusinessPlan>
{
    public void Configure(EntityTypeBuilder<BusinessPlan> builder)
    {
        builder.ToTable("BusinessPlans");
        builder.HasKey(x => x.Id);
    }
}
