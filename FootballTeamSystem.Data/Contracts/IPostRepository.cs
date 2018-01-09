using System;
using System.Collections.Generic;
using System.Web;
using FootballTeamSystem.Data.Model;

namespace FootballTeamSystem.Data.Contracts
{
    public interface IPostRepository : IEfRepository<Post>
    {
        void Add(Post post, HttpPostedFileBase image);
        void Update(Post post, HttpPostedFileBase image);
        Post GetPost(Guid id);
        IEnumerable<Post> GetAllPosts();
    }
}
