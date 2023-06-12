using Chilite.Domain;
using Chilite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Chilite.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly DataManager _dataManager;

    public HomeController(DataManager dataManager)
    {
        _dataManager = dataManager;
    }

    public IActionResult Index()
    {
        return View(_dataManager.InterviewsRepository.GetAllInterviewsAsync().Where(i => i.UserId == User.FindFirst(ClaimTypes.NameIdentifier).Value));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}