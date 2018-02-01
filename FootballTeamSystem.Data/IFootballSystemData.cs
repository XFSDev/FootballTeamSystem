namespace FootballTeamSystem.Data
{
    using System;

    using Model;
    using FootballTeamSystem.Data.Contracts;

    public interface IFootballSystemData : IDisposable
    {
       IEfRepository<Post> Posts { get; }
       IEfRepository<Player> Players { get; }
        IEfRepository<Comment> Comments { get; }
        IEfRepository<User> Users { get; }

        IMsSqlDbContext Context { get; }

        int SaveCanges();
    }
}
