namespace FootballTeamSystem.Controllers
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Data;
    using Data.Model;
    using Infrastructure.Constants;
    using ViewModels;

    [Authorize(Roles = RoleName.CanManagePlayers)]
    public class PlayerController : BaseController
    {
        public PlayerController(IFootballSystemData footballSystemData)
            : base(footballSystemData)
        {
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
                //TODO: Make this to add image to player
                Data.Players.Add(Mapper.Map<PlayerViewModel,Player>(player));
                Data.SaveCanges();

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

                player.FullName = model.FullName;
                player.Birthdate = model.Birthdate;
                player.Position = model.Position;
                player.ShirtNumber = model.ShirtNumber;
                player.IsCaptain = model.IsCaptain;
                player.IsViceCaptain = model.IsViceCaptain;


               //TODO: Make this work! _footballSystemData.Players.Update(player, playerImage);
                Data.SaveCanges();

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