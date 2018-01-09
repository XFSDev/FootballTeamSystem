using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using FootballTeamSystem.Data.Model;

namespace FootballTeamSystem.Data
{
    public interface IMsSqlDbContext : IDisposable
    {
        IDbSet<Post> Posts { get; set; }

        int SaveChanges();
        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;
    }
}