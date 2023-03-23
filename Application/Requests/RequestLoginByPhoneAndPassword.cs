namespace Application.Requests;

public struct RequestLoginByPhoneAndPassword
{
    //[Required(ErrorMessage = "لطفاً نام کاربری را وارد نمائید")]
    //[StringLength(11 , ErrorMessage = "لطفاً نام کاربری را به صورت یازده کاراکتری وارد نمائید", MinimumLength = 8)]
    public string? Phone { get; set; }
    
    //[Required(ErrorMessage = "لطفاً رمز عبور را وارد نمائید")]
    //[StringLength(20, ErrorMessage = "لطفاً رمز عبور را به صورت دقیق وارد نمائید", MinimumLength = 8)]
    public string Password { get; set; }
}
