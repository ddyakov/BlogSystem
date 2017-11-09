namespace BlogSystem.ViewModels.Manage
{
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;

    public class ManageLoginsVM
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }

        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }
}
