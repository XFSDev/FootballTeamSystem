
namespace FootballTeamSystem.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;

    using FootballTeamSystem.Data;
    using FootballTeamSystem.Data.Model;

    public class BaseController : Controller
    {
      protected IFootballSystemData Data { get; private set; }

        protected User UserProfile { get; private set; }

        public BaseController(IFootballSystemData data)
        {
            this.Data = data;
        }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.UserProfile = this.Data.Users.All.FirstOrDefault(u => u.UserName == requestContext.HttpContext.User.Identity.Name);

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}