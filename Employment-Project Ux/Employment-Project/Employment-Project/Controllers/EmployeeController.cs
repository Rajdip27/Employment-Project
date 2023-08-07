using Microsoft.AspNetCore.Mvc;

namespace Employment_Project.Controllers;

public class EmployeeController : Controller
{
    private readonly HttpClient _httpClient;
    public EmployeeController()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://localhost:7225/api/");
    }

    public IActionResult Index()
    {
        return View();
    }
}
