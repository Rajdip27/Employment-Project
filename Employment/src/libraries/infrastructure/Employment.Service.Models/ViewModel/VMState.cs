using Employment.Sheared.Common;

namespace Employment.Service.Models.ViewModel;

public class VMState:IVM
{
	public int Id { get; set; }
	public string StateName { get; set; } = string.Empty;
	public int CountryId { get; set; }
	public string? CountryName {  get; set; } 
}
