namespace FootballTeamSystem.Controllers
{
    using System;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper;

    using FootballTeamSystem.Data;
    using FootballTeamSystem.Data.Model;
    using FootballTeamSystem.ViewModels.Comment;
    using Infrastructure.Constants;

    public class CommentController : BaseController
    {
        public CommentController(IFootballSystemData data) : base(data)
        {
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostComment(PostCommentViewModel comment)
        {
            if (comment != null && ModelState.IsValid)
            {
                var dbComment = Mapper.Map<Comment>(comment);
                dbComment.Author = this.UserProfile;

                var currentPost = Data.Posts.GetById(comment.PostId);
                if (currentPost == null)
                {
                    throw new HttpException(404, "Post not found!");
                }

                currentPost.Comments.Add(dbComment);
                this.Data.SaveCanges();

                var viewModel = Mapper.Map<CommentViewModel>(dbComment);

                return RedirectToAction("Details", "Post", new { id = comment.PostId});
            }

            throw new HttpException(400, "Invalid comment!");
        }
    }
}