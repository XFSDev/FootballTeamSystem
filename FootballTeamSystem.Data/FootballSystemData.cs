namespace FootballTeamSystem.Data
{
    using System;
    using System.Collections.Generic;

    using FootballTeamSystem.Data.Contracts;
    using FootballTeamSystem.Data.Model;
    using FootballTeamSystem.Data.Model.Contracts;
    using FootballTeamSystem.Data.Repositories;

    public class FootballSystemData : IFootballSystemData
    {
        private readonly IMsSqlDbContext _context;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();


        public FootballSystemData() : this(new MsSqlDbContext())
        {

        }

        public FootballSystemData(IMsSqlDbContext context)
        {
            this._context = context;
        }

        public IEfRepository<Post> Posts => this.GetRepository<Post>();
        public IEfRepository<Player> Players => this.GetRepository<Player>();
        public IEfRepository<Comment> Comments => this.GetRepository<Comment>();
        public IEfRepository<User> Users => this.GetRepository<User>();
        public IEfRepository<Match> Matches => this.GetRepository<Match>();


        public IMsSqlDbContext Context => this._context;

        private IEfRepository<T> GetRepository<T>()
            where T : class, IDeletable
        {
            if (!this._repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(EfRepository<T>);

                //if (typeof(T).IsAssignableFrom(typeof(Post)))
                //{
                //    type = typeof(PostRepository);
                //}

                //if (typeof(T).IsAssignableFrom(typeof(Player)))
                //{
                //    type = typeof(PlayerRepository);
                //}

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
