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
        [Display(Name = "Име и фамилия")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Дата на раждане")]
        public DateTime Birthdate { get; set; }

        [Required]
        [Range(1,99)]
        [Display(Name = "Номер на фланелка")]
        public byte ShirtNumber { get; set; }

        public string PlayerImagePath { get; set; }

        [Required]
        [Display(Name = "Позиция")]
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