namespace FootballTeamSystem.Controllers
{
    using System;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using FootballTeamSystem.Data.Model;
    using FootballTeamSystem.ViewModels.Post;
    using FootballTeamSystem.Infrastructure.Constants;
    using FootballTeamSystem.Services.Contracts;

    [Authorize(Roles = RoleName.CanManagePosts)]
    public class PostController : Controller
    {

        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            this._postService = postService;
        }

        [Route("posts")]
        [AllowAnonymous]
        public ActionResult Index()
        {
            var posts = _postService.GetPosts().ProjectTo<ListPostViewModel>();

            return View(posts);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddPostViewModel post)
        {
            if (ModelState.IsValid)
            {
                _postService.AddPost(Mapper.Map<Post>(post), post.UploadedImage);

                return this.RedirectToAction(c => c.Index());
            }

            return View(Views.Create, post);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Details(Guid id)
        {
            var post = _postService.GetPostById(id);

            if (post == null)
            {
                return HttpNotFound();
            }


            return this.View(Mapper.Map<ListPostViewModel>(post));
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var post = _postService.GetPostById(id);

            if (post == null)
                return HttpNotFound();

            return this.View(Mapper.Map<EditPostViewModel>(post));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditPostViewModel model)
        {
            if (ModelState.IsValid)
            {
                var postToUpdate = _postService.GetPostById(model.Id);

                if (postToUpdate == null)
                {
                    return HttpNotFound();
                }

                postToUpdate.Title = model.Title;
                postToUpdate.Content = model.Content;
                postToUpdate.IsFeaturedPost = model.IsFeaturedPost;

                _postService.UpdatePost(postToUpdate, model.UploadedImage);

                return this.RedirectToAction(c => c.Index());
            }

            return this.View(Views.Edit, model);
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            var post = _postService.GetPostById(id);

            if (post == null)
            {
                return HttpNotFound();
            }

            return this.View(Mapper.Map<Post, DeletePostViewModel>(post));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DeletePostViewModel model)
        {
            var isDeleted = _postService.DeletePost(model.Id);

            if (isDeleted == false)
            {
                return HttpNotFound();
            }

            return this.RedirectToAction(c => c.Index());
        }
    }
}