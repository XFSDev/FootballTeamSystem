namespace FootballTeamSystem.Controllers
{
    using System;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using FootballTeamSystem.Data;
    using FootballTeamSystem. Data.Model;
    using FootballTeamSystem.ViewModels;
    using FootballTeamSystem.Infrastructure.Constants;

    public class MatchController : BaseController
    {
        public MatchController(IFootballSystemData data) : base(data)
        {
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var matches = Data.Matches.All.ProjectTo<MatchViewModel>();

            return View(matches);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Create(MatchViewModel matchModel)
        {
            if (ModelState.IsValid)
            {
                var newMatch = Mapper.Map<Match>(matchModel);

                Data.Matches.Add(newMatch);
                Data.SaveCanges();

                return  this.RedirectToAction(c => c.Index());

            }

            return this.View(Views.Edit, matchModel);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var matchToEdit = Data.Matches.GetById(id);

            if (matchToEdit == null)
            {
                return HttpNotFound();
            }

            return this.View( Mapper.Map<MatchViewModel>(matchToEdit));
        }

        [HttpPost]
        public ActionResult Edit(MatchViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbMatch = Data.Matches.GetById(model.Id);

                if (dbMatch == null)
                {
                    return HttpNotFound();
                }

                var updatedMatch = Mapper.Map(model, dbMatch);

                Data.Matches.Update(updatedMatch);
                Data.SaveCanges();

                return RedirectToAction("Index");
            }


            return this.View(Views.Edit, model);
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            return null;
        }
    }
}