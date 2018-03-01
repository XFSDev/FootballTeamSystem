namespace FootballTeamSystem.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using FootballTeamSystem.Data.Model;
    using  FootballTeamSystem.Infrastructure.Mapping;

    public class MatchViewModel : IMapFrom<Match>, IHaveCustomMappings
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Home Team")]
        public string HomeTeam { get; set; }

        [Required]
        [Display(Name = "Away Team")]
        public string AwayTeam { get; set; }

        [Display(Name = "Home Score")]
        public int HomeTeamScore { get; set; }

        [Display(Name = "Away Score")]
        public int AwayTeamScore { get; set; }

        [Required]
        [Display(Name = "Scheduled for")]
        public DateTime MatchDate { get; set; }

        [Required]
        [Display(Name = "Status")]
        public MatchStatus MatchStatus { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<MatchViewModel, Match>()
                .ForMember(m => m.Id, opt => opt.Ignore()).ReverseMap();
        }
    }
}