namespace Domain.Mapping.Plans;

public class UsersPlansMapping:IEntityTypeConfiguration<UsersPlans>
{
    public void Configure(EntityTypeBuilder<UsersPlans> builder)
    {
        builder.ToTable("UsersPlans");
        builder.HasKey(x => x.UsersPlansId);

    }
}