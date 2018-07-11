namespace Blog.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comment()
        {
            Comments1 = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(1500)]
        public string Content { get; set; }

        public int PostId { get; set; }

        public int UserId { get; set; }

        public int? CommentId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments1 { get; set; }

        public virtual Comment Comment1 { get; set; }

        public virtual Post Post { get; set; }

        public virtual User User { get; set; }
    }
}
