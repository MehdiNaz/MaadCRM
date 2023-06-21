namespace Domain.Mapping.IdentityMapping;

public class UserGroupMapping : IEntityTypeConfiguration<UserGroup>
{
    public void Configure(EntityTypeBuilder<UserGroup> builder)

    {
        builder.ToTable("UserGroups");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Status).IsRequired();
        builder.Property(x => x.DisplayOrder).IsRequired();
        // builder.Property(x => x.DateCreated).IsRequired();
        // builder.Property(x => x.DateLastUpdate).IsRequired();
        builder.Property(x => x.IdBusiness).IsRequired();
        
        builder.Property(e => e.Version).IsRowVersion();
        
        builder.HasOne(x => x.IdBusinessNavigation)
            .WithMany(x => x.UserGroups)
            .HasForeignKey(x => x.IdBusiness)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_UserGroup_Business");
        
        builder.HasOne(d => d.IdUserAddNavigation)
            .WithMany(p => p.GroupAdded)
            .HasForeignKey(d => d.IdUserAdded)
            .HasConstraintName("FK_UserGroup_User_Added");
        
        builder.HasOne(d => d.IdUserUpdateNavigation)
            .WithMany(p => p.GroupUpdated)
            .HasForeignKey(d => d.IdUserUpdated)
            .HasConstraintName("FK_UserGroup_User_Updated");
    }
}