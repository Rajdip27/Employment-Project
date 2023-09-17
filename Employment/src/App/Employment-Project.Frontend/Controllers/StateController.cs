using Employment_Project.Frontend.Contracts.Base;
using Employment_Project.Frontend.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Employment_Project.Frontend.Controllers;

public class StateController : Controller
{
    private readonly IEmploymentClient _employmentClient;

    public StateController(IEmploymentClient employmentClient)
    {
        _employmentClient = employmentClient;
    }

    public async Task<IActionResult> Index() => View(await _employmentClient.GetAllState());

    [HttpGet]
    public async Task<IActionResult> AddorEdit(int id)
    {
        ViewData["CountryId"] = await _employmentClient.CountryDropdown();
        if (id == 0) return View(new State());
        else
        {
            var response = await _employmentClient.GetStateById(id);
            if (response != null) return View(response);
        }
        return View(new State());
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddorEdit(int id, State state)
    {
        if (ModelState.IsValid)
        {
            if (id == 0)
            {
                //save data
                if (ModelState.IsValid)
                {
                    await _employmentClient.AddState(state);
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                //UPDATE//
                if (ModelState.IsValid)
                {
                    await _employmentClient.UpdateState(id, state);
                    return RedirectToAction(nameof(Index));
                }
                return View(state);
            }
        }

        return View(new State());
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _employmentClient.DeleteState(id);
        return RedirectToAction(nameof(Index));
    }
}
