namespace Application.Requests;

public struct RequestLoginByMail
{
    [Required(ErrorMessage = "Enter Email")]
    [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
    public string Email { get; set; }

    [StringLength(20, ErrorMessage = "Password should been between {1} and {2}", MinimumLength = 8)]
    [Required(ErrorMessage = "Enter Password")]
    public string Password { get; set; }
}