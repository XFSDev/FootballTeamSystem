namespace FootballTeamSystem.Controllers
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using FootballTeamSystem.Data;
    using FootballTeamSystem.Data.Model;
    using FootballTeamSystem.Infrastructure.Constants;
    using FootballTeamSystem.ViewModels;
    using FootballTeamSystem.Services.Contracts;

    [Authorize(Roles = RoleName.CanManagePlayers)]
    public class PlayerController : BaseController
    {
        private readonly IPlayerService playerService;
        public PlayerController(IFootballSystemData footballSystemData, IPlayerService playerService)
            : base(footballSystemData)
        {
            this.playerService = playerService;
        }

        [HttpGet]
        [Route("players")]
        [AllowAnonymous]
        public ActionResult Index()
        {
            var players = Data.Players.All.ProjectTo<PlayerViewModel>();

            return View(players);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(PlayerViewModel player, HttpPostedFileBase playerImage)
        {
            if (ModelState.IsValid)
            {
                this.playerService.AddPlayer(Mapper.Map<PlayerViewModel,Player>(player),playerImage);

                return this.RedirectToAction(c => c.Index());
            }

            return View(Views.Add, player);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var playerToEdit = Data.Players.GetById(id);

            if (playerToEdit == null)
            {
                return HttpNotFound();
            }

            return this.View(Mapper.Map<PlayerViewModel>(playerToEdit));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PlayerViewModel model, HttpPostedFileBase playerImage)
        {
            if (ModelState.IsValid)
            {
                var player = Data.Players.GetById(model.Id);

                var updatedPlayer = Mapper.Map(model, player);


               playerService.UpdatePlayer(updatedPlayer, playerImage);

                return this.RedirectToAction(c => c.Index());
            }

            return this.View(Views.Edit, model);
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            var playerToDelete = Data.Players.GetById(id);

            if (playerToDelete == null)
            {
                return HttpNotFound();
            }

            return this.View(Mapper.Map<PlayerViewModel>(playerToDelete));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PlayerViewModel model)
        {
            var playerToDelete = Data.Players.GetById(model.Id);

            if (playerToDelete == null)
            {
                return HttpNotFound();
            }

             Data.Players.Delete(playerToDelete);
             Data.SaveCanges();

            return this.RedirectToAction(c => c.Index());
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Details(Guid id)
        {
            var player = Data.Players.GetById(id);

            if (player == null)
            {
                return HttpNotFound();
            }

            return this.View(Mapper.Map<PlayerViewModel>(player));
        }
    }
}