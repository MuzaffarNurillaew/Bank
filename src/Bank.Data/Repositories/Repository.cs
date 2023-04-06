using Bank.Data.DbContexts;
using Bank.Data.IRepositories;
using Bank.Domain.Commons;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bank.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Auditable
    {
        private readonly BankDbContext dbContext;
        private readonly DbSet<T> dbSet;
        public Repository(BankDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        #region delete
        /// <summary>
        /// Deletes information in database
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>true if action is successful, false if unable to delete</returns>
        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            var entity = await this.SelectAsync(expression);
            
            if (entity is not null)
            {
                this.dbSet.Remove(entity);
                return true;
            }
            
            return false;
        }
        #endregion

        #region insert
        /// <summary>
        /// Inserts element to a table
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T> InsertAsync(T entity)
        {
            var entry = await this.dbSet.AddAsync(entity);

            return entry.Entity;
        }
        #endregion

        #region save
        /// <summary>
        /// saves tracking changes
        /// </summary>
        /// <returns></returns>
        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }
        #endregion

        #region select all
        /// <summary>
        /// Selects all element of table
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> SelectAll() => this.dbSet;
        #endregion

        #region select
        /// <summary>
        /// selects element from a table specified with expression
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<T> SelectAsync(Expression<Func<T, bool>> expression)
            => await this.dbSet.FirstOrDefaultAsync(expression);
        #endregion

        #region update
        /// <summary>
        /// updates element in the table
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T> UpdateAsync(T entity)
        {
            var entry = this.dbSet.Update(entity);

            return await Task.FromResult(entry.Entity);
        }
        #endregion
    }
}
