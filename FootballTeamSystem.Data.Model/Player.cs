namespace FootballTeamSystem.Data.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Web;

    using Abstraction;

    public class Player : DataModel
    {
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        [Range(1,99)]
        public byte ShirtNumber { get; set; }

        [Required]
        public PlayerPositions Position { get; set; }

        public string PlayerImagePath { get; set; }

        public bool IsCaptain { get; set; }

        public bool IsViceCaptain { get; set; }

        public void AddImage(HttpPostedFileBase image)
        {
            var allowedContentTypes = new[] { "image/jpeg", "image/png", "image/jpg" };
            if (image != null && allowedContentTypes.Contains(image.ContentType))
            {

                var playersImagesDirectory = "/Content/Uploads/Players/";
                var filename = image.FileName;
                var uploadPath = playersImagesDirectory + filename;

                var storigePath = HttpContext.Current.Server.MapPath(uploadPath);

                //Checking if the directory exist.
                var serverPostImagePath = HttpContext.Current.Server.MapPath(playersImagesDirectory);
                if (!Directory.Exists(serverPostImagePath))
                {
                    Directory.CreateDirectory(serverPostImagePath);
                }

                image.SaveAs(storigePath);

                this.PlayerImagePath = uploadPath;
            }
        }
    }
}
