using Employment.Sheared.Common;

namespace Employment.DataAccess.Contracts.CommonInterface;

public interface IRepository<in TEntity, IModel, T> where TEntity : class, IEntity<T>, new()
	where IModel : class, IVM<T>, new()
	where T : IEquatable<T>
{
	/// <summary>Gets the by identifier asynchronous.</summary>
	/// <param name="id">The identifier.</param>
	/// <returns>
	///   <br />
	/// </returns>
	public Task<IModel> GetByIdAsync(T id);
	/// <summary>
	/// Gets all asynchronous.
	/// </summary>
	/// <returns></returns>
	public Task<IEnumerable<IModel>> GetAllAsync();
	/// <summary>
	/// Deletes the asynchronous.
	/// </summary>
	/// <param name="entity">The entity.</param>
	/// <returns></returns>
	public Task DeleteAsync(TEntity entity);
	/// <summary>
	/// Deletes the asynchronous.
	/// </summary>
	/// <param name="id">The identifier.</param>
	/// <returns></returns>
	public Task DeleteAsync(T id);
	/// <summary>
	/// Updates the asynchronous.
	/// </summary>
	/// <param name="id">The identifier.</param>
	/// <param name="entity">The entity.</param>
	/// <returns></returns>
	public Task<IModel> UpdateAsync(T id, TEntity entity);
	/// <summary>
	/// Inserts the asynchronous.
	/// </summary>
	/// <param name="entity">The entity.</param>
	/// <returns></returns>
	public Task<IModel> InsertAsync(TEntity entity);
}
