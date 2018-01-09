using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using FootballTeamSystem.Data;
using FootballTeamSystem.Data.Model;
using FootballTeamSystem.Models;

namespace FootballTeamSystem.Controllers
{

    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IData _data;

        public HomeController(IData data)
        {
            this._data = data;
        }
        public ActionResult Index()
        {
            var posts = _data.Posts.GetAllPosts().Select(Mapper.Map<Post, PostViewModel>);

            return this.View(posts);
        }


        [Authorize(Roles = "CanManagePosts")]
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