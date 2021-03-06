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

  // Checks so login credentials are valid
  private bool IsValidLogin(string userName, string password)
  {
    return userName.Equals("admin") && password.Equals("password");
  }

  // If the user enters valid credentials s/he is logged in
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Login([Bind] User user)
  {

    if (ModelState.IsValid && IsValidLogin(user.Username, user.Password))
    { // Creates a list of claims containg claim-types for name and role
      var claims = new List<Claim>
      {
        new Claim(ClaimTypes.Name, user.Username),
        new Claim(ClaimTypes.Role, "Admin")
      };

      // A claimed identity is a collection of claims. These claims are stored in a cookie
      var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
      // A collection of identities that identifies the user. A ClaimsPrincipal can have multiple ClaimsIdentity
      var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
      // Sets configuration values about the authenticated cookie
      var authProperties = new AuthenticationProperties
      {
        // Allows the refresh of the cookie
        AllowRefresh = true,
        // Allows the cookie to be stored between requests
        IsPersistent = true,
      };

      // Sign and create cookie based on claims and authproperties
      await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authProperties);

      return LocalRedirect("/");
    }

    return View("Index");
  }

  [HttpGet]
  public async Task<IActionResult> Logout()
  { // Invalidates and removes the cookie
    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return Redirect("/");
  }
}
