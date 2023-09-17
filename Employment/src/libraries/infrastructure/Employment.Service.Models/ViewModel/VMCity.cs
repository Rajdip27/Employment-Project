using Employment.Sheared.Common;

namespace Employment.Service.Models.ViewModel;

public class VMCity:IVM
{
	public int Id { get; set; }
	public string CityName { get; set; } = string.Empty;
	public int StateId { get; set; }
	public string StateName { get; set; }=string.Empty;
}
