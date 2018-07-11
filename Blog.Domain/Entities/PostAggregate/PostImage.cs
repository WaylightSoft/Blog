namespace Blog.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PostImage")]
    public partial class PostImage
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        public int ImageId { get; set; }

        public int? ImageNumber { get; set; }

        public virtual Image Image { get; set; }

        public virtual Post Post { get; set; }
    }
}
