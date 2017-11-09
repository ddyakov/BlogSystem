namespace BlogSystem.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class ExternalLoginConfirmationVM
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
