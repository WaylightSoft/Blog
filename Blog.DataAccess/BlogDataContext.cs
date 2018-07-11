namespace Blog.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Blog.Domain.Entities;

    public partial class BlogDataContext : DbContext
    {
        public BlogDataContext()
            : base("name=BlogDataContext")
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostImage> PostImages { get; set; }
        public virtual DbSet<PostTag> PostTags { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserCredential> UserCredentials { get; set; }
        public virtual DbSet<UserRatedPost> UserRatedPosts { get; set; }
        public virtual DbSet<UserSubsToTag> UserSubsToTags { get; set; }
        public virtual DbSet<UserSubToUser> UserSubToUsers { get; set; }
        public virtual DbSet<PlatformInfo> PlatformInfoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<Comment>()
                .HasMany(e => e.Comments1)
                .WithOptional(e => e.Comment1)
                .HasForeignKey(e => e.CommentId);

            modelBuilder.Entity<Image>()
                .Property(e => e.Path)
                .IsUnicode(false);

            modelBuilder.Entity<Image>()
                .HasMany(e => e.PostImages)
                .WithRequired(e => e.Image)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Image>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Image)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.Post)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.PostImages)
                .WithRequired(e => e.Post)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.PostTags)
                .WithRequired(e => e.Post)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.UserRatedPosts)
                .WithRequired(e => e.Post)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tag>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Tag>()
                .HasMany(e => e.PostTags)
                .WithRequired(e => e.Tag)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tag>()
                .HasMany(e => e.UserSubsToTags)
                .WithRequired(e => e.Tag)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Nickname)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Bio)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Posts)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserSubsToTags)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserSubscriberId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserSubToUsers)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserCreatorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserSubToUsers1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.UserSubscriberId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserCredential>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<UserCredential>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<UserCredential>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.UserCredential)
                .HasForeignKey(e => e.UserCredentialsId);

            modelBuilder.Entity<PlatformInfo>()
                .Property(e => e.Logline)
                .IsUnicode(false);
        }
    }
}
