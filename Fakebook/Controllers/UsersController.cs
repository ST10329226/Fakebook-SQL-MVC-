// Path: Controllers/UsersController.cs
using Microsoft.AspNetCore.Mvc;
using Fakebook.Models; // Your models namespace
using Microsoft.EntityFrameworkCore; // For .AsQueryable(), .ToListAsync()
using Microsoft.AspNetCore.Mvc.Rendering; // For SelectList, SelectListItem
using System.Linq; // For LINQ methods like ToLower(), Contains(), Last()
using System.Diagnostics; // Good to keep, though not directly used in Index logic

namespace Fakebook.Controllers // Ensure this namespace matches your project's controller namespace
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Action to display users with enhanced search, filter, and sort capabilities
        public async Task<IActionResult> Index(
            string searchString,
            string emailDomainFilter,
            string sortOrder)
        {
            var users = _context.Users.AsQueryable();

            // --- Search Logic with Scoring ---
            if (!string.IsNullOrEmpty(searchString))
            {
                string lowerSearch = searchString.ToLower();

                // Calculate a score for each user based on how well they match the search term
                // This creates an anomymous type containing the User object and its calculated Score
                users = users.Select(u => new
                {
                    User = u,
                    Score = (u.Username != null && u.Username.ToLower().Contains(lowerSearch) ? 100 : 0) + // Highest score for username match
                            (u.Email != null && u.Email.ToLower().Contains(lowerSearch) ? 50 : 0) +        // Medium score for email match
                            (u.Bio != null && u.Bio.ToLower().Contains(lowerSearch) ? 10 : 0)              // Lowest score for bio match
                })
                .OrderByDescending(x => x.Score) // Order results by score (highest first)
                .Where(x => x.Score > 0) // Only include users that had at least one match (score > 0)
                .Select(x => x.User); // Select back the original User object
            }

            // --- Email Domain Filter ---
            if (!string.IsNullOrEmpty(emailDomainFilter))
            {
                users = users.Where(u => u.Email != null && u.Email.ToLower().EndsWith(emailDomainFilter.ToLower()));
            }

            // --- Sorting Logic ---
            // Applies the specified sort order to the user query
            users = sortOrder switch
            {
                "username_desc" => users.OrderByDescending(u => u.Username), // Sort by Username (Z-A)
                "username_asc" => users.OrderBy(u => u.Username),           // Sort by Username (A-Z)
                "email_desc" => users.OrderByDescending(u => u.Email),     // Sort by Email (Z-A)
                "email_asc" => users.OrderBy(u => u.Email),                // Sort by Email (A-Z)
                _ => users.OrderByDescending(u => u.CreatedAt),             // Default: Sort by creation date (newest first)
            };

            // Extracts distinct email domains from all users
            var emailDomains = await _context.Users
                .Where(u => u.Email != null && u.Email.Contains("@")) // Ensure email exists and has '@'
                .Select(u => "@" + u.Email.Substring(u.Email.IndexOf("@") + 1)) // Extract domain (e.g., "@gmail.com")
                .Distinct() // Get only unique domains
                .OrderBy(domain => domain) // Sort domains alphabetically
                .Select(domain => new SelectListItem { Value = domain, Text = domain }) // Create SelectListItem for dropdown
                .ToListAsync();
            // Pass the SelectList to the view
            ViewData["EmailDomains"] = new SelectList(emailDomains, "Value", "Text");

            // For Sorting Options dropdown:
            // Defines the available sorting options
            var sortOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "default", Text = "Default (Newest First)" },
                new SelectListItem { Value = "username_asc", Text = "Username (A-Z)" },
                new SelectListItem { Value = "username_desc", Text = "Username (Z-A)" },
                new SelectListItem { Value = "email_asc", Text = "Email (A-Z)" },
                new SelectListItem { Value = "email_desc", Text = "Email (Z-A)" }
            };
            // Pass the SelectList to the view
            ViewData["SortOptions"] = new SelectList(sortOptions, "Value", "Text");

            // Return the filtered and sorted users to the view
            return View(await users.ToListAsync());
        }
    }
}