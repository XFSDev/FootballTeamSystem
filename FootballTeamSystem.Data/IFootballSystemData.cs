namespace FootballTeamSystem.Data
{
    using System;

    using Model;
    using FootballTeamSystem.Data.Contracts;

    public interface IFootballSystemData : IDisposable
    {
       IEfRepository<Post> Posts { get; }
       IEfRepository<Player> Players { get; }

        IMsSqlDbContext Context { get; }

        int SaveCanges();
    }
}
