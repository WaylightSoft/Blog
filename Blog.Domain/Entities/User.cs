namespace Blog.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Comments = new HashSet<Comment>();
            Posts = new HashSet<Post>();
            UserRatedPosts = new HashSet<UserRatedPost>();
            UserSubsToTags = new HashSet<UserSubsToTag>();
            UserSubToUsers = new HashSet<UserSubToUser>();
            UserSubToUsers1 = new HashSet<UserSubToUser>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nickname { get; set; }

        [Required]
        [StringLength(255)]
        public string Bio { get; set; }

        public int ImageId { get; set; }

        public int RoleId { get; set; }

        public int UserCredentialsId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        public virtual Image Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts { get; set; }

        public virtual Role Role { get; set; }

        public virtual UserCredential UserCredential { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRatedPost> UserRatedPosts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserSubsToTag> UserSubsToTags { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserSubToUser> UserSubToUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserSubToUser> UserSubToUsers1 { get; set; }
    }
}
