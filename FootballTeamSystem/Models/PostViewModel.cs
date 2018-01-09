using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using FootballTeamSystem.Data.Model;

namespace FootballTeamSystem.Models
{
    public class PostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {

        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Съдържание")]
        public string Content { get; set; }

        public string Description { get; set; }

        public User Author { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsFeaturedPost { get; set; }

        public string ImagePath { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<PostViewModel, Post>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}