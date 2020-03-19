using Microsoft.AspNetCore.Mvc;
using SocialDemo.Models;
using System.Linq;
using System.Collections.Generic;

namespace SocialDemo.Controllers
{
  public class PostController : Controller
  {
    private readonly SocialDemoContext _db;
    public PostController(SocialDemoContext db)
    {
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
    public ActionResult Create(Post newPost)
    {
      _db.Posts.Add(newPost);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}