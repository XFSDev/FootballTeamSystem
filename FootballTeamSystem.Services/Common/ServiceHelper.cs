namespace FootballTeamSystem.Services.Common
{
    using System;
    using System.IO;
    using System.Web;

    public class ServiceHelper
    {
        public static string SaveImageToFileSystemAndReturnPath(HttpPostedFileBase postImage, string postsImagesDir)
        {
            var filename = postImage.FileName;
            var uploadPath = postsImagesDir + filename;

            var storagePath = HttpContext.Current.Server.MapPath(uploadPath);

            //Checking if the directory exist.
            var serverPostImagePath = HttpContext.Current.Server.MapPath(postsImagesDir);
            if (!Directory.Exists(serverPostImagePath))
            {
                Directory.CreateDirectory(serverPostImagePath ?? throw new InvalidOperationException());
            }

            postImage.SaveAs(storagePath);
            return uploadPath;
        }
    }
}
