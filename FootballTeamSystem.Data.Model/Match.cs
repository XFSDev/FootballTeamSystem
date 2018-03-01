namespace FootballTeamSystem.Data.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using FootballTeamSystem.Data.Model.Abstraction;

    public class Match : DataModel
    {
        [Required]
        public string HomeTeam { get; set; }

        [Required]
        public string AwayTeam { get; set; }

        public int HomeTeamScore  { get; set; }

        public int AwayTeamScore { get; set; }

        [Required]
        public DateTime MatchDate { get; set; }

        [Required]
        public MatchStatus MatchStatus { get; set; }
    }
}
