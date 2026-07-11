using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BloggingPlatformApi.Models;
using BloggingPlatformApi.Data;
using Microsoft.EntityFrameworkCore;

namespace BloggingPlatformApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly BlogPostContext _context;
        //static private List<BlogPost> _posts = new List<BlogPost>()
        //{
        //    new BlogPost
        //    {
        //        Id = 1,
        //        Title = "First Post",
        //        Content = "This is the content of the first post.",
        //        Tags = new List<string> { "Introduction", "Welcome" },
        //        CreatedAt = DateTime.UtcNow,
        //        UpdatedAt = DateTime.UtcNow
        //    },
        //};
        public PostsController(BlogPostContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<BlogPost>> GetPosts([FromQuery] string? term)
        {
            term = term?.ToLower();
            var query = _context.blogposts.AsQueryable();
            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(p => p.Title.ToLower().Contains(term) || p.Content.ToLower().Contains(term) || p.Category.ToLower().Contains(term) || p.Tags.Any(t => t.ToLower().Contains(term)));
            }
            var post = await query.ToListAsync();
            return Ok(post);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BlogPost>> GetPost(int id)
        {
            var post = await _context.blogposts.FindAsync(id);
            if (post == null)
            {
                return NotFound("Post not found.");
            }
            return Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult<BlogPost>> AddPost(BlogPost post)
        {
            if (post == null)
            {
                return BadRequest("Post cannot be null.");
            }
            _context.blogposts.Add(post);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPosts), new { id = post.Id }, post);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(int id, BlogPost post)
        {
            if (post == null)
            {
                return BadRequest("Post cannot be null.");
            }

            var existingPost = await _context.blogposts.FindAsync(id);
            if (existingPost == null)
            {
                return NotFound("Post not found.");
            }

            existingPost.Title = post.Title;
            existingPost.Content = post.Content;
            existingPost.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var existingPost = await _context.blogposts.FindAsync(id);
            if (existingPost == null)
            {
                return NotFound("Post not found.");
            }

            _context.blogposts.Remove(existingPost);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
