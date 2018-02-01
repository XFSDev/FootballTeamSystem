namespace FootballTeamSystem.ViewModels.Post
{
    using System.Collections.Generic;
    using System.Linq;
    using Comment;

    public class IndexPostViewModel
    {
        public IEnumerable<SingleDetailsPostViewModel> Posts { get; set; }
        public IQueryable<IndexCommentViewModel> RecentComments { get; set; }
    }
}