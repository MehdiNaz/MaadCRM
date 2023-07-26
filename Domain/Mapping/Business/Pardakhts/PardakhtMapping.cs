namespace Domain.Mapping.Business.Pardakhts;

public class PardakhtMapping : IEntityTypeConfiguration<Pardakht>
{
    public void Configure(EntityTypeBuilder<Pardakht> builder)
    {
        builder.ToTable("Pardakht");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.PriceDiscount).IsRequired();
        builder.Property(x => x.PriceTotal).IsRequired();
        builder.Property(x => x.Status).IsRequired();
        
        
        builder.Property(e => e.Version).IsRowVersion();

        builder.HasOne(x => x.IdBusinessNavigation)
            .WithMany(x => x.Pardakhts)
            .HasForeignKey(d => d.IdBusiness)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Pardakht_Business");
        
        builder.HasOne(x => x.IdUserNavigation)
            .WithMany(x => x.Pardakhts)
            .HasForeignKey(d => d.IdUser)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Pardakht_User");
        
        builder.HasOne(x => x.IdUserUpdateNavigation)
            .WithMany(x => x.PardakhtsUpdated)
            .HasForeignKey(d => d.IdUserUpdated)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Update_Pardakht_User");
        
        builder.HasOne(x => x.IdUserAddNavigation)
            .WithMany(x => x.PardakhtsAdded)
            .HasForeignKey(d => d.IdUserAdded)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Add_Pardakht_User");
    }
}