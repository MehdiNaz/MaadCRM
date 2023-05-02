namespace Domain.Mapping.Customers.Feedback;

public class CustomerFeedbackCategoryMapping : IEntityTypeConfiguration<CustomerFeedbackCategory>
{
    public void Configure(EntityTypeBuilder<CustomerFeedbackCategory> builder)
    {
        builder.ToTable("CustomerCategories");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(255).IsRequired();

        builder.Property(e => e.Version)
            .IsRowVersion();
        
        // builder.HasOne(x => x.IdUserNavigation)
        //     .WithMany(x => x.CustomerFeedbacks)
        //     .HasForeignKey(d => d.IdUser)
        //     .OnDelete(DeleteBehavior.ClientSetNull)
        //     .HasConstraintName("FK_Feedback_User");
        //
        // builder.HasOne(x => x.IdUserNavigation)
        //     .WithMany(x => x.CustomerFeedbacks)
        //     .HasForeignKey(d => d.IdUserAdded)
        //     .OnDelete(DeleteBehavior.ClientSetNull)
        //     .HasConstraintName("FK_Add_Feedback_User");
        //
        // builder.HasOne(x => x.IdUserNavigation)
        //     .WithMany(x => x.CustomerFeedbacks)
        //     .HasForeignKey(d => d.IdUserUpdated)
        //     .OnDelete(DeleteBehavior.ClientSetNull)
        //     .HasConstraintName("FK_Feedback_Customer_User");
    }
}