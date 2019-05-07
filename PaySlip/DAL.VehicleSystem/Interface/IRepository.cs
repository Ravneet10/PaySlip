using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.VehicleSystem.Interface
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();
        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns></returns>
        IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> where = null);
        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] includeProperties);
        /// <summary>
        /// Finds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        TEntity Find(object id);
        /// <summary>
        /// Finds the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns></returns>
        TEntity Find(Expression<Func<TEntity, bool>> where = null);
        /// <summary>
        /// Finds the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        TEntity Find(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] includeProperties);
        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Insert(TEntity entity);
        /// <summary>
        /// Updates the specified entity to update.
        /// </summary>
        /// <param name="entityToUpdate">The entity to update.</param>
        void Update(TEntity entityToUpdate);
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void Delete(object id);
        /// <summary>
        /// Deletes the specified entity to delete.
        /// </summary>
        /// <param name="entityToDelete">The entity to delete.</param>
        void Delete(TEntity entityToDelete);
        /// <summary>
        /// Deletes the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        void Delete(Expression<Func<TEntity, bool>> where);
        ///// <summary>
        ///// Executes the raw command.
        ///// </summary>
        ///// <param name="commandText">The command text.</param>
        ///// <param name="parameters">The parameters.</param>
        ///// <returns></returns>
        //int ExecuteRawCommand(string commandText, params object[] parameters);
        ///// <summary>
        ///// Executes the stored procedure.
        ///// </summary>
        ///// <param name="commandText">The command text.</param>
        ///// <param name="parameters">The parameters.</param>
        ///// <returns></returns>
        //IEnumerable<TEntity> ExecuteStoredProcedure(string commandText, params object[] parameters);
        /// <summary>
        /// Gets the with raw SQL.
        /// </summary>
        /// <param name="queryText">The query text.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetWithRawSql(string queryText, params object[] parameters);
        /// <summary>
        /// Applies the changes.
        /// </summary>
        /// <param name="existingEntity">The existing entity.</param>
        /// <param name="updatedEntity">The updated entity.</param>
        void ApplyChanges(TEntity existingEntity, TEntity updatedEntity);
        /// <summary>
        /// Determines whether [is entity attached to database] [the specified entity].
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        bool IsEntityAttachedToDB(TEntity entity);
        /// <summary>
        /// Dettaches the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Dettach(TEntity entity);
       
    }
}
