using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Web;
using FootballTeamSystem.Data.Model.Abstraction;
using Microsoft.AspNet.Identity;


namespace FootballTeamSystem.Data.Model
{
    public class Post : DataModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }


        public string Description { get; set; }

        public virtual User Author { get; set; }

        [ForeignKey("Author")]
        public string AuthorId { get; set; }


        public bool IsFeaturedPost { get; set; }

        public string ImagePath { get; set; }



        public void AddImage(HttpPostedFileBase image)
        {
            var allowedContentTypes = new[] { "image/jpeg", "image/png", "image/jpg" };
            if (image != null && allowedContentTypes.Contains(image.ContentType))
            {

                var postsImagesDir = "/Content/Uploads/Posts/";
                var filename = image.FileName;
                var uploadPath = postsImagesDir + filename;

                var storigePath = HttpContext.Current.Server.MapPath(uploadPath);

                //Checking if the directory exist.
                var serverPostImagePath = HttpContext.Current.Server.MapPath(postsImagesDir);
                if (!Directory.Exists(serverPostImagePath))
                {
                 Directory.CreateDirectory(serverPostImagePath);
                }

                image.SaveAs(storigePath);

                this.ImagePath = uploadPath;
            }
        }

        public void AddDescription()
        {
            if (this.Content.Length <= 500)
            {
                this.Description = this.Content;
            }
            else
            {
                this.Description = this.Content.Substring(0, 500);
            }
        }

        public void AddAuthor()
        {
            var authorId = HttpContext.Current.User.Identity.GetUserId();
            this.AuthorId = authorId;
        }
    }
}
