using System; // Required for DateTime
using Microsoft.EntityFrameworkCore;

namespace Fakebook.Models
{ 
    /// <summary>
    /// Represents a Comment entity in the database.
    /// This model maps directly to the dbo.Comments table.
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// Gets or sets the unique identifier for the comment.
        /// This is the primary key and is auto-incremented in the database.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of the post this comment belongs to.
        /// This is a foreign key linking to the Posts table.
        /// </summary>
        public int PostId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who made this comment.
        /// This is a foreign key linking to the Users table.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the content of the comment.
        /// This is a required field and can store a large amount of text.
        /// </summary>
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the timestamp when the comment was created.
        /// This field is automatically set to the current date/time by the database upon insertion.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        // --- Navigation Properties for Entity Framework Core ---
        /// <summary>
        /// Gets or sets the Post object associated with this comment.
        /// This is a navigation property used by Entity Framework Core to represent the
        /// one-to-many relationship between Posts and Comments (one post can have many comments).
        /// It allows you to easily access the Post details from a Comment object.
        /// </summary>
        public Post Post { get; set; }  // Assuming you have a Post.cs model

        /// <summary>
        /// Gets or sets the User object associated with this comment.
        /// This is a navigation property used by Entity Framework Core to represent the
        /// one-to-many relationship between Users and Comments (one user can make many comments).
        /// It allows you to easily access the User details from a Comment object.
        /// </summary>
        public User User { get; set; }  // Assuming you have a User.cs model
    }
}