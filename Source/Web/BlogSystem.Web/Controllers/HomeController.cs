namespace BlogSystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using AutoMapper;
    using Data.Services.Contracts;
    using ViewModels.Comment;

    public class HomeController : Controller
    {
        private ICommentsService commentsService;

        public HomeController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        public ActionResult Index()
        {
            var model = this.commentsService.GetAllComments();
            var vms = Mapper.Map<List<CommentVM>>(model);

            return View(vms);
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