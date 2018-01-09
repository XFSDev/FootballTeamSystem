using System;
using FootballTeamSystem.Data.Contracts;

namespace FootballTeamSystem.Data
{
    public interface IData : IDisposable
    {
        IPostRepository Posts { get; }

        IMsSqlDbContext Context { get; }

        int SaveCanges();
    }
}
