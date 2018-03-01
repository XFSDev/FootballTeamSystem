namespace FootballTeamSystem.Services.Contracts
{
    using System.Web;
    using Data.Model;

    public interface IPlayerService : IService
    {
        void AddPlayer(Player player, HttpPostedFileBase playerImage);
        void UpdatePlayer(Player player, HttpPostedFileBase playerImage);
    }
}
