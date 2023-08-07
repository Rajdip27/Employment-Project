using Employment_Project.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Employment_Project.Controllers;

public class CityController : Controller
{
    private readonly HttpClient _httpClient;

    public CityController()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://localhost:7225/api/");
    }
   
     private async Task<List<City>> GetCityAll()
    {
        var response = await _httpClient.GetAsync("City");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var citylist = JsonConvert.DeserializeObject<List<City>>(content);
            return citylist;
        }
        return new List<City>();
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var listCiy = await GetCityAll();
        return View(listCiy);
    }
}
