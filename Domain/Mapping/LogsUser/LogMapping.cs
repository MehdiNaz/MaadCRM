namespace Domain.Mapping.LogsUser;

public class LogMapping : IEntityTypeConfiguration<Log>
{
    public void Configure(EntityTypeBuilder<Log> builder)
    {
        builder.ToTable("Logs");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.UserId).HasMaxLength(255).IsRequired();
        builder.Property(x => x.IpAddress).HasMaxLength(255).IsRequired();
        builder.Property(x => x.UserAgent).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(255);

        builder.HasOne(x => x.PeyGiry)
            .WithMany(x => x.Logs)
            .HasForeignKey(x => x.PeyGiryId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_PeyGiry_Log");

        builder.HasOne(x => x.Note)
            .WithMany(x => x.Logs)
            .HasForeignKey(x => x.NoteId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Note_Log");

        builder.HasOne(x => x.Feedback)
            .WithMany(x => x.Logs)
            .HasForeignKey(x => x.FeedBackId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Feedback_Log");

        builder.HasOne(x => x.Customer)
            .WithMany(x => x.Logs)
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Customer_Log");

        builder.HasOne(x => x.Product)
            .WithMany(x => x.Logs)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Product_Log");

        builder.HasOne(x => x.ProductCategory)
            .WithMany(x => x.Logs)
            .HasForeignKey(x => x.ProductCategoryId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ProductCategory_Log");

        builder.HasOne(x => x.ForooshFactor)
            .WithMany(x => x.Logs)
            .HasForeignKey(x => x.ForooshId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ForooshFactor_Log");

        builder.HasOne(x => x.User)
            .WithMany(x => x.Logs)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Profile_Log");
    }
}