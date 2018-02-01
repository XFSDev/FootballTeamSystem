namespace FootballTeamSystem.Data.Model
{
    using System.ComponentModel.DataAnnotations;

    using Abstraction;

    public class Comment : DataModel
    {
        [Required]
        [StringLength(1000)]
        public string Content { get; set; }

        public string AuthorId { get; set; }
        public virtual User Author { get; set; }

        public string PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
