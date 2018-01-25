namespace FootballTeamSystem.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    using FootballTeamSystem.Data.Contracts;
    using FootballTeamSystem.Data.Model.Contracts;

    public  class EfRepository<T> : IEfRepository<T>
        where T : class , IDeletable
    {
        public EfRepository(IMsSqlDbContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        protected IDbSet<T> DbSet { get; private set; }

        protected IMsSqlDbContext Context { get; private set; }

        public IQueryable<T> All
        {
            get
            {
                return this.DbSet.Where(x => !x.IsDeleted);
            }
        }

        public IQueryable<T> AllAndDeleted
        {
            get { return this.DbSet; }
        }

        public virtual void Add(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);

            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.DbSet.Add(entity);
            }
        }

        public virtual T GetById(Guid id)
        {
            return this.DbSet.Find(id);
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;

            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public void Update(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }
    }
}
