using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chilite.Controllers;

[Authorize]
public class ChatController : Controller
{
    public IActionResult Room() => View();

    public IActionResult JoinChat(string userName)
    {


        return Json(new { success = true });
    }
}