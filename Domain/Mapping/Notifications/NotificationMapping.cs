namespace Domain.Mapping.Notifications;

public class NotificationMapping : IEntityTypeConfiguration<Notif>
{
    public void Configure(EntityTypeBuilder<Notif> builder)
    {
        builder.ToTable("Notifications");
        builder.HasKey(x => x.Id);
        

        builder.Property(e => e.Version).IsRowVersion();

        builder.HasOne(x => x.IdPeyGiryNavigation)
            .WithMany(x => x.Notifications)
            .HasForeignKey(x => x.IdPeyGiry)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Notifications_CustomerPeyGiry");
        
        builder.HasOne(x => x.IdUserNavigation)
            .WithMany(x => x.Notifications)
            .HasForeignKey(d => d.IdUser)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Notifications_User");

        builder.HasOne(x => x.IdUserUpdateNavigation)
            .WithMany(x => x.NotificationUpdated)
            .HasForeignKey(d => d.IdUserUpdated)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Update_Notifications_User");

        builder.HasOne(x => x.IdUserAddNavigation)
            .WithMany(x => x.NotificationAdded)
            .HasForeignKey(d => d.IdUserAdded)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Add_Notifications_User");
    }
}
