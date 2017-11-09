namespace BlogSystem.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class ForgotPasswordVM
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
