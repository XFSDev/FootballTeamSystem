namespace FootballTeamSystem.ViewModels
{
    using System.Collections.Generic;
    using Post;

    public class HomeViewModel
    {
        public ListPostViewModel FeaturedPost { get; set; }
        public IList<ListPostViewModel> Posts { get; set; }
    }
}