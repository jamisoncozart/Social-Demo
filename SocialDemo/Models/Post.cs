using System.Collections.Generic;

namespace SocialDemo.Models
{
  public class Post
  {
    public string Title { get; set; }
    public string Body { get; set; }
    public string Author { get; set; }
    public int Upvotes { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
    public int PostId { get; set; }
  }
}