namespace BlogSystem.Web.Controllers
{
    using System.Web.Mvc;
    using AutoMapper;
    using Data.Services.Contracts;
    using ViewModels.User;

    public class BaseController : Controller
    {
        private const string CURRENT_USER = "CurrentUser";
        private IUserService userService;
            
        public BaseController(IUserService userService)
        {
            this.userService = userService;
        }

        public UserVM CurrentUser
        {
            get
            {
                if (Session[CURRENT_USER] as UserVM != null)
                {
                    return Session[CURRENT_USER] as UserVM;
                }
                else if (this.userService != null)
                {
                    Session[CURRENT_USER] = Mapper.Map<UserVM>(this.userService.GetByEmail(User.Identity.Name));

                    return Session[CURRENT_USER] as UserVM;
                }

                return null;
            }
        }
    }
}