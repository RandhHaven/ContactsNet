namespace Phonebook.Contacts.GenericRepository
{
    using Microsoft.EntityFrameworkCore;
    using Phonebook.Contacts.Core.GenericRepository;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class Repository<T> : IRepository<T> where T : class
    {
        #region Properties
        private readonly DbContext dbContext;
        public DbSet<T> _dbSet;
        #endregion

        #region Build
        public Repository(DbContext _dbContext)
        {
            this.dbContext = _dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
            this._dbSet = dbContext.Set<T>();
        }
        #endregion

        #region Methods
        public async virtual Task<T> Add(T entity)
        {
            var ent = await this._dbSet.AddAsync(entity);
            return ent.Entity;
        }

        public async Task<T> Get(Guid id)
        {
            var objectFind = await this._dbSet.FindAsync(id);
            return objectFind;
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

        public async Task<T> Remove(Guid id)
        {
            var entityRemove = await this._dbSet.FindAsync(id);
            Remove(entityRemove);
            return entityRemove;
        }

        public void Remove(T entity)
        {
           this._dbSet.Remove(entity);
        }

        public virtual T Update(T entity)
        {            
            return entity;
        }
        #endregion
    }
}
