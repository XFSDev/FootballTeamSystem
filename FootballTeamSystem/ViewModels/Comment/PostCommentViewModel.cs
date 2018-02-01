namespace FootballTeamSystem.ViewModels.Comment
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using FootballTeamSystem.Data.Model;
    using FootballTeamSystem.Infrastructure.Mapping;
    public class PostCommentViewModel : IMapFrom<Comment>
    {
        public PostCommentViewModel()
        {
            
        }

        public PostCommentViewModel(Guid postId)
        {
            this.PostId = postId;
        }

        public Guid PostId { get; set; }

        [Required]
        [StringLength(1000)]
        public string Content { get; set; }
    }
}