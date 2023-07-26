namespace Domain.Mapping.Business.Pardakhts;

public class TakhfifMapping : IEntityTypeConfiguration<Takhfif>
{
    public void Configure(EntityTypeBuilder<Takhfif> builder)
    {
        builder.ToTable("Takhfif");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Status).IsRequired();
        
        builder.Property(e => e.Version).IsRowVersion();
        
        builder.HasOne(x => x.IdUserUpdateNavigation)
            .WithMany(x => x.TakhfifsUpdated)
            .HasForeignKey(d => d.IdUserUpdated)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Update_Takhfif_User");
        
        builder.HasOne(x => x.IdUserAddNavigation)
            .WithMany(x => x.TakhfifsAdded)
            .HasForeignKey(d => d.IdUserAdded)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Add_Takhfif_User");
    }
}