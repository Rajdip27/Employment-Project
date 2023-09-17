using Employment.Sheared.Common;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Employment.Service.Models.ViewModel
{
	public class VMEmployee:IVM
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
		public string Gender { get; set; } = string.Empty;
		public int DepartmentId { get; set; }
		public string DepartmentName { get; set; } = string.Empty;
		public DateTime JoiningDate { get; set; }
		public Boolean Ssc { get; set; }
		public Boolean Hsc { get; set; }
		public Boolean Bsc { get; set; }
		public Boolean Msc { get; set; }
		public string Picture { get; set; } = string.Empty;
		public int CountryId { get; set; }
		public string CountryName { get; set; }= string.Empty;
		
		public int StateId { get; set; }
		public string StateName { get; set; } = string.Empty;
		public int CityId { get; set; }
		public string CityName { get; set; } = string.Empty;
        public IFormFile ? PictureFile { get; set; }
    }
}
