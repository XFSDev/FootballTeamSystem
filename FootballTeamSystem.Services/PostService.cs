namespace FootballTeamSystem.Services
{
    using System;
    using System.Linq;
    using System.Web;

    using Contracts;
    using Common;
    using Data;
    using Data.Model;
    using Microsoft.AspNet.Identity;

    public class PostService : IPostService
    {
        protected IFootballSystemData Data { get; private set; }

        public PostService(IFootballSystemData data)
        {
            this.Data = data;
        }

        public void AddPost(Post post, HttpPostedFileBase postImage)
        {

            post.AuthorId = HttpContext.Current.User.Identity.GetUserId();
            UpdatePostImage(post, postImage);
            UpdatePostDescription(post);

            this.Data.Posts.Add(post);
            this.Data.SaveCanges();

        }

        public void UpdatePost(Post post, HttpPostedFileBase postImage)
        {
            UpdatePostImage(post, postImage);
            UpdatePostDescription(post);

            this.Data.Posts.Update(post);
            this.Data.SaveCanges();
        }

        public bool DeletePost(Guid id)
        {
            try
            {
                var post = Data.Posts.GetById(id);

                if (post == null)
                {
                    return false;
                }

                this.Data.Posts.Delete(post);
                this.Data.SaveCanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Post GetPostById(Guid postId)
        {
            return this.Data.Posts.GetById(postId);
        }

        private static void UpdatePostImage(Post post, HttpPostedFileBase postImage)
        {
            var allowedContentTypes = new[] { "image/jpeg", "image/png", "image/jpg" };
            if (postImage != null && allowedContentTypes.Contains(postImage.ContentType))
            {
                var postsImagesDir = "/Content/Uploads/Posts/";
                string uploadPath = ServiceHelper.SaveImageToFileSystemAndReturnPath(postImage, postsImagesDir);

                post.ImagePath = uploadPath;
            }
            else
            {
                if (post.ImagePath == null)
                {
                    var defaultPostImage = "/Content/Images/footballTeamSystem-noPostImage.jpg";
                    post.ImagePath = defaultPostImage;
                }
            }

        }

       

        private static void UpdatePostDescription(Post post)
        {
            post.Description = post.Content.Length <= 500 ? post.Content : post.Content.Substring(0, 500);
        }

        public IQueryable<Post> GetFeaturedPosts()
        {
            return this.Data.Posts
                .All
                .Where(p => p.IsFeaturedPost)
                .OrderByDescending(o => o.CreatedOn);
        }

        public IQueryable<Post> GetPosts()
        {
            return this.Data.Posts
                .All
                .OrderByDescending(o => o.CreatedOn);
        }
    }
}
