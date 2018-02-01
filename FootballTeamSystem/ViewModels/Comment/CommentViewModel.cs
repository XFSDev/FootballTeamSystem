namespace FootballTeamSystem.ViewModels.Comment
{
    using System;
    using AutoMapper;
    using Data.Model;
    using Infrastructure.Mapping;

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public Guid Id { get; set; }
        public string AuthorName { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(m => m.AuthorName, opt => opt.MapFrom(m => m.Author.UserName));
        }
    }
}