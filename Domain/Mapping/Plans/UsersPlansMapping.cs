namespace Domain.Mapping.Plans;

public class UsersPlansMapping : IEntityTypeConfiguration<BusinessPlan>
{
    public void Configure(EntityTypeBuilder<BusinessPlan> builder)
    {
        builder.ToTable("UsersPlans");
        builder.HasKey(x => x.Id);

        // builder.HasOne(x => x.Business).WithMany(x => x.BusinessPlans).HasForeignKey(x => x.Id);
        // builder.HasOne(x => x.Plan).WithMany(x => x.UsersPlans).HasForeignKey(x => x.Id);
    }
}