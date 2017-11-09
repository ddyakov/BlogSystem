namespace BlogSystem.ViewModels.Manage
{
    using System.ComponentModel.DataAnnotations;

    public class VerifyPhoneNumberVM
    {
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
