namespace BlogSystem.Data.Common
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;
    using Models;
    using Models.Entities;

    public class DeletableEntityRepository<T> : Repository<T>, IDeletableEntityRepository<T>
        where T : class, IDeletableEntity
    {
        public DeletableEntityRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public override IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeExpressions)
        {
            return base.GetAll(includeExpressions).Where(x => !x.IsDeleted);
        }

        public IQueryable<T> AllWithDeleted()
        {
            return base.GetAll();
        }

        public override void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;

            DbEntityEntry entry = this.Context.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public override T FirstOrDefault(Expression<Func<T, bool>> conditions)
        {
            return this.GetAll().FirstOrDefault(conditions);
        }

        public override bool Any(Expression<Func<T, bool>> conditions)
        {
            return this.GetAll().Any(conditions);
        }

        public override bool All(Expression<Func<T, bool>> conditions)
        {
            return this.GetAll().All(conditions);
        }

        public override int Count(Expression<Func<T, bool>> conditions)
        {
            return this.GetAll().Count(conditions);
        }

        public override IQueryable<T> Where(Expression<Func<T, bool>> conditions)
        {
            return this.GetAll().Where(conditions);
        }
    }
}
