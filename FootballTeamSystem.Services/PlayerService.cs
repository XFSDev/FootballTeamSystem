namespace FootballTeamSystem.Services
{
    using System.Linq;
    using System.Web;
    using Common;
    using Contracts;
    using Data;
    using Data.Model;

    public class PlayerService : IPlayerService
    {
        protected IFootballSystemData Data { get; private set; }

        public PlayerService(IFootballSystemData data)
        {
            this.Data = data;
        }

        public void AddPlayer(Player player, HttpPostedFileBase playerImage)
        {
            UpdatePlayerImage(player, playerImage);

            this.Data.Players.Add(player);
            this.Data.SaveCanges();
        }

        public void UpdatePlayer(Player player, HttpPostedFileBase playerImage)
        {
            UpdatePlayerImage(player, playerImage);

            this.Data.Players.Update(player);
            this.Data.SaveCanges();
        }

        private static void UpdatePlayerImage(Player player, HttpPostedFileBase playerImage)
        {
            var allowedContentTypes = new[] { "image/jpeg", "image/png", "image/jpg" };
            if (playerImage != null && allowedContentTypes.Contains(playerImage.ContentType))
            {
                var playersImageDir = "/Content/Uploads/Players/";
                string uploadPath = ServiceHelper.SaveImageToFileSystemAndReturnPath(playerImage, playersImageDir);

                player.PlayerImagePath = uploadPath;
            }
            else
            {
                if (player.PlayerImagePath == null)
                {
                    var defaultPostImage = "/Content/Images/footballTeamSystem-noavatar.png";
                    player.PlayerImagePath = defaultPostImage;
                }
            }

        }
    }
}
