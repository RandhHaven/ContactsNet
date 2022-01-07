namespace Phonebook.Contacts.GenericRepository
{
    using Microsoft.EntityFrameworkCore;
    using Phonebook.Contacts.Core.GenericRepository;
    using Phonebook.Contacts.Infrastructure.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class Repository<T> : IRepository<T> where T : class
    {
        #region Properties
        private readonly DbContext databaseContext;
        internal DbSet<T> _dbSet;
        #endregion

        #region Build
        public Repository(DbContext _databaseContext)
        {
            databaseContext = _databaseContext
                ?? throw new ArgumentNullException(nameof(_databaseContext));
            this._dbSet = databaseContext.Set<T>();
        }
        #endregion

        #region Methods
        public virtual void Add(T entity)
        {
            this._dbSet.Add(entity);
        }

        public async Task<T> Get(Int64 id)
        {
            var objectFind = this._dbSet.Find(id);
            return await Task.Factory.StartNew(() => objectFind);
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = this._dbSet;
            if (!Object.Equals(filter, null))
            {
                query = query.Where(filter);
            }
            if (!Object.Equals(includeProperties, null))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            if (!Object.Equals(orderBy, null))
            {
                return await orderBy(query).ToListAsync();
            }
            return await query.ToListAsync();
        }

        public Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter, string includeProperties = null)
        {
            IQueryable<T> query = this._dbSet;
            if (!Object.Equals(filter, null))
            {
                query = query.Where(filter);
            }
            if (!Object.Equals(includeProperties, null))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.FirstOrDefaultAsync();
        }

        public void Remove(long id)
        {
            var entityRemove = this._dbSet.Find(id);
            Remove(entityRemove);
        }

        public void Remove(T entity)
        {
            this._dbSet.Remove(entity);
        }

        public virtual void Update(T entity)
        {
        }
        #endregion
    }
}
