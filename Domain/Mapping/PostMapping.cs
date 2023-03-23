namespace Domain.Mapping;

public class PostMapping : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Content).HasMaxLength(250);
    }
}