using System.Linq.Expressions;
using Loan.Data.EntityModel;

namespace Loan.Data;

public interface IRepository<TEntity, in TIdentifier> 
 where TEntity : IEntity<TIdentifier>
 where TIdentifier : IEquatable<TIdentifier>
{
    /// <summary>
    /// Update entity in repository.
    /// </summary>
    /// <param name="filter">A <see cref="Func{TDelegate}"/> to filter entities by..</param>
    /// <returns>An <see cref="IEnumerable{TEntity}"/> of entities.</returns>
    Task<IEnumerable<TEntity>> GetEntities(Func<TEntity, bool>? filter = null);

    /// <summary>
    /// Insert entity in repository.
    /// </summary>
    /// <param name="entity">Entity to update.</param>
    /// <returns>New inserted entity.</returns>
    Task<TEntity> Insert(TEntity entity);

    /// <summary>
    /// Delete entity in repository.
    /// </summary>
    /// <param name="identifier">Entity's identifier to delete.</param>
    Task Delete(TIdentifier identifier);

    /// <summary>
    /// Update entity in repository.
    /// </summary>
    /// <param name="entity">Entity to update.</param>
    /// <returns>Updated entity.</returns>
    Task<TEntity> Update(TEntity entity);
}