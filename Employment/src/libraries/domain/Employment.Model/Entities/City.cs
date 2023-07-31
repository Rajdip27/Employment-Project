using Employment.Sheared.Common;

namespace Employment.Model.Entities;

public class City : BaseAuditableEntity, IEntity
{
	/// <summary>
	/// Gets or sets the identifier.
	/// </summary>
	/// <value>
	/// The identifier.
	/// </value>
	public int Id { get; set; }
	/// <summary>
	/// Gets or sets the name of the city.
	/// </summary>
	/// <value>
	/// The name of the city.
	/// </value>
	public string CityName { get; set; } = string.Empty;
	/// <summary>
	/// Gets or sets the state identifier.
	/// </summary>
	/// <value>
	/// The state identifier.
	/// </value>
	public int StateId { get; set; }
	/// <summary>
	/// Gets or sets the state.
	/// </summary>
	/// <value>
	/// The state.
	/// </value>
	public State State { get; set; }


}
