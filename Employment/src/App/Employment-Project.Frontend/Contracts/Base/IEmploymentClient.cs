using Employment_Project.Frontend.Models.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Employment_Project.Frontend.Contracts.Base;

public interface IEmploymentClient
{

    #region Department 
    Task<Department> GetDepartmentById(int id);
    Task<IEnumerable<Department>> GetAllDepartment();
    Task AddDepartment(Department  department);
    Task UpdateDepartment(int id, Department  department);
    Task<Department> DeleteDepartment(int id);
    public  Task<IEnumerable<SelectListItem>> DepartmentDropdown();
    #endregion
    #region City 
    Task<City> GetCityById(int id);
    Task<IEnumerable<City>> GetAllCity();
    Task AddCity(City city);
    Task UpdateCity(int id, City city);
    Task<City> DeleteCity(int id);
    public  Task<IEnumerable<SelectListItem>> CityDropdown();
    #endregion
    #region Country 
    Task<Country> GetCountryById(int id);
    Task<IEnumerable<Country>> GetAllCountry();
    Task AddCountry(Country  country);
    Task UpdateCountry(int id, Country country);
    Task<Country> DeleteCountry(int id);
    public  Task<IEnumerable<SelectListItem>> CountryDropdown();
    #endregion
    #region State 
    Task<State> GetStateById(int id);
    Task<IEnumerable<State>> GetAllState();
    Task AddState(State state);
    Task UpdateState(int id, State state);
    Task<State> DeleteState(int id);
    public  Task<IEnumerable<SelectListItem>> StateDropdown();
    #endregion
    #region Employee 
    Task<Employee> GetEmployeeById(int id);
    Task<IEnumerable<Employee>> GetAllEmployee();
    Task AddEmployee(Employee  employee);
    Task UpdateEmployee(int id, Employee  employee);
    Task<Employee> DeleteEmployee(int id);
    #endregion
}
