using Microsoft.AspNetCore.Identity;

namespace Domain.Models.Users;

public class User : IdentityUser<int>, IEntity<int>
{
    public User()
    {
        IsActive = true;
    }

    [StringLength(100)]
    public string FullName { get; set; }
    [StringLength(100)]
    public string FirstName { get; set; }
    [StringLength(100)]
    public string LastName { get; set; }
    public int? Age { get; set; }
    public GenderType Gender { get; set; }
    public bool IsActive { get; set; }
    public DateTime? BirthDayDateMilladi { get; set; }
    public string OtpPassword { get; set; }
    public DateTime OtpPasswordExpired { get; set; }
    public DateTimeOffset? LastLoginDate { get; set; }
    // public ICollection<Post1> Posts { get; set; }
    public ICollection<Business> Business { get; set; }
    public ICollection<CustomerSubmission> customerSubmissions { get; set; }
    public ICollection<ActivityLog> ActivityLogs { get; set; }
    public ICollection<Notification> Notifications { get; set; }

}

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(p => p.UserName).IsRequired().HasMaxLength(100);
    }
}

public enum GenderType
{
    [Display(Name = "مرد")]
    Male = 1,

    [Display(Name = "زن")]
    Female = 2
}