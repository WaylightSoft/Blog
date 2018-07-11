namespace Blog.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserRatedPost")]
    public partial class UserRatedPost
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        public int? UserId { get; set; }

        public int Points { get; set; }

        public virtual Post Post { get; set; }

        public virtual User User { get; set; }
    }
}
