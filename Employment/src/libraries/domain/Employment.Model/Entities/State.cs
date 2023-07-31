using Employment.Sheared.Common;

namespace Employment.Model.Entities;

public class State : BaseAuditableEntity, IEntity
{
	/// <summary>
	/// Gets or sets the identifier.
	/// </summary>
	/// <value>
	/// The identifier.
	/// </value>
	public int Id { get; set;}
	/// <summary>
	/// Gets or sets the name of the state.
	/// </summary>
	/// <value>
	/// The name of the state.
	/// </value>
	public string StateName { get; set; } = string.Empty;
	/// <summary>
	/// Gets or sets the country identifier.
	/// </summary>
	/// <value>
	/// The country identifier.
	/// </value>
	public int CountryId { get;set; }


	public Country Country { get; set; }
}
