namespace BlogSystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using AutoMapper;
    using Data.Services.Contracts;
    using ViewModels.Category;
    using ViewModels.Comment;
    using ViewModels.User;

    public class HomeController : BaseController
    {
        public HomeController(IUserService userService) 
            : base (userService)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}