namespace FootballTeamSystem.ViewModels.Post
{
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper;

    using Data.Model;
    using Infrastructure.Mapping;

    public class AddPostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        public string Content { get; set; }

        public bool IsFeaturedPost { get; set; }

        public HttpPostedFileBase UploadedImage { get; set; }


        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<AddPostViewModel, Post>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}