using Microsoft.AspNetCore.Mvc;
using SocialDemo.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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