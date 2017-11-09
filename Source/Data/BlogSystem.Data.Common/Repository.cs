namespace BlogSystem.Data.Common
{
    using System;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using Models;

    public class Repository<T> : IRepository<T> where T : class
    {
        public Repository(ApplicationDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        protected ApplicationDbContext Context { get; set; }

        protected IDbSet<T> DbSet { get; set; }

        public virtual IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeExpressions)
        {
            try
            {
                IQueryable<T> set = this.DbSet.AsQueryable<T>();

                foreach (var includeExpression in includeExpressions)
                {
                    set = set.Include(includeExpression);
                }

                return set;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual T Get(int id)
        {
            try
            {
                return this.DbSet.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Add(T entity)
        {
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual T FirstOrDefault(Expression<Func<T, bool>> conditions)
        {
            try
            {
                return this.DbSet.FirstOrDefault(conditions);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Update(T entity)
        {
            try
            {
                DbEntityEntry entry = this.Context.Entry(entity);
                if (entry.State == EntityState.Detached)
                {
                    this.DbSet.Attach(entity);
                }

                entry.State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual bool All(Expression<Func<T, bool>> conditions)
        {
            try
            {
                return this.DbSet.All(conditions);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Delete(T entity)
        {
            try
            {
                DbEntityEntry entry = this.Context.Entry(entity);
                if (entry.State != EntityState.Deleted)
                {
                    entry.State = EntityState.Deleted;
                }
                else
                {
                    this.DbSet.Attach(entity);
                    this.DbSet.Remove(entity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Delete(int id)
        {
            try
            {
                var entity = this.Get(id);

                if (entity != null)
                {
                    this.Delete(entity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Delete(Expression<Func<T, bool>> conditions)
        {
            foreach (var item in this.GetAll().Where(conditions))
            {
                this.Delete(item);
            }
        }

        public virtual IQueryable<T> Where(Expression<Func<T, bool>> conditions)
        {
            try
            {
                return this.GetAll().Where(conditions);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual bool Any(Expression<Func<T, bool>> conditions)
        {
            try
            {
                return this.DbSet.Any(conditions);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual int Count(Expression<Func<T, bool>> conditions)
        {
            try
            {
                return this.DbSet.Count(conditions);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SaveChanges()
        {
            try
            {
                return this.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

