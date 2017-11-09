namespace BlogSystem.Data.Common
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IDeletableEntityRepository<T> : IRepository<T> where T : class
    {
        IQueryable<T> AllWithDeleted();
    }
}
