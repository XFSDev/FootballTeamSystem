namespace FootballTeamSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using FootballTeamSystem.Data.Model;

    public interface IMsSqlDbContext : IDisposable
    {
        IDbSet<Post> Posts { get; set; }
        IDbSet<Player> Players { get; set; }
        IDbSet<Comment> Comments { get; set; }
        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;

        int SaveChanges();
    }
}