namespace FootballTeamSystem.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Contracts;
    using Model;

    public class PlayerRepository : EfRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(IMsSqlDbContext context) : base(context)
        {
        }

        public void Add(Player player, HttpPostedFileBase playerImage)
        {
            player.AddImage(playerImage);

            base.Add(player);
        }

        public void Update(Player player, HttpPostedFileBase playerImage)
        {
           player.AddImage(playerImage);

            base.Update(player);
        }

        public Player GetPlayer(Guid id)
        {
            return base.Context.Players.SingleOrDefault(pl => pl.Id == id);
        }

        public IEnumerable<Player> GetPlayers()
        {
            return base.All;
        }
    }
}
