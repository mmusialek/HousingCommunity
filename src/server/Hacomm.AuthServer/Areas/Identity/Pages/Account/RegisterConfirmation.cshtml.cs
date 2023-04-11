using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hacomm.AuthServer.Areas.Identity.Pages.Account;

[AllowAnonymous]
public class RegisterConfirmationModel : PageModel
{
    //private readonly IConfiguration _configuration;

    //public RegisterConfirmationModel(IConfiguration configuration)
    //{
    //    _configuration = configuration;
    //}

    //public string ReturnUrl { get; set; } = string.Empty;

    public IActionResult OnGet(string email, string? returnUrl = null)
    {
        returnUrl = returnUrl ?? Url.Content("~/");

        //ViewData["ReturnUrl"] = _configuration["ClientUri"];
        ViewData["ReturnUrl"] = returnUrl;

        return Page();
    }
}
