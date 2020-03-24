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

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, SocialDemoContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
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
    var user = new ApplicationUser { UserName = model.Email };
    IdentityResult result = await _userManager.CreateAsync(user, model.Password);
    if(result.Succeeded)
    {
      return RedirectToAction("Index");
    }
    else
    {
      return View();
    }
  }


  }
}