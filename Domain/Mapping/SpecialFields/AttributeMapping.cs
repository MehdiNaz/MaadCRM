namespace Domain.Mapping.SpecialFields;

public class AttributeMapping : IEntityTypeConfiguration<Attribute>
{
    public void Configure(EntityTypeBuilder<Attribute> builder)
    {
        builder.ToTable("Attributes");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Lable).HasMaxLength(255);
        builder.Property(x => x.ValidationFileAllowExtension).HasMaxLength(255).IsRequired();
        builder.Property(x => x.DefaultValue).HasMaxLength(255).IsRequired();

        builder.HasOne(x => x.IdBusinessNavigation)
            .WithMany(x => x.Attributes)
            .HasForeignKey(x => x.IdBusiness)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Attribute_Business");

        builder.HasOne(d => d.IdUserAddNavigation)
            .WithMany(p => p.AttributeAdded)
            .HasForeignKey(d => d.IdUserAdded)
            .HasConstraintName("FK_Attribute_User_Added");

        builder.HasOne(d => d.IdUserUpdateNavigation)
            .WithMany(p => p.AttributeUpdated)
            .HasForeignKey(d => d.IdUserUpdated)
            .HasConstraintName("FK_Attribute_User_Updated");
    }
}