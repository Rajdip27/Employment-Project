using Employment_Project.Frontend.Contracts.Base;
using Employment_Project.Frontend.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Employment_Project.Frontend.Controllers;

public class DepartmentController : Controller
{
    private IEmploymentClient _employmentClient;
    public DepartmentController(IEmploymentClient employmentClient) => _employmentClient = employmentClient;
    public async Task<IActionResult> Index() => View(await _employmentClient.GetAllDepartment());
    [HttpGet]
    public async Task<IActionResult> AddorEdit(int id)
    {
        if (id == 0) return View(new Department());
        else
        {
            var data = await _employmentClient.GetDepartmentById(id);
            return View(data);
        }
    }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> AddorEdit(Department department, int id)
    {
        if (ModelState.IsValid)
        {
            if (id == 0)
            {
                await _employmentClient.AddDepartment(department);
                return RedirectToAction("Index");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    await _employmentClient.UpdateDepartment(id, department);
                    return RedirectToAction("Index");
                }
                return View(department);
            }
        }
        return View(new Department());
    }
    public async Task<ActionResult> Delete(int id)
    {
        await _employmentClient.DeleteDepartment(id);
        return RedirectToAction("Index");
    }

}
