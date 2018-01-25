namespace FootballTeamSystem.Data.Contracts
{
    using System;
    using System.Linq;

    public interface IEfRepository<T>
        where T : class
    {
        IQueryable<T> All { get; }

        IQueryable<T> AllAndDeleted { get; }

        void Add(T post);

        T GetById(Guid id);

        void Delete(T entity);

        void Update(T entity);
    }
}
