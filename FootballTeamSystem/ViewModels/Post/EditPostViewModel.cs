namespace FootballTeamSystem.ViewModels.Post
{
    using System;

    using AutoMapper;

    using Data.Model;
    using Infrastructure.Mapping;

    public class EditPostViewModel : AddPostViewModel, IMapFrom<Post>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        public new void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<EditPostViewModel, Post>()
                .ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}