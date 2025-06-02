// Path: Models/Post.cs
using System;
using System.Collections.Generic; // Added for ICollection
// No need for DataAnnotations or Schema unless you have specific needs not covered by EF conventions

namespace Fakebook.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public required string Content { get; set; } // Mark as 'required' for non-nullable string data
        public DateTime CreatedAt { get; set; }

        public User? User { get; set; } // Mark navigation property as nullable
        public ICollection<Comment>? Comments { get; set; } // Mark collection as nullable if it might not be loaded/initialized
        public ICollection<Like>? Likes { get; set; }       // Mark collection as nullable if it might not be loaded/initialized
    }
}