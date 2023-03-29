namespace Domain.Mapping;

public class LogMapping : IEntityTypeConfiguration<Log>
{
    public void Configure(EntityTypeBuilder<Log> builder)
    {
        builder.ToTable("Logs");
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.User).WithMany(x => x.Logs).HasForeignKey(x => x.UserId);
    }
}