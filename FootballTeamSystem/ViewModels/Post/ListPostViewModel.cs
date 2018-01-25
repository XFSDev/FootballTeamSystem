namespace FootballTeamSystem.ViewModels.Post
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using Data.Model;
    using Infrastructure.Mapping;

    public class ListPostViewModel: IMapFrom<Post>
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        public string Content { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        public  string AuthorUserName { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedOn { get; set; }

        public bool IsFeaturedPost { get; set; }

        public string ImagePath { get; set; }
    }
}