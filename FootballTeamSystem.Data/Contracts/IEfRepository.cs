using System.Linq;

namespace FootballTeamSystem.Data.Contracts
{
    public interface IEfRepository<T>
        where T : class
    {
        IQueryable<T> All { get; }

        IQueryable<T> AllAndDeleted { get; }

        void Add(T post);

        void Delete(T entity);

        void Update(T entity);
    }
}
