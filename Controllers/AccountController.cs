using Chilite.Domain.Entities;
using Chilite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Chilite.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Login(string returnUrl)
    {
        ViewBag.returnUrl = returnUrl;
        return View(new LoginViewModel());
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByNameAsync(model.UserLogin);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    if (await _userManager.IsInRoleAsync(user, "admin"))
                        return Redirect(returnUrl ?? "Home/Admin");
                    
                    else
                        return Redirect(returnUrl ?? "/");
                }
            }

            ModelState.AddModelError(nameof(LoginViewModel.UserLogin), "Неправильный логин или пароль");
        }

        return View(model);
    }

    [AllowAnonymous]
    public IActionResult Registration(string returnUrl)
    {
        ViewBag.returnUrl = returnUrl;
        return View(new RegistrationViewModel());
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Registration(RegistrationViewModel model)
    {
        if (ModelState.IsValid)
        {
            var existingUser = await _userManager.FindByNameAsync(model.UserLogin);
            
            if (existingUser != null)
            {
                ModelState.AddModelError(nameof(RegistrationViewModel.UserLogin), "Данный пользователь уже зарегистрирован");
                return View(model);
            }

            var user = new ApplicationUser
            {
                UserName = model.UserLogin,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);

                return View(model);
            }
        }

        return View(model);
    }

    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction(nameof(HomeController.Index), "Home");
    }
}