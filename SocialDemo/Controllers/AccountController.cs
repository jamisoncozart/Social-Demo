using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SocialDemo.Models;
using System.Threading.Tasks;
using SocialDemo.ViewModels;

namespace SocialDemo.Controllers
{
  public class AccountController : Controller
  {
    private readonly SocialDemoContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, SocialDemoContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _roleManager = roleManager;
      _db = db;
    }

  public ActionResult Index()
  {
    return View();
  }

  public IActionResult Register()
  {
    return View();
  }

  [HttpPost]
  public async Task<ActionResult> Register (RegisterViewModel model)
  {
    var userExists = await _roleManager.RoleExistsAsync("User");
    var adminExists = await _roleManager.RoleExistsAsync("Admin");
    if(!userExists)
    {
      var roleResult = _roleManager.CreateAsync(new IdentityRole("User"));
    }
    if(!adminExists)
    {
      var roleResult = _roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    var user = new ApplicationUser { UserName = model.Email };
    IdentityResult result = await _userManager.CreateAsync(user, model.Password);
    if(result.Succeeded)
    {
      ApplicationUser currentUser = await _userManager.FindByEmailAsync(user.Email);
      var roleResult = await _userManager.AddToRoleAsync(user, "User");
      return RedirectToAction("Index");
    }
    else
    {
      return View();
    }
  }

  public ActionResult Login()
  {
    return View();
  }

  [HttpPost]
  public async Task<ActionResult> Login(LoginViewModel model)
  {
    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
    if(result.Succeeded)
    {
      return RedirectToAction("Index");
    }
    else
    {
      return View();
    }
  }

  [HttpPost]
  public async Task<ActionResult> LogOff()
  {
    await _signInManager.SignOutAsync();
    return RedirectToAction("Index");
  }


  }
}