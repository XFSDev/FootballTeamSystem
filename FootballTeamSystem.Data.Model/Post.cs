namespace FootballTeamSystem.Data.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    using Microsoft.AspNet.Identity;

    using FootballTeamSystem.Data.Model.Abstraction;

    public class Post : DataModel
    {
        public Post()
        {
            this.AuthorId = HttpContext.Current.User.Identity.GetUserId();
        }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string Description { get; set; }

        public virtual User Author { get; set; }

        [ForeignKey("Author")]
        public string AuthorId { get; set; }


        public bool IsFeaturedPost { get; set; }


        public string ImagePath { get; set; }
    }
}
