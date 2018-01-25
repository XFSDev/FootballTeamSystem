namespace FootballTeamSystem.Controllers
{
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using FootballTeamSystem.Data;
    using ViewModels.Post;

    [AllowAnonymous]
    public class HomeController : BaseController
    {
        public HomeController(IFootballSystemData footballSystemData)
            : base(footballSystemData)
        {
         
        }

        public ActionResult Index()
        {
            var posts = Data.Posts.All.ProjectTo<ListPostViewModel>();
            
            return this.View(posts);
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