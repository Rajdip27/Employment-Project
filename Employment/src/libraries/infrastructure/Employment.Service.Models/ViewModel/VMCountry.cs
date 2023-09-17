using Employment.Sheared.Common;

namespace Employment.Service.Models.ViewModel;

public class VMCountry:IVM
{
	public int Id { get; set; }
	public string CountryName { get; set; } = string.Empty;
}
