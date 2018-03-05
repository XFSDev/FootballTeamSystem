namespace FootballTeamSystem.Controllers
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using FootballTeamSystem.Data;
    using FootballTeamSystem.Data.Model;
    using FootballTeamSystem.ViewModels.Post;
    using FootballTeamSystem.Infrastructure.Constants;
    using FootballTeamSystem.Services.Contracts;
    using FootballTeamSystem.ViewModels.Comment;

    [Authorize(Roles = RoleName.CanManagePosts)]
    public class PostController : BaseController
    {
        private readonly IPostService postService;

        public PostController(IFootballSystemData data, IPostService postService) : base(data)
        {
            this.postService = postService;
        }

        [Route("posts")]
        [AllowAnonymous]
        public ActionResult Index()
        {
            var viewModel = new IndexPostViewModel
            {
                Posts = postService.GetPosts().ProjectTo<SingleDetailsPostViewModel>(),
                RecentComments = Data.Comments.All.OrderByDescending(c=> c.CreatedOn).Take(6).ProjectTo<IndexCommentViewModel>()
            };

            return View(viewModel);
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
                postService.AddPost(Mapper.Map<Post>(post), post.UploadedImage);

                return this.RedirectToAction(c => c.Index());
            }

            return View(Views.Create, post);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Details(Guid id)
        {
            var post = postService.GetPostById(id);

            if (post == null)
            {
                return HttpNotFound();
            }


            return this.View(Mapper.Map<SingleDetailsPostViewModel>(post));
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var post = postService.GetPostById(id);

            if (post == null)
            {
                return HttpNotFound();

            }

            return this.View(Mapper.Map<EditPostViewModel>(post));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditPostViewModel model)
        {
            if (ModelState.IsValid)
            {
                var postInDb = postService.GetPostById(model.Id);

                var postInDbImg = postInDb.ImagePath;

                if (postInDb == null)
                {
                    return HttpNotFound();
                }

                var updatedPost = Mapper.Map(model, postInDb);

                if (updatedPost.ImagePath == null && postInDb != null)
                {
                    updatedPost.ImagePath = postInDbImg;
                }

                postService.UpdatePost(updatedPost, model.UploadedImage);

                return this.RedirectToAction(c => c.Index());
            }

            return this.View(Views.Edit, model);
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            var post = postService.GetPostById(id);

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
            var isDeleted = postService.DeletePost(model.Id);

            if (isDeleted == false)
            {
                return HttpNotFound();
            }

            return this.RedirectToAction(c => c.Index());
        }
    }
}