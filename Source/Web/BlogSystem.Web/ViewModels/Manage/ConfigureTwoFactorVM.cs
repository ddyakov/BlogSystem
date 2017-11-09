namespace BlogSystem.Web.ViewModels.Manage
{
    using System.Web.Mvc;
    using System.Collections.Generic;

    public class ConfigureTwoFactorVM
    {
        public string SelectedProvider { get; set; }

        public ICollection<SelectListItem> Providers { get; set; }
    }
}
