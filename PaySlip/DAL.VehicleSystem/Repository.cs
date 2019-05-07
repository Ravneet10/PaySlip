using System;
using System.Collections.Generic;

using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure;
using DAL.VehicleSystem.Interface;
using Microsoft.EntityFrameworkCore;

namespace DAL.VehicleSystem
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        #region Private/Internal Members

        /// <summary>
        /// The _context
        /// </summary>
        internal DbContext _context;
        /// <summary>
        /// The _DB set
        /// </summary>
        internal DbSet<TEntity> _dbSet;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        #endregion

        #region Public Interface Implementation

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> where = null)
        {
            return null != where ? _dbSet.Where(where) : _dbSet;
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;
            if (includeProperties != null) includeProperties.ToList().ForEach(i => { query = query.Include(i); });
            return null != where ? query.Where(where) : query;
        }

        /// <summary>
        /// Finds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual TEntity Find(object id)
        {
            return _dbSet.Find(id);
        }

        /// <summary>
        /// Finds the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns></returns>
        public virtual TEntity Find(Expression<Func<TEntity, bool>> where = null)
        {
            return FindAll(where).FirstOrDefault();
        }

        /// <summary>
        /// Finds the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        public virtual TEntity Find(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;
            if (includeProperties != null) includeProperties.ToList().ForEach(i => { query = query.Include(i); });
            return null != where ? query.Where(where).FirstOrDefault() : query.FirstOrDefault();
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        /// <summary>
        /// Updates the specified entity to update.
        /// </summary>
        /// <param name="entityToUpdate">The entity to update.</param>
        public virtual void Update(TEntity entityToUpdate)
        {
            var entry = _context.Entry(entityToUpdate);
            if (entry.State == EntityState.Detached)
            {
                _dbSet.Attach(entityToUpdate);
                entry = _context.Entry(entityToUpdate);
            }
            entry.State = EntityState.Modified;
        }

        /// <summary>
        /// Deletes the specified entity to delete.
        /// </summary>
        /// <param name="entityToDelete">The entity to delete.</param>
        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        /// <summary>
        /// Deletes the specified entity to delete.
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        /// <summary>
        /// Deletes the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        public virtual void Delete(System.Linq.Expressions.Expression<Func<TEntity, bool>> where)
        {
            var objects = _dbSet.Where(where).AsEnumerable();
            foreach (var item in objects)
            {
                Delete(item);
            }
        }

        ///// <summary>
        ///// Executes the raw command.
        ///// </summary>
        ///// <param name="commandText">The command text.</param>
        ///// <param name="parameters">The parameters.</param>
        ///// <returns></returns>
        //public int ExecuteRawCommand(string commandText, params object[] parameters)
        //{
        //    return _context.Database.ExecuteSqlCommand(commandText, parameters);
        //}

        ///// <summary>
        ///// Executes the stored procedure.
        ///// </summary>
        ///// <param name="commandText">The command text.</param>
        ///// <param name="parameters">The parameters.</param>
        ///// <returns></returns>
        //public IEnumerable<TEntity> ExecuteStoredProcedure(string commandText, params object[] parameters)
        //{
        //    return (_context as IObjectContextAdapter).ObjectContext.ExecuteStoreQuery<TEntity>(commandText, parameters).ToList();
        //}

        ///// <summary>
        ///// Gets the with raw SQL.
        ///// </summary>
        ///// <param name="queryText">The query text.</param>
        ///// <param name="parameters">The parameters.</param>
        ///// <returns></returns>
        //public IEnumerable<TEntity> GetWithRawSql(string queryText, params object[] parameters)
        //{
        //    return _dbSet.SqlQuery(queryText, parameters).ToList();
        //}

        /// <summary>
        /// Applies the changes.
        /// </summary>
        /// <param name="existingEntity">The existing entity.</param>
        /// <param name="updatedEntity">The updated entity.</param>
        public void ApplyChanges(TEntity existingEntity, TEntity updatedEntity)
        {
            var entry = _context.Entry(existingEntity);
            if (entry.State == EntityState.Detached)
            {
                _dbSet.Attach(existingEntity);
            }
            _context.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);
        }

        /// <summary>
        /// Dettaches the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Dettach(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }

      

        /// <summary>
        /// IsEntityAttachedToDB
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public bool IsEntityAttachedToDB(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Gets the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        internal IQueryable<TEntity> Get(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           List<Expression<Func<TEntity, object>>> includeProperties = null,
           int? page = null,
           int? pageSize = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (includeProperties != null)
                includeProperties.ForEach(i => query = query.Include(i));
            if (filter != null)
                query = query.Where(filter);


            if (orderBy != null)
                query = orderBy(query);

            if (page != null && pageSize != null)
                query = query
                    .Skip((page.Value - 1) * pageSize.Value)
                    .Take(pageSize.Value);

            return query;
        }

        public IEnumerable<TEntity> GetWithRawSql(string queryText, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
