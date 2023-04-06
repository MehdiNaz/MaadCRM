namespace Domain.Mapping.Plans;

public class UsersPlansMapping : IEntityTypeConfiguration<UsersPlans>
{
    public void Configure(EntityTypeBuilder<UsersPlans> builder)
    {
        builder.ToTable("UsersPlans");
        builder.HasKey(x => x.UsersPlansId);

        builder.HasOne(x => x.User).WithMany(x => x.UsersPlans).HasForeignKey(x => x.UserId);
        builder.HasOne(x => x.Plan).WithMany(x => x.UsersPlans).HasForeignKey(x => x.PlanId);
    }
}