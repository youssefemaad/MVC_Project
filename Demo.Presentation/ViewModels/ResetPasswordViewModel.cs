namespace Demo.Presentation.ViewModels;

public class ResetPasswordViewModel
{
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "password Is Required.")]
    public string Password { get; set; }
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
}
