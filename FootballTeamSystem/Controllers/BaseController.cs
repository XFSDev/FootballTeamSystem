
namespace FootballTeamSystem.Controllers
{
    using System.Web.Mvc;
    using Data;

    public class BaseController : Controller
    {
      protected IFootballSystemData Data { get; private set; }

        public BaseController(IFootballSystemData data)
        {
            this.Data = data;
        }
    }
}