using System; // Required for DateTime
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Fakebook.Models // IMPORTANT: Replace 'YourAppName' with your actual project's namespace
{
    /// <summary>
    /// Represents a Like entity in the database.
    /// This model maps directly to the dbo.Likes table.
    /// </summary>
    public class Like
    {
        /// <summary>
        /// Gets or sets the unique identifier for the like.
        /// This is the primary key and is auto-incremented in the database.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of the post that was liked.
        /// This is a foreign key linking to the Posts table.
        /// </summary>
        public int PostId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who made the like.
        /// This is a foreign key linking to the Users table.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the count or value of the like.
        /// This field defaults to 1 in the database.
        /// </summary>
        public int Like_count { get; set; }

        /// <summary>
        /// Gets or sets the timestamp when the like was recorded.
        /// This field is automatically set to the current date/time by the database upon insertion.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        // --- Navigation Properties for Entity Framework Core ---
        /// <summary>
        /// Gets or sets the Post object associated with this like.
        /// This is a navigation property used by Entity Framework Core to represent the
        /// one-to-many relationship between Posts and Likes (one post can have many likes).
        /// It allows you to easily access the Post details from a Like object.
        /// </summary>
        public Post Post { get; set; } = null!; // Navigation property, EF Core will set this

        /// <summary>
        /// Gets or sets the User object associated with this like.
        /// This is a navigation property used by Entity Framework Core to represent the
        /// one-to-many relationship between Users and Likes (one user can give many likes).
        /// It allows you to easily access the User details from a Like object.
        /// </summary>
        public User User { get; set; } = null!; // Assuming you have a User.cs model
    }
}