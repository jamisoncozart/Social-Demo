using Microsoft.AspNetCore.Mvc;
using SocialDemo.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace SocialDemo.Controllers
{
  [Authorize]
  public class PostController : Controller
  {
    private readonly SocialDemoContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public PostController(UserManager<ApplicationUser> userManager, SocialDemoContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      List<Post> allPosts = _db.Posts.ToList();
      return View(allPosts);
    }

    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public async Task<ActionResult> Create(Post newPost)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      newPost.User = currentUser;
      _db.Posts.Add(newPost);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      Post thisPost = _db.Posts.FirstOrDefault(post => post.PostId == id);
      return View(thisPost);
    }

    [HttpPost]
    public ActionResult Edit(Post edittedPost)
    {
      _db.Entry(edittedPost).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult Upvote(int id)
    {
      if(id == 0)
      {
        return RedirectToAction("Index");
      }
      Post thisPost = _db.Posts.FirstOrDefault(post => post.PostId == id);
      thisPost.Upvotes++;
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult Destroy(int id)
    {
      Post thisPost = _db.Posts.FirstOrDefault(post => post.PostId == id);
      _db.Posts.Remove(thisPost);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}