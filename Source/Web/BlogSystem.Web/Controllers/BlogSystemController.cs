namespace BlogSystem.Web.Controllers
{
    using System.Web.Mvc;
    using Data.Services.Contracts;

    public class BlogSystemController : BaseController
    {public BlogSystemController(IUserService userService) : base(userService)
        {
        }

        // GET: BlogSystem
        public ActionResult Index()
        {
            return View();
        }
    }
}