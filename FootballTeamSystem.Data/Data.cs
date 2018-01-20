using System;
using System.Collections.Generic;
using FootballTeamSystem.Data.Contracts;
using FootballTeamSystem.Data.Model;
using FootballTeamSystem.Data.Model.Contracts;
using FootballTeamSystem.Data.Repositories;

namespace FootballTeamSystem.Data
{
    public class Data : IData
    {
        private readonly IMsSqlDbContext _context;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();


        public Data() : this(new MsSqlDbContext())
        {

        }

        public Data(IMsSqlDbContext context)
        {
            this._context = context;
        }

        public IPostRepository Posts => (IPostRepository)this.GetRepository<Post>();
        public IPlayerRepository Players => (IPlayerRepository)this.GetRepository<Player>();


        public IMsSqlDbContext Context => this._context;

        private IEfRepository<T> GetRepository<T>()
            where T : class, IDeletable
        {
            if (!this._repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(EfRepository<T>);

                if (typeof(T).IsAssignableFrom(typeof(Post)))
                {
                    type = typeof(PostRepository);
                }

                if (typeof(T).IsAssignableFrom(typeof(Player)))
                {
                    type = typeof(PlayerRepository);
                }

                this._repositories.Add(typeof(T), Activator.CreateInstance(type, this._context));
            }

            return (IEfRepository<T>)this._repositories[typeof(T)];
        }

        public int SaveCanges()
        {
            return this._context.SaveChanges();
        }


        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._context?.Dispose();
            }
        }
    }
}
