namespace Domain.Mapping.Business.Pardakhts;

public class PardakhtTakhfifMapping : IEntityTypeConfiguration<PardakhtTakhfif>
{
    public void Configure(EntityTypeBuilder<PardakhtTakhfif> builder)
    {
        builder.ToTable("PardakhtTakhfif");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Status).IsRequired();
        
        builder.Property(e => e.Version).IsRowVersion();

        builder.HasOne(x => x.IdTakhfifNavigation)
            .WithMany(x => x.PardakhtTakhfifs)
            .HasForeignKey(d => d.IdTakhfif)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_PardakhtTakhfif_Takhfif");
        
        builder.HasOne(x => x.IdPardakhtNavigation)
            .WithMany(x => x.PardakhtTakhfifs)
            .HasForeignKey(d => d.IdPardakht)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_PardakhtTakhfif_Pardakht");
        
        builder.HasOne(x => x.IdUserUpdateNavigation)
            .WithMany(x => x.PardakhtTakhfifsUpdated)
            .HasForeignKey(d => d.IdUserUpdated)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Update_PardakhtTakhfif_User");
        
        builder.HasOne(x => x.IdUserAddNavigation)
            .WithMany(x => x.PardakhtTakhfifsAdded)
            .HasForeignKey(d => d.IdUserAdded)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Add_PardakhtTakhfif_User");
    }
}