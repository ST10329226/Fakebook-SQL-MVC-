// Path: Models/User.cs
using System; // For DateTime
using System.Collections.Generic; // For ICollection
using System.ComponentModel.DataAnnotations; // For [Key] (optional, EF infers from 'Id')
// using System.ComponentModel.DataAnnotations.Schema; // Not needed for this model

namespace Fakebook.Models
{
    /// <summary>
    /// Represents a User entity in the database.
    /// This model maps directly to the dbo.Users table.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// This is the primary key and is auto-incremented in the database.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique username for the user.
        /// This field is required and must be unique in the database.
        /// Marked with 'required' (C# 11+) to indicate it must be set on creation.
        /// </summary>
        public required string Username { get; set; }

        /// <summary>
        /// Gets or sets the hashed password of the user.
        /// This field is required for security.
        /// Marked with 'required' (C# 11+) to indicate it must be set on creation.
        /// </summary>
        public required string PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// This field is required and must be unique in the database.
        /// Marked with 'required' (C# 11+) to indicate it must be set on creation.
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// Gets or sets an optional short biography for the user.
        /// This field can be null.
        /// </summary>
        public string? Bio { get; set; }

        /// <summary>
        /// Gets or sets the URL or path to the user's profile picture.
        /// This field can be null.
        /// </summary>
        public string? ProfilePictureUrl { get; set; }

        /// <summary>
        /// Gets or sets the timestamp when the user account was created.
        /// This field is automatically set to the current date/time by the database upon insertion.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        // --- Navigation Properties for Entity Framework Core ---
        // These are marked as nullable ('?') as EF Core populates them dynamically,
        // and they might not be loaded or might be null if no related entities exist.

        /// <summary>
        /// Gets or sets a collection of Posts created by this user.
        /// </summary>
        public ICollection<Post>? Posts { get; set; }

        /// <summary>
        /// Gets or sets a collection of Comments made by this user.
        /// </summary>
        public ICollection<Comment>? Comments { get; set; }

        /// <summary>
        /// Gets or sets a collection of Likes given by this user.
        /// </summary>
        public ICollection<Like>? Likes { get; set; }
    }
}