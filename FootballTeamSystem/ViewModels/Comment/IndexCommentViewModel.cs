using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballTeamSystem.ViewModels.Comment
{
    using AutoMapper;
    using Data.Model;
    using Infrastructure.Mapping;
    public class IndexCommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public string AuthorName { get; set; }
        public string Content { get; set; }
        public string PostId { get; set; }
        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Comment, IndexCommentViewModel>()
                .ForMember(m => m.AuthorName, opt => opt.MapFrom(m => m.Author.UserName))
                .ForMember(m => m.PostId, opt => opt.MapFrom(m => m.Post.Id));
        }
    }
}