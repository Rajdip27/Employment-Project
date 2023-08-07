namespace Employment_Project.Models.ViewModel;

public class City
{
    public int id { get; set; }
    public string cityName { get; set; } = string.Empty;
    public int stateId { get; set; }
    public State?states { get; set; }
  
}
