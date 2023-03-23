using System.ComponentModel.DataAnnotations;

namespace Application.Requests;

public struct RequestProfile
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Family { get; set; }

    [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "ایمیل صحیح نیست.")]
    public string Email { get; set; }

    public string Password { get; set; }

    public DateOnly DateBirthday { get; set; }
}