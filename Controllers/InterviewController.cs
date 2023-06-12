using Chilite.Domain;
using Chilite.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chilite.Controllers;

[Authorize]
public class InterviewController : Controller
{
    private readonly DataManager _dataManager;

    public InterviewController(DataManager dataManager)
    {
        _dataManager = dataManager;
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Interview interview)
    {
        if (ModelState.IsValid)
        {
            await _dataManager.InterviewsRepository.SaveInterviewAsync(interview);
            return RedirectToAction("Index", "Home");
        }

        return View(interview);
    }
}
