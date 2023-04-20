using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vetheria.AuthServer.Database;

namespace Vetheria.AuthServer.Areas.Identity.Pages.Account;

[AllowAnonymous]

public sealed class LogoutModel : PageModel
{
    private readonly SignInManager<ApplicationUserEntity> _signInManager;
    private readonly ILogger<LogoutModel> _logger;

    public LogoutModel(SignInManager<ApplicationUserEntity> signInManager, ILogger<LogoutModel> logger)
    {
        _signInManager = signInManager;
        _logger = logger;
    }

    public async Task<IActionResult> OnPost(string? returnUrl = null)
    {
        await _signInManager.SignOutAsync();
        _logger.LogInformation(LoggerEventIds.UserLoggedOut, "User logged out.");
        if (returnUrl != null)
        {
            return LocalRedirect(returnUrl);
        }
        else
        {
            return RedirectToPage("~/");
        }
    }
}
