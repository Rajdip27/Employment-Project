using Employment_Project.Frontend.Contracts.Base;
using Employment_Project.Frontend.Models.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;
namespace Employment_Project.Frontend.Contracts;
public class EmploymentClient:IEmploymentClient
{
    private readonly HttpClient _httpClient;
    public EmploymentClient(IHttpClientFactory clientFactory) =>
        _httpClient = clientFactory.CreateClient("EmployeeApi");

    //Create
    #region Crate

    public async Task AddCity(City city) => await _httpClient.PostAsJsonAsync("City",city);

    public async Task AddCountry(Country  country)
    => await _httpClient.PostAsJsonAsync("Country", country);

    public async Task AddDepartment(Department  department)
   => await _httpClient.PostAsJsonAsync("Department", department);

    public async Task AddEmployee(Employee employee)
    {
        var content = new MultipartFormDataContent {
        {
            new StreamContent(employee.PictureFile.OpenReadStream())
            {
                Headers ={
                    ContentLength= employee.PictureFile.Length,
                    ContentType=new MediaTypeHeaderValue(employee.PictureFile.ContentType)
                }
            },
                "PictureFile", employee.PictureFile.FileName
        }};
        string[] fields = { "Name", "Gender", "Address", "JoiningDate", "DepartmentId", "CountryId", "CityId", "StateId", "Bsc", "Hsc", "Ssc", "Msc" };
        foreach (string field in fields)
        {
            content.Add(new StringContent(employee.GetType().GetProperty(field).GetValue(employee, null).ToString()), field);
        }
        await _httpClient.PostAsync("Employee", content);
    }
    public async Task AddState(State state)
    => await _httpClient.PostAsJsonAsync("State", state);
    #endregion
    //Delete
    #region Delete

    public async Task<City> DeleteCity(int id)
    {
        var response = await _httpClient.DeleteAsync($"City/{id}");
        if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<City>();
        else throw new Exception($"Failed to delete entity with ID {id}. Status code: {response.StatusCode}");
    }

    public async Task<Country> DeleteCountry(int id)
    {
        var response = await _httpClient.DeleteAsync($"Country/{id}");
        if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<Country>();
        else throw new Exception($"Failed to delete entity with ID {id}. Status code: {response.StatusCode}");
    }

    public async Task<Department> DeleteDepartment(int id)
    {
        var response = await _httpClient.DeleteAsync($"Department/{id}");
        if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<Department>();
        else throw new Exception($"Failed to delete entity with ID {id}. Status code: {response.StatusCode}");
    }
    public async Task<Employee> DeleteEmployee(int id)
    {
        var response = await _httpClient.DeleteAsync($"Employee/{id}");
        if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<Employee>();
        else throw new Exception($"Failed to delete entity with ID {id}. Status code: {response.StatusCode}");
    }

    public  async Task<State> DeleteState(int id)
    {
        var response = await _httpClient.DeleteAsync($"State/{id}");
        if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<State>();
        else throw new Exception($"Failed to delete entity with ID {id}. Status code: {response.StatusCode}");
    }
    #endregion
    //GetAll
    #region GetAll
    public async Task<IEnumerable<City>> GetAllCity()
    {
        var response = await _httpClient.GetAsync("City");
        return await response.Content.ReadFromJsonAsync<IEnumerable<City>>();
    }

    public async Task<IEnumerable<Country>> GetAllCountry()
    {
        var response = await _httpClient.GetAsync("Country");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Country>>();
    }

    public async Task<IEnumerable<Department>> GetAllDepartment()
    {
        var response = await _httpClient.GetAsync("Department");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Department>>();
    }

    public async Task<IEnumerable<Employee>> GetAllEmployee()
    {
        var response = await _httpClient.GetAsync("Employee");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Employee>>();
    }

    public async Task<IEnumerable<State>> GetAllState()
    {
        var response = await _httpClient.GetAsync("State");
        return await response.Content.ReadFromJsonAsync<IEnumerable<State>>();
    }
    #endregion
    //GetById
    #region GetById
    public async Task<City> GetCityById(int id)
    {
        var response = await _httpClient.GetAsync($"City/{id}");
        return await response.Content.ReadFromJsonAsync<City>();
    }
    public async Task<Country> GetCountryById(int id)
    {
        var response = await _httpClient.GetAsync($"Country/{id}");
        return await response.Content.ReadFromJsonAsync<Country>();
    }
    public async Task<Department> GetDepartmentById(int id)
    {
        var response = await _httpClient.GetAsync($"Department/{id}");
        return await response.Content.ReadFromJsonAsync<Department>();
    }
    public async Task<Employee> GetEmployeeById(int id)
    {
        var response = await _httpClient.GetAsync($"Employee/{id}");
        return await response.Content.ReadFromJsonAsync<Employee>();
    }
    public async Task<State> GetStateById(int id)
    {
        var response = await _httpClient.GetAsync($"State/{id}");
        return await response.Content.ReadFromJsonAsync<State>();
    }
    #endregion
    //Update
    #region Update
    public async Task UpdateCity(int id, City city) => await _httpClient.PutAsJsonAsync($"City/{id}", city);
    public async Task UpdateCountry(int id, Country country) => await _httpClient.PutAsJsonAsync($"Country/{id}", country);
    public async Task UpdateDepartment(int id, Department  department) => await _httpClient.PutAsJsonAsync($"Department/{id}", department);
    public async Task UpdateState(int id, State state) => await _httpClient.PutAsJsonAsync($"State/{id}", state);
    public async Task UpdateEmployee(int id, Employee employee) => await _httpClient.PutAsJsonAsync($"Employee/{id}", employee);
    #endregion

    //Dropdown
    #region Dropdown

    public async Task<IEnumerable<SelectListItem>> DepartmentDropdown()
    {
        using (var departmentResponse = await _httpClient.GetAsync("Department"))
        {
            departmentResponse.EnsureSuccessStatusCode();
            var selectListItems = JsonConvert.DeserializeObject<List<Department>>(await departmentResponse.Content.ReadAsStringAsync()).Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.DepartmentName
            }).ToList();
            return selectListItems;
        }
    }
    public async Task<IEnumerable<SelectListItem>> CityDropdown()
    {
        using (var cityResponse = await _httpClient.GetAsync("City"))
        {
            cityResponse.EnsureSuccessStatusCode();
            var selectListItems = JsonConvert.DeserializeObject<List<City>>(await cityResponse.Content.ReadAsStringAsync()).Select(city => new SelectListItem
            {
                Value = city.Id.ToString(),
                Text = city.CityName
            }).ToList();
            return selectListItems;
        }
    }
    public async Task<IEnumerable<SelectListItem>> CountryDropdown()
    {
        using (var countryResponse = await _httpClient.GetAsync("Country"))
        {
            countryResponse.EnsureSuccessStatusCode();
            var selectListItems = JsonConvert.DeserializeObject<List<Country>>(await countryResponse.Content.ReadAsStringAsync()).Select(country => new SelectListItem
            {
                Value = country.Id.ToString(),
                Text = country.CountryName
            }).ToList();
            return selectListItems;
        }
    }
    public async Task<IEnumerable<SelectListItem>> StateDropdown()
    {
        using (var stateResponse = await _httpClient.GetAsync("State"))
        {
            stateResponse.EnsureSuccessStatusCode();
            var selectListItems = JsonConvert.DeserializeObject<List<State>>(await stateResponse.Content.ReadAsStringAsync()).Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.StateName
            }).ToList();
            return selectListItems;
        }
    }
    #endregion

}
