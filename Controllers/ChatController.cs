using Chilite.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chilite.Controllers;

[Authorize]
public class ChatController : Controller
{
    private readonly DataManager _dataManager;

    public ChatController(DataManager dataManager)
    {
        _dataManager = dataManager;
    }

    public async Task<IActionResult> Room(Guid id) 
    {
        return View(await _dataManager.InterviewsRepository.GetInterviewByIdAsync(id));
    }
}