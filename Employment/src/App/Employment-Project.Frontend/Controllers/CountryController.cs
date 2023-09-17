
using Employment_Project.Frontend.Contracts.Base;
using Employment_Project.Frontend.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Employment_Project.Frontend.Controllers;

public class CountryController : Controller
{
    private IEmploymentClient _employmentClient;
    public CountryController(IEmploymentClient  employmentClient) => _employmentClient = employmentClient;
    public async Task<IActionResult> Index() => View(await _employmentClient.GetAllCountry());
    [HttpGet]
    public async Task<IActionResult> AddorEdit(int id)
    {
        if (id == 0) return View(new Country());
        else
        {
            var data = await _employmentClient.GetCountryById(id);
            return View(data);
        }
    }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> AddorEdit(Country country, int id)
    {
        if (ModelState.IsValid)
        {
            if (id == 0)
            {
                //Save//
                await _employmentClient.AddCountry(country);
                return RedirectToAction(nameof(Index));
            }
            else
            {         //Update
                if (ModelState.IsValid)
                {
                    await _employmentClient.UpdateCountry(id, country);
                    return RedirectToAction(nameof(Index));
                }
                return View(country);
            }
        }
        return View(new Country());
    }
    public async Task<ActionResult> Delete(int id)
    {
        await _employmentClient.DeleteCountry(id);
        return RedirectToAction(nameof(Index));
    }
}