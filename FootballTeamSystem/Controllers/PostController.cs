using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using FootballTeamSystem.Data;
using FootballTeamSystem.Data.Model;
using FootballTeamSystem.Models;

namespace FootballTeamSystem.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly IData _data;

        public PostController(IData data)
        {
            this._data = data;
        }

        [Route("posts")]
        [AllowAnonymous]
        public ActionResult Index()
        {
            var posts = _data.Posts.GetAllPosts().Select(Mapper.Map<Post, PostViewModel>);

            return View(posts);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostViewModel model, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                var newPost = Mapper.Map<PostViewModel, Post>(model);


                _data.Posts.Add(newPost, image);
                _data.SaveCanges();

                return RedirectToAction("Index", "Post");
            }

            return View("Create", model);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Details(Guid id)
        {
            var post = _data.Posts.GetPost(id);

            if (post == null)
            {
                return HttpNotFound();
            }


            return this.View(Mapper.Map<Post, PostViewModel>(post));
        }

        [HttpGet]
        [Authorize(Roles = RoleName.CanManagePosts)]
        public ActionResult Edit(Guid id)
        {

            var post = _data.Posts.GetPost(id);

            if (post == null)
                return HttpNotFound();

            return this.View(Mapper.Map<Post, PostViewModel>(post));
        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Edit(PostViewModel model, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                var postToUpdate = _data.Posts.GetPost(model.Id);

                if (postToUpdate == null)
                {
                    return HttpNotFound();
                }


                postToUpdate.Title = model.Title;
                postToUpdate.Content = model.Content;
                postToUpdate.IsFeaturedPost = model.IsFeaturedPost;

                _data.Posts.Update(postToUpdate, image);
                _data.SaveCanges();

                return RedirectToAction("Index");
            }

            return this.View("Edit", model);
        }

        [HttpGet]
        [Authorize(Roles = RoleName.CanManagePosts)]
        public ActionResult Delete(Guid id)
        {
            var post = _data.Posts.GetPost(id);

            if (post == null)
                return HttpNotFound();

            return this.View(Mapper.Map<Post, PostViewModel>(post));
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManagePosts)]
        public ActionResult Delete(PostViewModel model)
        {
            var postForDelete = _data.Posts.GetPost(model.Id);

            if (postForDelete == null)
            {
                return HttpNotFound();
            }

            _data.Posts.Delete(postForDelete);
            _data.SaveCanges();

            return RedirectToAction("Index");
        }
    }
}