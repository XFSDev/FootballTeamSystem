namespace FootballTeamSystem.Services.Contracts
{
    using System;
    using System.Linq;
    using System.Web;
    using Data.Model;

    public interface IPostService : IService
    {
        void AddPost(Post post, HttpPostedFileBase postImage);
        void UpdatePost(Post post, HttpPostedFileBase postImage);
        bool DeletePost(Guid id);
        Post GetPostById(Guid postId);
        IQueryable<Post> GetFeaturedPosts();
        IQueryable<Post> GetPosts();
    }
}
