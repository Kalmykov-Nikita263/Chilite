using Chilite.Domain;
using Chilite.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Chilite.Controllers;

[Authorize]
public class InterviewController : Controller
{
    private readonly DataManager _dataManager;
    private readonly ApplicationDbContext _context;

    public InterviewController(DataManager dataManager, ApplicationDbContext context)
    {
        _dataManager = dataManager;
        _context = context;
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Interview interview)
    {
        if (ModelState.IsValid)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await _dataManager.InterviewsRepository.SaveInterviewAsync(interview);

            var userInterview = new UserInterview
            {
                UserId = userId,
                InterviewId = interview.InterviewId
            };

            await _context.UserInterviews.AddAsync(userInterview);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        return View(interview);
    }

    public async Task<IActionResult> Search(string searchQuery)
    {
        if (Guid.TryParse(searchQuery, out Guid interviewId))
        {
            var interview = await _dataManager.InterviewsRepository.GetInterviewByIdAsync(interviewId);

            if (interview != null)
            {
                return View(interview);
            }
        }

        return View("NotFound");
    }
}
