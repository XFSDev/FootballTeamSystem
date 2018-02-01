namespace FootballTeamSystem.Data.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    using Microsoft.AspNet.Identity;

    using FootballTeamSystem.Data.Model.Abstraction;

    public class Post : DataModel
    {
        private ICollection<Comment> comments;

        public Post()
        {
            this.comments = new HashSet<Comment>();
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

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
