using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using FootballTeamSystem.Data.Contracts;
using FootballTeamSystem.Data.Model;

namespace FootballTeamSystem.Data.Repositories
{
    public class PostRepository : EfRepository<Post>, IPostRepository
    {
        public PostRepository(IMsSqlDbContext context) : base(context)
        {
        }

        public override void Add(Post post)
        {
            post.AddDescription();
            post.AddAuthor();

            base.Add(post);
        }

        public void Add(Post post, HttpPostedFileBase image)
        {
            post.AddDescription();
            post.AddAuthor();
            post.AddImage(image);

            base.Add(post);
        }

        public void Update(Post post, HttpPostedFileBase image)
        {
            post.AddDescription();
            post.AddImage(image);
            post.AddAuthor();

            base.Update(post);
        }

        public Post GetPost(Guid id)
        {
            return Context.Posts.SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return Context.Posts.Include(a => a.Author).Where(p => p.IsDeleted == false).ToList();
        }
    }
}
