using System.ComponentModel;

namespace Employment_Project.Frontend.Models.ViewModel;

public class City
{
    [DisplayName("Id")]
    public int Id { get; set; }
    [DisplayName("Name")]
    public string CityName { get; set; } = string.Empty;

    public int StateId { get; set; }
    [DisplayName("State")]
    public string StateName { get; set; }
   
  
}
