namespace FootballTeamSystem.ViewModels
{
    using System.Collections.Generic;
    using Post;

    public class HomeViewModel
    {
        public IEnumerable<AddPostViewModel> Posts { get; set; }
    }
}