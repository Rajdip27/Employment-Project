using Employment_Project.Frontend.Contracts.Base;
using Employment_Project.Frontend.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Employment_Project.Frontend.Controllers;

public class CityController : Controller
{
    private readonly IEmploymentClient _employmentClient;
    public CityController(IEmploymentClient employmentClient)=> _employmentClient = employmentClient;
    public async Task<IActionResult> Index() => View(await _employmentClient.GetAllCity());
    [HttpGet]
    public async Task<IActionResult> AddorEdit(int id)
    {
        ViewData["stateId"] = await _employmentClient.StateDropdown();
        if (id == 0) return View(new City());
        else
        {
            var response = await _employmentClient.GetCityById(id);
            if (response != null) return View(response);
        }
        return View(new State());
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddorEdit(int id, City city)
    {
        if (ModelState.IsValid)
        {
            if (id == 0)
            {
                //save data
                if (ModelState.IsValid)
                {
                    await _employmentClient.AddCity(city);
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                //UPDATE//
                if (ModelState.IsValid)
                {
                    await _employmentClient.UpdateCity(id, city);
                    return RedirectToAction(nameof(Index));
                }
                return View(city);
            }
        }
        return View(new City());
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _employmentClient.DeleteCity(id);
        return RedirectToAction(nameof(Index));
    }
}
