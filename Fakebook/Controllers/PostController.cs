using Microsoft.AspNetCore.Mvc;
using Fakebook.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Fakebook.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString, string usernameFilter, DateTime? dateFrom, DateTime? dateTo, string sortOrder)
        {
            var posts = _context.Posts
                .Include(p => p.User) // Ensure User navigation property is included
                .AsQueryable();
          
            // Search by post caption or owner's username
            if (!string.IsNullOrEmpty(searchString))
            {
                string lowerSearch = searchString.ToLower();
                posts = posts.Where(p =>
                    (p.Content != null && p.Content.ToLower().Contains(lowerSearch)) || // Search in Post Content
                    (p.User != null && p.User.Username != null && p.User.Username.ToLower().Contains(lowerSearch))); // Search in associated User's Username
            }

            // Filter by specific user
            if (!string.IsNullOrEmpty(usernameFilter))
            {
                posts = posts.Where(p => p.User != null && p.User.Username == usernameFilter);
            }

            // Filter by date range
            if (dateFrom.HasValue)
            {
                posts = posts.Where(p => p.CreatedAt >= dateFrom.Value);
            }

            if (dateTo.HasValue)
            {
                posts = posts.Where(p => p.CreatedAt <= dateTo.Value);
            }

            // Sorting logic
            posts = sortOrder switch
            {
                "oldest" => posts.OrderBy(p => p.CreatedAt),
                _ => posts.OrderByDescending(p => p.CreatedAt), // Default: newest first
            };



            // For username dropdown list:
            // Ensure you are selecting username and value.
            // SelectList needs text and value properties for options.
            // Using a simple SelectListItem list if you just need usernames.
            var distinctUsernames = await _context.Users
                                                .Select(u => new SelectListItem { Value = u.Username, Text = u.Username })
                                                .Distinct()
                                                .ToListAsync();
            ViewData["Usernames"] = new SelectList(distinctUsernames, "Value", "Text");



            return View(await posts.ToListAsync());
        }
    }
}
