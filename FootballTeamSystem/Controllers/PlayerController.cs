using System.Web.Mvc;

namespace FootballTeamSystem.Controllers
{
    using System;
    using System.Linq;
    using System.Web;
    using AutoMapper;
    using Data;
    using Data.Model;
    using Models;

    public class PlayerController : Controller
    {
        private readonly IData _data;

        public PlayerController(IData data)
        {
            this._data = data;
        }

        [HttpGet]
        [Route("players")]
        public ActionResult Index()
        {
            var players = _data.Players.GetPlayers().Select(Mapper.Map<Player,PlayerViewModel>).ToList();

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
                _data.Players.Add(Mapper.Map<PlayerViewModel,Player>(player), playerImage);
                _data.SaveCanges();

                return RedirectToAction("Index");
            }

            return View("Add", player);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var playerToEdit = _data.Players.GetPlayer(id);

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
                var player = _data.Players.GetPlayer(model.Id);

                player.FullName = model.FullName;
                player.Birthdate = model.Birthdate;
                player.Position = model.Position;
                player.ShirtNumber = model.ShirtNumber;
                player.IsCaptain = model.IsCaptain;
                player.IsViceCaptain = model.IsViceCaptain;


                _data.Players.Update(player, playerImage);
                _data.SaveCanges();

                return RedirectToAction("Index");
            }

            return this.View("Edit", model);
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            var playerToDelete = _data.Players.GetPlayer(id);

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
            var playerToDelete = _data.Players.GetPlayer(model.Id);

            if (playerToDelete == null)
            {
                return HttpNotFound();
            }

            _data.Players.Delete(playerToDelete);
            _data.SaveCanges();

            return RedirectToAction("Index");
        }
    }
}