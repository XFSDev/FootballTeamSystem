namespace FootballTeamSystem.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using Model;

    public interface IPlayerRepository : IEfRepository<Player>
    {
        void Add(Player player, HttpPostedFileBase playerImage);
        void Update(Player player, HttpPostedFileBase playerImage);

        Player GetPlayer(Guid id);

        IEnumerable<Player> GetPlayers();
    }
}