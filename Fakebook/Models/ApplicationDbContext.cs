using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;



namespace Fakebook.Models // IMPORTANT: Replace 'YourAppName' with your actual project's namespace
{
    /// <summary>
    /// Represents the database context for the Fakebook application.
    /// This class inherits from DbContext and is used to interact with the database
    /// using Entity Framework Core.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Constructor for ApplicationDbContext.
        /// It accepts DbContextOptions, which are configured in Program.cs (or Startup.cs).
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet properties for each of your entities, mapping to database tables
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts => Set<Post>();
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }

        /// <summary>
        /// Configures the model that was discovered by convention from the entity types
        /// exposed in DbSet properties on the derived context.
        /// This is where you define relationships, constraints, and other database mappings
        /// that cannot be inferred by convention or data annotations alone.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- Configure Relationships ---

            // User to Posts (One-to-Many)
            // A User has many Posts, and a Post belongs to one User.
            modelBuilder.Entity<Post>()
                .HasOne(p => p.User) // A Post has one User
                .WithMany(u => u.Posts) // A User has many Posts
                .HasForeignKey(p => p.UserId) // UserId is the foreign key in Post
                .OnDelete(DeleteBehavior.NoAction); // Matches SQL: ON DELETE NO ACTION

            // Post to Comments (One-to-Many)
            // A Post has many Comments, and a Comment belongs to one Post.
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Post) // A Comment has one Post
                .WithMany(p => p.Comments) // A Post has many Comments
                .HasForeignKey(c => c.PostId) // PostId is the foreign key in Comment
                .OnDelete(DeleteBehavior.NoAction); // Matches SQL: ON DELETE NO ACTION

            // User to Comments (One-to-Many)
            // A User has many Comments, and a Comment belongs to one User.
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User) // A Comment has one User
                .WithMany(u => u.Comments) // A User has many Comments
                .HasForeignKey(c => c.UserId) // UserId is the foreign key in Comment
                .OnDelete(DeleteBehavior.NoAction); // Matches SQL: ON DELETE NO ACTION

            // Post to Likes (One-to-Many)
            // A Post has many Likes, and a Like belongs to one Post.
            modelBuilder.Entity<Like>()
                .HasOne(l => l.Post) // A Like has one Post
                .WithMany(p => p.Likes) // A Post has many Likes
                .HasForeignKey(l => l.PostId) // PostId is the foreign key in Like
                .OnDelete(DeleteBehavior.NoAction); // Matches SQL: ON DELETE NO ACTION

            // User to Likes (One-to-Many)
            // A User has many Likes, and a Like belongs to one User.
            modelBuilder.Entity<Like>()
                .HasOne(l => l.User) // A Like has one User
                .WithMany(u => u.Likes) // A User has many Likes
                .HasForeignKey(l => l.UserId) // UserId is the foreign key in Like
                .OnDelete(DeleteBehavior.NoAction); // Matches SQL: ON DELETE NO ACTION

            // --- Configure Unique Constraint for Likes ---
            // Ensures that a user can only like a specific post once.
            // This maps to the UQ_Likes_PostId_UserId UNIQUE constraint in your SQL schema.
            modelBuilder.Entity<Like>()
                .HasIndex(l => new { l.PostId, l.UserId })
                .IsUnique();

            // --- Optional: Configure string lengths if not handled by conventions ---
            // These are good practices, but EF Core often infers reasonable defaults.
            // You can uncomment and adjust if needed for specific column sizes.
            // modelBuilder.Entity<User>()
            //     .Property(u => u.Username)
            //     .HasMaxLength(50);
            // modelBuilder.Entity<User>()
            //     .Property(u => u.PasswordHash)
            //     .HasMaxLength(255);
            // modelBuilder.Entity<User>()
            //     .Property(u => u.Email)
            //     .HasMaxLength(255);
        }
    }
}