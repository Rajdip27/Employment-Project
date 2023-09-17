namespace Employment_Project.Frontend.Models.ViewModel;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Gender { get; set; }
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public DateTime JoiningDate { get; set; }
    public bool SSC { get; set; }
    public bool HSC { get; set; }
    public bool BSC { get; set; }
    public bool MSC { get; set; }
    public string Picture { get; set; }
    public int CountryId { get; set; }
    public string CountryName { get; set; }
    public int StateId { get; set; }
    public string StateName { get; set; }
    public int CityId { get; set; }
    public string CityName { get; set; }
    public IFormFile PictureFile {  get; set; }


}
