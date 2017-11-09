namespace BlogSystem.Data.Common
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<T> where T : class 
    {
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeExpression);

        T Get(int id);

        void Add(T entity);

        bool All(Expression<Func<T, bool>> conditions);

        T FirstOrDefault(Expression<Func<T, bool>> conditions);

        void Update(T entity);

        void Delete(T entity);

        void Delete(int id);

        void Delete(Expression<Func<T, bool>> conditions);

        IQueryable<T> Where(Expression<Func<T, bool>> conditions);

        bool Any(Expression<Func<T, bool>> conditions);

        int Count(Expression<Func<T, bool>> conditions);

        int SaveChanges();
    }
}
