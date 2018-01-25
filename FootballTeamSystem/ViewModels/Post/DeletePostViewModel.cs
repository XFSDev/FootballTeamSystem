namespace FootballTeamSystem.ViewModels.Post
{
    using System;

    using AutoMapper;

    using Data.Model;
    using Infrastructure.Mapping;
    public class DeletePostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public Guid Id { get; set; }    
        public string PostTitle { get; set; }
        public string PostContent { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Post, DeletePostViewModel>()
                .ForMember(m => m.PostTitle, opt => opt.MapFrom(t => t.Title))
                .ForMember(m => m.PostContent, opt => opt.MapFrom(t => t.Content));
        }
    }
}