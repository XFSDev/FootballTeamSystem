namespace FootballTeamSystem.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using Data.Model;
    using Infrastructure.Mapping;

    public class PlayerViewModel: IMapFrom<Player>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Date of birth")]
        public DateTime Birthdate { get; set; }

        [Required]
        [Range(1,99)]
        [Display(Name = "Jersey number")]
        public byte ShirtNumber { get; set; }

        public string PlayerImagePath { get; set; }

        [Required]
        public PlayerPositions Position { get; set; }

        public bool IsCaptain { get; set; }

        public bool IsViceCaptain { get; set; }


        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<PlayerViewModel, Player>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}