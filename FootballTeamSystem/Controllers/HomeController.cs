namespace FootballTeamSystem.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using FootballTeamSystem.Data;
    using ViewModels;
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
           

            var featuredPost = Data.Posts
                .All
                .Where(f => f.IsFeaturedPost)
                .OrderByDescending(d => d.CreatedOn)
                .ProjectTo<ListPostViewModel>()
                .First();

            var posts = Data.Posts.All
                .OrderByDescending(p => p.CreatedOn)
                .ProjectTo<ListPostViewModel>()
                .ToList();

            var viewModel = new HomeViewModel
            {
                FeaturedPost = featuredPost,
                Posts = posts
            };

            return this.View(viewModel);
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