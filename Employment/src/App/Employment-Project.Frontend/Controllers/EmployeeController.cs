
using Employment_Project.Frontend.Contracts.Base;
using Employment_Project.Frontend.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Employment_Project.Frontend.Controllers;

public class EmployeeController : Controller
{
    private readonly IEmploymentClient _employmentClient;

    public EmployeeController(IEmploymentClient employmentClient)
    {
        _employmentClient = employmentClient;
    }

    public async Task<IActionResult> Index() => View(await _employmentClient.GetAllEmployee());

    [HttpGet]
    public async Task<IActionResult> AddorEdit(int id)
    {
        ViewData["stateId"] = await _employmentClient.StateDropdown();
        ViewData["cityId"] = await _employmentClient.CityDropdown();
        ViewData["countryId"] = await _employmentClient.CountryDropdown();
        ViewData["departmentId"] = await _employmentClient.DepartmentDropdown();
        if (id == 0) return View(new Employee());
        else
        {
            var response = await _employmentClient.GetEmployeeById(id);
            if (response != null) return View(response);
        }
        return View(new Employee());
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddorEdit(int id, [FromForm] Employee employee)
    {
        if (ModelState.IsValid)
        {
            if (id == 0)
            {
                //save data
                if (ModelState.IsValid)
                {
                   await _employmentClient.AddEmployee(employee);
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                //UPDATE//
                if (ModelState.IsValid)
                {
                    await _employmentClient.UpdateEmployee(id, employee);
                    return RedirectToAction(nameof(Index));
                }
                return View(employee);
            }
        }
        return View(new Employee());
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _employmentClient.DeleteEmployee(id);
        return RedirectToAction(nameof(Index));
    }
}
