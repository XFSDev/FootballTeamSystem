namespace FootballTeamSystem.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using FootballTeamSystem.Data;
    using FootballTeamSystem.ViewModels;
    using FootballTeamSystem.ViewModels.Post;

    [AllowAnonymous]
    public class HomeController : BaseController
    {
        public HomeController(IFootballSystemData footballSystemData)
            : base(footballSystemData)
        {

        }

        public ActionResult Index()
        {
           
            return this.View();
        }


        public ActionResult About()
        {
           //TODO: Implement Timespan graph

            return View();
        }

        public ActionResult Contact()
        {
            //TODO: Implement EmailSender()

            return View();
        }
    }
}