using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MVCBookstore.Models;

namespace MVCBookstore.Controllers;

public class LoginController : Controller
{
  public IActionResult Index()
  {
    return View();
  }

  private bool IsValidLogin(string userName, string password)
  {
    return userName.Equals("fogelbergrasmus") && password.Equals("supersecret");
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Login([Bind] User user)
  {
    
    if (ModelState.IsValid && IsValidLogin(user.Username, user.Password))
    {
      var claims = new List<Claim>
      {
        new Claim(ClaimTypes.Name, user.Username),
        new Claim(ClaimTypes.Role, "Admin")
      };

      var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
      var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
      var authProperties = new AuthenticationProperties
      {
        AllowRefresh = true,
        IsPersistent = true,
      };


      await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authProperties);

      return LocalRedirect("/");
    }

    return View("Index");
  }

  [HttpGet]
  public async Task<IActionResult> Logout()
  {
    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return Redirect("/");
  }
}
