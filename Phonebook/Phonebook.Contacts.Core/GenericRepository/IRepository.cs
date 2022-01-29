namespace Phonebook.Contacts.Core.GenericRepository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRepository<T>
    {
        Task<T> Get(Guid id);

        Task<IEnumerable<T>> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            String includeProperties = null);

        Task<T> GetFirstOrDefault(
            Expression<Func<T, bool>> filter,
            String includeProperties = null);

        Task<T> Add(T entity);

        Task<T> Remove(Guid id);

        void Remove(T entity);
    }
}